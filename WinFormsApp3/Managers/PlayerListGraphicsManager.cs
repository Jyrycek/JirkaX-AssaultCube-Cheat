using InjectMemory;
using MemoryInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Managers
{
    class PlayerListGraphicsManager
    {
        private const int WIDTH = 130;

        private Form mainForm;

        public Form MainForm { get => mainForm; set => mainForm = value; }

        public PlayerListGraphicsManager(Form mainForm)
        {
            MainForm = mainForm;

            mainForm.BackColor = Color.FromArgb(50, 50, 50);

            SetWindowPosition();
        }


        public void RenderGraphics(PaintEventArgs e)
        {
            Pen mypen = new Pen(Color.Black, 6);
            Graphics g = e.Graphics;

            g.DrawLine(mypen, 0, 0, WIDTH, 0);

            mypen = new Pen(Color.Black, 3);
            g.DrawLine(mypen, 0, 25, WIDTH, 25);
        }

        //Nastasvuje veliksot a pozici menu
        public void SetWindowPosition()
        {
            User32.RECT outrect;
            User32.GetWindowRect(User32.handle, out outrect);

            MainForm.Size = new Size(WIDTH, 185);

            MainForm.Top = outrect.top + 300;
            MainForm.Left = outrect.right - WIDTH - 20;

            MainForm.FormBorderStyle = FormBorderStyle.None;
            int initialStyle = User32.GetWindowLong(mainForm.Handle, -20);
            User32.SetWindowLong(mainForm.Handle, -20, initialStyle | 0x80000 | 0x20);
        }
    }
}