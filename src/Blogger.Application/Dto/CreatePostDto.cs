﻿using AutoMapper;
using Blogger.Application.Mappings;
using Blogger.Domain.Entities;

namespace Blogger.Application.Dto
{
    public class CreatePostDto : IMap
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, Post>();
        }
    }
}
