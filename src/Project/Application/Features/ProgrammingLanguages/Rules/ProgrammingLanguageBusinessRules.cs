﻿using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageReadRepository programmingLanguageReadRepository)
    {
        _programmingLanguageReadRepository = programmingLanguageReadRepository;
    }
    
    public async Task CheckIfProgrammingLanguageNameIsUnique(string name)
    {
        IPaginate<ProgrammingLanguage> result = await _programmingLanguageReadRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNameAlreadyExists); //TODO: Localize message.
    }

    public async Task CheckIfProgrammingLanguageExists(ProgrammingLanguage programmingLanguage)
    {
        if (programmingLanguage == null) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotFound); //TODO: Localize message.
    }
}