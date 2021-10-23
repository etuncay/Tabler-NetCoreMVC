#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tabler-NetCoreMVC.csproj", "."]
RUN dotnet restore "./Tabler-NetCoreMVC.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Tabler-NetCoreMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tabler-NetCoreMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tabler-NetCoreMVC.dll"]