using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Interfaces;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessService
{
    public class NominateActionLogService : INominateActionLogService
    {
        private readonly INominateActionLogRepository _repository;
        public NominateActionLogService(INominateActionLogRepository nominateActionLogRepository)
        {
            _repository = nominateActionLogRepository;
        }
        public async Task<IEnumerable<NominateActionLog>> GetNominateActionLogs() => await _repository.GetNominateActionLogs();
        public async Task<NominateActionLog?> GetNominateActionLog(Guid id) => await _repository.GetNominateActionLog(id);
        public async Task UpdateNominateActionLog(Guid id, NominateActionLog nominateActionLog) => await _repository.UpdateNominateActionLog(id, nominateActionLog);
        public async Task<NominateActionLog> AddNominateActionLog(NominateActionLog nominateActionLog) => await _repository.AddNominateActionLog(nominateActionLog);
        public async Task DeleteNominateActionLog(Guid id)=> await _repository.DeleteNominateActionLog(id);
    }
}
