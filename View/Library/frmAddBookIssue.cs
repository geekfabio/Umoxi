using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddBookIssue : Form
    {
        public frmAddBookIssue()
        {
            InitializeComponent();
        }

        private void frmAddBookIssue_Load(object sender, EventArgs e)
        {
            LoadData();
            lstBook.Visible = false;
            lstEmployee.Visible = false;
            txtBookName.Select();
            LoadCheckVal();
        }

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClass);
            ConnectionNode.FILLComboBox("SELECT        BATCH_ID, BatchName  FROM            Batch", cmbSession);
            cmbStudent.Items.Clear();
        }

        private void txtBookName_Click(object sender, EventArgs e)
        {
            lstBook.Visible = true;
            ConnectionNode.FillListBox("SELECT   BOOK_ID, BookName  FROM   BookInfo", lstBook);
        }

        private void txtBookName_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keydata = e.KeyData;
            if (keydata == Keys.Down)
            {
                if (lstBook.Items.Count > 0)
                {
                    lstBook.Visible = true;
                    lstBook.SelectedIndex = 0;
                    lstBook.Select();
                }
            }
        }

        private void txtBookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                lstBook.Visible = false;
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                txtBookID.Text = null;
                txtAuthorName.Text = null;
                txtISBN.Text = null;
                txtBarcode.Text = null;
                txtEdition.Text = null;
                txtPublisher.Text = null;
                ConnectionNode.FillListBox("SELECT   BOOK_ID, BookName  FROM   BookInfo", lstBook);
                lstBook.Visible = true;
            }
            else
            {
                lstBook.Visible = true;
                ConnectionNode.FillListBox("SELECT   BOOK_ID, BookName  FROM   BookInfo WHERE  (BookName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtBookName.Text)) + "%')", lstBook);
            }
        }

        private void LoadCheckVal()
        {
            switch (toggleSwitchBeneficiary.IsOn)
            {
                case true:
                    gbstudent.Enabled = true;
                    gbEmployee.Enabled = false;
                    LoadData();
                    txtEmployeeID.Text = null;
                    txtEmployeeName.Text = null;
                    txtContactNo.Text = null;
                    txtDesignation.Text = null;
                    lstEmployee.Visible = false;
                    break;
                case false:
                    gbstudent.Enabled = false;
                    gbEmployee.Enabled = true;
                    LoadData();
                    txtEmployeeID.Text = null;
                    txtEmployeeName.Text = null;
                    txtContactNo.Text = null;
                    txtDesignation.Text = null;
                    lstEmployee.Visible = false;
                    break;
            }
        }

        private void txtEmployeeName_Click(object sender, EventArgs e)
        {
            lstEmployee.Visible = true;
            ConnectionNode.FillListBox("SELECT   EmployeeID, EmployeeName  FROM   Employee", lstEmployee);
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keydata = e.KeyData;
            if (keydata == Keys.Down)
            {
                if (lstEmployee.Items.Count > 0)
                {
                    lstEmployee.Visible = true;
                    lstEmployee.SelectedIndex = 0;
                    lstEmployee.Select();
                }
            }
        }

        private void txtEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                lstEmployee.Visible = false;
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                txtEmployeeID.Text = null;
                txtContactNo.Text = null;
                txtDesignation.Text = null;
                ConnectionNode.FillListBox("SELECT   EmployeeID, EmployeeName  FROM   Employee", lstEmployee);
                lstEmployee.Visible = false;
            }
            else
            {
                lstBook.Visible = true;
                ConnectionNode.FillListBox("SELECT   EmployeeID, EmployeeName  FROM   Employee WHERE  (EmployeeName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtEmployeeName.Text)) + "%')", lstEmployee);
            }
        }

        private void toggleSwitchBeneficiary_Toggled(object sender, EventArgs e)
        {
            LoadCheckVal();
        }

        private void lstEmployee_DoubleClick(object sender, EventArgs e)
        {
            if (lstEmployee.Items.Count > 0)
            {
                txtEmployeeID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstEmployee.SelectedItem), " # ")[0]);
                txtEmployeeName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstEmployee.SelectedItem), " # ")[1]);
                lstEmployee.Visible = false;
                ConnectionNode.ExecuteSQLQuery(" SELECT     Employee.FathersName, Employee.MothersName, Employee.ContactNo, Designation.Designation_Name " +
                    " FROM            Employee INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID WHERE        (Employee.EmployeeID = " + txtEmployeeID.Text + ") ");
                txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                txtDesignation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Designation_Name"]);
            }
        }

        private void lstEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                if (lstEmployee.Items.Count > 0)
                {
                    txtEmployeeID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstEmployee.SelectedItem), " # ")[0]);
                    txtEmployeeName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstEmployee.SelectedItem), " # ")[1]);
                    lstEmployee.Visible = false;
                    ConnectionNode.ExecuteSQLQuery(" SELECT     Employee.FathersName, Employee.MothersName, Employee.ContactNo, Designation.Designation_Name " +
                        " FROM            Employee INNER JOIN Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID WHERE        (Employee.EmployeeID = " + txtEmployeeID.Text + ") ");
                    txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                    txtDesignation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Designation_Name"]);
                }
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
            {
            }
            else if (string.IsNullOrEmpty(cmbSession.Text))
            {
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
            }
            else
            {
                ConnectionNode.FILLComboBox(" SELECT        STUDENT_ID, StudentName  FROM            StudentInformation " +
                    " WHERE        (SCHOOL_ID = " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (CLASS_ID = " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (BATCH_ID = " + cmbSession.Text.Split(" # ".ToCharArray()[0])[0] + ") ", cmbStudent);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Snackbar.Show(this, "Required: Book", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (toggleSwitchBeneficiary.IsOn)
                {
                    case true:
                        if (string.IsNullOrEmpty(cmbStudent.Text))
                        {
                            Snackbar.Show(this, "Required: Student", BunifuSnackbar.MessageTypes.Error);
                        }
                        else
                        {

                            ConnectionNode.ExecuteSQLQuery("SELECT        QtyAvailable  FROM            BookInfo  WHERE        (BOOK_ID = " + txtBookID.Text + ")");
                            if (Convert.ToInt32(ConnectionNode.sqlDT.Rows[0]["QtyAvailable"]) <= 0)
                            {
                                Snackbar.Show(this, "Sorry! unavailable Book.", BunifuSnackbar.MessageTypes.Warning);
                            }
                            else
                            {
                                //---------------------------------------------------------
                                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  BookIssue (BOOK_ID, IssuDate, ExpectedRtnDate, Remarks, STUDENT_ID, EmployeeID, Status, Qty, User_ID) DateTimeS  " +
                                    " ( " + txtBookID.Text + ", '" + Strings.Format(dtpIssueDate.DateTime, "MM/dd/yyyy") + "', '" + Strings.Format(dtpReturnDate.DateTime, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(txtRemarks.Text) + "', ") + cmbStudent.Text.Split(" # ".ToCharArray()[0])[0] + ", 0, 'Issued', 1 , '" + Convert.ToString(ConnectionNode.userID) + "') ");
                                ConnectionNode.ExecuteSQLQuery(" UPDATE  BookInfo SET QtyAvailable=QtyAvailable-1  WHERE        (BOOK_ID = " + txtBookID.Text + ")");
                                this.Close();
                                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                                //---------------------------------------------------------
                            }
                        }
                        break;
                    case false:
                        if (string.IsNullOrEmpty(txtEmployeeID.Text))
                        {
                            Snackbar.Show(this, "Required: Employee", BunifuSnackbar.MessageTypes.Error);
                        }
                        else
                        {

                            ConnectionNode.ExecuteSQLQuery("SELECT        QtyAvailable  FROM            BookInfo  WHERE        (BOOK_ID = " + txtBookID.Text + ")");
                            if (Convert.ToInt32(ConnectionNode.sqlDT.Rows[0]["QtyAvailable"]) <= 0)
                            {
                                Snackbar.Show(this, "Sorry! Book unavailable.", BunifuSnackbar.MessageTypes.Warning);
                            }
                            else
                            {
                                //---------------------------------------------------------
                                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  BookIssue (BOOK_ID, IssuDate, ExpectedRtnDate, Remarks, STUDENT_ID, EmployeeID, Status, Qty, User_ID) VALUES  " +
                                    " ( " + txtBookID.Text + ", '" + Strings.Format(dtpIssueDate.DateTime, "MM/dd/yyyy") + "', '" + Strings.Format(dtpReturnDate.DateTime, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(txtRemarks.Text) + "', 0, ") + txtEmployeeID.Text + ", 'Issued', 1 , '" + Convert.ToString(ConnectionNode.userID) + "') ");
                                ConnectionNode.ExecuteSQLQuery(" UPDATE  BookInfo SET QtyAvailable=QtyAvailable-1  WHERE        (BOOK_ID = " + txtBookID.Text + ")");
                                this.Close();
                                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                                //---------------------------------------------------------
                            }
                        }
                        break;
                }
            }
        }

        private void lstBook_DoubleClick(object sender, EventArgs e)
        {
            if (lstBook.Items.Count > 0)
            {
                txtBookID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstBook.SelectedItem), " # ")[0]);
                txtBookName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstBook.SelectedItem), " # ")[1]);
                lstBook.Visible = false;
                ConnectionNode.ExecuteSQLQuery(" SELECT *  FROM   BookInfo WHERE BOOK_ID=" + txtBookID.Text + " ");
                txtAuthorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Author"]);
                txtISBN.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ISBN"]);
                txtBarcode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Barcode"]);
                txtEdition.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Edition"]);
                txtPublisher.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Publisher"]);
                // dtpEntryDate.Select()
            }
        }

        private void lstBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                if (lstBook.Items.Count > 0)
                {
                    txtBookID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstBook.SelectedItem), " # ")[0]);
                    txtBookName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstBook.SelectedItem), " # ")[1]);
                    lstBook.Visible = false;
                    ConnectionNode.ExecuteSQLQuery(" SELECT *  FROM   BookInfo WHERE BOOK_ID=" + txtBookID.Text + " ");
                    txtAuthorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Author"]);
                    txtISBN.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ISBN"]);
                    txtBarcode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Barcode"]);
                    txtEdition.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Edition"]);
                    txtPublisher.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Publisher"]);
                    //  dtpEntryDate.Select()
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
                TabContent.SelectedTabPage = Page1;
            else if (NavigationBar.SelectedItem == tabBeneficiary)
                TabContent.SelectedTabPage = Page2;
        }

        private void frmAddBookIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
