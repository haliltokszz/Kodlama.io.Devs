using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Commands.CreateCommand;
using Application.Features.ProgrammingLanguages.Commands.DeleteCommand;
using Application.Features.ProgrammingLanguages.Commands.UpdateCommand;
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
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDTO>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDTO>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
    }
}