FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notissimus.PointerTracking.Web/Notissimus.PointerTracking.Web.csproj", "Notissimus.PointerTracking.Web/"]
RUN dotnet restore "Notissimus.PointerTracking.Web/Notissimus.PointerTracking.Web.csproj"
COPY . .
WORKDIR "/src/Notissimus.PointerTracking.Web"
RUN dotnet build "Notissimus.PointerTracking.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Notissimus.PointerTracking.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notissimus.PointerTracking.Web.dll"]
