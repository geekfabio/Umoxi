using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;

namespace Umoxi
{
    public partial class usEmployee : UserControl
    {
        public usEmployee()
        {
            InitializeComponent();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            LoadCheckVal();
            LoadData();
        }

        #region instance
        private static usEmployee _instance;

        public static usEmployee Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usEmployee();
                return _instance;
            }
        }
        #endregion

        private string ChekValues;

        private void LoadCheckVal()
        {
            switch (toggleSwitch.IsOn)
            {
                case true:
                    ChekValues = "Y";
                    break;
                case false:
                    ChekValues = "N";
                    break;
            }
            LoadData();
        }
        private void LoadData()
        {
            ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, " +
                " Department.Department_Name, Designation.Designation_Name, Employee.JoiningDate, Employee.Gender FROM            Employee INNER JOIN " +
                " SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " + (
                " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID WHERE (Employee.Status = '" + ChekValues + "') "), DataGridView1);
        }

        private void toggleSwitch_Toggled(object sender, EventArgs e)
        {
            LoadCheckVal();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                switch (cmbSearchBy.Text)
                {
                    case "ID":
                        #region ID
                        //search by student id
                        if (!Information.IsNumeric(txtSearch.Text))
                        {
                            LoadData();
                        }
                        else
                        {
                            ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup, " +
                                " Employee.DateOfBirth, Employee.Religion, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                                " SchoolInformation.School_Name, Department.Department_Name, Designation.Designation_Name FROM            Employee INNER JOIN " +
                                " SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " +
                                " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " + (
                                " WHERE        (Employee.EmployeeID = " + UtilitiesFunctions.str_repl(txtSearch.Text) + ") AND (Employee.Status = '" + ChekValues + "') "), DataGridView1);
                        }
                        #endregion
                        break;
                    case "Name":
                        #region Name
                        //search by employee name
                        ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup, " +
                            " Employee.DateOfBirth, Employee.Religion, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                            " SchoolInformation.School_Name, Department.Department_Name, Designation.Designation_Name FROM            Employee INNER JOIN " +
                            " SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " +
                            " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                            " WHERE  (Employee.EmployeeName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ("%')  AND (Employee.Status = '" + ChekValues + "') "), DataGridView1);
                        #endregion
                        break;
                    case "Dad":
                        #region Father
                        //search by employee's father name
                        ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup, " +
                            " Employee.DateOfBirth, Employee.Religion, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                            " SchoolInformation.School_Name, Department.Department_Name, Designation.Designation_Name FROM            Employee INNER JOIN " +
                            " SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " +
                            " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                            " WHERE  (Employee.FathersName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ("%')  AND (Employee.Status = '" + ChekValues + "') "), DataGridView1);
                        #endregion
                        break;
                    case "Contact":
                        #region Contact
                        //search by employee cotact no
                        ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup, " +
                            " Employee.DateOfBirth, Employee.Religion, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                            " SchoolInformation.School_Name, Department.Department_Name, Designation.Designation_Name FROM            Employee INNER JOIN " +
                            " SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " +
                            " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                            " WHERE  (Employee.ContactNo LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ("%')  AND (Employee.Status = '" + ChekValues + "') "), DataGridView1);
                        #endregion
                        break;
                }
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddEmployee employee = new frmAddEmployee();
            using (employee)
            {
                employee.ShowDialog();
            }
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region edit
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup,  " +
                        "  Employee.DateOfBirth, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                        " Employee.Status, Employee.EmployeePicture, Employee.SCHOOL_ID, SchoolInformation.School_Name, Employee.DEPARTMENT_ID, Department.Department_Name, " +
                        " Employee.DESIGNATION_ID, Designation.Designation_Name FROM            Employee INNER JOIN " +
                        "  SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN " +
                        "  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID WHERE        (Employee.EmployeeID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");

                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddEmployee employee = new frmAddEmployee();

                            employee.txtEmployeeID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeID"]);
                            employee.txtEmployeeName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeName"]);
                            employee.txtFathersName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FathersName"]);
                            employee.txtMothersName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["MothersName"]);
                            employee.cmbGender.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Gender"]);
                            employee.dtpDateOfBirth.EditValue = (DateTime)(ConnectionNode.sqlDT.Rows[0]["DateOfBirth"]);
                            employee.cmbBloodGroup.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BloodGroup"]);
                            employee.cmbNationality.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Nationality"]);
                            employee.dtpJoiningDate.EditValue = (DateTime)(ConnectionNode.sqlDT.Rows[0]["JoiningDate"]);
                            employee.dtpJoiningDate.EditValue = (DateTime)(ConnectionNode.sqlDT.Rows[0]["JoiningDate"]);
                            employee.txtAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                            employee.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                            employee.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                            double SCHOOL_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"]);
                            string School_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                            double DEPARTMENT_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["DEPARTMENT_ID"]);
                            string Department_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Department_Name"]);
                            double DESIGNATION_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["DESIGNATION_ID"]);
                            string Designation_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Designation_Name"]);

                            if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "Y")
                            {
                                employee.rbActive.Checked = true;
                            }
                            else if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "N")
                            {
                                employee.rbDeActive.Checked = true;
                            }
                            else
                            {
                                employee.rbActive.Checked = false;
                            }

                            byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["EmployeePicture"]);
                            MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                            employee.PictureBox1.Image = Image.FromStream(stmBLOBData);

                            employee.cmbSchool.Text = SCHOOL_ID + " # " + School_Name;
                            employee.cmbDepartment.Text = DEPARTMENT_ID + " # " + Department_Name;
                            employee.cmbDesignation.Text = DESIGNATION_ID + " # " + Designation_Name;

                            employee.btnSave.Text = "Update";

                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (employee)
                            {
                                employee.ShowDialog();
                            }
                            LoadData();
                            #endregion
                        }
                    }
                    #endregion
                    break;
                default:
                    #region click
                    ConnectionNode.ExecuteSQLQuery(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Employee.FathersName, Employee.MothersName, Employee.Gender, Employee.BloodGroup,  " +
                        "  Employee.DateOfBirth, Employee.Nationality, Employee.Address, Employee.ContactNo, Employee.Email, Employee.JoiningDate, " +
                        " Employee.Status, Employee.EmployeePicture, Employee.SCHOOL_ID, SchoolInformation.School_Name, Employee.DEPARTMENT_ID, Department.Department_Name, " +
                        " Employee.DESIGNATION_ID, Designation.Designation_Name FROM            Employee INNER JOIN " +
                        "  SchoolInformation ON Employee.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN " +
                        "  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID WHERE        (Employee.EmployeeID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                        txtEmployeeName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeName"]);
                        txtFathersName.Text = "Dad: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FathersName"]);
                        txtMothersName.Text = "Mom: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["MothersName"]);
                        cmbGender.Text = "Gender: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Gender"]);
                        dtpDateOfBirth.Text = "Birth: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["DateOfBirth"]);
                        cmbBloodGroup.Text = "Blood Group: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BloodGroup"]);
                        cmbNationality.Text = "Nationality: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Nationality"]);
                        dtpJoiningDate.Text = "Joining Date: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["JoiningDate"]);
                        txtAddress.Text = "Address: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                        txtContactNo.Text = "Number: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                        txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                        cmbSchool.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                        cmbDepartment.Text = "Department: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Department_Name"]);
                        cmbDesignation.Text = "Designation: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Designation_Name"]);

                        byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["EmployeePicture"]);
                        MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                        PictureBox1.Image = Image.FromStream(stmBLOBData);
                    }
                    #endregion
                    break;
            }
        }

    }
}
