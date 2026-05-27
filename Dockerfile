FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY DeliveryOrderApp.Web/DeliveryOrderApp.Web.csproj DeliveryOrderApp.Web/
RUN dotnet restore DeliveryOrderApp.Web/DeliveryOrderApp.Web.csproj

COPY . .
WORKDIR /src/DeliveryOrderApp.Web
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 8080

CMD ["dotnet", "DeliveryOrderApp.Web.dll"]