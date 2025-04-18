FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /src
COPY ["WebUI/WebUI.csproj", "WebUI/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app/build
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebUI.dll"]
