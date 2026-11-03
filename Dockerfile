FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["WikiSumBackend/WikiSumBackend.API.csproj", "WikiSumBackend/"]
COPY ["WikiSumBackend.Application/WikiSumBackend.Application.csproj", "WikiSumBackend.Application/"]
COPY ["WikiSumBackend.Contracts/WikiSumBackend.Contracts.csproj", "WikiSumBackend.Contracts/"]
COPY ["WikiSumBackend.Domain/WikiSumBackend.Domain.csproj", "WikiSumBackend.Domain/"]
COPY ["WikiSumBackend.Infrastructure/WikiSumBackend.Infrastructure.csproj", "WikiSumBackend.Infrastructure/"]

RUN dotnet restore "WikiSumBackend/WikiSumBackend.API.csproj"

COPY . .

# Opnieuw restore uitvoeren voor alle projecten
RUN dotnet restore "WikiSumBackend/WikiSumBackend.API.csproj"

# EF Core CLI installeren
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /src/WikiSumBackend

# API publiceren
RUN dotnet publish "WikiSumBackend.API.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:7022

EXPOSE 7022

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WikiSumBackend.API.dll"]
