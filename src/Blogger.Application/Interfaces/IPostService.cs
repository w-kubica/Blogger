using Blogger.Application.Dto;

namespace Blogger.Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetPostById(int id);

        PostDto AddPost(CreatePostDto post);

    }
}
