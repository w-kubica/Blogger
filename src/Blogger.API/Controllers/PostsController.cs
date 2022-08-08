﻿using Blogger.Application.Dto;
using Blogger.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blogger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Retrieves all posts")]
        [HttpGet]
        public ActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrieves a specific post by unique id")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new post.")]
        [HttpPost]
        public IActionResult Create(CreatePostDto newPost)
        {
            var post = _postService.AddPost(newPost);

            return Created($"api/posts/{post.Id}", post); 
        }
    }
}