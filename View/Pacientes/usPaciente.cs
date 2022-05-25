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
        string pacienteID = string.Empty;
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
                ConnectionNode.sqlString = "SELECT `paciente_id`, `nome`, `contactos`, `genero`,  `data_cadastro`, `data_nascimento`, `parente_nome` FROM `pacientes` WHERE estado_eliminado = '0'";
                ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            }
            finally { 
                if (DataGridView1.RowCount > 0)
                    lblCount.Text = "Total : " + DataGridView1.RowCount + "  Paciente(s).";
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
                ConnectionNode.sqlString = "SELECT `paciente_id`, `nome`, `contactos`, `genero`,  `data_cadastro`, `data_nascimento`, `parente_nome` FROM `pacientes` WHERE estado_eliminado ='0' AND Nome LIKE \'%" + searchTxt + "%\' OR parente_nome LIKE \'%" + searchTxt + "%\'  OR data_cadastro LIKE \'%" + searchTxt + "%\' OR  data_nascimento LIKE \'%" + searchTxt + "%\'";
                ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
           
                if (DataGridView1.RowCount > 0)
                {
                    lblCount.Text = "Total: " + DataGridView1.RowCount + "  Paciente(s).";
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
            if(DataGridView1.RowCount > 0)
            {    
                ConnectionNode.ExecuteSQLQuery("SELECT `paciente_id`, `nome`, `data_nascimento`, `foto`, `contactos`, `email`, `genero`, `nacionalidade`, `grupo_sangue`, `endereco`, `parente_nome`, `parente_contacto`, `parente_endereco`, `alergias_conhecidas`, `data_cadastro`, `nota`, `estado_internado`, `estado_eliminado` FROM `pacientes` WHERE estado_eliminado = '0' AND paciente_id ='"+ Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + "'");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    pacienteID = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["paciente_id"]);
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



        private void DataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            //TODO IMPLEMENT GENERO FOR PACIENTE
            if (MessageBox.Show("Dejesa realmente eliminar o paciente?", "Paciente", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ConnectionNode.ExecuteCommad("UPDATE `pacientes` SET `estado_eliminado`='1' WHERE paciente_id = '" + pacienteID + "'");
                LoadData();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (frmViewPhoto frmPhoto = new frmViewPhoto()) {
                frmPhoto.bunifuPictureBox1.Image = PictureBox1.Image;
                frmPhoto.ShowDialog(); }       
           
        }
    }
}
