using System.ComponentModel.DataAnnotations;

namespace MemoryInjection
{
     public abstract class Category
     {
        public abstract string Name { get; }

        private System.Windows.Forms.Label label;
        private List<Module> items = new List<Module> ();
        private bool isOnCategory = false; //aktuálne zobrazene policko
        private bool isSelected = false; //otevreny prvek

        public Category(System.Windows.Forms.Label label, bool isOnCategory)
        {
            this.label = label;
            this.IsOnCategory = isOnCategory;
        }
        public Category(System.Windows.Forms.Label label)
        {
            this.label = label;
        }

        public Label Label { get => label; set => label = value; }
        public bool IsOnCategory { get => isOnCategory; set => isOnCategory = value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }
        internal List<Module> Items { get => items; set => items = value; }

        public void addItem(Module item)
        {
            Items.Add(item);
        }
    }
}
