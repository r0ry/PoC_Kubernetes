FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["VaultTestClient/VaultTestClient.csproj", "VaultTestClient/"]
RUN dotnet restore "VaultTestClient/VaultTestClient.csproj"
COPY . .
WORKDIR "/src/VaultTestClient"
RUN dotnet build "VaultTestClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VaultTestClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VaultTestClient.dll"]