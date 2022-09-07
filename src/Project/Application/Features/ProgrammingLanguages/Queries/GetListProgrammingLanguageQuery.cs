using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries;

public class GetListProgrammingLanguageQuery: IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageReadRepository programmingLanguageReadRepository, IMapper mapper)
        {
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguages = await _programmingLanguageReadRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);
        }
    }
}