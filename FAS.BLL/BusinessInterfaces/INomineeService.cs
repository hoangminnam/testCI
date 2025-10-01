using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessInterfaces
{
    public interface INomineeService
    {
        public Task<IEnumerable<Nominee>> GetNominees();
        public Task<Nominee?> GetNominee(Guid id);
        public Task UpdateNominee(Guid id, Nominee nominee);
        public Task AddNominee(Nominee nominee);
        public Task DeleteNominee(Guid id);
    }
}
