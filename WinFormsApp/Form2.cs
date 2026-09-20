using System;
using System.Windows.Forms;
using AppLogic;

namespace WinFormsApp
{
    /// <summary>
    /// Форма с бизнес-функциями: самое дорогое, самое дешёвое, группировка.
    /// </summary>
    public partial class Form2 : Form
    {
        private ILogic logic;

        /// <summary>
        /// Конструктор формы с бизнес-функциями.
        /// </summary>
        /// <param name="logic">Ссылка на бизнес-логику.</param>
        public Form2(ILogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        /// <summary>
        /// Показывает самое дорогое устройство.
        /// </summary>
        private void buttonMostExpensive_Click(object sender, EventArgs e)
        {
            var iqos = logic.GetMostExpensiveIqos();
            MessageBox.Show(iqos == null ? "Список пуст." : iqos.ToString(),
                "Самое дорогое устройство");
        }

        /// <summary>
        /// Показывает самое дешёвое устройство.
        /// </summary>
        private void buttonCheapest_Click(object sender, EventArgs e)
        {
            var iqos = logic.GetCheapestIqos();
            MessageBox.Show(iqos == null ? "Список пуст." : iqos.ToString(),
                "Самое дешёвое устройство");
        }

        /// <summary>
        /// Отображает группировку устройств по стране.
        /// </summary>
        private void buttonGroup_Click(object sender, EventArgs e)
        {
            var groups = logic.GroupByCountry();
            listBoxGroups.Items.Clear();
            foreach (var g in groups)
            {
                listBoxGroups.Items.Add($"Страна: {g.Key}");
                foreach (var item in g.Value)
                    listBoxGroups.Items.Add($"   {item}");
            }
        }
    }
}