using FAS.DAL.Interfaces;
using FAS.Model;
using FAS.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace FAS.DAL.Repositories
{
    public class CouncilMemberRepository : ICouncilMemberRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CouncilMemberRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CouncilMember> AddCouncilMember(CouncilMember councilMember)
        {
            councilMember.Id = Guid.NewGuid();
            _dbContext.CouncilMembers.Add(councilMember);
            try
            {
                await _dbContext.SaveChangesAsync();
                return councilMember;
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public async Task<bool> DeleteCouncilMember(Guid id)
        {
            var councilMember = await GetCouncilMemberById(id);
            if (councilMember != null)
            {
                _dbContext.CouncilMembers.Remove(councilMember);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CouncilMember>> GetCouncilMemberAll()
        {
            try
            {
                return await _dbContext.CouncilMembers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CouncilMember?> GetCouncilMemberById(Guid id)
        {
            try
            {
                return await _dbContext.CouncilMembers.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CouncilMember?> UpdateCouncilMember(Guid id, CouncilMember councilMember)
        {
            var existingCouncilMember = await GetCouncilMemberById(id);
            if (existingCouncilMember != null)
            {
                existingCouncilMember.FullName = councilMember.FullName;
                existingCouncilMember.Email = councilMember.Email;
                existingCouncilMember.Position = councilMember.Position;
                existingCouncilMember.Role = councilMember.Role;
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return existingCouncilMember;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public async Task<CouncilMember?> GetCouncilMemberFilter(string filter)
        {
            var councilMember =  await _dbContext.CouncilMembers.FirstOrDefaultAsync(cm => cm.FullName!.Contains(filter, StringComparison.OrdinalIgnoreCase) || cm.Position!.Contains(filter, StringComparison.OrdinalIgnoreCase));
            return councilMember;
        }
    }
}
