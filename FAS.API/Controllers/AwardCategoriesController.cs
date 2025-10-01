using AutoMapper;
using FAS.Model;
using FAS.Model.DTOs;
using FAS.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AwardCategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AwardCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwardCategoryDto>>> GetAll()
        {
            var categories = await _context.AwardCategories
                                           .OrderBy(c => c.Order)
                                           .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AwardCategoryDto>>(categories));
        }

        // GET: api/AwardCategories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AwardCategoryDto>> GetById(Guid id)
        {
            var entity = await _context.AwardCategories.FindAsync(id);
            if (entity == null) return NotFound();

            return Ok(_mapper.Map<AwardCategoryDto>(entity));
        }

        // POST: api/AwardCategories
        [HttpPost]
        public async Task<ActionResult<AwardCategoryDto>> CreateCategory([FromBody] AwardCategoryCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Category name cannot be empty.");

            var entity = _mapper.Map<AwardCategory>(dto);
            entity.Id = Guid.NewGuid();

            _context.AwardCategories.Add(entity);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<AwardCategoryDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, result);
        }
    }
}
