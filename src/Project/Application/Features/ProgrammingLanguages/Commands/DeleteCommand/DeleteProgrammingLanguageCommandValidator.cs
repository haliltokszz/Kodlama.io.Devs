﻿using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteCommand;

public class DeleteProgrammingLanguageCommandValidator: AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguageCommandValidator()
    {
        RuleFor(p=> p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        RuleFor(p => p.isSoftDelete)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}