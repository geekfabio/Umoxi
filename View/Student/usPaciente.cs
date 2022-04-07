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
            //Estado = Internado, Atendido, Recuperado, Cadastrado
            try { 
                ConnectionNode.sqlString = "SELECT `paciente_id`, `nome`, `contactos`, `genero`,  `data_cadastro`, `data_nascimento`, `parente_nome` FROM `pacientes` WHERE estado_eliminado = 'Não'";
                ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            }
            finally { 
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                    lblCount.Text = "Total : " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  Paciente(s).";
                else
                    lblCount.Text = "Nenhum Paciente encontrado.";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                string searchTxt = UtilitiesFunctions.str_repl(txtSearch.Text).ToString();
                ConnectionNode.sqlString = "SELECT `paciente_id`, `nome`, `contactos`, `genero`,  `data_cadastro`, `data_nascimento`, `parente_nome`, FROM `pacientes` WHERE Nome LIKE \'%" + searchTxt + "%\' OR parente_nome LIKE \'%" + searchTxt + "%\'  OR data_cadastro LIKE \'%" + searchTxt + "%\' OR  data_nascimento LIKE \'%" + searchTxt + "%\' AND estado_internado = 'Não'  ";
                ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    lblCount.Text = "Total: " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + "  Paciente(s).";
                }
                else
                {
                    lblCount.Text = "Nenhum paciente encontrado.";
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
            if(DataGridView1.Rows.Count > 0)
            UtilitiesFunctions.ExportDataToExcelSheet(DataGridView1);
         

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            switch (e.ColumnIndex)
            {
                case 0:
                    #region Edit
                    //TODO implement genero da paciente 
                    if (MessageBox.Show("Deseja editar os dados do Paciente " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    //ConnectionNode.ExecuteSQLQuery(" SELECT        StudentInformation.STUDENT_ID, StudentInformation.AdmissionNo, StudentInformation.AdmisionDate, StudentInformation.SCHOOL_ID, " +
                    //    " SchoolInformation.School_Name, StudentInformation.BATCH_ID, Batch.BatchName, StudentInformation.CLASS_ID, ClassName.Class_name, " +
                    //    " StudentInformation.StudentName, StudentInformation.Gender, StudentInformation.DateOfBirth, StudentInformation.PresentAddress, " +
                    //    " StudentInformation.PermanentAddress, StudentInformation.Nationality, StudentInformation.ContactNO, StudentInformation.Email, StudentInformation.Religion, " +
                    //    " StudentInformation.BloodGroup, StudentInformation.Height, StudentInformation.Weight, StudentInformation.SpecialNote, StudentInformation.ReferenceName, " +
                    //    " StudentInformation.ReferenceContactNo, StudentInformation.Status, StudentInformation.StudentPicture FROM            StudentInformation INNER JOIN " +
                    //    " SchoolInformation ON StudentInformation.SCHOOL_ID = SchoolInformation.SCHOOL_ID INNER JOIN Batch ON StudentInformation.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                    //    "  ClassName ON StudentInformation.CLASS_ID = ClassName.CLASS_ID WHERE        (StudentInformation.STUDENT_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") ");
                    ConnectionNode.ExecuteSQLQuery("SELECT `paciente_id`, `nome`, `data_nascimento`, `foto`, `contactos`, `email`, `genero`, `estado_civil`, `grupo_sangue`, `endereco`, `parente_nome`, `parente_contacto`, `parente_endereco`, `alergias_conhecidas`, `data_cadastro`, `nota`, `estado_internado`, `estado_eliminado` FROM `pacientes` WHERE estado_eliminado = 'Não'");
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                    
                        txtAdmissionNO.Text = "Processo: #" + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["paciente_id"]);
                        txtStudentName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nome"]);
                        cmbGender.Text = "Gênero: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["genero"]);
                        dtpDateOfBirth.Text = "Nascimento: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["data_nascimento"]);
                        txtPresentAddress.Text = "Morada: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["endereco"]);
                      //  cmbNationality.Text = "Nacionalidade: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nacionalidade"]);
                        txtContactNo.Text = "Contacto: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Contactos"]);
                        txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["email"]);
                        cmbBloodGroup.Text = "Tipo sanguíneo: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["grupo_sangue"]);
                        txtHeight.Text = "Altura: 1.78m";
                        txtWeight.Text = "Peso: 50kg" ;
                        if (File.Exists(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"])))
                            PictureBox1.Image = Image.FromFile(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]));
                        else
                            PictureBox1.Image = Umoxi.Properties.Resources.icons8_image_240;
                        cmbSchool.Text = "Parente: "  ;
                        cmbSession.Text = "Contacto: "  ;
                        cmbClass.Text = "Endereco: " ;

                    }
                    #endregion
                    break;
            }
        }

        private void usStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
