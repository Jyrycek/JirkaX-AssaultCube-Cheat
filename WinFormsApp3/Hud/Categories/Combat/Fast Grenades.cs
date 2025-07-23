using InjectMemory;

namespace MemoryInjection
{
    class Fast_Grenades : Module
    {
        public override string Name => "Fast Grenades";
        public override int Value => 0;
        public override int Offset => Data.grenadeThrowOffset;

        public Fast_Grenades(System.Windows.Forms.Label label) : base(label) { }
        public Fast_Grenades(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Fast_Grenades(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
