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
    [Route("api/v1/nominate-action-log/[action]")]
    [ApiController]
    public class NominateActionLogsController : ControllerBase
    {
        private readonly INominateActionLogService _nominateActionLogService;

        public NominateActionLogsController(INominateActionLogService nominateActionLogService)
        {
            _nominateActionLogService = nominateActionLogService;
        }

        // GET: api/NominateActionLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NominateActionLog>>> GetNominateActionLogAll()
        {
            var actions = await _nominateActionLogService.GetNominateActionLogs();
            return Ok(actions);
        }

        // GET: api/NominateActionLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NominateActionLog>> GetNominateActionLogFilter(Guid id)
        {
            var nominateActionLog = await _nominateActionLogService.GetNominateActionLog(id);

            if (nominateActionLog == null)
            {
                return NotFound();
            }

            return nominateActionLog;
        }

        // PUT: api/NominateActionLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNominateActionLog(Guid id, [FromBody] NominateActionLog nominateActionLog)
        {
            if (id != nominateActionLog.Id)
            {
                return BadRequest();
            }

            await _nominateActionLogService.UpdateNominateActionLog(id, nominateActionLog);

            return Ok();
        }

        // POST: api/NominateActionLogs
        [HttpPost]
        public async Task<ActionResult<NominateActionLog>> SetNominateActionLogInfo([FromBody] NominateActionLog nominateActionLog)
        {
            await _nominateActionLogService.AddNominateActionLog(nominateActionLog);

            return Ok(nominateActionLog);
        }

        // DELETE: api/NominateActionLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNominateActionLog(Guid id)
        {
            await _nominateActionLogService.DeleteNominateActionLog(id);

            return Ok(id);
        }
    }
}
