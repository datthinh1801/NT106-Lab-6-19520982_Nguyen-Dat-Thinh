using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            new Server().Show();
        }
    }
}
