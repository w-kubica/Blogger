﻿using Blogger.Application.Dto;
using Blogger.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Blogger.API.Controllers.v2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ICosmosPostService _postService;
        public PostsController(ICosmosPostService postService)
        {
            _postService = postService;
        }

        [SwaggerOperation(Summary = "Retrieves all posts")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [SwaggerOperation(Summary = "Retrieves a specific post by unique id")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [SwaggerOperation(Summary = "Create a new post.")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCosmosPostDto newPost)
        {
            var post = await _postService.AddPostAsync(newPost);

            return Created($"api/posts/{post.Id}", post);
        }

        [SwaggerOperation(Summary = "Update a existing post.")]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCosmosPostDto updatePost)
        {
           await _postService.UpdatePostAsync(updatePost);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific post.")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
           await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
