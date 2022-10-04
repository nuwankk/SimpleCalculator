using bf.api.Helpers;
using bf.api.jwt;
using Microsoft.AspNetCore.Mvc;

namespace bf.api.auth
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [Route("bf/api/auth/[controller]")]
    [ApiController]
    public class User:ControllerBase
    {
        /// <summary>
        /// Common method to authenticate the mock JWT user
        /// </summary>
        /// <param name="inboundObject">User authentication object</param>
        /// <returns>This will return the status result after processing the given data set.
        /// Always look for standard HTTP reponse codes and expected results are 200, 204, 400, 404, 422
        /// In the event of internal errors, refer IsSuccess boolean property and errors will be available with ErrorMessage property
        /// </returns>
        [HttpPost("JWTLogin")]
        public Result JWTLogin([FromBody] AuthObject inboundObject)
        {
            if (inboundObject.UserName == "appadmin" && inboundObject.Password == DateTime.Now.ToString("MM/dd/yyyy"))
            {
                return new Result() { IsSuccess = true, JWT = JwtManager.GenerateToken(inboundObject.UserName, 0, inboundObject.Password) };
            }
            else
            {
                return new Result() { ErrorMessage = "login failed, Please try again", UserMessage = "login failed, Please try again" };
            }
        }
    }
}
