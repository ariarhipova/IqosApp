using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Dapper;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий на Dapper (сценарий Dapper).
    /// SQL-запросы пишутся вручную, Dapper подставляет параметры
    /// и раскладывает строки результата по свойствам объекта.
    /// Имя таблицы = имя класса (Iqos), столбцы = свойства класса.
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly string connectionString;
        private readonly string table;
        private readonly string[] columns; // хранимые свойства, кроме Id

        /// <summary>
        /// Создаёт репозиторий с подключением из <see cref="DbSettings"/>.
        /// </summary>
        public DapperRepository() : this(DbSettings.ConnectionString)
        {
        }

        /// <summary>
        /// Создаёт репозиторий с указанной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к SQL Server.</param>
        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
            table = $"[dbo].[{typeof(T).Name}]";
            columns = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite)
                .Where(p => p.Name != nameof(IDomainObject.Id))
                .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null)
                .Where(p => IsSimpleType(p.PropertyType))
                .Select(p => p.Name)
                .ToArray();

            // Dapper сам таблицы не создаёт — если их ещё нет, их создаст EF
            DbInitializer.EnsureCreated();
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <inheritdoc />
        public void Add(T entity)
        {
            var columnList = string.Join(", ", columns.Select(c => $"[{c}]"));
            var valueList = string.Join(", ", columns.Select(c => $"@{c}"));
            var sql = $"INSERT INTO {table} ({columnList}) OUTPUT INSERTED.[Id] VALUES ({valueList})";

            using (var connection = CreateConnection())
            {
                entity.Id = connection.ExecuteScalar<int>(sql, entity);
            }
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            var sql = $"DELETE FROM {table} WHERE [Id] = @Id";

            using (var connection = CreateConnection())
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        /// <inheritdoc />
        public IEnumerable<T> ReadAll()
        {
            var sql = $"SELECT * FROM {table}";

            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql).ToList();
            }
        }

        /// <inheritdoc />
        public T? ReadById(int id)
        {
            var sql = $"SELECT * FROM {table} WHERE [Id] = @Id";

            using (var connection = CreateConnection())
            {
                return connection.QuerySingleOrDefault<T>(sql, new { Id = id });
            }
        }

        /// <inheritdoc />
        public void Update(T entity)
        {
            var setList = string.Join(", ", columns.Select(c => $"[{c}] = @{c}"));
            var sql = $"UPDATE {table} SET {setList} WHERE [Id] = @Id";

            using (var connection = CreateConnection())
            {
                connection.Execute(sql, entity);
            }
        }

        /// <summary>
        /// Хранится ли свойство такого типа в отдельном столбце таблицы
        /// (навигационные свойства и коллекции пропускаются).
        /// </summary>
        private static bool IsSimpleType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            return type.IsPrimitive
                   || type.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal)
                   || type == typeof(DateTime)
                   || type == typeof(DateTimeOffset)
                   || type == typeof(TimeSpan)
                   || type == typeof(Guid)
                   || type == typeof(byte[]);
        }
    }
}
