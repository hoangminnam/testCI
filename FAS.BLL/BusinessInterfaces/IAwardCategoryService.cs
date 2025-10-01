using FAS.Model.DTOs;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessInterfaces
{
    public interface IAwardCategoryService
    {
        Task<List<AwardCategoryDto>> GetAwardCategoryPage();
        Task<List<AwardCategoryDto>> GetAwardCategoryFilter(string search);
        Task<AwardCategory> SetAwardCategoryInfo(AwardCategoryDto awardCategory);
        Task<AwardCategory?> UpdateAwardCategoryInfo(AwardCategoryDto awardCategory);
        Task<string> DeleteAwardCategory(Guid awardCategoryId);    
    }
}
