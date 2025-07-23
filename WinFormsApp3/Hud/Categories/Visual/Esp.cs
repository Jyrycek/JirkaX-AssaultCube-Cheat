using System.Threading;
using WinFormsApp3;

namespace MemoryInjection
{
    internal class Esp : Module
    {
        public override string Name => "ESP";
        private static bool isEnabled = false;
        public static bool IsEnabled { get => isEnabled; set => isEnabled = value; }

        public Esp(System.Windows.Forms.Label label) : base(label) { }
        public Esp(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Esp(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }

        Thread thread;
        public override void Execute()
        {
            if (!IsEnabled)
            {

                thread = new Thread(ESP) { IsBackground = true };
                thread.Start();

                IsEnabled = true;
            }
        }

        private void ESP()
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
