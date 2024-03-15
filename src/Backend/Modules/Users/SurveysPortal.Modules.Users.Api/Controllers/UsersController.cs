using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveysPortal.Modules.Users.Core.Commands;
using SurveysPortal.Modules.Users.Core.DTO;
using SurveysPortal.Modules.Users.Core.Queries;
using SurveysPortal.Shared.Abstractions.Dispatchers;

namespace SurveysPortal.Modules.Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers() => Ok(await dispatcher.QueryAsync(new GetAllUsers()));

    [HttpGet("getUserById/{id:Guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDto>> GetUser(Guid id)
    {
        return await dispatcher.QueryAsync(new GetUser { UserId = id });
    }

    [HttpPut("deactivate/{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task DeactivateUser(Guid id)
    {
        await dispatcher.SendAsync(new DeactivateUser { UserId = id });
    }

    [HttpPut("activate/{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task ActivateUser(Guid id)
    {
        await dispatcher.SendAsync(new ActivateUser { UserId = id });
    }
}