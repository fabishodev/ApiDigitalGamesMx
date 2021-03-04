FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiDigitalGamesMx/ApiDigitalGamesMx.csproj", "./"]
RUN dotnet restore "ApiDigitalGamesMx/ApiDigitalGamesMx.csproj"
COPY ["ApiProducts.Library/ApiProducts.Library.csproj", "./"]
RUN dotnet restore "ApiProducts.Library/ApiProducts.Library.csproj"
COPY . .

RUN dotnet build "ApiDigitalGamesMx/ApiDigitalGamesMx.csproj" -c Release -o /app/build
RUN dotnet build "ApiProducts.Library/ApiProducts.Library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiDigitalGamesMx/ApiDigitalGamesMx.csproj" -c Release -o /app/publish
RUN dotnet publish "ApiProducts.Library/ApiProducts.Library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiDigitalGamesMx.dll"]
