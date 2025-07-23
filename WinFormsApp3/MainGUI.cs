using ConfigManagerSpace;
using InjectMemory;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class MainGUI : MaterialForm
    {
        private PanelDesign panelDesign;
        private PanelController panelController;

        public MainGUI()
        {
            InitializeComponent();

            Data.SaveBoxes = new List<CheckBox> { SaveFileCheckBox, SaveDatabaseCheckBox };
            Data.LoadBoxes = new List<CheckBox> { LoadFileCheckBox, LoadDatabaseCheckBox };

            panelController = new PanelController(new Label[] { labelMenuActivated, labelPlayerListActivated });
            panelDesign = new PanelDesign(this);

            labelLoginName.Text = LoginForm.UserName;

        }

        private void whitedarkmode_CheckedChanged(object sender, EventArgs e)
        {
            panelDesign.ThemeChanger();
        }

        private void SwitchMenu_CheckedChanged(object sender, EventArgs e)
        {
            panelController.MenuInitialize(labelMenuActivated);
        }

        private void SwitchPlayerList_CheckedChanged(object sender, EventArgs e)
        {
            panelController.PlayerListInitialize(labelPlayerListActivated);
        }

        private void LoadFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox temp = (System.Windows.Forms.CheckBox)sender;
            string checkBoxName = temp.Name;
            bool state = temp.Checked;

            if (checkBoxName == null) { return; }

            if (checkBoxName == "LoadDatabaseCheckBox")
            {
                LoadFileCheckBox.Checked = !state;
            }
            else if (checkBoxName == "LoadFileCheckBox")
            {
                LoadDatabaseCheckBox.Checked = !state;
            }
        }

        private void SaveFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox temp = (System.Windows.Forms.CheckBox)sender;
            string checkBoxName = temp.Name;
            bool state = temp.Checked;

            if (checkBoxName == null) { return; }

            if (checkBoxName == "SaveDatabaseCheckBox")
            {
                SaveFileCheckBox.Checked = !state;
            }
            else if (checkBoxName == "SaveFileCheckBox")
            {
                SaveDatabaseCheckBox.Checked = !state;
            }
        }

        private void materialLabel10_Click(object sender, EventArgs e)
        {
            performFileDialogPath(ref ConfigManager.ConfigFilePathReader);
        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {
            performFileDialogPath(ref ConfigManager.ConfigFilePathReader);
        }

        private void performFileDialogPath(ref string ConfigFilePath)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ConfigFilePath = openFileDialog.FileName;
                }
            }
        }
    }
}
