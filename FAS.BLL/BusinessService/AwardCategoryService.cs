using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Interfaces;
using FAS.DAL.Repositories;
using FAS.Model.DTOs;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessService
{
    public class AwardCategoryService : IAwardCategoryService
    {
        private readonly IAwardCategoryRepository _repository;
        public AwardCategoryService(IAwardCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AwardCategoryDto>> GetAwardCategoryPage()
        {
            return await _repository.GetAwardCategoryPage();
        }
        public async Task<List<AwardCategoryDto>> GetAwardCategoryFilter(string search)
        {
            return await _repository.GetAwardCategoryFilter(search);
        }
        public async Task<AwardCategory> SetAwardCategoryInfo(AwardCategoryDto awardCategory)
        {
            return await _repository.SetAwardCategoryInfo(awardCategory);
        }
        public async Task<AwardCategory?> UpdateAwardCategoryInfo(AwardCategoryDto awardCategory)
        {
            return await _repository.UpdateAwardCategoryInfo(awardCategory);
        }
        public async Task<string> DeleteAwardCategory(Guid awardCategoryId)
        {
            return await _repository.DeleteAwardCategory(awardCategoryId);
        }
    }
}
