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
    public partial class frmAddSubject : Form
    {
        public frmAddSubject()
        {
            InitializeComponent();
            loadData();
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

        private void loadData()
        {
            ConnectionNode.FILLComboBox("SELECT CLASS_ID, Class_name  FROM            ClassName", cmbClass);
            ConnectionNode.FILLComboBox("SELECT BATCH_ID, BatchName  FROM            Batch", cmbBatch);
            ConnectionNode.FILLComboBox("SELECT SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtSubjectCode, lblCode);
            TransitionsEffects.ResetColor(txtSubjectName, lblSubject);

            if (string.IsNullOrEmpty(txtSubjectCode.Text))
            {
                TransitionsEffects.ShowTransition(txtSubjectCode, lblCode);
                Snackbar.Show(this, "Required: Subject code", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtSubjectName.Text))
            {
                TransitionsEffects.ShowTransition(txtSubjectName, lblSubject);
                Snackbar.Show(this, "Required: Subject", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSchool.Text))
            {
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbBatch.Text))
            {
                Snackbar.Show(this, "Required: Batch", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Subject (SubjectCode, SubjectName, CLASS_ID, BATCH_ID, SCHOOL_ID) VALUES " + (
                        " ('" + UtilitiesFunctions.str_repl(txtSubjectCode.Text) + "', '" + UtilitiesFunctions.str_repl(txtSubjectName.Text) + "', ") + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbBatch.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add subject # " + txtSubjectName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE Subject SET SubjectCode='" + UtilitiesFunctions.str_repl(txtSubjectCode.Text) + "', SubjectName='" + UtilitiesFunctions.str_repl(txtSubjectName.Text) + "', CLASS_ID=" + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ", BATCH_ID=" + cmbBatch.Text.Split(" # ".ToCharArray()[0])[0] + ", SCHOOL_ID= " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + " " +
                        " WHERE SUBJECT_ID=" + txtSubjectID.Text + "   ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated subject atualizada # " + txtSubjectName.Text);

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

        private void frmAddSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
