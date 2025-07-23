namespace InjectMemory
{
    partial class Main
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            label4 = new Label();
            Nadpis = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(33, 98);
            label4.Margin = new Padding(3);
            label4.Name = "label4";
            label4.Size = new Size(67, 16);
            label4.TabIndex = 11;
            label4.Text = "Grenade";
            // 
            // Nadpis
            // 
            Nadpis.AutoSize = true;
            Nadpis.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Nadpis.ForeColor = Color.White;
            Nadpis.Location = new Point(36, 4);
            Nadpis.Margin = new Padding(4, 3, 4, 3);
            Nadpis.Name = "Nadpis";
            Nadpis.Size = new Size(59, 20);
            Nadpis.TabIndex = 12;
            Nadpis.Text = "JirkaX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(39, 31);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(50, 16);
            label1.TabIndex = 13;
            label1.Text = "Ammo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(39, 54);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(52, 16);
            label2.TabIndex = 14;
            label2.Text = "Health";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(43, 76);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(48, 16);
            label3.TabIndex = 15;
            label3.Text = "Armor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(33, 120);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(66, 16);
            label5.TabIndex = 16;
            label5.Text = "Ammo_2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(14, 142);
            label6.Margin = new Padding(4, 3, 4, 3);
            label6.Name = "label6";
            label6.Size = new Size(101, 16);
            label6.TabIndex = 17;
            label6.Text = "Fast Grenade";
            // 
            // backgroundWorker2
            // 
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(120, 161);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Nadpis);
            Controls.Add(label4);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Main";
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            Load += Form1_Load;
            Paint += Form1_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label Nadpis;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

