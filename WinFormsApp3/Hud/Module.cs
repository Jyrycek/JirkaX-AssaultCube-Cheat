using InjectMemory;
using MemoryAccesor;

namespace MemoryInjection
{
    abstract public class Module
    {
        public abstract string Name { get; }
        public virtual int Value { get; }
        public virtual int Offset { get; }
        private System.Windows.Forms.Label? label;

        //Aktuálně se nachází na políčku
        private bool isOnItem = false;
        private Color color = Color.Red;

        public System.Windows.Forms.Label Label { get => label; set => label = value; }
        public bool IsOnItem { get => isOnItem; set => isOnItem = value; }
        //Všechny vybrané políčka - zelené true, červené - false
        public bool IsSelected { get; set; } = false;
        public Color Color { get => Color = IsSelected ? Color.LimeGreen : Color.Red; set => color = value; }

        public Module(System.Windows.Forms.Label label)
        {
            Label = label;
        }
        public Module(System.Windows.Forms.Label label, bool isOnItem)
        {
            Label = label;
            IsOnItem = isOnItem;
        }
        public Module (System.Windows.Forms.Label label, bool isSelected, bool isOnItem)
        {
            Label = label;
            IsSelected = isSelected;
            IsOnItem = isOnItem;
        }

        public virtual void Execute()
        {
            MemoryManager.WriteMemory(Data.LocalPlayerAddress, Offset, Value);
        }

        public void SetIsSelected()
        {
            IsSelected = !IsSelected;
        }
        public void SetColor()
        {
            Label.ForeColor = Color;
        }
    }
}