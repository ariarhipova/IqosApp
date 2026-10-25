using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Контекст Entity Framework (сценарий EF).
    /// Описывает, какие сущности хранятся в БД. Таблицы EF создаёт сам
    /// при первом обращении — если базы нет или она пустая.
    /// </summary>
    public class DBContext : DbContext
    {
        /// <summary>
        /// Создаёт контекст с подключением из <see cref="DbSettings"/>.
        /// </summary>
        public DBContext() : base(DbSettings.ConnectionString)
        {
        }

        /// <summary>
        /// Таблица устройств IQOS.
        /// </summary>
        public DbSet<Iqos> Iqos { get; set; } = null!;

        /// <summary>
        /// Настройка модели: таблица называется так же, как класс (Iqos),
        /// без автоматического множественного числа — по этому имени
        /// её находит DapperRepository.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
