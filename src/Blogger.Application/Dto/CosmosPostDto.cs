﻿using AutoMapper;
using Blogger.Application.Mappings;
using Blogger.Domain.Cosmos;

namespace Blogger.Application.Dto
{
    public class CosmosPostDto : IMap
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CosmosPost, CosmosPostDto>();
        }
    }
}
