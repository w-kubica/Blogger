using AutoMapper;
using Blogger.Application.Dto;
using Blogger.Application.Interfaces;
using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces;

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

        public IEnumerable<PostDto> GetAllPosts()
        {
            var _posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(_posts); 
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDto>(post);
        }

        public PostDto AddPost(CreatePostDto post)
        {
            if (string.IsNullOrEmpty(post.Title))
            {
                throw new Exception("Post cannot have an empty title.");
            }

            var newPost = _mapper.Map<Post>(post);
            _postRepository.Add(newPost);

            return _mapper.Map<PostDto>(newPost); 
        }

        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);

            var post = _mapper.Map(updatePost, existingPost);

            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            
            _postRepository.Delete(post);
        }
    }
}
