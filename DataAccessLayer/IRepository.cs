using System.Collections.Generic;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий: основные CRUD-операции над хранилищем доменных объектов.
    /// Бизнес-логика работает только с этим интерфейсом и не знает,
    /// что под ним — Entity Framework или Dapper.
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта.</typeparam>
    public interface IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Добавляет объект в хранилище. После вызова у объекта заполнен Id из БД.
        /// </summary>
        /// <param name="entity">Добавляемый объект.</param>
        void Add(T entity);

        /// <summary>
        /// Удаляет объект по идентификатору. Если объекта нет — ничего не происходит.
        /// </summary>
        /// <param name="id">Идентификатор объекта.</param>
        void Delete(int id);

        /// <summary>
        /// Возвращает все объекты.
        /// </summary>
        /// <returns>Список всех объектов.</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Возвращает объект по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор объекта.</param>
        /// <returns>Найденный объект или null.</returns>
        T? ReadById(int id);

        /// <summary>
        /// Сохраняет изменения объекта (запись ищется по Id).
        /// </summary>
        /// <param name="entity">Изменённый объект.</param>
        void Update(T entity);
    }
}
