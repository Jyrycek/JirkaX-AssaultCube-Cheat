namespace MainProgram
{
    partial class ConsoleOutput
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
            ConsoleBox = new TextBox();
            SuspendLayout();
            // 
            // ConsoleBox
            // 
            ConsoleBox.Location = new Point(-1, 12);
            ConsoleBox.Multiline = true;
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.Size = new Size(804, 452);
            ConsoleBox.TabIndex = 0;
            ConsoleBox.TextChanged += ConsoleBox_TextChanged;
            // 
            // ConsoleOutput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ConsoleBox);
            Name = "ConsoleOutput";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConsoleOutput";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ConsoleBox;
    }
}