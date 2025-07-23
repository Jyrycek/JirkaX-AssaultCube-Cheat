using InjectMemory;

namespace MemoryInjection
{
    class Infinite_Ammo : Module
    {
        public override string Name => "Infinite Ammo";
        public override int Value => 999;
        public override int Offset => Data.ammoOffset;

        public Infinite_Ammo(System.Windows.Forms.Label label) : base(label) { }
        public Infinite_Ammo(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Infinite_Ammo(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
