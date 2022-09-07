using Application.Features.ProgrammingLanguages.DTOs;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries;

public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageByIdDTO>
{
    public string Id { get; set; }
    
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageByIdDTO>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;
        private readonly IMapper _mapper;
        
        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            _mapper = mapper;
        }
        
        public async Task<ProgrammingLanguageByIdDTO> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguage = await _programmingLanguageReadRepository.GetByIdAsync(request.Id);
            await _programmingLanguageBusinessRules.CheckIfProgrammingLanguageExists(programmingLanguage);
            
            return _mapper.Map<ProgrammingLanguageByIdDTO>(programmingLanguage);
        }
    }
}