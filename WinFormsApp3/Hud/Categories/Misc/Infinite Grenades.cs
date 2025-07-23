using InjectMemory;

namespace MemoryInjection
{
    class Infinite_Grenades : Module
    {
        public override string Name => "Infinite Grenades";
        public override int Value => 999;
        public override int Offset => Data.grenadeOffset;

        public Infinite_Grenades(System.Windows.Forms.Label label) : base(label) { }
        public Infinite_Grenades(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Infinite_Grenades(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
