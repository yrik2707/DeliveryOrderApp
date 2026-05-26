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


CMD ["sh", "-c", "until pg_isready -h postgres -p 5432 -U postgres; do echo 'Waiting for PostgreSQL...'; sleep 2; done; dotnet DeliveryOrderApp.Web.dll"]