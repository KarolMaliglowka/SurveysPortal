using SurveysPortal.Modules.Notifications.Api;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Api;
using SurveysPortal.Modules.Surveys.Simple.Api;
using SurveysPortal.Modules.Users.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddUsersModule()
    .AddSurveysQuestionAnswerModule()
    .AddSurveysSimpleModule()
    .AddNotificationsModule();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
