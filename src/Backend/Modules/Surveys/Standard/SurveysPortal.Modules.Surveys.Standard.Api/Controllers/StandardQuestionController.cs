using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.Queries;
using SurveysPortal.Shared.Abstractions.Dispatchers;

namespace SurveysPortal.Modules.Surveys.Standard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StandardQuestionController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<QuestionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<QuestionDto>>> GetAllQuestions() => Ok(await dispatcher.QueryAsync(new GetAllQuestions()));

    [HttpGet("getQuestionById/{id:int}")]
    [ProducesResponseType(typeof(QuestionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
    {
        return await dispatcher.QueryAsync(new GetQuestion { QuestionId = id });
    }
}