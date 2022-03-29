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
            ConnectionNode.FILLComboBox(" SELECT        EmployeeID, EmployeeName  FROM            Employee  WHERE        (SCHOOL_ID = " + school.Text.Split(" # ".ToCharArray()[0])[0] + ") ", cmbTeacher);
            ConnectionNode.FILLComboBox(" SELECT        SUBJECT_ID, SubjectName  FROM            Subject  WHERE        (CLASS_ID = " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ") ", cmbSubject);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbTeacher.Text))
            {
                Snackbar.Show(this, "Required: Employee", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSubject.Text))
            {
                Snackbar.Show(this, "Required: Subject", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT   *  FROM            DailyAttendance " +
                    " WHERE        (SCHOOL_ID = " + school.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (BATCH_ID = " + session.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (CLASS_ID = " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (SUBJECT_ID = " + cmbSubject.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (EntryDate = '" + Strings.Format(dtpEntryDate.EditValue, "MM/dd/yyyy") + "') ");

                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    Snackbar.Show(this, "Attendance already exist", BunifuSnackbar.MessageTypes.Error);
                }
                else
                {
                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        double STUDENT_ID = Convert.ToDouble(row.Cells["Column2"].Value);

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO DailyAttendance (SCHOOL_ID, BATCH_ID, CLASS_ID, EmployeeID, SUBJECT_ID, EntryDate, EntryTime, STUDENT_ID, User_ID, Status) VALUES " +
                                " (" + school.Text.Split(" # ".ToCharArray()[0])[0] + ", " + session.Text.Split(" # ".ToCharArray()[0])[0] + ", " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbTeacher.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSubject.Text.Split(" # ".ToCharArray()[0])[0] + ", '" + Strings.Format(dtpEntryDate.EditValue, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToShortTimeString() + "', ") + Convert.ToString(STUDENT_ID) + ", " + Convert.ToString(ConnectionNode.userID) + ", 'Present') ");
                        }
                        else
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO DailyAttendance (SCHOOL_ID, BATCH_ID, CLASS_ID, EmployeeID, SUBJECT_ID, EntryDate, EntryTime, STUDENT_ID, User_ID, Status) VALUES " +
                            " (" + school.Text.Split(" # ".ToCharArray()[0])[0] + ", " + session.Text.Split(" # ".ToCharArray()[0])[0] + ", " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbTeacher.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSubject.Text.Split(" # ".ToCharArray()[0])[0] + ", '" + Strings.Format(dtpEntryDate.EditValue, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToShortTimeString() + "', ") + Convert.ToString(STUDENT_ID) + ", " + Convert.ToString(ConnectionNode.userID) + ", 'Absent') ");
                        }
                    }
                }

                this.Close();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void frmAddDailyAttendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
