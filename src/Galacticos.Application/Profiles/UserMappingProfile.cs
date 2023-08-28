using AutoMapper;
using Galacticos.Application.DTOs.Auth;
using Galacticos.Application.Features.Auth.Requests.Commands;
using Galacticos.Application.Features.Auth.Requests.Queries;
using Galacticos.Domain.Entities;
using Galacticos.Application.DTOs.Auth;

namespace Galacticos.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<RegisterCommand, User>();
        CreateMap<LoginRequest, LoginQuery>();
    }
}