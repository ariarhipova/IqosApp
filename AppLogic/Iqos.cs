using System;

namespace AppLogic
{
    /// <summary>
    /// Сущность, представляющая устройство IQOS.
    /// </summary>
    public class Iqos
    {
        /// <summary>
        /// Уникальный идентификатор устройства.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Модель устройства.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Цвет устройства.
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Страна-производитель.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Цена устройства в рублях.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество стиков в упаковке.
        /// </summary>
        public int SticksPerPack { get; set; }

        /// <summary>
        /// Возвращает строковое представление сущности.
        /// </summary>
        /// <returns>Строка с информацией об устройстве.</returns>
        public override string ToString()
        {
            return $"{Id}. {Model} ({Color}) - {Country}, цена: {Price} руб., стиков: {SticksPerPack}";
        }
    }
}