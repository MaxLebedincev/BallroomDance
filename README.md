# BallroomDance

> Бальные танцы

Проект включает в себя:

1. BallroomDance.API  - интерфейс для взаимодействия с сервером (C#)
2. BallroomDance.Test - тесты для проверки интерфейса (C#)
3. BallroomDance.Vue  - клиентская часть сайта (Vue 3)

> [!WARNING]
> Многие элементы приложения не подключены, но основа собирается и работает


### Запуск проекта

1. Склонировать проект.

2. Создать базу данных из бэкапа по пути.

```
BallroomDance.API/Migrations/databaseMS.bacpac
```

3. Провести инсталляцию компонентов для клиентской части по пути

```
BallroomDance\BallroomDance.Vue
```

4. Используя команду через терминал 

```
npm i
```

5. Запустить клиентскую часть.

```
npm run serve
```

6. Заполнить данные appsettings.json по пути

```
BallroomDance.API/appsettings.json
```

7. Запустить серверную часть (проект BallroomDance.API)
