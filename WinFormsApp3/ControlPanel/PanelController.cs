using Exceptions;
using InjectMemory;
using WinFormsApp3;


namespace MainProgram
{
    public class PanelController
    {
        private PlayersList playerList;
        private Main main;

        private bool isPlayerListIntialized = false;
        private bool isMenuIntialized = false;

        public static bool IsEnabledPlayerList = false;

        private int def_X = 0;
        public PanelController()  { }
        public PanelController(Label[] label)
        {
            def_X = label[0].Location.X;

            foreach (Label item in label)
            {
                item.ForeColor = Color.Red;
            }
        }

        public void MenuInitialize(Label? label = null)
        {
            if (!isMenuIntialized)
            {
                try
                {
                    main = new Main();
                }
                catch (OpenProcessException)
                {
                    MessageBox.Show("Chyba otevření procesu!", "Error");
                    Environment.Exit(-1);
                }

                isMenuIntialized = true;

                if (label != null) labelInitialize(label);
                return;
            }

            if (isMenuIntialized)
            {
                // main.Hide();
            }
            else
            {
                //   main.Show();
            }

            labelInitialize(label);
            isMenuIntialized = !isMenuIntialized;
        }
        public void PlayerListInitialize(Label? label = null)
        {
            if (!isPlayerListIntialized)
            {
                try
                {
                    playerList = new PlayersList();
                }
                catch (OpenProcessException)
                {
                    MessageBox.Show("Chyba otevření procesu!", "Error");
                    Environment.Exit(-1);
                }
            }

            if (isPlayerListIntialized)
            {
                // playerList.Dispose();
                // IsEnabledPlayerList = false;
                // main.GetWindowFocusHook().WindowFocusGained -= main.WindowFocusGainedHandler;
                // main.GetWindowFocusHook().WindowFocusLost -= main.WindowFocusLostHandler;
            }

            if (label != null) labelInitialize(label);

            isPlayerListIntialized = !isPlayerListIntialized;
            IsEnabledPlayerList = !IsEnabledPlayerList;
        }
        private void labelInitialize(Label label)
        {
            if (label.ForeColor == Color.Green)
            {
                label.Location = new Point(def_X, label.Location.Y);
                label.Text = "Not Active";
                label.ForeColor = Color.Red;
            }
            else
            {
                label.Location = new Point(def_X + 14, label.Location.Y);
                label.Text = "Active";
                label.ForeColor = Color.Green;
            }
        }
    }
}
