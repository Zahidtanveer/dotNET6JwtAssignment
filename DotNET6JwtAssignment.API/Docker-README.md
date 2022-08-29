# Deployment guidelines on any server using docker

# 1.Create docker file
The Dockerfile file is used by the "docker build" command to create a container image. 
This file is a text file named Dockerfile that doesn't have an extension.
Create a file named Dockerfile in the directory containing the .csproj and open it in a text editor. 
----------------------------------------------------------------------------------------------------
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
----------------------------------------------------------------------------------------------------

# 2. Create Image 

cmd:"docker build -t dotnet6jwtassignmentapi-image -f Dockerfile"

run "docker images" to see a list of images installed

# 3. Create Container

cmd: "docker create --name dotnet6jwtassignmentapi dotnet6jwtassignmentapi-image"

The docker create command from above will create a container based on the dotnet6jwtassignmentapi-image image.

=> List of all containers, use the docker ps -a command

# 4. Run & Stop Container
Run Container
cmd:"docker start dotnet6jwtassignmentapi"

"docker start" command to start the container, and then uses the "docker ps" command to only show containers that are running

Stop Container
cmd: "docker stop dotnet6jwtassignmentapi"

"docker stop" command will stop the container

# 5.Publish Docker Container

docker login --username username

prompts for password if you omit --password 

docker tag imageName username/repoName

docker push username/repoName