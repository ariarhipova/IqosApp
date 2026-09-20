using System.Collections.Generic;

namespace AppLogic
{
    /// <summary>
    /// Интерфейс бизнес-логики для работы с устройствами IQOS.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Добавляет новое устройство в список.
        /// </summary>
        /// <param name="iqos">Устройство для добавления. Id назначается автоматически.</param>
        /// <exception cref="System.ArgumentException">Если устройство с такой моделью уже существует.</exception>
        void AddIqos(Iqos iqos);

        /// <summary>
        /// Возвращает список всех устройств.
        /// </summary>
        /// <returns>Список всех добавленных устройств.</returns>
        List<Iqos> GetAllIqos();

        /// <summary>
        /// Возвращает устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>Найденное устройство либо null, если не найдено.</returns>
        Iqos? GetIqosById(int id);

        /// <summary>
        /// Обновляет данные устройства по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <param name="updatedIqos">DTO с новыми значениями.</param>
        /// <returns>True, если обновление успешно; иначе False.</returns>
        bool UpdateIqosById(int id, UpdateIqosDTO updatedIqos);

        /// <summary>
        /// Удаляет устройство по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор устройства.</param>
        /// <returns>True, если удаление успешно; иначе False.</returns>
        bool DeleteIqosById(int id);

        /// <summary>
        /// Проверяет существование устройства с указанной моделью.
        /// </summary>
        /// <param name="model">Модель устройства.</param>
        /// <returns>True, если устройство существует; иначе False.</returns>
        bool IqosExists(string model);

        /// <summary>
        /// Возвращает самое дорогое устройство.
        /// </summary>
        /// <returns>Самое дорогое устройство или null, если список пуст.</returns>
        Iqos? GetMostExpensiveIqos();

        /// <summary>
        /// Возвращает самое дешёвое устройство.
        /// </summary>
        /// <returns>Самое дешёвое устройство или null, если список пуст.</returns>
        Iqos? GetCheapestIqos();

        /// <summary>
        /// Группирует устройства по стране-производителю.
        /// </summary>
        /// <returns>Словарь: страна → список устройств.</returns>
        Dictionary<string, List<Iqos>> GroupByCountry();
    }
}