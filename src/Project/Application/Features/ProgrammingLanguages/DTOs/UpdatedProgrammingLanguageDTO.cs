namespace Application.Features.ProgrammingLanguages.DTOs;

public class UpdatedProgrammingLanguageDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool isDeleted { get; set; }
}