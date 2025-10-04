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
    [Route("api/v1/comment-nominee/[action]")]
    [ApiController]
    public class CommentNomineesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly ICommentNomineeService _commentNomineeService;

        public CommentNomineesController(ICommentNomineeService commentNomineeService)
        {
            _commentNomineeService = commentNomineeService;
        }

        // GET: api/CommentNominees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentNominee>>> GetCommentNomineeAll()
        {
            var commentNominees = await _commentNomineeService.GetCommentNominees();
            return Ok(commentNominees);
        }

        // GET: api/CommentNominees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentNominee>> GetCommentNomineeFilter(Guid id)
        {
            var commentNominee = await _commentNomineeService.GetCommentNominee(id);

            if (commentNominee == null)
            {
                return NotFound();
            }

            return commentNominee;
        }

        // PUT: api/CommentNominees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentNominee(Guid id, [FromBody] CommentNominee commentNominee)
        {
            if (id != commentNominee.Id)
            {
                return BadRequest();
            }

            await _commentNomineeService.UpdateCommentNominee(id, commentNominee);

            return Ok();
        }

        // POST: api/CommentNominees
        [HttpPost]
        public async Task<ActionResult<CommentNominee>> SetCommentNomineeInfo([FromBody] CommentNominee commentNominee)
        {
            var result = await _commentNomineeService.AddCommentNominee(commentNominee);
            return Ok(result);
        }

        // DELETE: api/CommentNominees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentNominee(Guid id)
        {
            await _commentNomineeService.DeleteCommentNominee(id);

            return Ok();
        }

    }
}
