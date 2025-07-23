using ezOverLay;
using InjectMemory;
using MemoryInjection;
using System.Drawing;
using System.Threading;

namespace WinFormsApp3
{
    public partial class CoverForm : Form
    {
        private VisualModules visualModules;

        public static Graphics g;
        public static CoverForm coverForm;


        public CoverForm()
        {
            InitializeComponent();

            visualModules = new VisualModules(this);

            coverForm = this;

            this.Show();

            Thread thread = new Thread(BackgroundProcessing) { IsBackground = true };
            thread.Start();
        }

        private void BackgroundProcessing()
        {
            while (true)
            {
                if (Esp.IsEnabled || WireFrame.IsEnabled || Nametags.IsEnabled)
                    CoverForm.coverForm.Invoke(new Action(() => CoverForm.coverForm.Refresh()));

                Thread.Sleep(14);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (!GameManager.IsFocused)
            //    return;

            visualModules.visualEngine(e.Graphics);
        }
    }
}
