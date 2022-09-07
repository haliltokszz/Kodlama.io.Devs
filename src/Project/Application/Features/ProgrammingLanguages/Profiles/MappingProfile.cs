using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDTO>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageListDTO>().ReverseMap();
        CreateMap<ProgrammingLanguage, ProgrammingLanguageByIdDTO>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
    }
}