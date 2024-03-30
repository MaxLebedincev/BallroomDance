# BallroomDance.API

> Бальные танцы интерфейс серверной части

Включает в себя:

- Controllers - точки входа
	- Interaction - объекты взаимодействия с точками входа
- DAL - слой доступа к данным
	- Configurations - конфигурация сущностей таблиц
	- Interfaces 	 - интерфейсы сущностей DAL
	- Repositories 	 - представление таблиц в виде сущностей
	- ApplicationDbContext - контекст приложения
	- UnitOfWork - единица работы (выполняет все операции с бд)
- Domain - домен
	- Entity - сущности таблиц
- Migrations - миграции бд
	- AllSelect  - все select
	- databaseMS - бэкап БД
	- FillData   - заполнение данных
- Service - сервисы
	- Registeration    - регистрация сервисов
	- ExceptionHandler - обработчик ошибок
- Tools - инструменты
	- Security - безопасности
- appsettings 	  - конфигурация приложения
- Scheme_DataBase - схема БД