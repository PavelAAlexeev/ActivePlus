1. Как запустить:
перейти в папку ActivePlus/Mvc
затем в консоле:
dotnet run
Или из Visual Studio, я запускал из VS Code
Для работы необходим какой-то сервер, у меня Kestrel, запустилось без каких-либо танцев
При запуске сервер висит на:
https://localhost:5001
http://localhost:5000
Имеется "технический" фронтенд: Swagger, в нем видно ендпоинты и параметеры:
http://localhost:5000/swagger/index.html
https://localhost:5001/swagger/index.html
Очень удобно, можно вводить параметры и видеть результат
Можно так же воспользоваться Postman например

2. Тесты: 
перейти в папку ActivePlus/Mvc/ServiceTests
и затем в консли
dotnet test

3. О задачах
3.1 Задача " Реализовать веб-приложение с использованием C# , которое предоставит функционал сложения каждого второго нечетного числа из массива чисел тела запроса и вернёт их сумму по модулю."
Тут не очень понятно, что значит по модулю? По модулю 2, то есть XOR? Или просто слодить модули чисел? Я сложил модули, думаю это не принципально.
URL вида
https://localhost:5001/api/ActivePlus/Task1?array=1&array=2&array=3&array=4&array=5&array=6&array=7&array=8&array=9 
Вернет 8. 

3.2 Задача " Реализовать веб-приложение с использованием C# , которое предоставит функционал
сложение двух непустых связанных списков, представляющих два неотрицательных целых и больших нуля числа. Цифры хранятся в обратном порядке, и каждый из их узлов содержит одну цифру. Сложите два числа и верните их в виде связанного списка.
 "
 Забавный момент, вчер читал книгу Карьера программиста. 6-е издание Лакман Макдауэлл Г. Не для прохождения тестирования,  для проведения как интервьюэр. Страница 86 задача 2.5 

 URL вида
"https://localhost:5001/api/ActivePlus/Task2?array1=9&array1=9&array2=9"
Вернет 
[
  1,
  0,
  8
]
Тут опять же не очень ясно, что такое обратый порядок. [  1,  0,  8] - это обратный порядок? В нулевом елементе сотни, в первом десятки и и. д. Если надо наоборот, то несколько строчк кода поменять, могу рассказать словами, если интересно.

3.3. "Реализовать веб-приложение с использованием C# ,которое предоставит функционал  
определения входящий строки является ли она палиндромом ."
Задача вообще ни разу не тривиальная. Пробелы и прочие знаки, UTF16 симоволы, состояшие из 4 или 6 слов, регистры. Пришлось покопаться, решение "сравнить массив в прямом и обратном направлении" верно только для очень огранниченного круха входных строк.

URL вида 
https://localhost:5001/api/ActivePlus/Task3?phrase=%D0%90%20%D1%80%D0%BE%D0%B7%D0%B0%20%D1%83%D0%BF%D0%B0%D0%BB%D0%B0%20%D0%BD%D0%B0%20%D0%BB%D0%B0%D0%BF%D1%83%20%D0%90%D0%B7%D0%BE%D1%80%D0%B0
(тут "А роза упала на рапу Азора")
Пример с символом ударения в тестах.

Поднимать в Azure Cloud пока не стал, может вечером в качетсве развлечения, там вроде примерно 10 минут.

