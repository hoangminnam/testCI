using FAS.Model.Models;
using FAS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.DAL.Interfaces;

namespace FAS.DAL.Repositories
{
    public class NominateActionLogRepository : INominateActionLogRepository
    {
        private readonly ApplicationDbContext _context;

        public NominateActionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NominateActionLog>> GetNominateActionLogs()
        {
            return await _context.NominateActionLogs.ToListAsync();
        }

        public async Task<NominateActionLog?> GetNominateActionLog(Guid id)
        {
            var nominateActionLog = await _context.NominateActionLogs.FindAsync(id);

            return nominateActionLog;
        }

        public async Task UpdateNominateActionLog(Guid id, NominateActionLog nominateActionLog)
        {
            if (id != nominateActionLog.Id)
            {
                return;
            }

            _context.Entry(nominateActionLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return;
        }

        public async Task<NominateActionLog> AddNominateActionLog(NominateActionLog nominateActionLog)
        {
            _context.NominateActionLogs.Add(nominateActionLog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return nominateActionLog;
        }

        public async Task DeleteNominateActionLog(Guid id)
        {
            var nominateActionLog = await _context.NominateActionLogs.FindAsync(id);
            if (nominateActionLog == null)
            {
                return;
            }

            _context.NominateActionLogs.Remove(nominateActionLog);
            await _context.SaveChangesAsync();

            return;
        }
    }
}
