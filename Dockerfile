FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AlumniAPI/AlumniAPI.csproj", "AlumniAPI/"]
RUN dotnet restore "AlumniAPI/AlumniAPI.csproj"
COPY . .
WORKDIR "/src/AlumniAPI"
RUN dotnet build "AlumniAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlumniAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlumniAPI.dll"]
