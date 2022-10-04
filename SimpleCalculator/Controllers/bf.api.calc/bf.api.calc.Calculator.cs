using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using bf.api.Helpers;
using bf.api.jwt;

namespace bf.api.calc
{
    /// <summary>
    /// Calculator controller
    /// </summary>
    [Route("bf/api/calc/[controller]")]
    [ApiController]
    public class Calculator : ControllerBase
    {
        /// <summary>
        /// To get the calculated addition result of the given numeric values
        /// </summary>
        /// <returns>This will return the status result after processing the given data set.
        /// Always look for the standard HTTP response codes and expected results are 200, 204, 400, 404, 422
        /// In the event of internal errors, refer IsSuccess boolean property and errors will be available with ErrorMessage property
        /// </returns>
        [HttpPost("Add")]
        public Result Addition(CalcIn calcIn)
        {
            IEnumerable<Claim>? claims = null;

            try
            {
                string auth_token = Request.Headers["Authorization"];

                if (!ModelState.IsValid || string.IsNullOrEmpty(auth_token))
                {
                    return new Result { IsSuccess=false, UserMessage= "Http state is invalid or Authorization header is missing" };
                }

                if (JwtManager.ValidateUserSessionV2(auth_token, ref claims))
                {
                    return CalculatorHelper.Addition(calcIn);
                }
                else
                    return new Result { IsSuccess = false, UserMessage = "Authorization header is missing" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, UserMessage = "Could not process the arithmetic request", ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// To get the calculated substraction (number1 - number2) result of the given numeric values
        /// </summary>
        /// <returns>This will return the status result after processing the given data set.
        /// Always look for the standard HTTP response codes and expected results are 200, 204, 400, 404, 422
        /// In the event of internal errors, refer IsSuccess boolean property and errors will be available with ErrorMessage property
        /// </returns>
        [HttpPost("Substract")]
        public Result Substraction(CalcIn calcIn)
        {
            IEnumerable<Claim>? claims = null;

            try
            {
                string auth_token = Request.Headers["Authorization"];

                if (!ModelState.IsValid || string.IsNullOrEmpty(auth_token))
                {
                    return new Result { IsSuccess = false, UserMessage = "Http state is invalid or Authorization header is missing" };
                }

                if (JwtManager.ValidateUserSessionV2(auth_token, ref claims))
                {
                    return CalculatorHelper.Substraction(calcIn);
                }
                else
                    return new Result { IsSuccess = false, UserMessage = "Authorization header is missing" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, UserMessage = "Could not process the arithmetic request", ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// To get the calculated multiplied result of the given numeric values
        /// </summary>
        /// <returns>This will return the status result after processing the given data set.
        /// Always look for the standard HTTP response codes and expected results are 200, 204, 400, 404, 422
        /// In the event of internal errors, refer IsSuccess boolean property and errors will be available with ErrorMessage property
        /// </returns>
        [HttpPost("Multiply")]
        public Result Multiply(CalcIn calcIn)
        {
            IEnumerable<Claim>? claims = null;

            try
            {
                string auth_token = Request.Headers["Authorization"];

                if (!ModelState.IsValid || string.IsNullOrEmpty(auth_token))
                {
                    return new Result { IsSuccess = false, UserMessage = "Http state is invalid or Authorization header is missing" };
                }

                if (JwtManager.ValidateUserSessionV2(auth_token, ref claims))
                {
                    return CalculatorHelper.Multiply(calcIn);
                }
                else
                    return new Result { IsSuccess = false, UserMessage = "Authorization header is missing" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, UserMessage = "Could not process the arithmetic request", ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// To get the calculated devision (number1 / number2) result of the given numeric values
        /// </summary>
        /// <returns>This will return the status result after processing the given data set.
        /// Always look for the standard HTTP response codes and expected results are 200, 204, 400, 404, 422
        /// In the event of internal errors, refer IsSuccess boolean property and errors will be available with ErrorMessage property
        /// </returns>
        [HttpPost("Devide")]
        public Result Devision(CalcIn calcIn)
        {
            IEnumerable<Claim>? claims = null;

            try
            {
                string auth_token = Request.Headers["Authorization"];

                if (!ModelState.IsValid || string.IsNullOrEmpty(auth_token))
                {
                    return new Result { IsSuccess = false, UserMessage = "Http state is invalid or Authorization header is missing" };
                }

                if (JwtManager.ValidateUserSessionV2(auth_token, ref claims))
                {
                    return CalculatorHelper.Devision(calcIn);
                }
                else
                    return new Result { IsSuccess = false, UserMessage = "Authorization header is missing" };

            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, UserMessage = "Could not process the arithmetic request", ErrorMessage = ex.Message };
            }
        }
    }
}
