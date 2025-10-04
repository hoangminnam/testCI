using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.DAL.Interfaces
{
    public interface INominateActionLogRepository
    {
        public Task<IEnumerable<NominateActionLog>> GetNominateActionLogs();
        public Task<NominateActionLog?> GetNominateActionLog(Guid id);
        public Task UpdateNominateActionLog(Guid id, NominateActionLog nominateActionLog);
        public Task<NominateActionLog> AddNominateActionLog(NominateActionLog nominateActionLog);
        public Task DeleteNominateActionLog(Guid id);
    }
}
