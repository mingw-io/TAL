namespace Member.Microservices.Controllers
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public PremiumController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ratingFactor"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [Route("calculate")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Calculate([FromQuery] double amount, [FromQuery] double ratingFactor, [FromQuery] int age)
        {
            IList<string> errorList = new List<string>();
            // var premium = (deathAmount * ratingFactor * age) / 1000 * 12;
            if (amount < 1.00)
            {
                errorList.Add("Invalid amount value!");
            }
            if (ratingFactor < 1.00)
            {
                errorList.Add("Invalid rating factor value!");
            }
            if ((age < 18) || (age > 65))
            {
                errorList.Add("Invalid age value!");
            }
            if (errorList.Count > 0)
            {
                var response = new { errors = errorList };

                return BadRequest(response);
            }

            double premiumInput = (amount * ratingFactor * age) / 1000 * 12;
            double premium = Math.Round(premiumInput, 2, MidpointRounding.AwayFromZero);

            // TODO:
            return Ok(new { premium = premium});
        }
    }
}