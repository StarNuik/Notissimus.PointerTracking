FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notissimus.PointerTracking.Api/Notissimus.PointerTracking.Api.csproj", "Notissimus.PointerTracking.Api/"]
RUN dotnet restore "Notissimus.PointerTracking.Api/Notissimus.PointerTracking.Api.csproj"
COPY . .
WORKDIR "/src/Notissimus.PointerTracking.Api"
RUN dotnet build "Notissimus.PointerTracking.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Notissimus.PointerTracking.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notissimus.PointerTracking.Api.dll"]
