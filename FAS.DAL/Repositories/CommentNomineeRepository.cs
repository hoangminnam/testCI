using FAS.DAL.Interfaces;
using FAS.Model.Models;
using FAS.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.DAL.Repositories
{
    public class CommentNomineeRepository : ICommentNomineeRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentNomineeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CommentNominee>> GetCommentNominees()
        {
            return await _context.CommentNominees.ToListAsync();
        }

        public async Task<CommentNominee?> GetCommentNominee(Guid id)
        {
            var commentNominee = await _context.CommentNominees.FindAsync(id);

            return commentNominee;
        }

        public async Task UpdateCommentNominee(Guid id, CommentNominee commentNominee)
        {
            _context.Entry(commentNominee).State = EntityState.Modified;

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

        public async Task<CommentNominee> AddCommentNominee(CommentNominee commentNominee)
        {
            _context.CommentNominees.Add(commentNominee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return commentNominee;
        }

        public async Task DeleteCommentNominee(Guid id)
        {
            var commentNominee = await _context.CommentNominees.FindAsync(id);
            if (commentNominee == null)
            {
                return;
            }

            _context.CommentNominees.Remove(commentNominee);
            await _context.SaveChangesAsync();

            return ;
        }
    }
}
