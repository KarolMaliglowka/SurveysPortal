FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
EXPOSE 4040
ENV ASPNETCORE_URLS=http://*:4040
RUN apt-get update && apt-get upgrade -y
RUN apt-get install curl -y

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Backend/.", "src/"]
RUN dotnet restore "src/Bootstrapper/SurveysPortal.Bootstrapper/SurveysPortal.Bootstrapper.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "src/Bootstrapper/SurveysPortal.Bootstrapper/SurveysPortal.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "src/Bootstrapper/SurveysPortal.Bootstrapper/SurveysPortal.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveysPortal.Bootstrapper.dll"]