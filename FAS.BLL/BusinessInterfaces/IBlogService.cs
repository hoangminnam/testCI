using FAS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.BLL.BusinessInterfaces
{
    public interface IBlogService
    {
        public Task<IEnumerable<Blog>> GetBlogs();

        public Task<Blog?> GetBlog(Guid id);

        public Task UpdateBlog(Guid id, Blog blog);

        public Task AddBlog(Blog blog);

        public Task DeleteBlog(Guid id);
    }
}
