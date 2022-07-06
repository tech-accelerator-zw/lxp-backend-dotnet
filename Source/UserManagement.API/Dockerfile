FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/UserManagement.API/UserManagement.API.csproj", "Source/UserManagement.API/"]
COPY ["Source/ModelLibrary/ModelLibrary.csproj", "Source/ModelLibrary/"]
RUN dotnet restore "Source/UserManagement.API/UserManagement.API.csproj"
COPY . .
WORKDIR "/src/Source/UserManagement.API"
RUN dotnet build "UserManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.API.dll"]