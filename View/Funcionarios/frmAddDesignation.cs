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
    public partial class frmAddDesignation : Form
    {
        public frmAddDesignation()
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
            TransitionsEffects.ResetColor(txtDesignationName, lblDesignationName);

            if (string.IsNullOrEmpty(txtDesignationName.Text))
            {
                TransitionsEffects.ShowTransition(txtDesignationName, lblDesignationName);
                Snackbar.Show(this, "Necessárop: Designação", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Salvar":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Designation (Designation_Name) VALUES ('" + UtilitiesFunctions.str_repl(txtDesignationName.Text) + "')  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add designation # " + txtDesignationName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Atualizar":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE Designation SET Designation_Name= '" + UtilitiesFunctions.str_repl(txtDesignationName.Text) + "' WHERE  DESIGNATION_ID=" + txtDegID.Text + "  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated designation # " + txtDesignationName.Text);

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

        private void frmAddDesignation_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
