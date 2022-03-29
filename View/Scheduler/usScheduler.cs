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
    public partial class usScheduler : UserControl
    {
        public usScheduler()
        {
            InitializeComponent();
          }

        #region instance
        private static usScheduler _instance;

        public static usScheduler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usScheduler();
                return _instance;
            }
        }
        #endregion

        private void schedulerDataStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
           
        }

        private void schedulerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
