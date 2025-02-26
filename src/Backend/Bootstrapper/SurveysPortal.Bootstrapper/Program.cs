using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
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

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
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
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("ApiCorsPolicy");

app.UseHttpsRedirection();
app.MapHealthChecks( "/health" );
app.UseExceptionHandler("/error");
app.UseRouting();
app.MapControllers();
app.UsePathBase("/");

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