using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Interfaces;
using FAS.Model.Models;

namespace FAS.BLL.BusinessService
{
    public class CouncilMemberService : ICouncilMemberService
    {
        private readonly ICouncilMemberRepository _councilMemberRepository;
        public CouncilMemberService(ICouncilMemberRepository councilMemberRepository)
        {
            _councilMemberRepository = councilMemberRepository;
        }

        public async Task<CouncilMember> AddCouncilMember(CouncilMember councilMember)
        {
            return await _councilMemberRepository.AddCouncilMember(councilMember);
        }

        public async Task<bool> DeleteCouncilMember(Guid id)
        {
            return await _councilMemberRepository.DeleteCouncilMember(id);
        }

        public async Task<IEnumerable<CouncilMember>> GetCouncilMemberAll()
        {
            return await _councilMemberRepository.GetCouncilMemberAll();
        }

        public async Task<CouncilMember?> GetCouncilMemberById(Guid id)
        {
            return await _councilMemberRepository.GetCouncilMemberById(id);
        }

        public Task<CouncilMember?> GetCouncilMemberFilter(string filter)
        {
            return _councilMemberRepository.GetCouncilMemberFilter(filter);
        }

        public async Task<CouncilMember?> UpdateCouncilMember(Guid id, CouncilMember councilMember)
        {
            return await _councilMemberRepository.UpdateCouncilMember(id, councilMember);
        }
    }
}
