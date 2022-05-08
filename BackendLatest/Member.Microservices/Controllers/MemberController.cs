
namespace Member.Microservices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    using Member.Microservices.Model;
    using System;

    using System.Linq;
    using Member.Microservices.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Authentication.JwtBearer;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMembersService _context;

        private readonly IList<Member> _members = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MemberController(IMembersService context)
        {
            this._context = context;

            // NOTE: this is here for quick testing purposes only
            _members = new List<Member>() { new Member() { Id = 1, Name = "Peta WILSON", DOB = new DateTime(1980, 01, 26), Occupation = OccupationEnum.Author },
                new Member() { Id = 2, Name = "Russell Crowe", Occupation = OccupationEnum.Mechanic }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // [Authorize]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult GetAll()
        {
            // NOTE: Force a runtime exception here to test the exception handler!
            // throw new System.Exception("An error occurred");

            try
            {
                // Fetch members from a MS SQL Server Database (TAL)
                var members_db = this._context.GetAll();
                if (members_db == null) return NotFound();

                var one = members_db.Count();

                return Ok(members_db);
            }
            catch (Exception ex)
            {
                // throw ex;
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var member = _context.GetAll().Where(a => a.Id == id).FirstOrDefault();
            if (member == null) return NotFound();
            return Ok(member);
        }
    }
}