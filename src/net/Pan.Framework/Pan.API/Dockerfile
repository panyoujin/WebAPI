FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Pan.API/Pan.API.csproj", "Pan.API/"]
RUN dotnet restore "Pan.API/Pan.API.csproj"
COPY . .
WORKDIR "/src/Pan.API"
RUN dotnet build "Pan.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pan.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pan.API.dll"]