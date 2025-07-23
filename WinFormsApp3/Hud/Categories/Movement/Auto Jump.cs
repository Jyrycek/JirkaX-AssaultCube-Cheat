using InjectMemory;

namespace MemoryInjection
{
    class Auto_Jump : Module
    {
        public override string Name => "Auto Jump";
        public override int Value => 16777216;
        public override int Offset => Data.flyOffset;

        public Auto_Jump(System.Windows.Forms.Label label) : base(label) { }
        public Auto_Jump(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Auto_Jump(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
