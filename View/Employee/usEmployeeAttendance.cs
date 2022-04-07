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
    public partial class usEmployeeAttendance : UserControl
    {
        public usEmployeeAttendance()
        {
            InitializeComponent();
            LoadData();
        }

        #region instance
        private static usEmployeeAttendance _instance;

        public static usEmployeeAttendance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usEmployeeAttendance();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
            ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name  FROM            Employee INNER JOIN " +
                " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                " WHERE        (Employee.Status = 'Y') AND (Employee.SCHOOL_ID = 0) ", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Error);
            else
                ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name  FROM            Employee INNER JOIN " +
                " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                " WHERE        (Employee.Status = 'Y') AND (Employee.SCHOOL_ID = " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") ", DataGridView1);
        }

        private void btnAddAttendace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Error);
            else
            {
                if (DataGridView1.RowCount > 0)
                {
                    //check attendance , if alredy taken
                    //save attendance
                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        double EmployeeID = Convert.ToDouble(row.Cells[1].Value);

                        if (!Convert.ToBoolean(row.Cells[0].Value))
                        {
                            ConnectionNode.ExecuteSQLQuery("SELECT     *  FROM            DailyAttendanceEmployee   WHERE        (EmployeeID = " + Convert.ToString(EmployeeID) + ") AND (EntryDate = '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + "')");
                            if (!(ConnectionNode.sqlDT.Rows.Count > 0))
                            {
                                ConnectionNode.ExecuteSQLQuery(" INSERT INTO DailyAttendanceEmployee (EmployeeID, EntryDate, EntryTime, User_ID, Status) VALUES " +
                                    " (" + Convert.ToString(EmployeeID) + ", '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToLongTimeString() + "', ") + Convert.ToString(ConnectionNode.userID) + ", 'Present') ");
                            }
                        }
                        else
                        {
                            ConnectionNode.ExecuteSQLQuery("SELECT     *  FROM            DailyAttendanceEmployee   WHERE        (EmployeeID = " + Convert.ToString(EmployeeID) + ") AND (EntryDate = '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + "')");
                            if (!(ConnectionNode.sqlDT.Rows.Count > 0))
                            {
                                ConnectionNode.ExecuteSQLQuery(" INSERT INTO DailyAttendanceEmployee (EmployeeID, EntryDate, EntryTime, User_ID, Status) VALUES " +
                                    " (" + Convert.ToString(EmployeeID) + ", '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToLongTimeString() + "', ") + Convert.ToString(ConnectionNode.userID) + ", 'Absent') ");
                            }

                        }
                    }
                    LoadData();
                    Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    Snackbar.Show(FrmMain.Default, "No employee(s) were found.", BunifuSnackbar.MessageTypes.Information);
                }
            }
        }
    }
}
