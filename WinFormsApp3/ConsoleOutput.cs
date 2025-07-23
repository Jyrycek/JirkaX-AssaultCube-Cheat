using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class ConsoleOutput : Form
    {
        public TextBox xd;
        public ConsoleOutput()
        {
            InitializeComponent();
            xd = ConsoleBox;
        }
        
        public void ConsoleBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
