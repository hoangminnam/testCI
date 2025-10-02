using FAS.Model.DTOs;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.DAL.Interfaces
{
    public interface IAwardCategoryRepository
    {
        Task<List<AwardCategoryDto>> GetAwardCategoryPage();
        Task<List<AwardCategoryDto>> GetAwardCategoryFilter(AwardCategoryDto filter);
        Task<AwardCategory> SetAwardCategoryInfo(AwardCategoryDto awardCategory);
        Task<AwardCategory?> UpdateAwardCategoryInfo(AwardCategoryDto awardCategory);
        Task<string> DeleteAwardCategory(Guid awardCategoryId);
    }
}
