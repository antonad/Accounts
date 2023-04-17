# Accounts

Test task was implemented using .net 7, web api, EF.


Initial task:

Используя .Net, СУБД MY SQL необходимо реализовать API поддерживающее следующий функционал:
1. Хранение информации о сотрудниках и их должностях. В предметной области применяются следующие сущности:
Сотрудник: ФИО, дата рождения
Должность: Название, Грейд (числовое значение от 1 до 15)
Сотрудники и должности связаны отношением многие-ко-многим
2. REST JSON API поддерживающие следующие методы:
Получение информации о сотруднике и всех его должностях
Сохранение (добавление нового и изменение существующего) информации о сотруднике и его должностях
Удаление сотрудника
Получение информации по должности
Сохранение (добавление новой и изменение существующей) информации о должности
Удаление должности (удаление должностей к которым привязаны сотрудники должно быть заблокировано)
API должно поддерживать Swagger или логирование (предпочтительнее Swagger)