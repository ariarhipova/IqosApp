using System;
using AppLogic;

namespace AppConsole
{
    class Program
    {
        static ILogic logic = new Logic();

        /// <summary>
        /// Точка входа в консольное приложение.
        /// </summary>
        static void Main(string[] args)
        {
            DefaultIqos();

            bool isRunning = true;
            while (isRunning)
            {
                PrintMenu();
                string choice = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                try
                {
                    switch (choice)
                    {
                        case "1": PrintAllIqos(); break;
                        case "2": AddIqosFromConsole(); break;
                        case "3": PrintIqosById(); break;
                        case "4": UpdateIqosFromConsole(); break;
                        case "5": DeleteIqosFromConsole(); break;
                        case "6": PrintMostExpensive(); break;
                        case "7": PrintCheapest(); break;
                        case "8": PrintGroupedByCountry(); break;
                        case "9": isRunning = false; break;
                        default: Console.WriteLine("Неверный пункт меню."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Заполняет систему тестовыми данными.
        /// </summary>
        static void DefaultIqos()
        {
            logic.AddIqos(new Iqos { Model = "IQOS 3 DUO", Color = "Белый", Country = "Япония", Price = 7990m, SticksPerPack = 20 });
            logic.AddIqos(new Iqos { Model = "IQOS 3", Color = "Чёрный", Country = "Япония", Price = 5990m, SticksPerPack = 20 });
            logic.AddIqos(new Iqos { Model = "IQOS 2.4 Plus", Color = "Синий", Country = "Швейцария", Price = 3990m, SticksPerPack = 20 });
        }

        /// <summary>
        /// Выводит главное меню приложения.
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("\n===== МЕНЮ =====");
            Console.WriteLine("1. Показать все устройства");
            Console.WriteLine("2. Добавить новое устройство");
            Console.WriteLine("3. Показать устройство по ID");
            Console.WriteLine("4. Изменить устройство по ID");
            Console.WriteLine("5. Удалить устройство по ID");
            Console.WriteLine("6. Показать самое дорогое устройство");
            Console.WriteLine("7. Показать самое дешёвое устройство");
            Console.WriteLine("8. Группировка по стране");
            Console.WriteLine("9. Выход");
            Console.Write("Выберите пункт меню: ");
        }

        /// <summary>
        /// Выводит все устройства.
        /// </summary>
        static void PrintAllIqos()
        {
            Console.WriteLine("\nВсе устройства:");
            foreach (var i in logic.GetAllIqos())
                Console.WriteLine(i);
        }

        /// <summary>
        /// Добавляет новое устройство через консоль.
        /// </summary>
        static void AddIqosFromConsole()
        {
            Console.Write("Модель: ");
            string model = Console.ReadLine() ?? "";
            Console.Write("Цвет: ");
            string color = Console.ReadLine() ?? "";
            Console.Write("Страна: ");
            string country = Console.ReadLine() ?? "";
            decimal price = ReadDecimal("Цена: ");
            int sticks = ReadInt("Стиков в упаковке: ");

            logic.AddIqos(new Iqos
            {
                Model = model,
                Color = color,
                Country = country,
                Price = price,
                SticksPerPack = sticks
            });
            Console.WriteLine("Устройство добавлено.");
        }

        /// <summary>
        /// Выводит устройство по ID.
        /// </summary>
        static void PrintIqosById()
        {
            int id = ReadInt("Введите ID: ");
            var iqos = logic.GetIqosById(id);
            if (iqos == null) { Console.WriteLine("Не найдено."); return; }
            Console.WriteLine(GetInfoIqos(iqos));
        }

        /// <summary>
        /// Изменяет устройство по ID.
        /// </summary>
        static void UpdateIqosFromConsole()
        {
            int id = ReadInt("Введите ID для изменения: ");
            var existing = logic.GetIqosById(id);
            if (existing == null) { Console.WriteLine("Не найдено."); return; }

            Console.Write($"Новая модель (текущая: {existing.Model}): ");
            string? model = Console.ReadLine();
            Console.Write($"Новый цвет (текущий: {existing.Color}): ");
            string? color = Console.ReadLine();
            Console.Write($"Новая страна (текущая: {existing.Country}): ");
            string? country = Console.ReadLine();

            decimal? price = null;
            Console.Write($"Новая цена (текущая: {existing.Price}): ");
            string? priceStr = Console.ReadLine();
            if (decimal.TryParse(priceStr, out var p)) price = p;

            int? sticks = null;
            Console.Write($"Новое кол-во стиков (текущее: {existing.SticksPerPack}): ");
            string? sticksStr = Console.ReadLine();
            if (int.TryParse(sticksStr, out var s)) sticks = s;

            logic.UpdateIqosById(id, new UpdateIqosDTO
            {
                Model = string.IsNullOrWhiteSpace(model) ? null : model,
                Color = string.IsNullOrWhiteSpace(color) ? null : color,
                Country = string.IsNullOrWhiteSpace(country) ? null : country,
                Price = price,
                SticksPerPack = sticks
            });
            Console.WriteLine("Обновлено.");
        }

        /// <summary>
        /// Удаляет устройство по ID.
        /// </summary>
        static void DeleteIqosFromConsole()
        {
            int id = ReadInt("Введите ID для удаления: ");
            Console.WriteLine(logic.DeleteIqosById(id) ? "Удалено." : "Не найдено.");
        }

        /// <summary>
        /// Показывает самое дорогое устройство.
        /// </summary>
        static void PrintMostExpensive()
        {
            var iqos = logic.GetMostExpensiveIqos();
            Console.WriteLine(iqos == null ? "Список пуст." : GetInfoIqos(iqos));
        }

        /// <summary>
        /// Показывает самое дешёвое устройство.
        /// </summary>
        static void PrintCheapest()
        {
            var iqos = logic.GetCheapestIqos();
            Console.WriteLine(iqos == null ? "Список пуст." : GetInfoIqos(iqos));
        }

        /// <summary>
        /// Группирует устройства по стране.
        /// </summary>
        static void PrintGroupedByCountry()
        {
            var groups = logic.GroupByCountry();
            foreach (var g in groups)
            {
                Console.WriteLine($"\nСтрана: {g.Key}");
                foreach (var i in g.Value)
                    Console.WriteLine($"  {i}");
            }
        }

        /// <summary>
        /// Формирует строку с информацией об устройстве.
        /// </summary>
        /// <param name="iqos">Устройство.</param>
        /// <returns>Строка с информацией.</returns>
        static string GetInfoIqos(Iqos iqos)
        {
            return $"Модель - {iqos.Model}\n" +
                   $"Цвет - {iqos.Color}\n" +
                   $"Страна - {iqos.Country}\n" +
                   $"Цена - {iqos.Price} руб.\n" +
                   $"Стиков в упаковке - {iqos.SticksPerPack}\n";
        }

        /// <summary>
        /// Считывает целое число с консоли.
        /// </summary>
        /// <param name="message">Приглашение к вводу.</param>
        /// <returns>Введённое целое число.</returns>
        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Некорректный ввод. Введите целое число.");
            }
        }

        /// <summary>
        /// Считывает decimal с консоли.
        /// </summary>
        /// <param name="message">Приглашение к вводу.</param>
        /// <returns>Введённое число.</returns>
        static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }
    }
}