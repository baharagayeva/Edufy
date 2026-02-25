# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# csproj-ləri ayrı kopyala (restore cache üçün)
COPY Edufy.API/Edufy.API.csproj Edufy.API/
COPY Edufy.Application/Edufy.Application.csproj Edufy.Application/
COPY Edufy.Domain/Edufy.Domain.csproj Edufy.Domain/
COPY Edufy.Repository/Edufy.Repository.csproj Edufy.Repository/
COPY Edufy.SqlServer/Edufy.SqlServer.csproj Edufy.SqlServer/

RUN dotnet restore Edufy.API/Edufy.API.csproj

# qalan source kodu kopyala
COPY . .

RUN dotnet publish Edufy.API/Edufy.API.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Edufy.API.dll"]