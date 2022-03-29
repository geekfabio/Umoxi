using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Umoxi
{
    public partial class usDeductions : UserControl
    {
        public usDeductions()
        {
            InitializeComponent(); 
            DataGridView2.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            LoadData();
        }

        #region instance
        private static usDeductions _instance;

        public static usDeductions Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDeductions();
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
            txtAmount.Text = null;
            txtDeductions.Text = null;
            dtpEntryDate.DateTime = DateTime.Now;
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabList)
            {
                TabContent.SelectedTabPage = Page2;
            }
        }

        private void btnFindSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Success);
            else
                ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name  FROM            Employee INNER JOIN " +
                    " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                    " WHERE        (Employee.Status = 'Y') AND (Employee.SCHOOL_ID = " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") ", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Success);
            else if (string.IsNullOrEmpty(txtDeductions.Text))
                Snackbar.Show(FrmMain.Default, "Required: Deduction", BunifuSnackbar.MessageTypes.Success);
            else if (!Information.IsNumeric(txtAmount.Text))
                Snackbar.Show(FrmMain.Default, "Required: Amount", BunifuSnackbar.MessageTypes.Success);
            else if (Conversion.Val(txtAmount.Text) <= 0d)
                Snackbar.Show(FrmMain.Default, "Required: Amount", BunifuSnackbar.MessageTypes.Success);
            else
            {
                if (DataGridView1.RowCount > 0)
                {
                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        double EmployeeID = Convert.ToDouble(row.Cells[1].Value);

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO    EmployeeLedger (EmployeeID, User_ID, EntryDate, Month, PostingType, Debit, Credit, Narration) VALUES " +
                                " (" + Convert.ToString(EmployeeID) + ", " + Convert.ToString(ConnectionNode.userID) + ", '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '"+DateTime.Now.ToString("MMMM")+"', 'Deductions', 0, '" + UtilitiesFunctions.str_repl(txtAmount.Text) + "', '" + UtilitiesFunctions.str_repl(txtDeductions.Text) + "') "));
                        }
                    }
                    UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add  deductions # " + txtDeductions.Text);
                    LoadData();
                    Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    Snackbar.Show(FrmMain.Default, "No employee(s) were found.", BunifuSnackbar.MessageTypes.Information);
                }
            }
        }

        private void btnFindData_Click(object sender, EventArgs e)
        {
            ConnectionNode.FillDataGrid(" SELECT        EmployeeLedger.EMP_LED_ID, EmployeeLedger.EntryDate, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name, " +
                " EmployeeLedger.Month, EmployeeLedger.Debit, EmployeeLedger.Credit FROM            EmployeeLedger INNER JOIN " +
                " Employee ON EmployeeLedger.EmployeeID = Employee.EmployeeID INNER JOIN Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                " WHERE        (EmployeeLedger.PostingType = 'Deductions') AND (EmployeeLedger.EntryDate >= '" + Strings.Format(dtpFrom.DateTime, "MM/dd/yyyy") + "' AND   EmployeeLedger.EntryDate <= '" + Strings.Format(dtpTo.DateTime, "MM/dd/yyyy") + "') ", DataGridView2);
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to delete " + Convert.ToString(DataGridView2.CurrentRow.Cells[3].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" DELETE FROM EmployeeLedger WHERE (EMP_LED_ID = " + Convert.ToString(DataGridView2.CurrentRow.Cells[1].Value) + ") ");
                        btnFindData.PerformClick();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Delete"), BunifuSnackbar.MessageTypes.Information);
                    }
                    break;
            }
        }

    }
}
