FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["background-task-queue.CORE/background-task-queue.CORE.csproj", "background-task-queue.CORE/"]
RUN dotnet restore "background-task-queue.CORE/background-task-queue.CORE.csproj"
COPY . .
WORKDIR "/src/background-task-queue.CORE"
RUN dotnet build "background-task-queue.CORE.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "background-task-queue.CORE.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "background-task-queue.CORE.dll"]
