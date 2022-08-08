using AutoMapper;
using Blogger.Application.Dto;
using Blogger.Application.Interfaces;
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
    }
}
