using InjectMemory;

namespace MemoryInjection
{
    class Infinite_Health : Module
    {
        public override string Name => "Infinite Health";
        public override int Value => 999;
        public override int Offset => Data.healthOffset;

        public Infinite_Health(System.Windows.Forms.Label label) : base(label) { }
        public Infinite_Health(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }
        public Infinite_Health(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
    }
}
