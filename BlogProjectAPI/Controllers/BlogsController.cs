using BlogProjectAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogContext _blogContext;
        public BlogsController(BlogContext blogContext)
        {
            this._blogContext = blogContext;
        }
        //GET: api/Blog
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            return await _blogContext.Blogs.ToListAsync();
        }

        //Post: api/blog
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Blog>> AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blogToAdd = new Blog()
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                BodyContent = blog.BodyContent,
                postedDate = blog.postedDate,
            };
            var result = await _blogContext.AddAsync(blogToAdd);

            if(result == null)
            {
                return BadRequest(result.State);
            }
            await _blogContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
