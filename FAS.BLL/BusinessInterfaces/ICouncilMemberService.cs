using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessInterfaces
{
    public interface ICouncilMemberService
    {
        //CRUD Operations
        Task<IEnumerable<CouncilMember>> GetCouncilMemberAll();
        Task<CouncilMember?> GetCouncilMemberById(Guid id);
        Task<CouncilMember> AddCouncilMember(CouncilMember councilMember);
        Task<CouncilMember?> UpdateCouncilMember(Guid id, CouncilMember councilMember);
        Task<bool> DeleteCouncilMember(Guid id);
        Task<CouncilMember?> GetCouncilMemberFilter(string filter);
    }
}
