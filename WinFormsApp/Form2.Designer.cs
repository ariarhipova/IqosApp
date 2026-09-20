namespace WinFormsApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonMostExpensive = new Button();
            buttonCheapest = new Button();
            buttonGroup = new Button();
            listBoxGroups = new ListBox();
            SuspendLayout();
            // 
            // buttonMostExpensive
            // 
            buttonMostExpensive.Location = new Point(12, 25);
            buttonMostExpensive.Name = "buttonMostExpensive";
            buttonMostExpensive.Size = new Size(103, 23);
            buttonMostExpensive.TabIndex = 0;
            buttonMostExpensive.Text = "Самое дорогое";
            buttonMostExpensive.UseVisualStyleBackColor = true;
            buttonMostExpensive.Click += buttonMostExpensive_Click;
            // 
            // buttonCheapest
            // 
            buttonCheapest.Location = new Point(12, 68);
            buttonCheapest.Name = "buttonCheapest";
            buttonCheapest.Size = new Size(103, 23);
            buttonCheapest.TabIndex = 1;
            buttonCheapest.Text = "Самое дешёвое";
            buttonCheapest.UseVisualStyleBackColor = true;
            buttonCheapest.Click += buttonCheapest_Click;
            // 
            // buttonGroup
            // 
            buttonGroup.Location = new Point(12, 111);
            buttonGroup.Name = "buttonGroup";
            buttonGroup.Size = new Size(103, 23);
            buttonGroup.TabIndex = 2;
            buttonGroup.Text = "Группировка";
            buttonGroup.UseVisualStyleBackColor = true;
            buttonGroup.Click += buttonGroup_Click;
            // 
            // listBoxGroups
            // 
            listBoxGroups.FormattingEnabled = true;
            listBoxGroups.ItemHeight = 15;
            listBoxGroups.Location = new Point(12, 171);
            listBoxGroups.Name = "listBoxGroups";
            listBoxGroups.Size = new Size(460, 169);
            listBoxGroups.TabIndex = 3;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(listBoxGroups);
            Controls.Add(buttonGroup);
            Controls.Add(buttonCheapest);
            Controls.Add(buttonMostExpensive);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Бизнес-функции";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonMostExpensive;
        private Button buttonCheapest;
        private Button buttonGroup;
        private ListBox listBoxGroups;
    }
}