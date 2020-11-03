# FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY aspnet-core-dotnet-core.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
# WORKDIR /app
# COPY --from=build-env /app/out .
# EXPOSE 80
# ENTRYPOINT ["dotnet", "aspnet-core-dotnet-core.dll"]

# FROM microsoft/aspnetcore-build:latest
# WORKDIR /app

# # Copy the published web app
# COPY ./aspnet-core-dotnet-core/ /app

# # Run command
# ENTRYPOINT ["dotnet", "aspnet-core-dotnet-core.dll"]