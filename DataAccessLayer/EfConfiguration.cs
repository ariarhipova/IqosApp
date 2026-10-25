using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Настройка Entity Framework в коде (вместо секции &lt;entityFramework&gt; в App.config).
    /// На .NET 8 это обязательный шаг: EF нужно явно сказать, что работаем с SQL Server.
    /// EF находит этот класс сам, потому что он лежит в одной сборке с DBContext.
    /// </summary>
    public class EfConfiguration : DbConfiguration
    {
        /// <summary>
        /// Регистрирует провайдер SQL Server.
        /// </summary>
        public EfConfiguration()
        {
            SetProviderFactory(SqlProviderServices.ProviderInvariantName, SqlClientFactory.Instance);
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
