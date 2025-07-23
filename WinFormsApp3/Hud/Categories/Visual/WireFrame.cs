using WinFormsApp3;

namespace MemoryInjection
{
    class WireFrame : Module
    {
        public static string name = "WireFrame";
        private static bool isEnabled = false;
        public static bool IsEnabled { get => isEnabled; set => isEnabled = value; }
        public override string Name => name;

        public WireFrame(System.Windows.Forms.Label label) : base(label) { }
        public WireFrame(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public WireFrame(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }

        public override void Execute()
        {
            if (!IsEnabled)
            {

                Thread thread = new Thread(Wireframe) { IsBackground = true };
                thread.Start();

                IsEnabled = true;
            }
        }
        private void Wireframe()
        {
            while (this.IsSelected)
            {
                Thread.Sleep(100);
            }
            IsEnabled = false;
            CoverForm.coverForm.Invoke(new Action(() => CoverForm.coverForm.Refresh()));
        }
    }
}
