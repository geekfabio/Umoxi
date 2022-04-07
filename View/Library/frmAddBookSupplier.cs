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
    public partial class frmAddBookSupplier : Form
    {
        public frmAddBookSupplier()
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
            TransitionsEffects.ResetColor(txtSupplierName, lblSupplierName);

            if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                TransitionsEffects.ShowTransition(txtSupplierName, lblSupplierName);
                Snackbar.Show(this, "Required: Supplier", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                TransitionsEffects.ShowTransition(txtAddress, lblAddress);
                Snackbar.Show(this, "Required: Address", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                Snackbar.Show(this, "Required: Contact", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO BookSupplier (Supplier_Name, Address, Contact_No, FAX, Email) VALUES " + (
                            " ('" + UtilitiesFunctions.str_repl(txtSupplierName.Text) + "', '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', '" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToShortTimeString(), "fornecedor adicionado # " + txtSupplierName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE BookSupplier  SET  Supplier_Name='" + UtilitiesFunctions.str_repl(txtSupplierName.Text) + "', Address='" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', Contact_No='" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', FAX='" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', Email='" + UtilitiesFunctions.str_repl(txtEmail.Text) + "' " +
                            " WHERE BOOK_SUPP_ID=" + txtSupplierID.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToShortTimeString(), "fornecedor atualizado # " + txtSupplierName.Text);

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

        private void frmAddBookSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
