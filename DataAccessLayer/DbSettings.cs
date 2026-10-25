namespace DataAccessLayer
{
    /// <summary>
    /// Строка подключения к БД — одна на оба сценария (EF и Dapper).
    /// По умолчанию используется LocalDB: база IqosDB создастся сама при первом запуске.
    /// Чтобы работать с файлом Database1.mdf, как в методичке, замените строку на ту,
    /// что показана в окне «Свойства» → «Строка подключения», например:
    /// Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\...\Database1.mdf;Integrated Security=True
    /// </summary>
    public static class DbSettings
    {
        /// <summary>
        /// Строка подключения к БД.
        /// </summary>
        public static string ConnectionString { get; set; } =
            @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=IqosDB;Integrated Security=True";
    }
}
