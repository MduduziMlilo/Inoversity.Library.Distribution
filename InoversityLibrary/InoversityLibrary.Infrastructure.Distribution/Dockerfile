FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InoversityLibrary.Infrastructure.Distribution/InoversityLibrary.Infrastructure.Distribution.csproj", "InoversityLibrary.Infrastructure.Distribution/"]
RUN dotnet restore "InoversityLibrary.Infrastructure.Distribution/InoversityLibrary.Infrastructure.Distribution.csproj"
COPY . .
WORKDIR "/src/InoversityLibrary.Infrastructure.Distribution"
RUN dotnet build "InoversityLibrary.Infrastructure.Distribution.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InoversityLibrary.Infrastructure.Distribution.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InoversityLibrary.Infrastructure.Distribution.dll"]
