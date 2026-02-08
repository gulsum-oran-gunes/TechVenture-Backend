using Application.Features.BootcampContents.Commands.Create;
using Application.Features.BootcampContents.Commands.Delete;
using Application.Features.BootcampContents.Commands.Update;
using Application.Features.BootcampContents.Queries.GetById;
using Application.Features.BootcampContents.Queries.GetList;
using Application.Features.BootcampContents.Rules;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping; // Add this line
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Application.Features.BootcampContents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampContent, CreateBootcampContentCommand>().ReverseMap();
        CreateMap<BootcampContent, CreatedBootcampContentResponse>().ReverseMap();
        CreateMap<BootcampContent, UpdateBootcampContentCommand>().ReverseMap();
        CreateMap<BootcampContent, UpdatedBootcampContentResponse>().ReverseMap();
        CreateMap<BootcampContent, DeleteBootcampContentCommand>().ReverseMap();
        CreateMap<BootcampContent, DeletedBootcampContentResponse>().ReverseMap();
        CreateMap<BootcampContent, GetByIdBootcampContentResponse>().ReverseMap();
        CreateMap<BootcampContent, GetListBootcampContentListItemDto>().ReverseMap();

        CreateMap<IPaginate<BootcampContent>, GetListResponse<GetListBootcampContentListItemDto>>().ReverseMap();
    }
}
