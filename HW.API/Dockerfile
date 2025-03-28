FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HW.API/HW.API.csproj", "HW.ApplicationDTOs/HW.ApplicationDTOs.csproj", "HW.Application/HW.Application.csproj", "HW.Core/HW.Core.csproj", "HW.Jwt/HW.Jwt.csproj", "HW.Persistence/HW.Persistence.csproj", "./"]
RUN dotnet restore "HW.API/HW.API.csproj"
COPY . .
WORKDIR "/src/HW.API"
RUN dotnet build "HW.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HW.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HW.API.dll"]