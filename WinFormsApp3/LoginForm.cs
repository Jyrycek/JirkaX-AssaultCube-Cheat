using Database;
using InjectMemory;
using MainProgram.LoginManager;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class LoginForm : MaterialForm
    {
        private PanelDesign panelDesign;
        private WebInterface? webInterface;
        private MainGUI? mainGUI;
        private static string? username;
        public static string? UserName { get => username; set => username = value; }

        public LoginForm()
        {
            InitializeComponent();

            panelDesign = new PanelDesign(this);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty) return;

            using DatabaseConnector connectionManager = new DatabaseConnector("localhost", "cheat_login", "root", "password");
            connectionManager.OpenConnection();

            //registrace
            //if (DatabaseOperations.ProcessRegister("admin", "admin", connectionManager.GetConnection()))
            //{
            //    MessageBox.Show("Registrace proběhla úspěšně.", "Upozornění!");

            //}
            //else
            //{
            //   MessageBox.Show("Uživatelské jméno již existuje. Vyberte prosím jiné.", "Upozornění!");
            //}

            bool successful = DatabaseOperations.ProcessLogin(usernameTextBox.Text, passwordTextBox.Text, connectionManager.GetConnection());
           
            if (successful)
            {
                this.Hide();

                UserName = usernameTextBox.Text;

                if (checkWebConfiguration.Checked)
                {
                    // C:\\Users\\jgeng\\PycharmProjects\\WebInterfaceCheat\\main.py
                  //  webInterface = new WebInterface("C:\\Users\\jirka\\SKJ\\TestWebRozhrani\\main.py");
                }
                else
                {
                    mainGUI = new MainGUI();
                    mainGUI.Show();
                }
            }
            else
            {
                MessageBox.Show("Špatné heslo.", "Upozornění!");
            }

            connectionManager.CloseConnection();
        }
    }
}
