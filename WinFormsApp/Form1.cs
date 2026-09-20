using AppLogic;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp
{
    /// <summary>
    /// Главная форма приложения для управления устройствами IQOS.
    /// </summary>
    public partial class Form1 : Form
    {
        private ILogic logic = new Logic();
        private Iqos? selectedIqos = null;

        /// <summary>
        /// Инициализирует форму, загружает данные и обновляет таблицу.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            DefaultIqos();
            RefreshGrid();
        }

        /// <summary>
        /// Заполняет систему тестовыми устройствами IQOS.
        /// </summary>
        private void DefaultIqos()
        {
            logic.AddIqos(new Iqos { Model = "IQOS 3 DUO", Color = "Белый", Country = "Япония", Price = 7990m, SticksPerPack = 20 });
            logic.AddIqos(new Iqos { Model = "IQOS 3", Color = "Чёрный", Country = "Япония", Price = 5990m, SticksPerPack = 20 });
            logic.AddIqos(new Iqos { Model = "IQOS 2.4 Plus", Color = "Синий", Country = "Швейцария", Price = 3990m, SticksPerPack = 20 });
        }

        /// <summary>
        /// Обновляет таблицу данных на форме.
        /// </summary>
        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = logic.GetAllIqos();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Columns["Id"] != null)
                dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.ReadOnly = true;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        /// <summary>
        /// Добавляет новое устройство по данным формы.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxCode.Text) ||
                string.IsNullOrWhiteSpace(textBoxCountry.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            if (!decimal.TryParse(textBoxRate.Text, out decimal price))
            {
                MessageBox.Show("Цена должна быть числом!", "Ошибка");
                return;
            }

            if (!int.TryParse(textBoxSticks.Text, out int sticks))
            {
                MessageBox.Show("Количество стиков должно быть целым числом!", "Ошибка");
                return;
            }

            logic.AddIqos(new Iqos
            {
                Model = textBoxName.Text,
                Color = textBoxCode.Text,
                Country = textBoxCountry.Text,
                Price = price,
                SticksPerPack = sticks
            });

            RefreshGrid();
            ClearFields();
        }

        /// <summary>
        /// Очищает поля формы.
        /// </summary>
        private void ClearFields()
        {
            textBoxName.Text = textBoxCode.Text = textBoxCountry.Text = textBoxRate.Text = textBoxSticks.Text = "";
            selectedIqos = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                selectedIqos = (Iqos?)dataGridView1.CurrentRow.DataBoundItem;
                if (selectedIqos != null)
                {
                    textBoxName.Text = selectedIqos.Model;
                    textBoxCode.Text = selectedIqos.Color;
                    textBoxCountry.Text = selectedIqos.Country;
                    textBoxRate.Text = selectedIqos.Price.ToString();
                    textBoxSticks.Text = selectedIqos.SticksPerPack.ToString();
                }
            }
        }

        /// <summary>
        /// Обновляет выбранное устройство.
        /// </summary>
        private void UpdateCurrency_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxRate.Text, out decimal price))
            {
                MessageBox.Show("Цена должна быть числом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedIqos == null) return;

            int? sticks = null;
            if (int.TryParse(textBoxSticks.Text, out int s)) sticks = s;

            var updated = new UpdateIqosDTO
            {
                Model = string.IsNullOrWhiteSpace(textBoxName.Text) ? null : textBoxName.Text,
                Color = string.IsNullOrWhiteSpace(textBoxCode.Text) ? null : textBoxCode.Text,
                Country = string.IsNullOrWhiteSpace(textBoxCountry.Text) ? null : textBoxCountry.Text,
                Price = price,
                SticksPerPack = sticks
            };
            logic.UpdateIqosById(selectedIqos.Id, updated);
            RefreshGrid();
            ClearFields();
        }

        /// <summary>
        /// Удаляет выбранное устройство.
        /// </summary>
        private void DeleteCurrency_Click(object sender, EventArgs e)
        {
            if (selectedIqos == null) return;

            logic.DeleteIqosById(selectedIqos.Id);
            RefreshGrid();
            ClearFields();
        }

        /// <summary>
        /// Открывает форму 2 с бизнес-функциями.
        /// </summary>
        private void buttonForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(logic);
            form2.Show();
        }
    }
}