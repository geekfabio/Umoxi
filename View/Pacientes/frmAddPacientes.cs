using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraBars.Navigation;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using System.IO;

namespace Umoxi
{
    public partial class frmAddPaciente : Form
    {
        public string userPhoto = "";
        public string pacienteID = "";
        public frmAddPaciente()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        #region DontMove
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        #endregion

        private void LoadData()
        {
            txtPaciente.Focus();
        }


        private void frmAddPaciente_Load(object sender, EventArgs e)
        {
            switch (btnSave.Text)
            {
                case "Adicionar":
                    break;
                case "Atualizar":
                    LoadData();
                    break;
            }
            txtPaciente.Focus();
        }


        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Imagem (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
                userPhoto = Path.Combine(OpenFileDialog1.FileName);
            }
        }

        void ClearTextBoxs()
        {
            txtPaciente.Clear();
            //TODO implemtar outras texts Boxs
        }
        bool ValidaCamposVazios()
        {
            if (!string.IsNullOrWhiteSpace(txtHeight.Text))
            {
            }
            else if (txtPaciente.Text.Length < 2)
            {
                
            }
            return true;
        }
        private bool ValidaCampos()
        {

            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                NavigationBar.SelectedItem = tabItemPaciente;
                TransitionsEffects.ShowTransition(txtPaciente, lblStudentName);
                Snackbar.Show(this, "Nome do paciente ", BunifuSnackbar.MessageTypes.Error);
              
                return false;
            }
            else if (txtPaciente.Text.Length < 2)
            {
                NavigationBar.SelectedItem = tabItemPaciente;
                TransitionsEffects.ShowTransition(txtPaciente, lblStudentName);
                Snackbar.Show(this, "o Nome é muito curto", BunifuSnackbar.MessageTypes.Error);
            
                return false;
            }
            else if (!txtPaciente.Text.Contains(" "))
            {
              
                NavigationBar.SelectedItem = tabItemPaciente;
                TransitionsEffects.ShowTransition(txtPaciente, lblStudentName);
                Snackbar.Show(this, "É Necessário o nome completo do Paciente", BunifuSnackbar.MessageTypes.Error);
                return false;
            }
            else if (!ValidaCamposVazios())
            {
                return false;
            }
            else { 
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtPaciente, lblStudentName);
          
            if (!ValidaCampos()) return;
            else { 
            
                if (string.IsNullOrEmpty(cmbBloodGroup.Text))
                    cmbBloodGroup.Text = "";
                if (!File.Exists(userPhoto)) userPhoto = "sem_foto";
                switch (btnSave.Text)
                {
                    case "Adicionar":
                        
                        ConnectionNode.ExecuteCommad("INSERT INTO " +
                            "`pacientes`(`nome`, `data_nascimento`," +
                            " `foto`, `contactos`, `email`," +
                            " `genero`, `nacionalidade`, `grupo_sangue`," +
                            "`endereco`, `parente_nome`, `parente_contacto`," +
                            "`parente_endereco`, `nota`" + ") " +
                            "VALUES ('"+ txtPaciente.Text+"','"+ dtpDateOfBirth.Text +"'," +
                            "'"+userPhoto+"','"+txtContactNo.Text +"','"+ txtEmail.Text +"','"+cmbGender.Text+"'," +
                            "'"+cmbNationality.Text+"','"+cmbBloodGroup.Text+ "','"+txtPresentAddress.Text+"','"+txtFathersName.Text+"'," +
                            "'"+txtContactNoParent.Text+ "','" + txtAddress.Text + "','" + txtSpecialNote.Text + "')");
                        Snackbar.Show(this, "Paciente " + txtPaciente.Text + " adicionado", BunifuSnackbar.MessageTypes.Success);
                        ConnectionNode.ExecuteSQLQuery("SELECT paciente_id FROM pacientes ORDER BY paciente_id DESC");
                        double id = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["paciente_id"]);
                        //upload image
                        ConnectionNode.UploadPacientePhoto(id, userPhoto);
                        //Log user
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Paciente: " + txtPaciente.Text + " adicionado por " + ConnectionNode.userName);
                        ClearTextBoxs();
                        break;
                    case "Atualizar":

                        ConnectionNode.ExecuteCommad("UPDATE " +
                            "`pacientes` SET `nome`='" + txtPaciente.Text + "', `data_nascimento`='" + dtpDateOfBirth.Text + "'," +
                            "`contactos`= '" + txtContactNo.Text + "', `email`='" + txtEmail.Text + "'," +
                            " `genero`='" + cmbGender.Text + "', `nacionalidade` = '" + cmbNationality.Text + "', `grupo_sangue` = '" + cmbBloodGroup.Text + "'," +
                            "`endereco` = '" + txtPresentAddress.Text + "', `parente_nome` = '" + txtFathersName.Text + "', `parente_contacto`= '" + txtContactNoParent.Text + "'," +
                            "`parente_endereco` = '" + txtAddress.Text + "', `nota` = '" + txtSpecialNote.Text + "' Where `paciente_id` = '" + pacienteID+"' ");
                        if (File.Exists(userPhoto))
                        {
                            ConnectionNode.UploadPacientePhoto(double.Parse(pacienteID), userPhoto);
                        }
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Paciente: " + txtPaciente.Text + " Atualizado por " + ConnectionNode.userName);

                        this.Close();

                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }
        

        private void NavigationBar_SelectedItemChanged(object sender, NavigationBarItemEventArgs e)
        {
            
             if (NavigationBar.SelectedItem == tabItemParents)
             {
              
                 TabContent.SelectedTabPage = tabParentes;
            }
            else
            {
                TabContent.SelectedTabPage = tabInfo;
            }
           
        }

    
       private void btnParentDetails_Click(object sender, EventArgs e)
       {
            
       }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddPaciente_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

        private void NavigationBar_Click(object sender, EventArgs e)
        {

        }

    
        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
          
        
        }

        private void timerToFocusTextBox_Tick(object sender, EventArgs e)
        {
            txtPaciente.Focus();
            timerToFocusTextBox.Dispose();
        }
    }
}
