using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
    [Category("Combat")]
    public class Combat : Category
    {
        public static string name = "Combat";
        public override string Name => name;

        public Combat(System.Windows.Forms.Label label, bool isOnCategory) : base(label, isOnCategory){ }
        public Combat(System.Windows.Forms.Label label) : base(label) { }
    }
}
