using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddWaiver : Form
    {
        public frmAddWaiver()
        {
            InitializeComponent();
            cmbSearchBy.SelectedIndex = 0;
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

        private void Clear()
        {
            txtStuID.Text = null;
            txtStudentName.Text = string.Empty;
            txtSchoolName.Text = null;
            txtSession.Text = null;
            txtClass.Text = null;
            txtContactNo.Text = null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cmbSearchBy.SelectedIndex)
            {
                case 0:
                    #region ID
                    //search by student id
                    if (!Information.IsNumeric(txtSearch.Text))
                    {
                        Clear();
                    }
                    else
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.StudentName, SchoolInformation.School_Name, Batch.BatchName, ClassName.Class_name,  StudentInformation.ContactNO " +
                        " FROM            StudentInformation INNER JOIN SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN " +
                        " Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            txtStuID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                            txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                            txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                            txtSession.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BatchName"]);
                            txtClass.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);
                            txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNO"]);
                        }
                    }
                    #endregion
                    break;
                case 1:
                    #region Process
                    //search by admission no
                    if (string.IsNullOrEmpty(txtSearch.Text))
                    {
                        Clear();
                        //Snackbar.Show(this, "Insira o num. do processo", BunifuSnackbar.MessageTypes.Warning);
                    }
                    else
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.StudentName, SchoolInformation.School_Name, Batch.BatchName, ClassName.Class_name,  StudentInformation.ContactNO " +
                            " FROM            StudentInformation INNER JOIN SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN " +
                            " Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID WHERE        (StudentInformation.AdmissionNo = '" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "') ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            txtStuID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                            txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                            txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                            txtSession.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BatchName"]);
                            txtClass.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);
                            txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNO"]);
                        }
                        else
                        {
                            //Snackbar.Show(this, "Nenhum estudante(s) encontrado", BunifuSnackbar.MessageTypes.Information);
                        }
                    }
                    #endregion
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtAmount, lblAmount);

            if (string.IsNullOrEmpty(txtStuID.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                Snackbar.Show(this, "Required: Student ID", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbMonth.Text))
            {
                NavigationBar.SelectedItem = tabWaiver;
                Snackbar.Show(this, "Required: Month", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtAmount.Text))
            {
                NavigationBar.SelectedItem = tabWaiver;
                TransitionsEffects.ShowTransition(txtAmount, lblAmount);
                Snackbar.Show(this, "Required: Amount", BunifuSnackbar.MessageTypes.Error);
            }
            else if (Conversion.Val(txtAmount.Text) <= 0d)
            {
                NavigationBar.SelectedItem = tabWaiver;
                Snackbar.Show(this, "Required: Amount", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO StudentLedger (STUDENT_ID, FEES_ID, EntryDate, EntryTime, User_ID, Debit, Credit, Narration, Month, PayMode) VALUES " +
                    " (" + txtStuID.Text + ", 0, '" + Strings.Format(dtpEntryDate.EditValue, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToShortTimeString() + "', ") + Convert.ToString(ConnectionNode.userID) + ",0, " + Convert.ToString(UtilitiesFunctions.str_repl(txtAmount.Text)) + ",   '" + Convert.ToString(UtilitiesFunctions.str_repl(txtNarration.Text)) + ("', '" + cmbMonth.Text + "', 'RENÚNCIA') "));
                UtilitiesFunctions.Logger(ConnectionNode.userID, DateAndTime.TimeOfDay.ToString(), "School payment, ID # " + txtSearch.Text + " , amount # " + txtAmount.Text);

                this.Close();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);

            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabWaiver)
            {
                TabContent.SelectedTabPage = Page2;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddWaiver_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
