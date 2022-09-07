using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateCommand;

public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDTO>
{
    public string Name { get; set; }
    
    public class CreateProgrammingLanguageCommandHandler:IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDTO>
    {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageWriteRepository programmingLanguageWriteRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _mapper = mapper;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
        }

        public async Task<CreatedProgrammingLanguageDTO> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguageBusinessRules.CheckIfProgrammingLanguageNameIsUnique(request.Name);
            
            var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            var createdProgramminLanguage = await _programmingLanguageWriteRepository.AddAsync(mappedProgrammingLanguage);
            var createdProgrammingLanguageDTO = _mapper.Map<CreatedProgrammingLanguageDTO>(createdProgramminLanguage);
            return createdProgrammingLanguageDTO;
        }
    }
}