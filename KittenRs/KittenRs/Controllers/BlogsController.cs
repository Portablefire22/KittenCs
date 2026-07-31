using KittenRs.Client.Data;
using KittenRs.Data;
using KittenRs.Data.Models;
using KittenRs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace KittenRs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : Controller
    {

        private PostService _postService;
        
        public BlogsController(PostService posts)
        {
            _postService = posts;
        }
        
        // GET: api/<BlogController>
        [HttpGet]
        public async Task<BlogDto[]> Get()
        {
            return await _postService.GetPosts();
        }

        [HttpGet("{title}/content")]
        public async Task<ActionResult<string>> GetContent(string title)
        {
            var posts = await _postService.GetPostContent(title);
            return posts == null? NotFound() :  Ok(posts);
        }
        
        [HttpGet("{title}")]
        public async Task<ActionResult<BlogDto>> Get(string title)
        {
            var posts = await _postService.GetPost(title);
            return posts == null? NotFound() :  Ok(posts);
        }


    }
}
