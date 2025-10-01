using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Interfaces;
using FAS.DAL.Repositories;
using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository) 
        { 
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<Blog>> GetBlogs() => await _blogRepository.GetBlogs();

        public async Task<Blog?> GetBlog(Guid id) => await _blogRepository.GetBlog(id);

        public async Task UpdateBlog(Guid id, Blog blog)=> await _blogRepository.UpdateBlog(id, blog);

        public async Task AddBlog(Blog blog) => await _blogRepository.AddBlog(blog);

        public async Task DeleteBlog(Guid id) => await _blogRepository.DeleteBlog(id);
    }
}
