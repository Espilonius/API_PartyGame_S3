#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameService_S3_Individueel/GameService_S3_Individueel.csproj", "GameService_S3_Individueel/"]
RUN dotnet restore "GameService_S3_Individueel/GameService_S3_Individueel.csproj"
COPY . .
WORKDIR "/src/GameService_S3_Individueel"
RUN dotnet build "GameService_S3_Individueel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameService_S3_Individueel.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameService_S3_Individueel.dll"]