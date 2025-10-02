using FAS.DAL.Interfaces;
using FAS.Model;
using FAS.Model.DTOs;
using FAS.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace FAS.DAL.Repositories
{
    public class AwardCategoryRepository : IAwardCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public AwardCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AwardCategoryDto>> GetAwardCategoryPage()
        {
            var result = await _context.AwardCategories
                .Select(aw => new AwardCategoryDto
                {
                    Id = aw.Id,
                    Name = aw.Name,
                    Description = aw.Description,
                    Order = aw.Order
                })
                .ToListAsync();
            return result;
        }
        public async Task<List<AwardCategoryDto>> GetAwardCategoryFilter(AwardCategoryDto filter)
        {
            var query = _context.AwardCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(ac =>
                    ac.Name.Contains(filter.Name) ||
                    ac.Description.Contains(filter.Description));
            }

            if (filter.ParentCategory.HasValue)
            {
                query = query.Where(ac => ac.ParentCategory == filter.ParentCategory.Value);
            }

            var result = await query
                .Select(aw => new AwardCategoryDto
                {
                    Id = aw.Id,
                    Name = aw.Name,
                    Description = aw.Description,
                    Order = aw.Order,
                    ParentCategory = aw.ParentCategory
                })
                .ToListAsync();

            return result;
        }
        public async Task<AwardCategory> SetAwardCategoryInfo(AwardCategoryDto awardCategory)
        {
            var result = new AwardCategory
            {
                Id = Guid.NewGuid(),
                Name = awardCategory.Name,
                Description = awardCategory.Description,
                Order = awardCategory.Order,
                ParentCategory = awardCategory.ParentCategory
            };
            _context.AwardCategories.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<AwardCategory?> UpdateAwardCategoryInfo(AwardCategoryDto dto)
        {
            var category = await _context.AwardCategories.FindAsync(dto.Id);
            if (category == null) return null;

            category.Name = dto.Name;
            category.Description = dto.Description;
            category.Order = dto.Order;
            category.ParentCategory = dto.ParentCategory;

            _context.AwardCategories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<string> DeleteAwardCategory(Guid awardCategoryId)
        {
            var result = await _context.AwardCategories.FindAsync(awardCategoryId);
            if (result == null)
            {
                return "AwardCategory không tồn tại!";
            }

            _context.AwardCategories.Remove(result);
            await _context.SaveChangesAsync();

            return "Xoá thành công!";
        }
    }
}
