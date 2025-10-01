using FAS.DAL.Interfaces;
using FAS.Model;
using FAS.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.DAL.Repositories
{
    public class NomineeRepository : INomineeRepository
    {
        private readonly ApplicationDbContext _context;

        public NomineeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nominee>> GetNominees()
        {
            return await _context.Nominees.ToListAsync();
        }

        public async Task<Nominee?> GetNominee(Guid id)
        {
            var nominee = await _context.Nominees.FindAsync(id);
            return nominee;
        }

        public async Task UpdateNominee(Guid id, Nominee nominee)
        {
            _context.Entry(nominee).State = EntityState.Modified;

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

        public async Task AddNominee(Nominee nominee)
        {
            _context.Nominees.Add(nominee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return;
        }

        public async Task DeleteNominee(Guid id)
        {
            var nominee = await _context.Nominees.FindAsync(id);
            if (nominee == null)
            {
                return;
            }

            _context.Nominees.Remove(nominee);
            await _context.SaveChangesAsync();
            return ;
        }
    }
}
