#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotNET6JwtAssignment.API/DotNET6JwtAssignment.API.csproj", "DotNET6JwtAssignment.API/"]
RUN dotnet restore "DotNET6JwtAssignment.API/DotNET6JwtAssignment.API.csproj"
COPY . .
WORKDIR "/src/DotNET6JwtAssignment.API"
RUN dotnet build "DotNET6JwtAssignment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNET6JwtAssignment.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNET6JwtAssignment.API.dll"]