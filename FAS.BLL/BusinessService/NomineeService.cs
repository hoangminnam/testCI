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
    public class NomineeService : INomineeService
    {
        private readonly INomineeRepository _nomineeRepository;
        public NomineeService(INomineeRepository nomineeRepository)
        {
            _nomineeRepository = nomineeRepository;
        }
        public async Task<IEnumerable<Nominee>> GetNominees() => await _nomineeRepository.GetNominees();
        public async Task<Nominee?> GetNominee(Guid id) => await _nomineeRepository.GetNominee(id);
        public async Task UpdateNominee(Guid id, Nominee nominee) => await _nomineeRepository.UpdateNominee(id,nominee);
        public async Task AddNominee(Nominee nominee) => await _nomineeRepository.AddNominee(nominee);
        public async Task DeleteNominee(Guid id) => await _nomineeRepository.DeleteNominee(id);
    }
}
