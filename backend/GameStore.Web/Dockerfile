FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ARG version_arg="unspecified"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG version_arg

WORKDIR /src
COPY ["GameStore.Web/GameStore.Web.csproj", "GameStore.Web/"]
COPY ["GameStore.Models/GameStore.Models.csproj", "GameStore.Models/"]
COPY ["GameStore.Utils/GameStore.Utils.csproj", "GameStore.Utils/"]
COPY ["GameStore.BLL/GameStore.BLL.csproj", "GameStore.BLL/"]
COPY ["GameStore.BLL.Abstract/GameStore.BLL.Abstract.csproj", "GameStore.BLL.Abstract/"]
COPY ["GameStore.DAL/GameStore.DAL.csproj", "GameStore.DAL/"]
COPY ["GameStore.DAL.Abstract/GameStore.DAL.Abstract.csproj", "GameStore.DAL.Abstract/"]
RUN dotnet restore "GameStore.Web/GameStore.Web.csproj"
COPY . .
WORKDIR "/src/GameStore.Web"
RUN dotnet build "GameStore.Web.csproj" -c Release -o /app/build -p:SourceRevisionId="${version_arg}"

FROM build AS publish
ARG version_arg

RUN dotnet publish "GameStore.Web.csproj" -c Release -o /app/publish -p:SourceRevisionId="${version_arg}" -p:PublishReadyToRun=true

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

RUN addgroup --group gstore --system 
RUN adduser -u 10001  --group gstore --system
RUN mkdir -p /app/configs
RUN mkdir -p /app/secrets
RUN chown -R gstore:gstore /app
RUN chmod -R 777 /app

# Disable globalization
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://*:8080

USER 10001
ENTRYPOINT ["dotnet", "GameStore.Web.dll"]

