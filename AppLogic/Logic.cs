using System;
using System.Collections.Generic;
using System.Linq;

namespace AppLogic
{
    /// <summary>
    /// Реализация бизнес-логики для работы с устройствами IQOS.
    /// </summary>
    public class Logic : ILogic
    {
        private List<Iqos> iqosList = new List<Iqos>();
        private int nextId = 0;

        /// <summary>
        /// Добавляет новое устройство в список.
        /// </summary>
        /// <param name="iqos">Устройство для добавления.</param>
        /// <exception cref="ArgumentNullException">Если iqos == null.</exception>
        /// <exception cref="ArgumentException">Если устройство с такой моделью уже существует.</exception>
        public void AddIqos(Iqos iqos)
        {
            if (iqos == null)
                throw new ArgumentNullException(nameof(iqos));

            if (IqosExists(iqos.Model))
                throw new ArgumentException($"Устройство с моделью {iqos.Model} уже существует");

            iqos.Id = nextId++;
            iqosList.Add(iqos);
        }

        /// <summary>
        /// Проверяет существование устройства с указанной моделью.
        /// </summary>
        /// <param name="model">Модель устройства.</param>
        /// <returns>True, если устройство существует; иначе False.</returns>
        public bool IqosExists(string model)
        {
            return iqosList.Any(i => i.Model == model);
        }

        /// <summary>
        /// Возвращает список всех устройств.
        /// </summary>
        /// <returns>Список всех устройств.</returns>
        public List<Iqos> GetAllIqos()
        {
            return iqosList.ToList();
        }

        /// <summary>
        /// Возвращает устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>Найденное устройство или null.</returns>
        public Iqos? GetIqosById(int id)
        {
            return iqosList.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Обновляет данные устройства по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <param name="updatedIqos">DTO с новыми значениями.</param>
        /// <returns>True, если обновление успешно; иначе False.</returns>
        public bool UpdateIqosById(int id, UpdateIqosDTO updatedIqos)
        {
            var iqos = iqosList.FirstOrDefault(i => i.Id == id);
            if (iqos == null) return false;

            iqos.Model = updatedIqos.Model ?? iqos.Model;
            iqos.Color = updatedIqos.Color ?? iqos.Color;
            iqos.Country = updatedIqos.Country ?? iqos.Country;
            iqos.Price = updatedIqos.Price ?? iqos.Price;
            iqos.SticksPerPack = updatedIqos.SticksPerPack ?? iqos.SticksPerPack;
            return true;
        }

        /// <summary>
        /// Удаляет устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>True, если удаление успешно; иначе False.</returns>
        public bool DeleteIqosById(int id)
        {
            var iqos = iqosList.FirstOrDefault(i => i.Id == id);
            if (iqos == null) return false;

            iqosList.Remove(iqos);
            return true;
        }

        /// <summary>
        /// Возвращает самое дорогое устройство.
        /// </summary>
        /// <returns>Самое дорогое устройство или null.</returns>
        public Iqos? GetMostExpensiveIqos()
        {
            return iqosList.OrderByDescending(i => i.Price).FirstOrDefault();
        }

        /// <summary>
        /// Возвращает самое дешёвое устройство.
        /// </summary>
        /// <returns>Самое дешёвое устройство или null.</returns>
        public Iqos? GetCheapestIqos()
        {
            return iqosList.OrderBy(i => i.Price).FirstOrDefault();
        }

        /// <summary>
        /// Группирует устройства по стране-производителю.
        /// </summary>
        /// <returns>Словарь: страна → список устройств.</returns>
        public Dictionary<string, List<Iqos>> GroupByCountry()
        {
            return iqosList
                .GroupBy(i => i.Country)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}