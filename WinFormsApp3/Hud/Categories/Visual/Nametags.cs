using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3;

namespace MemoryInjection
{
    internal class Nametags : Module
    {
        public override string Name => "Nametags";
        private static bool isEnabled = false;

        public static bool IsEnabled { get => isEnabled; set => isEnabled = value; }
        public Nametags(System.Windows.Forms.Label label) : base(label) { }
        public Nametags(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Nametags(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
        public override void Execute()
        {
            if (!IsEnabled)
            {
                Thread thread = new Thread(Nametag) { IsBackground = true };
                thread.Start();

                IsEnabled = true;
            }
        }
        private void Nametag()
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
