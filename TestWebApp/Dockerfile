﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestWebApp/TestWebApp.csproj", "TestWebApp/"]
RUN dotnet restore "TestWebApp/TestWebApp.csproj"
COPY . .
WORKDIR "/src/TestWebApp"
RUN dotnet build "TestWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebApp.dll"]
