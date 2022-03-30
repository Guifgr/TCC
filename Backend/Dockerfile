FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TccBackend/TccBackend.csproj", "TccBackend/"]
RUN dotnet restore "TccBackend/TccBackend.csproj"
COPY . .
WORKDIR "/src/TccBackend"
RUN dotnet build "TccBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TccBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TccBackend.dll"]
