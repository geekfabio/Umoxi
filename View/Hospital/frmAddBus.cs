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
    public partial class frmAddBus : Form
    {
        public frmAddBus()
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
            TransitionsEffects.ResetColor(txtBusNO, lblBusNO);
            TransitionsEffects.ResetColor(txtDriverName, lblDriverName);

            if (string.IsNullOrEmpty(txtBusNO.Text))
            {
                TransitionsEffects.ShowTransition(txtBusNO, lblBusNO);
                Snackbar.Show(this, "Required: Bus no", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtDriverName.Text))
            {
                TransitionsEffects.ShowTransition(txtDriverName, lblDriverName);
                Snackbar.Show(this, "Required: Driver name", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        #region save
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO SchoolBus (Bus_no, Driver_Name, Driver_Contact, Supervisor, SupervisorContact) VALUES " + (
                        " ( '" + UtilitiesFunctions.str_repl(txtBusNO.Text) + "', '" + UtilitiesFunctions.str_repl(txtDriverName.Text) + "', '" + UtilitiesFunctions.str_repl(txtDriverContact.Text) + "', '" + UtilitiesFunctions.str_repl(txtSupervisorName.Text) + "', '" + UtilitiesFunctions.str_repl(txtSupervisorContact.Text) + "' ) "));
                        
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Transporte adicionado # " + txtBusNO.Text);
                        
                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
#endregion
                        break;
                    case "Update":
                            #region update
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  SchoolBus  SET Bus_no='" + UtilitiesFunctions.str_repl(txtBusNO.Text) + "', Driver_Name='" + UtilitiesFunctions.str_repl(txtDriverName.Text) + "', Driver_Contact='" + UtilitiesFunctions.str_repl(txtDriverContact.Text) + "', Supervisor='" + UtilitiesFunctions.str_repl(txtSupervisorName.Text) + "', SupervisorContact ='" + UtilitiesFunctions.str_repl(txtSupervisorContact.Text) + "' " +
                        " WHERE BUS_ID=" + txtBusID.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Transporte atualizado # " + txtBusNO.Text);
                        
                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddBus_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
