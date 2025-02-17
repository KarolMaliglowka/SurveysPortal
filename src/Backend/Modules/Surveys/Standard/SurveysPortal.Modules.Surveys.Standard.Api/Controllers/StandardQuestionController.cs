using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveysPortal.Modules.Surveys.Standard.Application.Commands;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.Queries;
using SurveysPortal.Shared.Abstractions.Dispatchers;

namespace SurveysPortal.Modules.Surveys.Standard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandardQuestionController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<QuestionDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<QuestionDto>>> GetAllQuestions() => 
        Ok(await dispatcher.QueryAsync(new GetAllQuestions()));

    [HttpGet("getQuestionById/{questionId:int}")]
    [ProducesResponseType(typeof(QuestionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int questionId)
    {
        return await dispatcher.QueryAsync(new GetQuestion { QuestionId = questionId });
    }

    [HttpPut("deleteQuestion/{questionId:int}")]
    [ProducesResponseType(typeof(QuestionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task DeleteQuestion(int questionId)
    {
        await dispatcher.SendAsync(new DeleteQuestion{ QuestionId = questionId });
    }

    [HttpPost("createQuestion")]
    [ProducesResponseType(typeof(NewQuestion), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateQuestion([FromBody] NewQuestion command)
    {
        await dispatcher.SendAsync(new CreateQuestion
        {
            Question = command.Question!,
            Require = command.Required
        });
        return Created();
    }

    [HttpPut("updateQuestion/{questionId:int}")]
    [ProducesResponseType(typeof(NewQuestion), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateQuestion(int questionId, [FromBody] NewQuestion command)
    {
        await dispatcher.SendAsync(new EditQuestion
        {
            QuestionId = questionId,
            Question = command
        });
        return Ok();
    }
}