namespace AppLogic
{
    /// <summary>
    /// DTO для обновления сущности Iqos. Поля, равные null, не обновляются.
    /// </summary>
    public class UpdateIqosDTO
    {
        /// <summary>
        /// Новая модель (null — не менять).
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Новый цвет (null — не менять).
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Новая страна (null — не менять).
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Новая цена (null — не менять).
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Новое количество стиков (null — не менять).
        /// </summary>
        public int? SticksPerPack { get; set; }
    }
}