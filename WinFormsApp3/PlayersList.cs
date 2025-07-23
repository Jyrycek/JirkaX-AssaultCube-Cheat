using InjectMemory;
using MemoryAccesor;
using WinFormsApp3.Managers;

namespace WinFormsApp3
{
    public partial class PlayersList : Form
    {
        private PlayerListGraphicsManager playerListGraphicsManager;
        private PlayerListManager playerListManager;
        private WindowSizeHook windowSizeHook;
        private WindowFocusHook windowFocusHook;
        private GameManager gameManager;
        public PlayersList()
        {
            InitializeComponent();

            Data.LabelsNames = new List<Label> { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12 };
            Data.LabelsHealth = new List<Label> { label24, label23, label22, label21, label20, label19, label18, label17, label16, label15, label14, label13 };

            playerListGraphicsManager = new PlayerListGraphicsManager(this);
            gameManager = new GameManager();
            playerListManager = new PlayerListManager(this);
            windowSizeHook = new WindowSizeHook(MemoryManager.Process_id);
            windowFocusHook = new WindowFocusHook(gameManager);

            windowSizeHook.WindowSizeChanged += WindowSizeHook_WindowSizeChanged;
            windowFocusHook.WindowFocusGained += WindowFocusGainedHandler;
            windowFocusHook.WindowFocusLost += WindowFocusLostHandler;

            timer1.Start();
        }

        private void PlayersList_Load(object sender, EventArgs e)
        {
            playerListGraphicsManager.SetWindowPosition();
        }

        private void PlayersList_Paint(object sender, PaintEventArgs e)
        {
            playerListGraphicsManager.RenderGraphics(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerListManager.refreshForm();
        }
        private void WindowSizeHook_WindowSizeChanged(object sender, EventArgs e)
        {
            playerListGraphicsManager.SetWindowPosition();
        }
        private void WindowFocusGainedHandler(object sender, EventArgs e)
        {
            playerListManager.OnFocusGained();
        }

        private void WindowFocusLostHandler(object sender, EventArgs e)
        {
            playerListManager.OnFocusLost();
        }
    }
}