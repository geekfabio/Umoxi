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

namespace Umoxi
{
    public partial class usBookIssue : UserControl
    {
        public usBookIssue()
        {
            InitializeComponent();
        }

		#region instance
		private static usBookIssue _instance;

		public static usBookIssue Instance
		{
			get
			{
				if (_instance == null)
					_instance = new usBookIssue();
				return _instance;
			}
		}
		#endregion

		private void btnSearch_Click(object sender, EventArgs e)
        {
			if (rbAllEntry.Checked)
			{
				ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
					"  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
					" BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
					" Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
					" StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID ", DataGridView1);
			}
			else if (rbAllIssued.Checked)
			{
				ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
					"  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
					" BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
					" Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
					" StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (BookIssue.Status = 'Issued')", DataGridView1);
			}
			else if (rbAllReturned.Checked)
			{
				ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
					"  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
					" BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
					" Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
					" StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (BookIssue.Status = 'Returned')", DataGridView1);
			}
			else if (rbIssed.Checked)
			{
				ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
					"  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
					" BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
					" Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
					" StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (BookIssue.Status = 'Issued') " +
					" AND (BookIssue.IssuDate >= '" + Strings.Format(dtpFrom.DateTime, "MM/dd/yyyy") + "' AND BookIssue.IssuDate <= '" + Strings.Format(dtpTo.DateTime, "MM/dd/yyyy") + "') ", DataGridView1);
			}
			else if (rbRuturn.Checked)
			{
				ConnectionNode.FillDataGrid(" SELECT        BookIssue.BK_ISSU_ID, BookInfo.BookName, BookInfo.Author, BookInfo.ISBN, BookIssue.IssuDate, BookIssue.ExpectedRtnDate, StudentInformation.StudentName,  " +
					"  Employee.EmployeeName, Designation.Designation_Name, ClassName.Class_name, Batch.BatchName, BookIssue.Remarks, BookIssue.Status FROM            BookIssue INNER JOIN " +
					" BookInfo ON BookIssue.BOOK_ID = BookInfo.BOOK_ID LEFT OUTER JOIN Designation INNER JOIN " +
					" Employee ON Designation.DESIGNATION_ID = Employee.DESIGNATION_ID ON BookIssue.EmployeeID = Employee.EmployeeID LEFT OUTER JOIN ClassName INNER JOIN " +
					" StudentInformation ON ClassName.CLASS_ID = StudentInformation.CLASS_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ON BookIssue.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (BookIssue.Status = 'Issued') " +
					" AND (BookIssue.ExpectedRtnDate >= '" + Strings.Format(dtpFrom.DateTime, "MM/dd/yyyy") + "' AND BookIssue.ExpectedRtnDate <= '" + Strings.Format(dtpTo.DateTime, "MM/dd/yyyy") + "') ", DataGridView1);
			}
		}

        private void btnAddBookIssue_Click(object sender, EventArgs e)
        {
			OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

			frmAddBookIssue bookIssue = new frmAddBookIssue();
			using (bookIssue)
			{
				bookIssue.ShowDialog();
			}
			btnSearch.PerformClick();
		}
    }
}
