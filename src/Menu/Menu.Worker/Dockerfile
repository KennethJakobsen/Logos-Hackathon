FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Menu/Menu.Worker/Menu.Worker.csproj", "Menu/Menu.Worker/"]
RUN dotnet restore "Menu/Menu.Worker/Menu.Worker.csproj"
COPY . .
WORKDIR "/src/Menu/Menu.Worker"
RUN dotnet build "Menu.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Menu.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Menu.Worker.dll"]
