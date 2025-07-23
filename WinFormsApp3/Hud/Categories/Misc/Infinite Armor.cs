using InjectMemory;

namespace MemoryInjection
{
    class Infinite_Armor : Module
    {
        public override string Name => "Infinite Armor";
        public override int Value => 100;
        public override int Offset => Data.armorOffset;
        public Infinite_Armor(System.Windows.Forms.Label label) : base(label) { }
        public Infinite_Armor(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Infinite_Armor(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}