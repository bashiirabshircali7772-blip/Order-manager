FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["ASPCRUDAssignment.csproj", "./"]
RUN dotnet restore "ASPCRUDAssignment.csproj"

COPY . .
RUN dotnet publish "ASPCRUDAssignment.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ASPCRUDAssignment.dll"]
