# Usa imagem oficial do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ToDoApi.csproj", "./"]
RUN dotnet restore "./ToDoApi.csproj"
COPY . .
RUN dotnet build "ToDoApi.csproj" -c Release -o /app/build
RUN dotnet publish "ToDoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Configura o container para escutar na porta 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ToDoApi.dll"]