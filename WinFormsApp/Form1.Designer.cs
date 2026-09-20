namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            labelModel = new Label();
            labelColor = new Label();
            labelCountry = new Label();
            labelPrice = new Label();
            labelSticks = new Label();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            refresh = new Button();
            buttonForm2 = new Button();
            dataGridView1 = new DataGridView();
            textBoxName = new TextBox();
            textBoxCode = new TextBox();
            textBoxCountry = new TextBox();
            textBoxRate = new TextBox();
            textBoxSticks = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 492);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(12, 353);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(53, 15);
            labelModel.TabIndex = 1;
            labelModel.Text = "Модель:";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.Location = new Point(12, 377);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(36, 15);
            labelColor.TabIndex = 2;
            labelColor.Text = "Цвет:";
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new Point(12, 400);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(49, 15);
            labelCountry.TabIndex = 3;
            labelCountry.Text = "Страна:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(12, 423);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(38, 15);
            labelPrice.TabIndex = 4;
            labelPrice.Text = "Цена:";
            // 
            // labelSticks
            // 
            labelSticks.AutoSize = true;
            labelSticks.Location = new Point(12, 446);
            labelSticks.Name = "labelSticks";
            labelSticks.Size = new Size(49, 15);
            labelSticks.TabIndex = 5;
            labelSticks.Text = "Стиков:";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(93, 492);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 6;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += UpdateCurrency_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(174, 492);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += DeleteCurrency_Click;
            // 
            // refresh
            // 
            refresh.Location = new Point(255, 492);
            refresh.Name = "refresh";
            refresh.Size = new Size(75, 23);
            refresh.TabIndex = 8;
            refresh.Text = "Обновить";
            refresh.UseVisualStyleBackColor = true;
            refresh.Click += refresh_Click;
            // 
            // buttonForm2
            // 
            buttonForm2.Location = new Point(336, 492);
            buttonForm2.Name = "buttonForm2";
            buttonForm2.Size = new Size(75, 23);
            buttonForm2.TabIndex = 9;
            buttonForm2.Text = "Форма 2";
            buttonForm2.UseVisualStyleBackColor = true;
            buttonForm2.Click += buttonForm2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(764, 342);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(71, 350);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 12;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(71, 374);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(100, 23);
            textBoxCode.TabIndex = 13;
            // 
            // textBoxCountry
            // 
            textBoxCountry.Location = new Point(71, 397);
            textBoxCountry.Name = "textBoxCountry";
            textBoxCountry.Size = new Size(100, 23);
            textBoxCountry.TabIndex = 14;
            // 
            // textBoxRate
            // 
            textBoxRate.Location = new Point(71, 423);
            textBoxRate.Name = "textBoxRate";
            textBoxRate.Size = new Size(100, 23);
            textBoxRate.TabIndex = 15;
            // 
            // textBoxSticks
            // 
            textBoxSticks.Location = new Point(71, 446);
            textBoxSticks.Name = "textBoxSticks";
            textBoxSticks.Size = new Size(100, 23);
            textBoxSticks.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 534);
            Controls.Add(textBoxSticks);
            Controls.Add(textBoxRate);
            Controls.Add(textBoxCountry);
            Controls.Add(textBoxCode);
            Controls.Add(textBoxName);
            Controls.Add(buttonForm2);
            Controls.Add(refresh);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(labelSticks);
            Controls.Add(labelPrice);
            Controls.Add(labelCountry);
            Controls.Add(labelColor);
            Controls.Add(labelModel);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "IQOS CRUD";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label labelModel;
        private Label labelColor;
        private Label labelCountry;
        private Label labelPrice;
        private Label labelSticks;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button refresh;
        private Button buttonForm2;
        private DataGridView dataGridView1;
        private TextBox textBoxName;
        private TextBox textBoxCode;
        private TextBox textBoxCountry;
        private TextBox textBoxRate;
        private TextBox textBoxSticks;
    }
}
