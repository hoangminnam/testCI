using FAS.BLL.BusinessInterfaces;
using FAS.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FAS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouncilMemberController : ControllerBase
    {
        private readonly ICouncilMemberService _councilMemberService;
        public CouncilMemberController(ICouncilMemberService councilMemberService)
        {
            _councilMemberService = councilMemberService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCouncilMemberAll()
        {
            try
            {
                var councilMembers = await _councilMemberService.GetCouncilMemberAll();
                return Ok(councilMembers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouncilMemberById(Guid id)
        {
            try
            {
                var councilMember = await _councilMemberService.GetCouncilMemberById(id);
                if (councilMember == null)
                {
                    return NotFound();
                }
                return Ok(councilMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCouncilMember([FromBody] CouncilMember councilMember)
        {
            try
            {
                if (councilMember == null)
                {
                    return BadRequest();
                }
                var addedCouncilMember = await _councilMemberService.AddCouncilMember(councilMember);
                return CreatedAtAction(nameof(GetCouncilMemberById), new { id = addedCouncilMember.Id }, addedCouncilMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCouncilMember(Guid id, [FromBody] CouncilMember councilMember)
        {
            try
            {
                if (councilMember == null || id != councilMember.Id)
                {
                    return BadRequest();
                }
                var updatedCouncilMember = await _councilMemberService.UpdateCouncilMember(id, councilMember);
                if (updatedCouncilMember == null)
                {
                    return NotFound();
                }
                return Ok(updatedCouncilMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouncilMember(Guid id)
        {
            try
            {
                var result = await _councilMemberService.DeleteCouncilMember(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // add api filter
        [HttpGet]
        public async Task<IActionResult> FilterCouncilMembers([FromQuery] string? name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return BadRequest("Filter parameter is required.");
                }
                var councilMember = await _councilMemberService.GetCouncilMemberFilter(name);
                if (councilMember == null)
                {
                    return NotFound();
                }
                return Ok(councilMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
