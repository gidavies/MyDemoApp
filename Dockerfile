FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 443
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyDemoApp/MyDemoApp/MyDemoApp.Web.csproj", "MyDemoApp/MyDemoApp/"]
RUN dotnet restore "MyDemoApp/MyDemoApp/MyDemoApp.Web.csproj"
COPY . .
WORKDIR "/src/MyDemoApp/MyDemoApp"
RUN dotnet build "MyDemoApp.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyDemoApp.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyDemoApp.Web.dll"]
