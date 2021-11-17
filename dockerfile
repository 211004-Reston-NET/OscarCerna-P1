# First our virtual OS will need the .NET 5.0 SDK
# We can utilize docker hub to access published images by .Net
#Base Image
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

# Set working directory
WORKDIR /app

# Copy projects and paste into the image working directory
# * will grab anything in the folder that has .sln extension
COPY *.sln ./
COPY BusinessLogic/*.csproj BusinessLogic/
COPY DataAccess/*.csproj DataAccess/
COPY Models/*.csproj Models/
COPY STest/*.csproj STest/
COPY StoreWebUI/*.csproj StoreWebUI/

# Build/Restore Bin and Obj Files
RUN cd StoreWebUI && dotnet restore

# Copy Source Files
COPY . ./
# cmd /bin/bash It was to check if it copied everything and restored everything

# Publish application and dependencies to folder for deployment
RUN dotnet publish StoreWebUI -c Release -o publish --no-restore

# We change our base image to be the runtime since we already used the SDK to create the application itself
# This is to use a lot less memory
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

#
WORKDIR /app
COPY --from=Build /app/publish ./

CMD ["dotnet", "StoreWebUI.dll"]
