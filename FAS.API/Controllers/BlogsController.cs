using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FAS.Model;
using FAS.Model.Models;
using FAS.BLL;
using FAS.BLL.BusinessInterfaces;

namespace FAS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            var blogs = await _blogService.GetBlogs();
            return Ok(blogs);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(Guid id)
        {
            var blog = await _blogService.GetBlog(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(Guid id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            await _blogService.UpdateBlog(id, blog);

            return Ok();
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            await _blogService.AddBlog(blog);

            return Ok();
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            await _blogService.DeleteBlog(id);

            return Ok();
        }

    }
}
