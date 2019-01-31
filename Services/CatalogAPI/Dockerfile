FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CatalogAPI.csproj", "CatalogAPI/"]
RUN dotnet restore "CatalogAPI/CatalogAPI.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "CatalogAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CatalogAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CatalogAPI.dll"]