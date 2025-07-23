namespace MainProgram
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            passwordTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            usernameTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            checkWebConfiguration = new MaterialSkin.Controls.MaterialCheckbox();
            SuspendLayout();
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(118, 308);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Padding = new Padding(0, 0, 0, 20);
            materialButton1.Size = new Size(64, 36);
            materialButton1.TabIndex = 0;
            materialButton1.Tag = "";
            materialButton1.Text = "LOGIN";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.AnimateReadOnly = false;
            passwordTextBox.BackgroundImageLayout = ImageLayout.None;
            passwordTextBox.CharacterCasing = CharacterCasing.Normal;
            passwordTextBox.Depth = 0;
            passwordTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            passwordTextBox.HideSelection = true;
            passwordTextBox.LeadingIcon = null;
            passwordTextBox.Location = new Point(29, 196);
            passwordTextBox.MaxLength = 32767;
            passwordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.PrefixSuffixText = null;
            passwordTextBox.ReadOnly = false;
            passwordTextBox.RightToLeft = RightToLeft.No;
            passwordTextBox.SelectedText = "";
            passwordTextBox.SelectionLength = 0;
            passwordTextBox.SelectionStart = 0;
            passwordTextBox.ShortcutsEnabled = true;
            passwordTextBox.Size = new Size(250, 48);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.TabStop = false;
            passwordTextBox.Text = "admin";
            passwordTextBox.TextAlign = HorizontalAlignment.Left;
            passwordTextBox.TrailingIcon = (Image)resources.GetObject("passwordTextBox.TrailingIcon");
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.AnimateReadOnly = false;
            usernameTextBox.BackgroundImageLayout = ImageLayout.None;
            usernameTextBox.CharacterCasing = CharacterCasing.Normal;
            usernameTextBox.Depth = 0;
            usernameTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            usernameTextBox.HideSelection = true;
            usernameTextBox.LeadingIcon = null;
            usernameTextBox.Location = new Point(29, 111);
            usernameTextBox.MaxLength = 32767;
            usernameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PasswordChar = '\0';
            usernameTextBox.PrefixSuffixText = null;
            usernameTextBox.ReadOnly = false;
            usernameTextBox.RightToLeft = RightToLeft.No;
            usernameTextBox.SelectedText = "";
            usernameTextBox.SelectionLength = 0;
            usernameTextBox.SelectionStart = 0;
            usernameTextBox.ShortcutsEnabled = true;
            usernameTextBox.Size = new Size(250, 48);
            usernameTextBox.TabIndex = 3;
            usernameTextBox.TabStop = false;
            usernameTextBox.Text = "admin";
            usernameTextBox.TextAlign = HorizontalAlignment.Left;
            usernameTextBox.TrailingIcon = (Image)resources.GetObject("usernameTextBox.TrailingIcon");
            usernameTextBox.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(28, 89);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(72, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Username";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(29, 174);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(71, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Password";
            // 
            // checkWebConfiguration
            // 
            checkWebConfiguration.AutoSize = true;
            checkWebConfiguration.Depth = 0;
            checkWebConfiguration.Location = new Point(63, 256);
            checkWebConfiguration.Margin = new Padding(0);
            checkWebConfiguration.MouseLocation = new Point(-1, -1);
            checkWebConfiguration.MouseState = MaterialSkin.MouseState.HOVER;
            checkWebConfiguration.Name = "checkWebConfiguration";
            checkWebConfiguration.ReadOnly = false;
            checkWebConfiguration.Ripple = true;
            checkWebConfiguration.Size = new Size(181, 37);
            checkWebConfiguration.TabIndex = 6;
            checkWebConfiguration.Text = "Online Configuration";
            checkWebConfiguration.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(310, 361);
            Controls.Add(checkWebConfiguration);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(passwordTextBox);
            Controls.Add(materialButton1);
            Controls.Add(usernameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Sizable = false;
            Text = "     Login   ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialTextBox2 passwordTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 usernameTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCheckbox checkWebConfiguration;
    }
}