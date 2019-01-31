FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OcelotGW.csproj", "OcelotGW/"]
RUN dotnet restore "OcelotGW/OcelotGW.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "OcelotGW.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OcelotGW.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OcelotGW.dll"]