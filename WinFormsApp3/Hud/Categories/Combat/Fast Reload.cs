using InjectMemory;

namespace MemoryInjection
{
    class Fast_Reload : Module
    {
        public override string Name =>"Fast Reload";
        public override int Value => 0;
        public override int Offset => Data.grenadeThrowOffset;

        public Fast_Reload(System.Windows.Forms.Label label) : base(label) { }
        public Fast_Reload(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem){ }
        public Fast_Reload(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
