using Application.Features.Frameworks.Commands.CreateCommand;
using Application.Features.Frameworks.Commands.DeleteCommand;
using Application.Features.Frameworks.Commands.UpdateCommand;
using Application.Features.Frameworks.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FrameworkController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateFrameworkCommand createFrameworkCommand)
    {
        var result = await Mediator.Send(createFrameworkCommand);
        return Created("",result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await Mediator.Send(new GetListFrameworkQuery() { PageRequest = pageRequest });
        return Ok(result);
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdFrameworkQuery getByIdFrameworkQuery)
    {
        var result = await Mediator.Send(getByIdFrameworkQuery);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Get([FromBody] UpdateFrameworkCommand updateFrameworkCommand)
    {
        var result = await Mediator.Send(updateFrameworkCommand);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Get([FromQuery] DeleteFrameworkCommand deleteFrameworkCommand)
    {
        var result = await Mediator.Send(deleteFrameworkCommand);
        return Ok(result);
    }
}