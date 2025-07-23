using MemoryInjection;
using System.ComponentModel;
using WinFormsApp3;
using MemoryAccesor;
using Label = System.Windows.Forms.Label;
using ConfigManagerSpace;
using MainProgram;
using ConfigurationLibrary;

namespace InjectMemory
{
    public partial class Main : Form
    {
        private GameManager gameManager;
        private GraphicsManager graphicsManager;
        private GlobalKeyboardHook globalKeyboardHook;
        private MenuManager menuManager;
        private WindowSizeHook windowSizeHook;
        private WindowFocusHook windowFocusHook;


        public WindowFocusHook GetWindowFocusHook()
        {
            return windowFocusHook;
        }
        public Main()
        {
            InitializeComponent();
            
            DataInitialize();
            gameManager = new GameManager();
            graphicsManager = new GraphicsManager(gameManager, this);
            globalKeyboardHook = new GlobalKeyboardHook(); //menu
            menuManager = new MenuManager(graphicsManager, gameManager);
            windowSizeHook = new WindowSizeHook(MemoryManager.Process_id);
            windowFocusHook = new WindowFocusHook(gameManager);
            new CoverForm();

            windowSizeHook.WindowSizeChanged += WindowSizeHook_WindowSizeChanged!;
            globalKeyboardHook.KeyDown += GlobalKeyboardHook_KeyDown!;
            windowFocusHook.WindowFocusGained += WindowFocusGainedHandler!;
            windowFocusHook.WindowFocusLost += WindowFocusLostHandler!;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            graphicsManager.SetWindowPosition();

            backgroundWorker2.RunWorkerAsync();

            Data.LocalPlayerAddress = MemoryManager.LocalPlayerAddress;
        }
        private void DataInitialize()
        {
            Data.Labels = new List<Label> { label1, label2, label3, label4, label5, label6 };
            AppConfig? appConfig;
            if (Data.LoadBoxes[0] == null)
            {
                appConfig = ConfigManager.ReadJsonConfig();
            }
            else
            {
                if (Data.LoadBoxes[0].Checked)
                {
                    appConfig = ConfigManager.ReadJsonConfig();

                    if (appConfig == null)
                    {
                        throw new Exception("AppConfig is null. Json returned NULL");
                    }
                }
                else
                {
                    appConfig = ConfigManager.ReadConfigFromDatabase(LoginForm.UserName ?? throw new Exception("Username is NULL"));
                }
            }
            
            Data.LoadData(appConfig);
        }
        public void WindowFocusGainedHandler(object sender, EventArgs e)
        {
            graphicsManager.OnFocusGained();
        }
        public void WindowFocusLostHandler(object sender, EventArgs e)
        {
            graphicsManager.OnFocusLost();
        }
        private void GlobalKeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            menuManager.OnKeyChange(e.KeyCode);
        }
        private void WindowSizeHook_WindowSizeChanged(object sender, EventArgs e)
        {
            graphicsManager.SetWindowPosition();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphicsManager.RenderGraphics(e);
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                gameManager.ModuleExecutor();
                Thread.Sleep(200);
            }
        }
    }
}