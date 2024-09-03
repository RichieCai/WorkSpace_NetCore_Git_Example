#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitOfWorkPJEx_EF.csproj", "UnitOfWorkPJEx_EF/"]
#COPY ["UnitOfWorkPJEx_EF.csproj", "UnitOfWorkPJEx_EF/"]
RUN dotnet restore "UnitOfWorkPJEx_EF/UnitOfWorkPJEx_EF.csproj"


WORKDIR "/src/UnitOfWorkPJEx_EF"
COPY . .
RUN dotnet build "UnitOfWorkPJEx_EF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitOfWorkPJEx_EF.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitOfWorkPJEx_EF.dll"]




