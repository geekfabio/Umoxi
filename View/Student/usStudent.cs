using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usStudent : UserControl
    {
        public usStudent()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView1.Columns[9].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            cmbSearchBy.SelectedIndex = 3;
        }

        #region instance
        private static usStudent _instance;

        public static usStudent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usStudent();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.sqlString = " SELECT StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                "ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                " StudentInformation.Status FROM StudentInformation INNER JOIN " +
                " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID ";
            ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
            }
            else
            {
                lblCount.Text = "Nenhum estudante encontrado.";
            }
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
                            ConnectionNode.sqlString = " SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                                " ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                                " StudentInformation.Status FROM            StudentInformation INNER JOIN " +
                                "  SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID " +
                                " WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ") ";
                            ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                            if (ConnectionNode.sqlDT.Rows.Count > 0)
                            {
                                lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
                            }
                            else
                            {
                                lblCount.Text = "Nenhum estudante encontrado.";
                            }
                        }
                        #endregion
                        break;
                    case "Admission":
                        #region No Add
                        //search by admission no
                        ConnectionNode.sqlString = " SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                            " ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                            " StudentInformation.Status FROM            StudentInformation INNER JOIN " +
                            "  SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID " +
                            "  WHERE  (StudentInformation.AdmissionNo LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
                        }
                        else
                        {
                            lblCount.Text = "Nenhum estudante encontrado.";
                        }
                        #endregion
                        break;
                    case "Name":
                        #region name
                        //search by student name
                        ConnectionNode.sqlString = " SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                            " ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                            " StudentInformation.Status FROM            StudentInformation INNER JOIN " +
                            "  SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID " +
                            "  WHERE  (StudentInformation.StudentName LIKE '%" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
                        }
                        else
                        {
                            lblCount.Text = "Nenhum estudante encontrado.";
                        }
                        #endregion
                        break;
                    case "Number":
                        #region Contact
                        //search by contact no
                        ConnectionNode.sqlString = " SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                            " ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                            " StudentInformation.Status FROM            StudentInformation INNER JOIN " +
                            " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID " +
                            " WHERE  (StudentInformation.ContactNO LIKE '%" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
                        }
                        else
                        {
                            lblCount.Text = "Nenhum estudante encontrado.";
                        }
                        #endregion
                        break;
                    case "Email":
                        #region Mail
                        //search by email
                        ConnectionNode.sqlString = " SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.StudentName,  " +
                            " ClassName.Class_name, Batch.BatchName, StudentInformation.Gender, " +
                            " StudentInformation.Status FROM            StudentInformation INNER JOIN " +
                            " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID " +
                            " WHERE  (StudentInformation.Email LIKE '%" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  estudante(s).";
                        }
                        else
                        {
                            lblCount.Text = "Nenhum estudante encontrado.";
                        }
                        #endregion
                        break;
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddSchool_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddStudent student = new frmAddStudent();
            using (student)
            {
                student.ShowDialog();
            }
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            UtilitiesFunctions.ExportDataToExcelSheet(DataGridView1);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                    #region Edit
                    if (MessageBox.Show("Deseja editar os dados do estudante " + Convert.ToString(DataGridView1.CurrentRow.Cells[5].Value) + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.SCHOOL_ID, " +
                        " SchoolInformation.School_Name, StudentInformation.BATCH_ID, Batch.BatchName, StudentInformation.CLASS_ID, ClassName.Class_name, " +
                        " StudentInformation.StudentName, StudentInformation.Gender, StudentInformation.DateOfBirth, StudentInformation.PresentAddress, " +
                        " StudentInformation.PermanentAddress, StudentInformation.Nationality, StudentInformation.ContactNO, StudentInformation.Email, StudentInformation.Religion, " +
                        " StudentInformation.BloodGroup, StudentInformation.Height, StudentInformation.Weight, StudentInformation.SpecialNote, StudentInformation.ReferenceName, " +
                        " StudentInformation.ReferenceContactNo, StudentInformation.Status, StudentInformation.StudentPicture FROM            StudentInformation INNER JOIN " +
                        " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                        "  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") ");

                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddStudent student = new frmAddStudent();

                            double SCHOOL_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"]);
                            string School_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                            double BATCH_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BATCH_ID"]);
                            string BatchName = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BatchName"]);
                            double CLASS_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["CLASS_ID"]);
                            string Class_name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);

                            student.txtStudentID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                            student.txtAdmissionNO.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AdmissionNo"]);
                            student.dtpAdmissionDate.DateTime = (DateTime)(ConnectionNode.sqlDT.Rows[0]["AdmisionDate"]);
                            student.txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                            student.cmbGender.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Gender"]);
                            student.dtpDateOfBirth.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["DateOfBirth"]);
                            student.txtPresentAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PresentAddress"]);
                            student.cmbNationality.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Nationality"]);
                            student.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNO"]);
                            student.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                            student.cmbBloodGroup.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BloodGroup"]);
                            student.txtHeight.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Height"]);
                            student.txtWeight.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Weight"]);
                            student.txtSpecialNote.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SpecialNote"]);
                            
                            byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["StudentPicture"]);
                            MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                            student.PictureBox1.Image = Image.FromStream(stmBLOBData);
                            if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "Y")
                            {
                                student.rbActive.Checked = true;
                            }
                            else if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "BY")
                            {
                                student.rbBulkActive.Checked = true;
                            }
                            else if ((string)ConnectionNode.sqlDT.Rows[0]["Status"] == "N")
                            {
                                student.rbDeActive.Checked = true;
                            }

                            student.cmbSchool.Text = SCHOOL_ID + " # " + School_Name;
                            student.cmbSession.Text = BATCH_ID + " # " + BatchName;
                            student.cmbClass.Text = CLASS_ID + " # " + Class_name;

                            student.btnSave.Text = "Atualizar";

                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (student)
                            {
                                student.ShowDialog();
                            }
                            LoadData();
                            #endregion

                        }
                    }
                    #endregion
                    break;
                default:
                    #region View
                    ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.SCHOOL_ID, " +
                        " SchoolInformation.School_Name, StudentInformation.BATCH_ID, Batch.BatchName, StudentInformation.CLASS_ID, ClassName.Class_name, " +
                        " StudentInformation.StudentName, StudentInformation.Gender, StudentInformation.DateOfBirth, StudentInformation.PresentAddress, " +
                        " StudentInformation.PermanentAddress, StudentInformation.Nationality, StudentInformation.ContactNO, StudentInformation.Email, StudentInformation.Religion, " +
                        " StudentInformation.BloodGroup, StudentInformation.Height, StudentInformation.Weight, StudentInformation.SpecialNote, StudentInformation.ReferenceName, " +
                        " StudentInformation.ReferenceContactNo, StudentInformation.Status, StudentInformation.StudentPicture FROM            StudentInformation INNER JOIN " +
                        " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                        "  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") ");

                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                        string School_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                        string BatchName = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BatchName"]);
                        string Class_name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);

                        txtAdmissionNO.Text = "Processo: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AdmissionNo"]);
                        txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["StudentName"]);
                        cmbGender.Text = "Gênero: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Gender"]);
                        dtpDateOfBirth.Text = "Nascimento: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["DateOfBirth"]);
                        txtPresentAddress.Text = "Morada: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PresentAddress"]);
                        cmbNationality.Text = "Nacionalidade: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Nationality"]);
                        txtContactNo.Text = "Contacto: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNO"]);
                        txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                        cmbBloodGroup.Text = "Tipo sanguenio: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BloodGroup"]);
                        txtHeight.Text = "Altura: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Height"]);
                        txtWeight.Text = "Peso: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Weight"]);
                        byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["StudentPicture"]);
                        MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                        PictureBox1.Image = Image.FromStream(stmBLOBData);
                        
                        cmbSchool.Text = "Escola: " + School_Name;
                        cmbSession.Text = "Sessão: " + BatchName;
                        cmbClass.Text = "Classe: " + Class_name;

                    }
                    #endregion
                    break;
            }
        }

    }
}
