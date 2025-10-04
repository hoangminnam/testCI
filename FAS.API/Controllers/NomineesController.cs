using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FAS.Model;
using FAS.Model.Models;
using FAS.BLL.BusinessInterfaces;

namespace FAS.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v1/nominee/[action]")]
    [ApiController]
    public class NomineesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly INomineeService _nomineeService;

        public NomineesController(INomineeService nomineeService)
        {
            _nomineeService = nomineeService;
        }

        // GET: api/Nominees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nominee>>> GetNomineeAll()
        {
            var nominees = await _nomineeService.GetNominees();
            return Ok(nominees);
        }

        // GET: api/Nominees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nominee>> GetNomineeFilter(Guid id)
        {
            var nominee = await _nomineeService.GetNominee(id);

            if (nominee == null)
            {
                return NotFound();
            }

            return nominee;
        }

        // PUT: api/Nominees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNominee(Guid id, [FromBody] Nominee nominee)
        {
            if (id != nominee.Id)
            {
                return BadRequest();
            }

            await _nomineeService.UpdateNominee(id, nominee);

            return Ok();
        }

        // POST: api/Nominees
        [HttpPost]
        public async Task<ActionResult<Nominee>> SetNomineeInfo([FromBody] Nominee nominee)
        {
            await _nomineeService.AddNominee(nominee);

            return Ok();
        }

        // DELETE: api/Nominees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNominee(Guid id)
        {
            await _nomineeService.DeleteNominee(id);

            return Ok();
        }

    }
}
