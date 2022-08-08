using AutoMapper;
using Blogger.Application.Dto;
using Blogger.Domain.Entities;

namespace Blogger.Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Post, PostDto>();
                    cfg.CreateMap<CreatePostDto,Post>();
                })
                .CreateMapper();

    }
}
