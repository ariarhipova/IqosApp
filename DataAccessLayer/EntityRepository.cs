using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий на Entity Framework (сценарий EF).
    /// На каждую операцию создаётся свой короткоживущий DBContext —
    /// так данные всегда свежие и не копятся отслеживаемые объекты.
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        /// <inheritdoc />
        public void Add(T entity)
        {
            using (var db = new DBContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges(); // после сохранения EF сам проставит entity.Id
            }
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            using (var db = new DBContext())
            {
                var entity = db.Set<T>().Find(id);
                if (entity == null) return;

                db.Set<T>().Remove(entity);
                db.SaveChanges();
            }
        }

        /// <inheritdoc />
        public IEnumerable<T> ReadAll()
        {
            using (var db = new DBContext())
            {
                // ToList() обязателен: после Dispose контекста запрос уже не выполнить
                return db.Set<T>().AsNoTracking().ToList();
            }
        }

        /// <inheritdoc />
        public T? ReadById(int id)
        {
            using (var db = new DBContext())
            {
                return db.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == id);
            }
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            using (var db = new DBContext())
            {
                db.Set<T>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
