using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
    [Category("Visual")]
    public class Visual : Category
    {
        public static string name = "Visual";
        public override string Name => name;

        public Visual(System.Windows.Forms.Label label, bool isOnCategory) : base(label, isOnCategory) { }

        public Visual(System.Windows.Forms.Label label) : base(label) { }
    }
}
