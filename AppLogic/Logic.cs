using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace AppLogic
{
    /// <summary>
    /// Реализация бизнес-логики для работы с устройствами IQOS.
    /// Вместо списка в памяти данные хранятся в БД через репозиторий.
    /// </summary>
    public class Logic : ILogic
    {
        // Было (Практическая №1): private List<Iqos> iqosList = new List<Iqos>();
        private readonly IRepository<Iqos> repository;

        /// <summary>
        /// Создаёт бизнес-логику с репозиторием по умолчанию.
        /// Этот конструктор вызывают View (консоль и WinForms).
        /// Сценарий работы с БД выбирается здесь одной строкой.
        /// </summary>
        public Logic()
        {
           // repository = new EntityRepository<Iqos>();     // сценарий EF
            repository = new DapperRepository<Iqos>();   // сценарий Dapper
        }

        /// <summary>
        /// Создаёт бизнес-логику с переданным репозиторием.
        /// </summary>
        /// <param name="repository">Репозиторий устройств.</param>
        /// <exception cref="ArgumentNullException">Если repository == null.</exception>
        public Logic(IRepository<Iqos> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Добавляет новое устройство.
        /// </summary>
        /// <param name="iqos">Устройство для добавления. Id назначает БД.</param>
        /// <exception cref="ArgumentNullException">Если iqos == null.</exception>
        /// <exception cref="ArgumentException">Если устройство с такой моделью уже существует.</exception>
        public void AddIqos(Iqos iqos)
        {
            if (iqos == null)
                throw new ArgumentNullException(nameof(iqos));

            if (IqosExists(iqos.Model))
                throw new ArgumentException($"Устройство с моделью {iqos.Model} уже существует");

            repository.Add(iqos);
        }

        /// <summary>
        /// Проверяет существование устройства с указанной моделью.
        /// </summary>
        /// <param name="model">Модель устройства.</param>
        /// <returns>True, если устройство существует; иначе False.</returns>
        public bool IqosExists(string model)
        {
            return repository.ReadAll().Any(i => i.Model == model);
        }

        /// <summary>
        /// Возвращает список всех устройств.
        /// </summary>
        /// <returns>Список всех устройств.</returns>
        public List<Iqos> GetAllIqos()
        {
            return repository.ReadAll().ToList();
        }

        /// <summary>
        /// Возвращает устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>Найденное устройство или null.</returns>
        public Iqos? GetIqosById(int id)
        {
            return repository.ReadById(id);
        }

        /// <summary>
        /// Обновляет данные устройства по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <param name="updatedIqos">DTO с новыми значениями.</param>
        /// <returns>True, если обновление успешно; иначе False.</returns>
        public bool UpdateIqosById(int id, UpdateIqosDTO updatedIqos)
        {
            var iqos = repository.ReadById(id);
            if (iqos == null) return false;

            iqos.Model = updatedIqos.Model ?? iqos.Model;
            iqos.Color = updatedIqos.Color ?? iqos.Color;
            iqos.Country = updatedIqos.Country ?? iqos.Country;
            iqos.Price = updatedIqos.Price ?? iqos.Price;
            iqos.SticksPerPack = updatedIqos.SticksPerPack ?? iqos.SticksPerPack;

            repository.Update(iqos);
            return true;
        }

        /// <summary>
        /// Удаляет устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>True, если удаление успешно; иначе False.</returns>
        public bool DeleteIqosById(int id)
        {
            if (repository.ReadById(id) == null) return false;

            repository.Delete(id);
            return true;
        }

        /// <summary>
        /// Возвращает самое дорогое устройство.
        /// </summary>
        /// <returns>Самое дорогое устройство или null.</returns>
        public Iqos? GetMostExpensiveIqos()
        {
            return repository.ReadAll().OrderByDescending(i => i.Price).FirstOrDefault();
        }

        /// <summary>
        /// Возвращает самое дешёвое устройство.
        /// </summary>
        /// <returns>Самое дешёвое устройство или null.</returns>
        public Iqos? GetCheapestIqos()
        {
            return repository.ReadAll().OrderBy(i => i.Price).FirstOrDefault();
        }

        /// <summary>
        /// Группирует устройства по стране-производителю.
        /// </summary>
        /// <returns>Словарь: страна → список устройств.</returns>
        public Dictionary<string, List<Iqos>> GroupByCountry()
        {
            return repository.ReadAll()
                .GroupBy(i => i.Country)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
