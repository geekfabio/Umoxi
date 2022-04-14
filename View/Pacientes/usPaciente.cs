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
    public partial class usPaciente : UserControl
    {
        public usPaciente()
        {
            InitializeComponent();
           
        }

        #region instance
        private static usPaciente _instance;

        public static usPaciente Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usPaciente();
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

            frmAddPaciente student = new frmAddPaciente();
            using (student)
            {
                student.ShowDialog();
            }
            LoadData();
        }

        void GetInfo()
        {
            ConnectionNode.ExecuteSQLQuery("SELECT `paciente_id`, `nome`, `data_nascimento`, `foto`, `contactos`, `email`, `genero`, `nacionalidade`, `grupo_sangue`, `endereco`, `parente_nome`, `parente_contacto`, `parente_endereco`, `alergias_conhecidas`, `data_cadastro`, `nota`, `estado_internado`, `estado_eliminado` FROM `pacientes` WHERE estado_eliminado = 'Não' AND paciente_id ='"+ Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + "'");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                txtPacienteNome.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nome"]);
                cmbGender.Text = "Gênero: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["genero"]);
                dtpDateOfBirth.Text = "Nascimento: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["data_nascimento"]);
                txtPresentAddress.Text = "Morada: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["endereco"]);
                cmbNationality.Text = "Nacionalidade: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nacionalidade"]);
                txtContactNo.Text = "Contacto: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Contactos"]);
                txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["email"]);
                cmbBloodGroup.Text = "Tipo sanguíneo: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["grupo_sangue"]);
                txtHeight.Text = "Altura: 1.78m";
                txtWeight.Text = "Peso: 50kg";
                if (File.Exists(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"])))
                {
                    PictureBox1.Image = Image.FromFile(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]));
                }
                else
                {
                    PictureBox1.Image = Umoxi.Properties.Resources.icons8_image_240;
                  
                }
                txtParente.Text = "Parente: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["parente_nome"]); ;
                txtParenteContacto.Text = "Contacto: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["parente_contacto"]); ; ;
                txtEnderecoParente2.Text = "Endereco: " + Convert.ToString(ConnectionNode.sqlDT.Rows[0]["parente_endereco"]);

            }
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
                        ConnectionNode.ExecuteSQLQuery("SELECT * FROM PACIENTES WHERE paciente_id = '" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + "' ");

                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddPaciente addPaciente = new frmAddPaciente();

                            addPaciente.pacienteID = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["paciente_id"]); ;
                            addPaciente.txtPaciente.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nome"]);
                            addPaciente.cmbGender.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["genero"]);
                            addPaciente.dtpDateOfBirth.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["data_nascimento"]);
                            addPaciente.cmbNationality.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nacionalidade"]);
                            addPaciente.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["contactos"]);
                            addPaciente.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                            addPaciente.cmbBloodGroup.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["grupo_sangue"]);
                            //addPaciente.txtHeight.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Height"]);
                           // addPaciente.txtWeight.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Weight"]);
                            addPaciente.txtSpecialNote.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nota"]);
                            addPaciente.btnSave.Text = "Atualizar";
                            if (File.Exists(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"])))
                            {
                               
                                addPaciente.userPhoto = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]);
                                addPaciente.PictureBox1.Image = Image.FromFile(addPaciente.userPhoto);
                            }
                            else
                            {
                                addPaciente.userPhoto = "sem_foto";
                            }
                            //PARENTE
                            addPaciente.txtFathersName.Text = "";
                            addPaciente.txtAddress.Text = "";
                            addPaciente.txtContactNoParent.Text = "";
                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (addPaciente) { addPaciente.ShowDialog(); }                         
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
                    GetInfo();
                    #endregion
                    break;
            }
        }


        private void usPaciente_Load(object sender, EventArgs e)
        {
            if(ConnectionNode.userFuncao == "Administrador")
            {
                btnDelete.Visible = false;
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


        private void DataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            GetInfo();
        }
    }
}
