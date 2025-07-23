using InjectMemory;
using MemoryAccesor;
using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
    class Team_Changer : Module
    {
        [Required]
        public bool Enabled { get; set; } = false;
        public override string Name => "Change Team";
        public override int Offset => Data.teamOffset;
        public Team_Changer(System.Windows.Forms.Label label) : base(label) { }
        public Team_Changer(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem){ }
        public Team_Changer(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }

        public override void Execute()
        {
            byte team = MemoryManager.ReadByte(Data.LocalPlayerAddress, Data.teamOffset);
            
            byte result = (team == 0) ? (byte)1 : (byte)0;

            MemoryManager.WriteMemory(Data.LocalPlayerAddress, Offset, result);

            this.SetIsSelected();
            this.SetColor();
        }
    }
}
