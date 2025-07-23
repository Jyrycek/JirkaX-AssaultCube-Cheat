namespace MainProgram
{
    partial class MainGUI
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            XDDD = new TabPage();
            labelLoginName = new MaterialSkin.Controls.MaterialLabel();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            whitedarkmode = new MaterialSkin.Controls.MaterialSwitch();
            tabPage2 = new TabPage();
            SaveDatabaseCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            SaveFileCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            LoadDatabaseCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            LoadFileCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            labelPlayerListActivated = new Label();
            labelMenuActivated = new Label();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            SwitchPlayerList = new MaterialSkin.Controls.MaterialSwitch();
            SwitchMenu = new MaterialSkin.Controls.MaterialSwitch();
            tabPage1 = new TabPage();
            imageList1 = new ImageList(components);
            materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckbox();
            materialCheckbox2 = new MaterialSkin.Controls.MaterialCheckbox();
            materialCheckbox3 = new MaterialSkin.Controls.MaterialCheckbox();
            materialCheckbox4 = new MaterialSkin.Controls.MaterialCheckbox();
            materialTabControl1.SuspendLayout();
            XDDD.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(XDDD);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(754, 355);
            materialTabControl1.TabIndex = 0;
            // 
            // XDDD
            // 
            XDDD.BackColor = Color.White;
            XDDD.Controls.Add(labelLoginName);
            XDDD.Controls.Add(materialLabel9);
            XDDD.Controls.Add(whitedarkmode);
            XDDD.ImageKey = "ddmu1m9ns8gfkgka5713a3imsq-82567a68d90090de5e1c90173d5e3715.jpg";
            XDDD.Location = new Point(4, 39);
            XDDD.Name = "XDDD";
            XDDD.Padding = new Padding(3);
            XDDD.Size = new Size(746, 312);
            XDDD.TabIndex = 0;
            XDDD.Text = "Home";
            // 
            // labelLoginName
            // 
            labelLoginName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLoginName.AutoSize = true;
            labelLoginName.Depth = 0;
            labelLoginName.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelLoginName.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            labelLoginName.Location = new Point(380, 283);
            labelLoginName.MouseState = MaterialSkin.MouseState.HOVER;
            labelLoginName.Name = "labelLoginName";
            labelLoginName.Size = new Size(45, 24);
            labelLoginName.TabIndex = 7;
            labelLoginName.Text = "Jirka";
            labelLoginName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // materialLabel9
            // 
            materialLabel9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel9.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel9.Location = new Point(282, 283);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(93, 24);
            materialLabel9.TabIndex = 6;
            materialLabel9.Text = "Logged as";
            materialLabel9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // whitedarkmode
            // 
            whitedarkmode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            whitedarkmode.AutoSize = true;
            whitedarkmode.Depth = 0;
            whitedarkmode.Location = new Point(13, 272);
            whitedarkmode.Margin = new Padding(0);
            whitedarkmode.MouseLocation = new Point(-1, -1);
            whitedarkmode.MouseState = MaterialSkin.MouseState.HOVER;
            whitedarkmode.Name = "whitedarkmode";
            whitedarkmode.RightToLeft = RightToLeft.No;
            whitedarkmode.Ripple = true;
            whitedarkmode.Size = new Size(107, 37);
            whitedarkmode.TabIndex = 2;
            whitedarkmode.Text = "Theme";
            whitedarkmode.UseVisualStyleBackColor = true;
            whitedarkmode.CheckedChanged += whitedarkmode_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(SaveDatabaseCheckBox);
            tabPage2.Controls.Add(SaveFileCheckBox);
            tabPage2.Controls.Add(materialLabel10);
            tabPage2.Controls.Add(materialLabel8);
            tabPage2.Controls.Add(LoadDatabaseCheckBox);
            tabPage2.Controls.Add(LoadFileCheckBox);
            tabPage2.Controls.Add(materialLabel6);
            tabPage2.Controls.Add(labelPlayerListActivated);
            tabPage2.Controls.Add(labelMenuActivated);
            tabPage2.Controls.Add(materialLabel3);
            tabPage2.Controls.Add(materialLabel5);
            tabPage2.Controls.Add(materialLabel4);
            tabPage2.Controls.Add(materialLabel2);
            tabPage2.Controls.Add(materialLabel1);
            tabPage2.Controls.Add(SwitchPlayerList);
            tabPage2.Controls.Add(SwitchMenu);
            tabPage2.ImageKey = "home.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(746, 312);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "AssaultCube";
            // 
            // SaveDatabaseCheckBox
            // 
            SaveDatabaseCheckBox.AutoSize = true;
            SaveDatabaseCheckBox.Depth = 0;
            SaveDatabaseCheckBox.Location = new Point(484, 256);
            SaveDatabaseCheckBox.Margin = new Padding(0);
            SaveDatabaseCheckBox.MouseLocation = new Point(-1, -1);
            SaveDatabaseCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            SaveDatabaseCheckBox.Name = "SaveDatabaseCheckBox";
            SaveDatabaseCheckBox.ReadOnly = false;
            SaveDatabaseCheckBox.Ripple = true;
            SaveDatabaseCheckBox.Size = new Size(103, 37);
            SaveDatabaseCheckBox.TabIndex = 23;
            SaveDatabaseCheckBox.Text = "Database";
            SaveDatabaseCheckBox.UseVisualStyleBackColor = true;
            SaveDatabaseCheckBox.CheckedChanged += SaveFileCheckBox_CheckedChanged;
            // 
            // SaveFileCheckBox
            // 
            SaveFileCheckBox.AutoSize = true;
            SaveFileCheckBox.Checked = true;
            SaveFileCheckBox.CheckState = CheckState.Checked;
            SaveFileCheckBox.Depth = 0;
            SaveFileCheckBox.Location = new Point(484, 219);
            SaveFileCheckBox.Margin = new Padding(0);
            SaveFileCheckBox.MouseLocation = new Point(-1, -1);
            SaveFileCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            SaveFileCheckBox.Name = "SaveFileCheckBox";
            SaveFileCheckBox.ReadOnly = false;
            SaveFileCheckBox.Ripple = true;
            SaveFileCheckBox.Size = new Size(103, 37);
            SaveFileCheckBox.TabIndex = 22;
            SaveFileCheckBox.Text = "Local File";
            SaveFileCheckBox.UseVisualStyleBackColor = true;
            SaveFileCheckBox.CheckedChanged += SaveFileCheckBox_CheckedChanged;
            // 
            // materialLabel10
            // 
            materialLabel10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel10.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel10.Location = new Point(494, 186);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(45, 24);
            materialLabel10.TabIndex = 21;
            materialLabel10.Text = "Save";
            materialLabel10.Click += materialLabel10_Click;
            // 
            // materialLabel8
            // 
            materialLabel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel8.Location = new Point(143, 186);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(45, 24);
            materialLabel8.TabIndex = 20;
            materialLabel8.Text = "Load";
            materialLabel8.Click += materialLabel8_Click;
            // 
            // LoadDatabaseCheckBox
            // 
            LoadDatabaseCheckBox.AutoSize = true;
            LoadDatabaseCheckBox.Depth = 0;
            LoadDatabaseCheckBox.Location = new Point(133, 256);
            LoadDatabaseCheckBox.Margin = new Padding(0);
            LoadDatabaseCheckBox.MouseLocation = new Point(-1, -1);
            LoadDatabaseCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            LoadDatabaseCheckBox.Name = "LoadDatabaseCheckBox";
            LoadDatabaseCheckBox.ReadOnly = false;
            LoadDatabaseCheckBox.Ripple = true;
            LoadDatabaseCheckBox.Size = new Size(103, 37);
            LoadDatabaseCheckBox.TabIndex = 19;
            LoadDatabaseCheckBox.Text = "Database";
            LoadDatabaseCheckBox.UseVisualStyleBackColor = true;
            LoadDatabaseCheckBox.CheckedChanged += LoadFileCheckBox_CheckedChanged;
            // 
            // LoadFileCheckBox
            // 
            LoadFileCheckBox.AutoSize = true;
            LoadFileCheckBox.Checked = true;
            LoadFileCheckBox.CheckState = CheckState.Checked;
            LoadFileCheckBox.Depth = 0;
            LoadFileCheckBox.Location = new Point(133, 219);
            LoadFileCheckBox.Margin = new Padding(0);
            LoadFileCheckBox.MouseLocation = new Point(-1, -1);
            LoadFileCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            LoadFileCheckBox.Name = "LoadFileCheckBox";
            LoadFileCheckBox.ReadOnly = false;
            LoadFileCheckBox.Ripple = true;
            LoadFileCheckBox.Size = new Size(103, 37);
            LoadFileCheckBox.TabIndex = 18;
            LoadFileCheckBox.Text = "Local File";
            LoadFileCheckBox.UseVisualStyleBackColor = true;
            LoadFileCheckBox.CheckedChanged += LoadFileCheckBox_CheckedChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel6.Location = new Point(216, 162);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(257, 24);
            materialLabel6.TabIndex = 16;
            materialLabel6.Text = "[CONFIGURATION OPTIONS]";
            // 
            // labelPlayerListActivated
            // 
            labelPlayerListActivated.AutoSize = true;
            labelPlayerListActivated.Font = new Font("Schadow BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayerListActivated.Location = new Point(434, 85);
            labelPlayerListActivated.Name = "labelPlayerListActivated";
            labelPlayerListActivated.Size = new Size(79, 19);
            labelPlayerListActivated.TabIndex = 13;
            labelPlayerListActivated.Text = "Not Active";
            labelPlayerListActivated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMenuActivated
            // 
            labelMenuActivated.AutoSize = true;
            labelMenuActivated.Font = new Font("Schadow BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMenuActivated.Location = new Point(434, 48);
            labelMenuActivated.Name = "labelMenuActivated";
            labelMenuActivated.RightToLeft = RightToLeft.No;
            labelMenuActivated.Size = new Size(79, 19);
            labelMenuActivated.TabIndex = 12;
            labelMenuActivated.Text = "Not Active";
            labelMenuActivated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel3
            // 
            materialLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel3.Location = new Point(173, 3);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(83, 24);
            materialLabel3.TabIndex = 11;
            materialLabel3.Text = "[OFF/ON]";
            // 
            // materialLabel5
            // 
            materialLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(326, 48);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(41, 19);
            materialLabel5.TabIndex = 6;
            materialLabel5.Text = "Menu";
            // 
            // materialLabel4
            // 
            materialLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel4.Location = new Point(294, 3);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(104, 24);
            materialLabel4.TabIndex = 5;
            materialLabel4.Text = "[SETTINGS]";
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(308, 85);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(75, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Player List";
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel1.Location = new Point(432, 3);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(85, 24);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "[STATUS]";
            // 
            // SwitchPlayerList
            // 
            SwitchPlayerList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SwitchPlayerList.AutoSize = true;
            SwitchPlayerList.Depth = 0;
            SwitchPlayerList.Location = new Point(185, 76);
            SwitchPlayerList.Margin = new Padding(0);
            SwitchPlayerList.MouseLocation = new Point(-1, -1);
            SwitchPlayerList.MouseState = MaterialSkin.MouseState.HOVER;
            SwitchPlayerList.Name = "SwitchPlayerList";
            SwitchPlayerList.Ripple = true;
            SwitchPlayerList.Size = new Size(58, 37);
            SwitchPlayerList.TabIndex = 1;
            SwitchPlayerList.UseVisualStyleBackColor = true;
            SwitchPlayerList.CheckedChanged += SwitchPlayerList_CheckedChanged;
            // 
            // SwitchMenu
            // 
            SwitchMenu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SwitchMenu.AutoSize = true;
            SwitchMenu.Depth = 0;
            SwitchMenu.Location = new Point(185, 39);
            SwitchMenu.Margin = new Padding(0);
            SwitchMenu.MouseLocation = new Point(-1, -1);
            SwitchMenu.MouseState = MaterialSkin.MouseState.HOVER;
            SwitchMenu.Name = "SwitchMenu";
            SwitchMenu.Ripple = true;
            SwitchMenu.Size = new Size(58, 37);
            SwitchMenu.TabIndex = 0;
            SwitchMenu.UseVisualStyleBackColor = true;
            SwitchMenu.CheckedChanged += SwitchMenu_CheckedChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.ImageKey = "farcry6logo.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(746, 312);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "FarCry6";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "ddmu1m9ns8gfkgka5713a3imsq-82567a68d90090de5e1c90173d5e3715.jpg");
            imageList1.Images.SetKeyName(1, "home.png");
            imageList1.Images.SetKeyName(2, "farcry6logo.png");
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.AutoSize = true;
            materialCheckbox1.Depth = 0;
            materialCheckbox1.Location = new Point(0, 0);
            materialCheckbox1.Margin = new Padding(0);
            materialCheckbox1.MouseLocation = new Point(-1, -1);
            materialCheckbox1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox1.Name = "materialCheckbox1";
            materialCheckbox1.ReadOnly = false;
            materialCheckbox1.Ripple = true;
            materialCheckbox1.Size = new Size(10, 10);
            materialCheckbox1.TabIndex = 0;
            materialCheckbox1.Text = "materialCheckbox1";
            materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox2
            // 
            materialCheckbox2.AutoSize = true;
            materialCheckbox2.Depth = 0;
            materialCheckbox2.Location = new Point(0, 0);
            materialCheckbox2.Margin = new Padding(0);
            materialCheckbox2.MouseLocation = new Point(-1, -1);
            materialCheckbox2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox2.Name = "materialCheckbox2";
            materialCheckbox2.ReadOnly = false;
            materialCheckbox2.Ripple = true;
            materialCheckbox2.Size = new Size(10, 10);
            materialCheckbox2.TabIndex = 0;
            materialCheckbox2.Text = "materialCheckbox2";
            materialCheckbox2.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox3
            // 
            materialCheckbox3.AutoSize = true;
            materialCheckbox3.Depth = 0;
            materialCheckbox3.Location = new Point(0, 0);
            materialCheckbox3.Margin = new Padding(0);
            materialCheckbox3.MouseLocation = new Point(-1, -1);
            materialCheckbox3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox3.Name = "materialCheckbox3";
            materialCheckbox3.ReadOnly = false;
            materialCheckbox3.Ripple = true;
            materialCheckbox3.Size = new Size(10, 10);
            materialCheckbox3.TabIndex = 0;
            materialCheckbox3.Text = "materialCheckbox3";
            materialCheckbox3.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox4
            // 
            materialCheckbox4.AutoSize = true;
            materialCheckbox4.Depth = 0;
            materialCheckbox4.Location = new Point(0, 0);
            materialCheckbox4.Margin = new Padding(0);
            materialCheckbox4.MouseLocation = new Point(-1, -1);
            materialCheckbox4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox4.Name = "materialCheckbox4";
            materialCheckbox4.ReadOnly = false;
            materialCheckbox4.Ripple = true;
            materialCheckbox4.Size = new Size(10, 10);
            materialCheckbox4.TabIndex = 0;
            materialCheckbox4.Text = "materialCheckbox4";
            materialCheckbox4.UseVisualStyleBackColor = true;
            // 
            // MainGUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 422);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "MainGUI";
            Text = "JirkaX";
            materialTabControl1.ResumeLayout(false);
            XDDD.ResumeLayout(false);
            XDDD.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage XDDD;
        private TabPage tabPage2;
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialSwitch whitedarkmode;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch SwitchPlayerList;
        private MaterialSkin.Controls.MaterialSwitch SwitchMenu;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel labelLoginName;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Label labelPlayerListActivated;
        private Label labelMenuActivated;
        private MaterialSkin.Controls.MaterialCheckbox LoadFileCheckBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialCheckbox SaveDatabaseCheckBox;
        private MaterialSkin.Controls.MaterialCheckbox SaveFileCheckBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialCheckbox LoadDatabaseCheckBox;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox1;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox2;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox3;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox4;
    }
}