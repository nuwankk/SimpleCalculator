using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace bf.api.jwt
{
#pragma warning disable
    public class JwtManager
    {

        private static readonly string secret = "ZGIzT0lzaitCWEU5Tlpma2g0ODY1NSVHSEpkKjY1VGNOZWtyRisyZC8xc0ZuV0c0SG5WOFRaWTMwaVRPZHRWV0pHOGFiV3ZCMUdsT2dKdVFaZGNGMkx1cW0vaGNjTXc=";
        private static double sessionLimit = 1;
        private static double sessionCheckFr = 1;
        private static string aud = "localhost";
        private static bool autoLogout = false;

        public JwtManager(IConfiguration configuration)
        {
        }

        public static string GenerateToken(string username, int userid, string role, int expireMinutes = 20, int companyId = -1)
        {
            var symmetricKey = Convert.FromBase64String(secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenRef = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "self",
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.NameIdentifier, userid.ToString()),
                            new Claim(ClaimTypes.Role,role),
                            new Claim("TokenRef", tokenRef),
                            new Claim("CompId", companyId.ToString())
                }),
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetUserId(string token)
        {
            try
            {
                var principal = GetPrincipal(token);

                if (!principal.Identity.IsAuthenticated)
                    throw new Exception("Token is not valid");

                List<Claim> claims = principal.Claims.ToList();
                return Convert.ToInt32(claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            }

            catch (Exception ex)
            {
                throw new Exception("Token validation error ~ " + ex.Message);
            }
        }

        public static bool isAdmin(string token)
        {
            try
            {
                var principal = JwtManager.GetPrincipal(token);
                List<Claim> claims = principal.Claims.ToList();
                return claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value.Equals("admin");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidateUserSession(string token)
        {
            try
            {
                var principal = GetPrincipal(token);
                if (principal == null)
                    throw new UnauthorizedAccessException("Token is expired");

                var couchId = principal.Claims.Where(c => c.Type == "TokenRef").FirstOrDefault().Value;

                if (!principal.Identity.IsAuthenticated)
                    throw new UnauthorizedAccessException("Token validation error");
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Token validation error !!! " +ex.ToString());
            }

            return true;
        }

        public static bool ValidateUserSessionV2(string token, ref IEnumerable<Claim> claims)
        {
            try
            {
                var principal = GetPrincipal(token);
                if (principal == null)
                    throw new UnauthorizedAccessException("Token is expired");

                var couchId = principal.Claims.Where(c => c.Type == "TokenRef").FirstOrDefault().Value;
                claims = principal.Claims;

                if (!principal.Identity.IsAuthenticated)
                    throw new UnauthorizedAccessException("Token validation error");
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Token validation error");
            }

            return true;
        }
    }
}