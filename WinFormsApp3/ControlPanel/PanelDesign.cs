using MaterialSkin;
using MemoryInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjectMemory;
using System.Windows.Forms;
using Exceptions;
using MaterialSkin.Controls;
using ConfigManagerSpace;

namespace MainProgram
{
    public class PanelDesign
    {
        private bool isDarkTheme = false;

        private readonly MaterialForm Form;
        private MaterialSkinManager materialSkinManager;

        public PanelDesign(MaterialForm form)
        {
            this.Form = form;

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(Form);
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.Grey900, Primary.Purple500, Accent.DeepPurple700, TextShade.WHITE);
        }
        public void ThemeChanger()
        {
            materialSkinManager.Theme = isDarkTheme ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            isDarkTheme = !isDarkTheme;
        }
    }
}
