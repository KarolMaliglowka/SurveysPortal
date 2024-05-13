Survey's Portal
================================
--------------------------------

## DataBase

### Migrations

<p>After each change that affects the database structure, you must create a migration and update the database.
At this time, there are only one place in the project where you need to update if necessary:

[Users.Infrastructure](../Backend/Modules/Users/SurveysPortal.Modules.Users.Infrastructure), 
[Survey.Standard.Infrastructure](../Backend/Modules/Surveys/Standard/SurveysPortal.Modules.Surveys.Standard.Infrastructure)
 projects.</p>
<p>In order to migrate, we go to the DAL directory in a given project and execute the commands:</p>

Create ne migration
```bash
dotnet ef migrations add <migrationName> --startup-project <startUpProjectName> --project <proejctName> --context <contextName>
```

<p>and update the last migration you created</p>

```bash
dotnet ef database update <migrationName> --startup-project <startUpProjectName> --project <proejctName> --context <contextName>
```
e.g. :

for users
```bash
dotnet ef migrations add InitialMigration --startup-project ..\..\..\..\Bootstrapper\SurveysPortal.Bootstrapper\SurveysPortal.Bootstrapper.csproj --project .\SurveysPortal.Modules.Users.Infrastructure.csproj --context UsersDbContext
```

```bash
dotnet ef database update --startup-project ..\..\..\..\Bootstrapper\SurveysPortal.Bootstrapper\SurveysPortal.Bootstrapper.csproj --project .\SurveysPortal.Modules.Users.Infrastructure.csproj --context UsersDbContext
```

for standard surveys
```bash
dotnet ef migrations add InitialMigration --startup-project ..\..\..\..\Bootstrapper\SurveysPortal.Bootstrapper\SurveysPortal.Bootstrapper.csproj --project .\SurveysPortal.Modules.Surveys.Standard.Infrastructure.csproj --context StandardSurveysDbContext 
```

```bash
dotnet ef database update --startup-project ..\..\..\..\Bootstrapper\SurveysPortal.Bootstrapper\SurveysPortal.Bootstrapper.csproj --project .\SurveysPortal.Modules.Surveys.Standard.Infrastructure.csproj --context StandardSurveysDbContext
```

Information from [entityframeworktutorial.net](https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx).


[Back to README](../../README.md)