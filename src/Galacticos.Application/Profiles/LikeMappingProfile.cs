using AutoMapper;
using Galacticos.Domain.Entities;
using Galacticos.Application.DTOs.Likes;
using Galacticos.Application.DTOs.Like;

namespace Galacticos.Application.Profiles
{
    public class LikeMappingProfile : Profile
    {
        public LikeMappingProfile()
        {
            CreateMap<CreateLikeDto, Like>().ReverseMap();
            CreateMap<Like, LikeDto>().ReverseMap();  
            CreateMap<Like, LikeResponseDto>().ReverseMap();          
        }
    }
}