using Blogger.Application.Dto;

namespace Blogger.Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task <PostDto> GetPostByIdAsync(int id);

        Task <PostDto> AddPostAsync(CreatePostDto post);

        Task UpdatePostAsync(UpdatePostDto updatePost);

        Task DeletePostAsync(int id);
    }
}
