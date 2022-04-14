using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddGrading : Form
    {
        public frmAddGrading()
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
            TransitionsEffects.ResetColor(txtGradeName, lblGradeName);
            TransitionsEffects.ResetColor(txtGradeName, lblGradeName);
            TransitionsEffects.ResetColor(txtGradeName, lblGradeName);
            TransitionsEffects.ResetColor(txtGPA, lblGPA);
            TransitionsEffects.ResetColor(txtStatus, lblStatus);

            if (string.IsNullOrEmpty(txtGradeName.Text))
            {
                TransitionsEffects.ResetColor(txtGradeName, lblGradeName);
                Snackbar.Show(this, "Required: Grade", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtFrom.Text))
            {
                TransitionsEffects.ResetColor(txtFrom, lblFrom);
                Snackbar.Show(this, "Required: From", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtTo.Text))
            {
                TransitionsEffects.ResetColor(txtGradeName, lblGradeName);
                Snackbar.Show(this, "Required: Grade name", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtGPA.Text))
            {
                TransitionsEffects.ResetColor(txtGPA, lblGPA);
                Snackbar.Show(this, "Required: GPA", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtStatus.Text))
            {
                TransitionsEffects.ResetColor(txtStatus, lblStatus);
                Snackbar.Show(this, "Required: Status", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO GradingLevel  (Grade, MarkFrom, MarkTo, GPA, Status) VALUES  " + (
                         " ('" + UtilitiesFunctions.str_repl(txtGradeName.Text) + "', '" + UtilitiesFunctions.str_repl(txtFrom.Text) + "', '" + UtilitiesFunctions.str_repl(txtTo.Text) + "', '" + UtilitiesFunctions.str_repl(txtGPA.Text) + "', '" + UtilitiesFunctions.str_repl(txtStatus.Text) + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add grading # " + txtGradeName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  GradingLevel SET  Grade='" + UtilitiesFunctions.str_repl(txtGradeName.Text) + "', MarkFrom='" + UtilitiesFunctions.str_repl(txtFrom.Text) + "', MarkTo='" + UtilitiesFunctions.str_repl(txtTo.Text) + "', GPA='" + UtilitiesFunctions.str_repl(txtGPA.Text) + "', Status= '" + UtilitiesFunctions.str_repl(txtStatus.Text) + "' " +
                        " WHERE GRADE_ID=" + txtGradeID.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated grading # " + txtGradeName.Text);

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

        private void frmAddGrading_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
