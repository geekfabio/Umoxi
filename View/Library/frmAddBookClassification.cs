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
    public partial class frmAddBookClassification : Form
    {
        public frmAddBookClassification()
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
            TransitionsEffects.ResetColor(txtClassfName, lblClassificationName);

            if (string.IsNullOrEmpty(txtClassfName.Text))
            {
                TransitionsEffects.ShowTransition(txtClassfName, lblClassificationName);
                Snackbar.Show(this, "Required: Classification", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO BookClassification (Book_Classf_Type) VALUES ('" + UtilitiesFunctions.str_repl(txtClassfName.Text) + "')  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add classification of book # " + txtClassfName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE BookClassification SET Book_Classf_Type= '" + UtilitiesFunctions.str_repl(txtClassfName.Text) + "' WHERE  BOOK_CLASSF_ID=" + txtClassfID.Text + "  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated classification of book # " + txtClassfName.Text);

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

        private void frmAddBookClassification_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
