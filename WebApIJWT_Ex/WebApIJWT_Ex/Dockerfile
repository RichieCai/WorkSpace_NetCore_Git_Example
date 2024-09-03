#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApIJWT_Ex/WebApIJWT_Ex.csproj", "WebApIJWT_Ex/"]
RUN dotnet restore "WebApIJWT_Ex/WebApIJWT_Ex.csproj"
COPY . .
WORKDIR "/src/WebApIJWT_Ex"
RUN dotnet build "WebApIJWT_Ex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApIJWT_Ex.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApIJWT_Ex.dll"]