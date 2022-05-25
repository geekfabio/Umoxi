using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddDailyAttendance : Form
    {
        public BunifuDropdown school;
        public BunifuDropdown classe;
        public BunifuDropdown session;
        public BunifuDataGridView DataGridView1;
        public frmAddDailyAttendance()
        {
            InitializeComponent();
        }

        #region DontMove
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        #endregion

        private void frmAddDailyAttendance_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        
        }

        private void frmAddDailyAttendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
