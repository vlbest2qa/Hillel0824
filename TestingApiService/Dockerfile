FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY . ./
ENV CI=true
RUN dotnet build
RUN dotnet publish ./TestingApiService.sln -o ./publish


ENTRYPOINT ["dotnet", "publish/TestingApiService.dll"]