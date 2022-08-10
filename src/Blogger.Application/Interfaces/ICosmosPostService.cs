using Blogger.Application.Dto;

namespace Blogger.Application.Interfaces
{
    public interface ICosmosPostService
    {
        Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync();
        Task<CosmosPostDto> GetPostByIdAsync(string id);

        Task<CosmosPostDto> AddPostAsync(CreateCosmosPostDto post);

        Task UpdatePostAsync(UpdateCosmosPostDto updatePost);

        Task DeletePostAsync(string id);
    }
}
