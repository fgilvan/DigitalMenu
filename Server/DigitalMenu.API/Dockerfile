FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5235

ENV ASPNETCORE_URLS=http://+:5235

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Server/DigitalMenu/DigitalMenu.csproj", "Server/DigitalMenu/DigitalMenu/"]
RUN dotnet restore "Server\DigitalMenu\DigitalMenu.csproj"
COPY . .
WORKDIR "/src/Server/DigitalMenu"
RUN dotnet build "DigitalMenu.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "DigitalMenu.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DigitalMenu.dll"]
