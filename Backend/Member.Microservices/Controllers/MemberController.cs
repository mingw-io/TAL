
namespace Member.Microservices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Member.Microservices.Model;
    using System;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private static ILogger<MemberController> _logger;

        private readonly IList<Member> _members = null;

        /// <summary>
        /// 
        /// </summary>
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;

            _members = new List<Member>() { new Member() { Id = 1, Name = "Peta WILSON", DOB = new DateTime(1980, 01, 26), Occupation = OccupationEnum.Author },
                new Member() { Id = 2, Name = "Russell Crowe", Occupation = OccupationEnum.Mechanic }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Requested a Random API");

            // var customers = await _context.Products.ToListAsync();
            if (_members == null) return NotFound();
            return Ok(_members);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            // if (product == null) return NotFound();
            // return Ok(product);
            return NotFound();
        }
    }
}
