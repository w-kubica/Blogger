﻿using AutoMapper;
using Blogger.Application.Mappings;
using Blogger.Domain.Entities;

namespace Blogger.Application.Dto
{
    public class UpdatePostDto : IMap
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePostDto, Post>();
        }
    }
}
