using AutoMapper;
using Blogger.Application.Dto;
using Blogger.Application.Interfaces;
using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces;
using Microsoft.VisualBasic;

namespace Blogger.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var _posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDto>>(_posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> AddPostAsync(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post cannot have an empty title.");
            }

            var post = _mapper.Map<Post>(newPost);
            var result = await _postRepository.AddAsync(post);
            return _mapper.Map<PostDto>(result);
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePost)
        {
            var existingPost = await _postRepository.GetByIdAsync(updatePost.Id);

            var post = _mapper.Map(updatePost, existingPost);

            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            await _postRepository.DeleteAsync(post);

        }
    }
}
