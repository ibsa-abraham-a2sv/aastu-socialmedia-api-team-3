using AutoMapper;
using Galacticos.Application.DTOs.Auth;
using Galacticos.Application.Contract.Authentication;
using Galacticos.Application.DTOs.Users;
using Galacticos.Application.Features.Auth.Requests.Commands;
using Galacticos.Application.Features.Auth.Requests.Queries;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<RegisterCommand, User>();
        CreateMap<LoginRequest, LoginQuery>();
        CreateMap<User, UserDto>().ReverseMap();
    }
}