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
    public partial class frmAddExamination : Form
    {
        public frmAddExamination()
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
            TransitionsEffects.ResetColor(txtExamName, lblExamName);

            if (string.IsNullOrEmpty(txtExamName.Text))
            {
                TransitionsEffects.ShowTransition(txtExamName, lblExamName);
                Snackbar.Show(this, "Required: Examination", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!(cmbStatus.Text == "Yes" | cmbStatus.Text == "No"))
            {
                Snackbar.Show(this, "Required: Empty status", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Examination (ExaminationName, HeldDate, ResultPublishDate, StartTime, EndTime, SuperName, Status) VALUES  " + (
                        " ('" + UtilitiesFunctions.str_repl(txtExamName.Text) + "', '") + Strings.Format(dtpHeldDate.DateTime, "MM/dd/yyyy") + "', '" + Strings.Format(dtpPublishDate.DateTime, "MM/dd/yyyy") + "', '" + Strings.Format(dtpStartTime.DateTime, "MM/dd/yyyy H:mm:ss tt") + "', '" + Strings.Format(dtpEndTime.DateTime, "MM/dd/yyyy H:mm:ss tt") + ("', '" + UtilitiesFunctions.str_repl(txtSuperName.Text) + "', '" + UtilitiesFunctions.str_repl(cmbStatus.Text) + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "add  examination # " + txtExamName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE Examination SET ExaminationName='" + UtilitiesFunctions.str_repl(txtExamName.Text) + "', HeldDate='" + Strings.Format(dtpHeldDate.DateTime, "MM/dd/yyyy") + "', ResultPublishDate='" + Strings.Format(dtpPublishDate.DateTime, "MM/dd/yyyy") + "', " +
                        " StartTime='" + Strings.Format(dtpStartTime.DateTime, "MM/dd/yyyy H:mm:ss tt") + "',EndTime= '" + Strings.Format(dtpEndTime.DateTime, "MM/dd/yyyy H:mm:ss tt") + ("', SuperName='" + UtilitiesFunctions.str_repl(txtSuperName.Text) + "', Status='" + UtilitiesFunctions.str_repl(cmbStatus.Text) + "'   WHERE EXAM_ID = ") + txtExamID.Text + "");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "update  examination # " + txtExamName.Text);

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

        private void frmAddExamination_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
