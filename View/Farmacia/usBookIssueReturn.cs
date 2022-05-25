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
    public partial class usBookIssueReturn : UserControl
    {
        public usBookIssueReturn()
        {
            InitializeComponent();
            DataGridView1.Columns[1].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usBookIssueReturn _instance;

        public static usBookIssueReturn Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBookIssueReturn();
                return _instance;
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
            "  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
            " BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
            " Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
            " StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (BookIssue.Status = 'Issued')", DataGridView1);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        BookIssue.BK_ISSU_ID, BookIssue.BOOK_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookInfo.Barcode, BookInfo.Edition, BookInfo.Publisher, " +
                        " BookIssue.IssuDate, BookIssue.ExpectedRtnDate, BookIssue.Remarks, Employee.EmployeeName, Employee.FathersName, Employee.ContactNo, Employee.MothersName, " +
                        " Designation.Designation_Name, StudentInformation.StudentName, SchoolInformation.School_Name, Batch.BatchName, ClassName.Class_name, " +
                        " BookIssue.STUDENT_ID, BookIssue.EmployeeID FROM            SchoolInformation INNER JOIN " +
                        " StudentInformation ON SchoolInformation.SCHOOL_ID = StudentInformation.SCHOOL_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                        " ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID RIGHT OUTER JOIN BookIssue INNER JOIN " +
                        " BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID ON StudentInformation.STUDENT_ID = BookIssue.STUDENT_ID LEFT OUTER JOIN Designation INNER JOIN " +
                        " Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID WHERE        (BookIssue.BK_ISSU_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddBookReturn bookReturn = new frmAddBookReturn();
                            //get book infroamtion
                            bookReturn.txtBookID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BOOK_ID"]);
                            bookReturn.txtBookName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BookName"]);
                            bookReturn.txtAuthorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Author"]);
                            bookReturn.txtISBN.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ISBN"]);
                            bookReturn.txtBarcode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Barcode"]);
                            bookReturn.txtEdition.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Edition"]);
                            bookReturn.txtPublisher.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Publisher"]);

                            bookReturn.txtIssueDate.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["IssuDate"]);
                            bookReturn.txtIssueID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BK_ISSU_ID"]);
                            bookReturn.dtpReturnDate.DateTime = (DateTime)(ConnectionNode.sqlDT.Rows[0]["ExpectedRtnDate"]);
                            bookReturn.txtRemarks.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Remarks"]);

                            //get receiver  infromation
                            if (Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]) == "0")
                            {
                                bookReturn.txtSchoolName.Text = null;
                                bookReturn.txtStudentID.Text = null;
                                bookReturn.txtStudentName.Text = null;
                                bookReturn.txtSession.Text = null;
                                bookReturn.txtClass.Text = null;


                                bookReturn.txtEmployeeID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeID"]);
                                bookReturn.txtEmployeeName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeName"]);
                                bookReturn.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                                bookReturn.txtDesignation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Designation_Name"]);

                            }
                            else if (Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EmployeeID"]) == "0")
                            {
                                bookReturn.txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                                bookReturn.txtStudentID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                                bookReturn.txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                                bookReturn.txtSession.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BatchName"]);
                                bookReturn.txtClass.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);


                                bookReturn.txtEmployeeID.Text = null;
                                bookReturn.txtEmployeeName.Text = null;
                                bookReturn.txtContactNo.Text = null;
                                bookReturn.txtDesignation.Text = null;
                            }
                            //-----------------------------
                            //Open
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (bookReturn)
                            {
                                bookReturn.ShowDialog();
                            }
                            btnSearch.PerformClick();
                        }
                        else
                        {
                            Snackbar.Show(FrmMain.Default, "Oops! Illegal operation.", BunifuSnackbar.MessageTypes.Information);
                        }
                    }
                    break;
            }
        }
    }
}
