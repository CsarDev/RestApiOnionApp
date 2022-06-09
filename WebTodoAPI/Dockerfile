#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebTodoAPI/WebTodoAPI.csproj", "WebTodoAPI/"]
COPY ["Persistencia/Persistence.csproj", "Persistencia/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Services.Abstractions/Services.Abstractions.csproj", "Services.Abstractions/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]
RUN dotnet restore "WebTodoAPI/WebTodoAPI.csproj"
COPY . .
WORKDIR "/src/WebTodoAPI"
RUN dotnet build "WebTodoAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebTodoAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebTodoAPI.dll"]