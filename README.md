
[ADR](./ADRs%20(Architecture%20Decision%20Records).md)

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

