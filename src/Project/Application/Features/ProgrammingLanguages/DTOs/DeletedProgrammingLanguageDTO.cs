namespace Application.Features.ProgrammingLanguages.DTOs;

public class DeletedProgrammingLanguageDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool isDeleted { get; set; }
}