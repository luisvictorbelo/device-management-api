FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "DeviceManager.Api/DeviceManager.Api.csproj"
RUN dotnet publish "DeviceManager.Api/DeviceManager.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DeviceManager.Api.dll"]
