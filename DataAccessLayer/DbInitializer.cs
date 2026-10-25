namespace DataAccessLayer
{
    /// <summary>
    /// Гарантирует, что база и таблицы существуют.
    /// Используется сценарием Dapper: перед работой просим EF создать схему
    /// (если она уже есть — ничего не произойдёт).
    /// </summary>
    public static class DbInitializer
    {
        private static bool initialized;

        /// <summary>
        /// Создаёт базу и таблицы, если их ещё нет.
        /// </summary>
        public static void EnsureCreated()
        {
            if (initialized) return;

            using (var db = new DBContext())
            {
                db.Database.Initialize(force: false);
            }
            initialized = true;
        }
    }
}
