using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveysPortal.Modules.Surveys.Standard.Application.Commands;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.Queries;
using SurveysPortal.Shared.Abstractions.Dispatchers;

namespace SurveysPortal.Modules.Surveys.Standard.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StandardSurveyController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<SurveyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<SurveyDto>>> GetAllSurveys() =>
        Ok(await dispatcher.QueryAsync(new GetAllSurveys()));

    [HttpGet("getSurveyById/{surveyId:int}")]
    [ProducesResponseType(typeof(SurveyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SurveyDto>> GetQuestion(int surveyId)
    {
        return await dispatcher.QueryAsync(new GetSurvey { SurveyId = surveyId });
    }

    [HttpPut("deleteSurvey/{surveyId:int}")]
    [ProducesResponseType(typeof(SurveyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteSurvey(int surveyId)
    {
        await dispatcher.SendAsync(new DeleteSurvey{ SurveyId = surveyId });
        return Ok();
    }
    
    [HttpPost("createSurvey")]
    [ProducesResponseType(typeof(NewSurvey), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateSurvey([FromBody] NewSurvey command)
    {
        await dispatcher.SendAsync(new CreateSurvey
        {
            Survey = command.Survey!,
            Description = command.Description!,
            Introduction = command.Introduction!
        });
        return Created();
    }

    [HttpPut("updateSurvey/{surveyId:int}")]
    [ProducesResponseType(typeof(NewSurvey), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateSurvey(int surveyId, [FromBody] NewSurvey command)
    {
        await dispatcher.SendAsync(new EditSurvey
        {
            SurveyId = surveyId,
            Survey = command
        });
        return Ok();
    }

    public async Task<ActionResult> Assign(int surveyId, [FromBody] AssignUser command)
    {
        await dispatcher.SendAsync(new AssignUser
        {
            SurveyId = surveyId,
            AssignUser = command
        });
        return Ok();
    }
}