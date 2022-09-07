using Application.Features.ProgrammingLanguages.DTOs;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguages.Models;

public class ProgrammingLanguageListModel : BasePageableModel 
{
    public IEnumerable<ProgrammingLanguageListDTO> Items { get; set; }
}