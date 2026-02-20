using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SurveysPortal.Modules.Notifications.Api;
using SurveysPortal.Modules.Surveys.Simple.Api;
using SurveysPortal.Modules.Surveys.Standard.Api;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;
using SurveysPortal.Modules.Users.Api;
using SurveysPortal.Modules.Users.Core.Entities;
using SurveysPortal.Modules.Users.Infrastructure;
using SurveysPortal.Modules.Users.Infrastructure.DAL;
using SurveysPortal.Shared.Infrastructure;
using SurveysPortal.Shared.Infrastructure.Exceptions;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddProblemDetails();
// builder.Services.AddProblemDetails(options =>
//     options.CustomizeProblemDetails = context =>
//     {
//         context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method}:{context.HttpContext.Request.Path}";
//         context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
//         var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
//         context.ProblemDetails.Extensions.TryAdd("activity", activity?.Id);
//     });
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();




builder.Services.AddHealthChecks();
builder.Services
    .AddEndpointsApiExplorer();
builder.Services
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
        options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        options.IgnoreObsoleteActions();
        options.IgnoreObsoleteProperties();
        options.CustomSchemaIds(type => type.FullName);
    });

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy",
    corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    }));

builder.Services
    .AddSurveysStandardApiModule()
    .AddUsersModule()
    .AddSurveysSimpleModule()
    .AddNotificationsModule()
    .AddInfrastructureModule()
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

//add identity and JWT authentication
builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddSignInManager()
    .AddRoles<IdentityRole<Guid>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"] ??
                      throw new InvalidOperationException("Value Issuer in JwtSettings is null."),
        ValidAudience = builder.Configuration["JwtSettings:Audience"] ??
                        throw new InvalidOperationException("Value Audience in JwtSettings is null."),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Key"] ??
                                                                            throw new InvalidOperationException(
                                                                                "Value Key in JwtSettings is null.")))
    };
});

var app = builder.Build();

ApplyMigration();

await app.SeedUsersData();
await app.SeedStandardQuestionsData();
await app.SeedStandardSurveysData();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("ApiCorsPolicy");

app.UseHttpsRedirection();


app.MapHealthChecks("/health");
//app.UseExceptionHandler("/error");



app.UseRouting();
app.MapControllers();
app.UsePathBase("/");
//app.UseStatusCodePages();
app.UseExceptionHandler();
app.Run();

return;

void ApplyMigration()
{
    using var scope = app.Services
        .CreateScope();

    var contextTypes = builder.Services
        .Where(sd => sd.ServiceType.IsAssignableTo(typeof(DbContext)))
        .Select(sd => sd.ServiceType);

    foreach (var contextType in contextTypes)
    {
        var dbContext = (DbContext)scope.ServiceProvider
            .GetRequiredService(contextType);

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }
    }
}