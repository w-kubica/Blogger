using AutoMapper;
using Blogger.Application.Mappings;
using Blogger.Domain.Cosmos;

namespace Blogger.Application.Dto
{
    public class CreateCosmosPostDto : IMap
    {
        public string? Title { get; set; }
        public string? Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCosmosPostDto, CosmosPost>();
        }
    }
}
