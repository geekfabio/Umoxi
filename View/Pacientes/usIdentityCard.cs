using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usIdentityCard : UserControl
    {
        public usIdentityCard()
        {
            InitializeComponent();
            TabContent.SelectedTabPage = Page2;
        }

        #region instance
        private static usIdentityCard _instance;

        public static usIdentityCard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usIdentityCard();
                return _instance;
            }
        }
        #endregion

        private void panelPrintID1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
