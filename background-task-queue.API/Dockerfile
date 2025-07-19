FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["background-task-queue.API/background-task-queue.API.csproj", "background-task-queue.API/"]
RUN dotnet restore "background-task-queue.API/background-task-queue.API.csproj"
COPY ["background-task-queue.Domain/background-task-queue.Domain.csproj", "background-task-queue.Domain/"]
RUN dotnet restore "background-task-queue.Domain/background-task-queue.Domain.csproj"
COPY . .
WORKDIR "/src/background-task-queue.API"
RUN dotnet build "background-task-queue.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "background-task-queue.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "background-task-queue.API.dll"]
