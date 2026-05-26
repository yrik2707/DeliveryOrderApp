# DeliveryOrderApp — Тестовое задание Junior C# .NET Developer

Веб-приложение для приёмки заказов на доставку грузов.

## Функционал
- Создание заказа (город/адрес отправителя и получателя, вес, дата забора)
- Просмотр списка всех заказов с автоматически сгенерированным GUID
- Детальный просмотр заказа в режиме чтения

## Технологии
- ASP.NET Core 9 (MVC)
- Entity Framework Core 9
- PostgreSQL
- Bootstrap 5

## Запуск проекта

### Предварительные требования
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/)

### Настройка
1. Создайте базу данных `DeliveryOrders` в PostgreSQL:
   ```sql
   CREATE DATABASE "DeliveryOrders";