using InjectMemory;
using MemoryAccesor;
namespace MemoryInjection
{
    class Fly : Module
    {
        public override string Name => "Fly";
        public override int Value => 16777480;
        public override int Offset => Data.flyOffset;

        public Fly(System.Windows.Forms.Label label) : base(label) { }
        public Fly(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Fly(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }

        public override void Execute()
        {
            if (User32.GetAsyncKeyState(Keys.Space) < 0)
            {
                MemoryManager.WriteMemory(Data.LocalPlayerAddress, Offset, Value);
            }
        }
    }
}
