using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmViewPhoto : Form
    {
        public frmViewPhoto()
        {
            InitializeComponent();
        }

        private void frmViewPhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
