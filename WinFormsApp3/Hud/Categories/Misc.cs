using ConfigurationLibrary;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
    [Category("Misc")]
    public class Misc : Category
    {
        public static string name = "Misc";
        public override string Name => name;

        public Misc(System.Windows.Forms.Label label, bool isOnCategory) : base(label, isOnCategory) { }
        public Misc(System.Windows.Forms.Label label) : base(label) { }
    }
}
