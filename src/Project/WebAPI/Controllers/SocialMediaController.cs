using Application.Features.SocialMedias.Commands.CreateCommand;
using Application.Features.SocialMedias.Commands.DeleteCommand;
using Application.Features.SocialMedias.Commands.UpdateCommand;
using Application.Features.SocialMedias.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
    {
        var result = await Mediator.Send(createSocialMediaCommand);
        return Created("",result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await Mediator.Send(new GetListSocialMediaQuery() { PageRequest = pageRequest });
        return Ok(result);
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdSocialMediaQuery getByIdSocialMediaQuery)
    {
        var result = await Mediator.Send(getByIdSocialMediaQuery);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Get([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
    {
        var result = await Mediator.Send(updateSocialMediaCommand);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Get([FromQuery] DeleteSocialMediaCommand deleteSocialMediaCommand)
    {
        var result = await Mediator.Send(deleteSocialMediaCommand);
        return Ok(result);
    }
}