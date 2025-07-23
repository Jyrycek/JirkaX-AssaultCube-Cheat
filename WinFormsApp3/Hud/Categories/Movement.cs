using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
    [Category("Movement")]
    public class Movement : Category
    {
        public static string name = "Movement";
        public override string Name => name;
        public Movement(System.Windows.Forms.Label label, bool isOnCategory) : base(label, isOnCategory) { }
        public Movement(System.Windows.Forms.Label label) : base(label) { }
    }
}