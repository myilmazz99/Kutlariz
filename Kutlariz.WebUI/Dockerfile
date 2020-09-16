#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kutlariz.WebUI/Kutlariz.WebUI.csproj", "Kutlariz.WebUI/"]
COPY ["Kutlariz.DataAccess/Kutlariz.DataAccess.csproj", "Kutlariz.DataAccess/"]
COPY ["Kutlariz.Core/Kutlariz.Core.csproj", "Kutlariz.Core/"]
COPY ["Kutlariz.Entities/Kutlariz.Entities.csproj", "Kutlariz.Entities/"]
COPY ["Kutlariz.Business/Kutlariz.Business.csproj", "Kutlariz.Business/"]
RUN dotnet restore "Kutlariz.WebUI/Kutlariz.WebUI.csproj"
COPY . .
WORKDIR "/src/Kutlariz.WebUI"
RUN dotnet build "Kutlariz.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kutlariz.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kutlariz.WebUI.dll"]