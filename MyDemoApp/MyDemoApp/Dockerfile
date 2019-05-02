FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MyDemoApp/MyDemoApp.Web.csproj", "MyDemoApp/"]
RUN dotnet restore "MyDemoApp/MyDemoApp.Web.csproj"
COPY . .
WORKDIR "/src/MyDemoApp"
RUN dotnet build "MyDemoApp.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyDemoApp.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyDemoApp.Web.dll"]