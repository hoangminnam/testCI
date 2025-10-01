using FAS.DAL.Interfaces;
using FAS.Model;
using FAS.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FAS.DAL.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetBlog(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            return blog;
        }

        public async Task UpdateBlog(Guid id, Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;

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

        public async Task AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
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

        public async Task DeleteBlog(Guid id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return;
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return;
        }
    }
}
