using Microsoft.OpenApi.Models;
using SurveysPortal.Modules.Notifications.Api;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Api;
using SurveysPortal.Modules.Surveys.Simple.Api;
using SurveysPortal.Modules.Users.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Survey's Portal API",
            Version = "v1"
        });
    });
builder.Services
    .AddUsersModule()
    .AddSurveysQuestionAnswerModule()
    .AddSurveysSimpleModule()
    .AddNotificationsModule();

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
// app.UseExceptionHandler("/error");
// app.UseRouting();
// app.MapControllers();

app.Run();
