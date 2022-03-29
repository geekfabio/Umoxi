using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using System.IO;

namespace Umoxi
{
    public partial class usMarks : UserControl
    {
        private string ChekValues;

        public usMarks()
        {
            InitializeComponent();
            DataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView2.Columns[9].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            cmbSearchBy.SelectedIndex = 0;
            LoadData();
        }

        #region instance
        private static usMarks _instance;

        public static usMarks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usMarks();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT  EXAM_ID, ExaminationName  FROM    Examination  WHERE        (Status = 'Sim')", cmbExamination);
        }

        private void Clear()
        {
            txtStuID.Text = null;
            txtStudentName.Text = string.Empty;
            txtSchoolName.Text = null;
            txtSession.Text = null;
            txtClass.Text = null;
            StatusStudent(txtRegistrationStatus, 3);
            // crate blank grid
            ConnectionNode.FillDataGrid(" SELECT        Subject.SUBJECT_ID, Subject.SubjectCode, Subject.SubjectName  FROM            Subject INNER JOIN " + " StudentInformation ON Subject.SCHOOL_ID = StudentInformation.SCHOOL_ID AND Subject.CLASS_ID = StudentInformation.CLASS_ID AND  " + " Subject.BATCH_ID = StudentInformation.BATCH_ID  WHERE        (StudentInformation.STUDENT_ID = 000) ", DataGridView1);

        }

        private void ClearControl()
        {
            LoadMarkSheet(0, 0, 0, 0, 0);

            txtSubjectID.Text = null;
            txtSubjectCode.Text = null;
            txtSubjectName.Text = null;

            txtMaxTheory.Text = null;
            txtMaxPractical.Text = null;
            txtMaxTotalMarks.Text = null;

            txtTheory.Text = null;
            txtPractical.Text = null;
            txtTotalMarks.Text = null;
            txtCredit.Text = null;
            txtGrade.Text = null;
            txtGradePoint.Text = null;

            toggleResult.IsOn = false;
        }
        private void LoadInformationPassed()
        {
            switch (toggleResult.IsOn)
            {
                case true:
                    ChekValues = "Pass";
                    break;
                case false:
                    ChekValues = "Fail";
                    break;
            }
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
                        SqlqueryStudent();
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            //if found this data into database
                            txtStuID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                            txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                            txtSchoolName.Text = ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["School_Name"];
                            txtSession.Text = ConnectionNode.sqlDT.Rows[0]["BATCH_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["BatchName"];
                            txtClass.Text = ConnectionNode.sqlDT.Rows[0]["CLASS_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_name"];
                            if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "Y")
                                StatusStudent(txtRegistrationStatus, 1);
                            else if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "BY")
                                StatusStudent(txtRegistrationStatus, 2);
                            // fill grid using subject code
                            ConnectionNode.FillDataGrid(" SELECT        Subject.SUBJECT_ID, Subject.SubjectCode, Subject.SubjectName  FROM            Subject INNER JOIN " + " StudentInformation ON Subject.SCHOOL_ID = StudentInformation.SCHOOL_ID AND Subject.CLASS_ID = StudentInformation.CLASS_ID AND  " + " Subject.BATCH_ID = StudentInformation.BATCH_ID  WHERE        (StudentInformation.STUDENT_ID = " + txtStuID.Text + ") ", DataGridView1);

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
                        SqlqueryStudent();
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            //if found this data into database
                            txtStuID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                            txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                            txtSchoolName.Text = ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["School_Name"];
                            txtSession.Text = ConnectionNode.sqlDT.Rows[0]["BATCH_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["BatchName"];
                            txtClass.Text = ConnectionNode.sqlDT.Rows[0]["CLASS_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_name"];
                            if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "Y")
                                StatusStudent(txtRegistrationStatus, 1);
                            else if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "BY")
                                StatusStudent(txtRegistrationStatus, 2);
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

        private void StatusStudent(BunifuTextBox textBox, int status)
        {
            #region code
            switch (status)
            {
                case 1:
                    textBox.BorderColorIdle = Color.FromArgb(204, 231, 222);
                    textBox.BorderColorHover = Color.FromArgb(204, 231, 222);
                    textBox.BorderColorActive = Color.FromArgb(204, 231, 222);

                    textBox.OnHoverState.FillColor = Color.FromArgb(204, 231, 222);
                    textBox.OnIdleState.FillColor = Color.FromArgb(204, 231, 222);
                    textBox.OnIdleState.BorderColor = Color.FromArgb(204, 231, 222);

                    textBox.FillColor = Color.FromArgb(204, 231, 222);
                    textBox.ForeColor = Color.FromArgb(0, 135, 90);
                    textBox.Text = "Ative";
                    break;
                case 2:
                    textBox.BorderColorIdle = Color.FromArgb(255, 235, 210);
                    textBox.BorderColorHover = Color.FromArgb(255, 235, 210);
                    textBox.BorderColorActive = Color.FromArgb(255, 235, 210);

                    textBox.OnHoverState.FillColor = Color.FromArgb(255, 235, 210);
                    textBox.OnIdleState.FillColor = Color.FromArgb(255, 235, 210);
                    textBox.OnIdleState.BorderColor = Color.FromArgb(255, 235, 210);

                    textBox.FillColor = Color.FromArgb(255, 235, 210);
                    textBox.ForeColor = Color.FromArgb(255, 153, 31);
                    textBox.Text = "BULK STUDENT / NOT PROMOTED";
                    break;
                default:
                    textBox.BorderColorIdle = Color.FromArgb(204, 204, 204);
                    textBox.BorderColorHover = Color.FromArgb(204, 204, 204);
                    textBox.BorderColorActive = Color.FromArgb(204, 204, 204);

                    textBox.OnHoverState.FillColor = Color.FromArgb(204, 204, 204);
                    textBox.OnIdleState.FillColor = Color.FromArgb(204, 204, 204);
                    textBox.OnIdleState.BorderColor = Color.FromArgb(204, 204, 204);

                    textBox.FillColor = Color.FromArgb(204, 204, 204);
                    textBox.Text = null;
                    break;
            }
            #endregion
        }

        private void SqlqueryStudent()
        {
            //Only find active student
            ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.StudentName, Batch.BATCH_ID,  ClassName.CLASS_ID, SchoolInformation.SCHOOL_ID,  ClassName.Class_name, SchoolInformation.School_Name, Batch.BatchName,  " +
                " StudentInformation.Status  FROM            StudentInformation INNER JOIN SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN " +
                " Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID " +
                " WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ") AND (NOT (StudentInformation.Status = 'N')) ");

        }

        private void GetStudent()
        {
            ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.StudentPicture FROM            StudentInformation INNER JOIN " +
                        " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                        "  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(txtStuID.Text) + ") ");

            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                //if found this data into database
                lblStudentName.Text = txtStudentName.Text;
                lblClasse.Text = txtClass.Text;
                byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["StudentPicture"]);
                MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                PictureBox1.Image = Image.FromStream(stmBLOBData);

                //fill grid using subject code
                ConnectionNode.FillDataGrid(" SELECT        Subject.SUBJECT_ID, Subject.SubjectCode, Subject.SubjectName  FROM            Subject INNER JOIN " +
                    " StudentInformation ON Subject.SCHOOL_ID = StudentInformation.SCHOOL_ID AND Subject.CLASS_ID = StudentInformation.CLASS_ID AND  " +
                    " Subject.BATCH_ID = StudentInformation.BATCH_ID  WHERE        (StudentInformation.STUDENT_ID = " + txtStuID.Text + ") ", DataGridView1);
            }
        }

        private void LoadMarkSheet(double STUDENT_ID, double SCHOOL_ID, double BATCH_ID, double CLASS_ID, double EXAM_ID)
        {
            ConnectionNode.FillDataGrid(" SELECT        StudentResult.RESULT_ID, Subject.SubjectName, StudentResult.TheoryMarks, StudentResult.PracticalMarks, StudentResult.TotalMarks, StudentResult.Credit,  " + " StudentResult.Grade, StudentResult.GradePoint, StudentResult.ResultStatus  FROM            StudentResult INNER JOIN   Subject ON StudentResult.SUBJECT_ID = Subject.SUBJECT_ID " + " WHERE        (StudentResult.STUDENT_ID = " + STUDENT_ID + ") AND (StudentResult.SCHOOL_ID = " + SCHOOL_ID + ") AND (StudentResult.BATCH_ID = " + BATCH_ID + ") AND (StudentResult.CLASS_ID = " + CLASS_ID + ") AND   (StudentResult.EXAM_ID = " + EXAM_ID + ")  ORDER BY Subject.Sub_Order ", DataGridView2);
        }

        private void ViewButton(bool status)
        {
            switch (status)
            {
                case true:
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                    break;
                case false:
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    break;
            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
                ViewButton(false);
            }
            else if (NavigationBar.SelectedItem == tabMarks)
            {
                if (string.IsNullOrEmpty(txtStudentName.Text))
                {
                    ViewButton(false);
                    Snackbar.Show(FrmMain.Default, "Required: Student", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                {
                    GetStudent();
                    ViewButton(true);
                    TabContent.SelectedTabPage = Page2;
                }
            }
        }

        private void cmbExamination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStuID.Text))
            {
                LoadMarkSheet(double.Parse(txtStuID.Text), Convert.ToDouble(txtSchoolName.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(txtSession.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(txtClass.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(cmbExamination.Text.Split(" # ".ToCharArray()[0])[0]));
                txtMaxTheory.Focus();
            }
        }

        private void txtTheory_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtTheory.Text))
                txtTotalMarks.Text = "0";
            else if (!Information.IsNumeric(txtPractical.Text))
                txtTotalMarks.Text = "0";
            else
                txtTotalMarks.Text = Convert.ToString(Conversion.Val(txtTheory.Text) + Conversion.Val(txtPractical.Text));
        }

        private void txtPractical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                txtCredit.Focus();
        }

        private void txtPractical_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtTheory.Text))
                txtTotalMarks.Text = "0";
            else if (!Information.IsNumeric(txtPractical.Text))
                txtTotalMarks.Text = "0";
            else
                txtTotalMarks.Text = Convert.ToString(Conversion.Val(txtTheory.Text) + Conversion.Val(txtPractical.Text));
        }

        private void txtMaxTheory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                txtMaxPractical.Focus();
        }

        private void txtMaxTheory_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtMaxTheory.Text))
                txtMaxTotalMarks.Text = "0";
            else if (!Information.IsNumeric(txtMaxPractical.Text))
                txtMaxTotalMarks.Text = "0";
            else
                txtMaxTotalMarks.Text = Convert.ToString(Conversion.Val(txtMaxTheory.Text) + Conversion.Val(txtMaxPractical.Text));

        }

        private void txtMaxPractical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                txtTheory.Focus();
        }

        private void txtMaxPractical_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtMaxTheory.Text))
                txtMaxTotalMarks.Text = "0";
            else if (!Information.IsNumeric(txtMaxPractical.Text))
                txtMaxTotalMarks.Text = "0";
            else
                txtMaxTotalMarks.Text = Convert.ToString(Conversion.Val(txtMaxTheory.Text) + Conversion.Val(txtMaxPractical.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                toggleResult.Focus();
        }

        private void toggleResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnSave.PerformClick();
        }

        private void txtTotalMarks_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalMarks.Text))
            {
                txtGrade.Text = "-";
                txtGradePoint.Text = "0";
            }
            else
            {
                //get grading porint and gpa
                ConnectionNode.ExecuteSQLQuery("SELECT *  FROM   GradingLevel");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    for (int i = 0; i <= ConnectionNode.sqlDT.Rows.Count - 1; i++)
                    {
                        if (Conversion.Val(txtTotalMarks.Text) <= Convert.ToDouble(ConnectionNode.sqlDT.Rows[i]["MarkTo"]) && Conversion.Val(txtTotalMarks.Text) >= Convert.ToDouble(ConnectionNode.sqlDT.Rows[i]["MarkFrom"]))
                        {
                            txtGrade.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[i]["Grade"]);
                            txtGradePoint.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[i]["GPA"]);
                        }
                    }
                }
                else
                {
                    txtGrade.Text = "-";
                    txtGradePoint.Text = "0";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadInformationPassed();
            if (string.IsNullOrEmpty(cmbExamination.Text))
                Snackbar.Show(FrmMain.Default, "Required: Examination", BunifuSnackbar.MessageTypes.Error);
            else if (string.IsNullOrEmpty(txtSubjectID.Text))
                Snackbar.Show(FrmMain.Default, "Required: Subject", BunifuSnackbar.MessageTypes.Error);
            else if (!Information.IsNumeric(txtMaxTheory.Text))
                Snackbar.Show(FrmMain.Default, "Required: Maximum Theory Marks", BunifuSnackbar.MessageTypes.Error);
            else if (!Information.IsNumeric(txtMaxPractical.Text))
                Snackbar.Show(FrmMain.Default, "Required: Practical Marks", BunifuSnackbar.MessageTypes.Error);
            else if (!Information.IsNumeric(txtTheory.Text))
                Snackbar.Show(FrmMain.Default, "Required: Maximum Theory Marks", BunifuSnackbar.MessageTypes.Error);
            else if (!Information.IsNumeric(txtPractical.Text))
                Snackbar.Show(FrmMain.Default, "Required: Practical Marks", BunifuSnackbar.MessageTypes.Error);
            else if (string.IsNullOrEmpty(txtGradePoint.Text))
                Snackbar.Show(FrmMain.Default, "Required: Grade Point", BunifuSnackbar.MessageTypes.Error);
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO StudentResult (STUDENT_ID, SCHOOL_ID, BATCH_ID, CLASS_ID, EXAM_ID, SUBJECT_ID, TheoryMarks, PracticalMarks, TotalMarks, MaxTheoryMarks, MaxPracticalMarks, MaxTotalMarks, Credit, Grade, GradePoint, ResultStatus,   EntryDateTime, User_ID) VALUES ( " +
                    " " + txtStuID.Text + " , " + txtSchoolName.Text.Split(" # ".ToCharArray()[0])[0] + ",  " + txtSession.Text.Split(" # ".ToCharArray()[0])[0] + ", " + txtClass.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbExamination.Text.Split(" # ".ToCharArray()[0])[0] + ", " + txtSubjectID.Text.Split(" # ".ToCharArray()[0])[0] + ", " + Convert.ToString(UtilitiesFunctions.str_repl(txtTheory.Text)) + ", " + Convert.ToString(UtilitiesFunctions.str_repl(txtPractical.Text)) + " , " + Convert.ToString(UtilitiesFunctions.str_repl(txtTotalMarks.Text)) + " ,   " +
                    " " + Convert.ToString(UtilitiesFunctions.str_repl(txtMaxTheory.Text)) + ", " + Convert.ToString(UtilitiesFunctions.str_repl(txtMaxPractical.Text)) + " , " + Convert.ToString(UtilitiesFunctions.str_repl(txtMaxTotalMarks.Text)) + " , " +
                    " '" + Convert.ToString(UtilitiesFunctions.str_repl(txtCredit.Text)) + ("'  ,  '" + UtilitiesFunctions.str_repl(txtGrade.Text) + "', ") + Convert.ToString(UtilitiesFunctions.str_repl(txtGradePoint.Text)) + (", '" + ChekValues + "', '") + Strings.Format(DateTime.Now.ToLongTimeString()) + "', " + Convert.ToString(ConnectionNode.userID) + " )");
                
                LoadMarkSheet(double.Parse(txtStuID.Text), Convert.ToDouble(txtSchoolName.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(txtSession.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(txtClass.Text.Split(" # ".ToCharArray()[0])[0]), Convert.ToDouble(cmbExamination.Text.Split(" # ".ToCharArray()[0])[0]));

                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success, 5000, "Imprimir").Then((result) =>
                {
                    if (result == BunifuSnackbar.SnackbarResult.ActionClicked)
                        PreviewMarkSheet();
                });
            }
        }

        private void toggleResult_Toggled(object sender, EventArgs e)
        {
            LoadInformationPassed();
        }

        private void PreviewMarkSheet()
        {
            ConnectionNode.ExecuteSQLQuery("SELECT  *  FROM  StudentInformation  WHERE        (STUDENT_ID =" + Convert.ToString(UtilitiesFunctions.str_repl(txtStuID.Text)) + ")");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                double SCHOOL_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"]);
                double CLASS_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["CLASS_ID"]);
                double BATCH_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BATCH_ID"]);
                //Report.Print_Preview_Marksheet(System.Convert.ToDouble(UtilitiesFunctions.str_repl(txtStudentID.Text)), SCHOOL_ID, BATCH_ID, CLASS_ID, System.Convert.ToDouble(cmbExamination.Text.Split(" # ".ToCharArray()[0])[0]));
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    txtSubjectID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                    txtSubjectCode.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                    txtSubjectName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[3].Value);
                    break;
            }
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to delete " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" DELETE FROM   StudentResult  WHERE        (RESULT_ID = " + Convert.ToString(DataGridView2.CurrentRow.Cells[1].Value) + ")");
                        LoadMarkSheet(0, 0, 0, 0, 0);
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Delete"), BunifuSnackbar.MessageTypes.Information);
                    }
                    break;
            }
        }

    }
}
