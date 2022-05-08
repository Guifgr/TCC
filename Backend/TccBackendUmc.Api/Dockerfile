FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TccBackendUmc/TccBackendUmc.csproj", "TccBackendUmc/"]
RUN dotnet restore "TccBackendUmc/TccBackendUmc.csproj"
COPY . .
WORKDIR "/src/TccBackendUmc"
RUN dotnet build "TccBackendUmc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TccBackendUmc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TccBackendUmc.dll"]
