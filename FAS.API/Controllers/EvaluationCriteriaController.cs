using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FAS.Model.Models;
using FAS.Model.DTOs;
using FAS.Model;

namespace FAS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationCriteriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EvaluationCriteriaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/EvaluationCriteria?categoryId=xxx
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluationCriterionDto>>> Get([FromQuery] Guid? categoryId)
        {
            var query = _context.EvaluationCriteria.Include(ec => ec.AwardCategory).AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(ec => ec.AwardCategoryId == categoryId.Value);

            var list = await query.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<EvaluationCriterionDto>>(list));
        }

        // POST: api/EvaluationCriteria
        [HttpPost]
        public async Task<ActionResult<EvaluationCriterionDto>> Create(CreateEvaluationCriterionDto dto)
        {
            if (!_context.AwardCategories.Any(c => c.Id == dto.AwardCategoryId))
                return BadRequest("Invalid AwardCategoryId");

            var entity = _mapper.Map<EvaluationCriterion>(dto);

            _context.EvaluationCriteria.Add(entity);
            await _context.SaveChangesAsync();

            var result = await _context.EvaluationCriteria
                .Include(ec => ec.AwardCategory)
                .FirstOrDefaultAsync(ec => ec.Id == entity.Id);

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, _mapper.Map<EvaluationCriterionDto>(result));
        }

        // PUT: api/EvaluationCriteria/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEvaluationCriterionDto dto)
        {
            var entity = await _context.EvaluationCriteria.FindAsync(id);
            if (entity == null) return NotFound();

            _mapper.Map(dto, entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/EvaluationCriteria/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _context.EvaluationCriteria.FindAsync(id);
            if (entity == null) return NotFound();

            _context.EvaluationCriteria.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
