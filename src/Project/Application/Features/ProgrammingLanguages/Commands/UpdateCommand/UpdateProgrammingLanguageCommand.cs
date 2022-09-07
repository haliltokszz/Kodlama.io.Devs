using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateCommand;

public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDTO>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
    
    public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDTO>
    {
        private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;
        
        public UpdateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageWriteRepository programmingLanguageWriteRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }
        
        public async Task<UpdatedProgrammingLanguageDTO> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            var programmingLanguageToUpdate = await _programmingLanguageReadRepository.GetByIdAsync(request.Id);
            await _programmingLanguageBusinessRules
                .CheckIfProgrammingLanguageDoesNotExists(programmingLanguageToUpdate);

            _mapper.Map(request, programmingLanguageToUpdate, typeof(UpdateProgrammingLanguageCommand), typeof(ProgrammingLanguage));
             await _programmingLanguageWriteRepository.Update(programmingLanguageToUpdate);
            return _mapper.Map<UpdatedProgrammingLanguageDTO>(programmingLanguageToUpdate);
        }
    }
}