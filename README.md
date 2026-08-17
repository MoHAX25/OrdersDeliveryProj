# OrdersDeliveryProj

Веб-приложение на ASP.NET Core MVC (.NET 9) для оформления и учёта заказов на доставку: создание заказа (город/адрес отправителя и получателя, вес, дата забора), просмотр списка заказов и детальной информации по заказу. Данные хранятся в базе SQLite (Entity Framework Core), которая создаётся автоматически при первом запуске.

## Технологии

- .NET 9.0 / ASP.NET Core MVC
- Entity Framework Core 9.0 + SQLite (`OrdersDelivery.db`)

## Требования

- Установленный [.NET SDK 9.0](https://dotnet.microsoft.com/download) или новее

## Запуск проекта

1. Склонировать репозиторий:
   ```bash
   git clone https://github.com/MoHAX25/OrdersDeliveryProj.git
   cd OrdersDeliveryProj
   ```
2. Перейти в папку с проектом:
   ```bash
   cd OrdersDeliveryProj
   ```
3. Восстановить зависимости:
   ```bash
   dotnet restore
   ```
4. Запустить приложение:
   ```bash
   dotnet run
   ```
   При старте база данных SQLite (`OrdersDelivery.db`) создаётся автоматически, если её ещё нет — выполнять миграции вручную не требуется.

5. Открыть приложение в браузере по одному из адресов (см. `Properties/launchSettings.json`):
   - http://localhost:5101
   - https://localhost:7026

## Основные разделы

- `/Orders/Create` — создание нового заказа
- `/Orders/List` — список всех заказов
- `/Orders/Details/{id}` — детали конкретного заказа
