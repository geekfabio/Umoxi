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
    public partial class frmAddHoliday : Form
    {
        public frmAddHoliday()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtHoliday, lblHoliday);

            if (string.IsNullOrEmpty(txtHoliday.Text))
            {
                TransitionsEffects.ShowTransition(txtHoliday, lblHoliday);
                Snackbar.Show(this, "Required: Holiday", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(dtpHolidayDate.Text))
            {
                Snackbar.Show(this, "Required: Date", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Holiday (Description, HolidayDate) VALUES ('" + UtilitiesFunctions.str_repl(txtHoliday.Text) + "', '" + String.Format(dtpHolidayDate.DateTime.ToShortDateString(), "MM/dd/yyyy") + "')  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add holiday # " + txtHoliday.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE Holiday SET Description= '" + UtilitiesFunctions.str_repl(txtHoliday.Text) + "', HolidayDate= '" + String.Format(dtpHolidayDate.DateTime.ToShortDateString(), "MM/dd/yyyy") + "' WHERE  HOLIDAY_ID=" + txtHolidayID.Text + "  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated holiday # " + txtHoliday.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddHoliday_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
