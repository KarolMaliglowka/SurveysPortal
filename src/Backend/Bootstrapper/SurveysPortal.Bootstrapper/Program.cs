using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SurveysPortal.Modules.Notifications.Api;
using SurveysPortal.Modules.Surveys.Simple.Api;
using SurveysPortal.Modules.Surveys.Standard.Api;
using SurveysPortal.Modules.Users.Api;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Infrastructure;
using SurveysPortal.Modules.Users.Infrastructure.DAL;
using SurveysPortal.Shared.Infrastructure;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Survey's Portal API",
            Version = "v1"
        });
    });

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy",
    corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services
    .AddUsersModule()
    .AddSurveysStandardApiModule()
    .AddSurveysSimpleModule()
    .AddNotificationsModule()
    .AddInfrastructureModule()
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddAuthorization();
builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<UsersDbContext>();

var app = builder.Build();
await app.SeedData();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<User>();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseRouting();
app.MapControllers();

app.Run();
