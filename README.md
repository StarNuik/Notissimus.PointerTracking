
[ADR](./ADRs%20(Architecture%20Decision%20Records).md)

## Структура
`PointerTracking.Api` - Апи сервер, ручки без логики
`PointerTracking.Domain` - бизнес логика, сущности, дб интерфейс
`PointerTracking.Infrastructure` - реализация дб, свагер
`PointerTracking.Migrations` - хранилка миграций от `dotnet ef`
`Tests.*` - тесты

## Запуск
```bash
git clone git@github.com:StarNuik/Notissimus.PointerTracking.git
cd Notissimus.PointerTracking
(sudo) docker compose -f ./prod.compose.yaml up
cd Notissimus.PointerTracking.Migrations/
dotnet ef database update
# В браузере подключиться к "http://localhost"
# Данные в таблице можно получить по "http://localhost/api/pointer-tracking"
```

## ТЗ
Написать одностраничный сайт на ASP.NET Core
    с одной кнопкой "Отправить данные".
Добавить на странице js код,
    который собирает координаты движения мышки при ее движении
    в формате [X,Y,T],
    где X,Y - координаты, T - время события.
При нажатии по кнопке "Отправить данные"
    массив координат движения мышки, сохраненный ранее,
    должен отправляться на бекенд
    и сохраняться через Entity в таблицу произвольной базы данных
    в формате json.
Написать unit test к методу.
Предпочтение будет отдаваться решениям с использованием Clean Architecture.

