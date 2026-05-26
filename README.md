# DeliveryOrderApp — Тестовое задание Junior C# .NET Developer

Веб-приложение для приёмки заказов на доставку грузов.

## Функционал

- Создание заказа (город/адрес отправителя и получателя, вес, дата забора)
- Просмотр списка всех заказов с автоматически сгенерированным GUID
- Детальный просмотр заказа в режиме чтения

## Технологии

- ASP.NET Core 9 (MVC)
- Entity Framework Core 9
- PostgreSQL 16
- Bootstrap 5
- Docker / Docker Compose

## Быстрый запуск (Docker)

### Предварительные требования

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

### Запуск одной командой

```bash
docker compose up -d