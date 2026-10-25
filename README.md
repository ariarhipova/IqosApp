# IqosApp Ч лабы 1Ц2

ћногоуровнева€ архитектура. —ущность Ч IQOS.

## —труктура
- **Model** Ч сущность Iqos и интерфейс IDomainObject
- **DataAccessLayer** Ч работа с Ѕƒ: IRepository, DBContext + EntityRepository (EF), DapperRepository (Dapper)
- **AppLogic** Ч бизнес-логика (вместо списка Ч репозиторий)
- **AppConsole** Ч консолька
- **WinFormsApp** Ч WinForms

## Ѕаза данных
- ѕо умолчанию LocalDB, база `IqosDB` создаЄтс€ сама при первом запуске.
- —трока подключени€: `DataAccessLayer/DbSettings.cs`.
- —ценарий (EF или Dapper) переключаетс€ одной строкой в конструкторе `Logic()`.

## «апуск
-  онсоль: `AppConsole` 
- WinForms: `WinFormsApp`
