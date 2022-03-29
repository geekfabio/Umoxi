using System;
using System.Drawing;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;
using PasswordStrengthControlLib;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;

namespace Umoxi
{
    public partial class FrmFirstOpen : Form
    {
        readonly Timer tickToAppRestart = new Timer();
        string chkVAL;
        string userPhoto = "";
        string companyPhoto = "";
        public FrmFirstOpen()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        private void FrmUserRegistration_Load(object sender, EventArgs e)
        {
            stepProgress.SelectedItemIndex = -1;
            txtPass_TextChanged(null, null);
            txtUserID.Visible = false;

            txtAddress.Text = "Luanda";
            txtContactNo.Text = "000";
            txtUserName.Text = "adb";
            txtEmail.Text = "luanda@gmail.com";
            txtPassword.Text = "000123";
            txtRePassword.Text = "000123";
            txtuserFullName.Text = "ADR MMU T";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
          
            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtuserFullName, lbluserFullName);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);
            TransitionsEffects.ResetColor(txtEmail, lblEmail);
            TransitionsEffects.ResetColor(txtPassword, lblPassword);

                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    Snackbar.Show(this, "Usuário é Obrigatório", BunifuSnackbar.MessageTypes.Error);
                    TransitionsEffects.ShowTransition(txtUserName, lblUserName);
                }
                else if (string.IsNullOrWhiteSpace(txtuserFullName.Text))
                {
                    Snackbar.Show(this, "Nome completo é um campo Obrigatório", BunifuSnackbar.MessageTypes.Error);
                    TransitionsEffects.ShowTransition(txtuserFullName, lbluserFullName);
                }
                else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    Snackbar.Show(this, "Contacto Obrigatório", BunifuSnackbar.MessageTypes.Error);
                    TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                }
                else if (!UtilitiesFunctions.EmailCheck(txtEmail.Text.Trim()))
                {
                    Snackbar.Show(this, "Email Incorreto", BunifuSnackbar.MessageTypes.Error);
                    TransitionsEffects.ShowTransition(txtEmail, lblEmail);
                }
                else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    Snackbar.Show(this, "Palavra-passe Obrigatório", BunifuSnackbar.MessageTypes.Error);
                    TransitionsEffects.ShowTransition(txtPassword, lblPassword);
                }
                else
                {
                    if (passwordStrengthControl1.StrengthText == "Curta")
                    {
                        Snackbar.Show(this, "Senha curta, tente outra!", BunifuSnackbar.MessageTypes.Warning);
                    }
                    //pode aceitar senhas fracas
                   // else if (passwordStrengthControl1.StrengthText == "Fraca")
                   // {
                   //     Snackbar.Show(this, "Senha fraca, tente outra!", BunifuSnackbar.MessageTypes.Warning);
                   // }
                    else
                    {
                        if (txtPassword.Text == txtRePassword.Text)
                        {
                            chkVAL = "Y";
                            TabContent.SelectedTabPage = Page2;
                            stepProgress.SelectedItemIndex = 0;
                        }
                        else
                            Snackbar.Show(this, "As senhas não conscidem!", BunifuSnackbar.MessageTypes.Error);

                    }
                }
            
          
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page1;
            stepProgress.SelectedItemIndex = 0;
        }


        private void btnNext2_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page3;
            stepProgress.SelectedItemIndex = 2;
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Imagem (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
                userPhoto = Path.Combine(OpenFileDialog1.FileName);
            }
           
        }

            private void btnReturnP_Click(object sender, EventArgs e)
        {
            TabContent.SelectedTabPage = Page1;
            stepProgress.SelectedItemIndex = -1;
        }

        private void btnNextP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja confirmar os dados da usuario " + txtUserName.Text + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TabContent.SelectedTabPage = Page3;
                stepProgress.SelectedItemIndex = 1;
                txtHospitalName.Focus();
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            int x = PasswordStregthManager.Instance.GetPasswordScore(txtUserName.Text, txtPassword.Text);
            string str = PasswordStregthManager.Instance.GetPasswordStrength(txtUserName.Text, txtPassword.Text);
            Color col = PasswordStregthManager.Instance.GetPasswordColor(txtUserName.Text, txtPassword.Text);
            this.SetPasswordControls(this.passwordStrengthControl1, x, str, Color.Black, col); //"Forca: " +
        }

        private void SetPasswordControls(PasswordStrengthControl cont, int s, string text, Color f, Color b)
        {
            cont.Strength = s;
            cont.SolidColor = b;
            cont.ForeColor = f;
            cont.StrengthText = text;
        }

        private void chkFinish_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkFinish.Checked == true)
                btnSave.Enabled = true;
            else
            {
                btnSave.Enabled = false;
                Snackbar.Show(this, "Não pode utilizar o software\nsem aceitar os nossos termos e Condições!", BunifuSnackbar.MessageTypes.Information);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string destFileName = Path.Combine(ConnectionNode.appPathAvatar, "user "+ UtilitiesFunctions.stringReplaceInvalidSymbols(DateTime.Now.ToString())+ ".png");

            //upload image
            try
            {
                if (!String.IsNullOrWhiteSpace(userPhoto) && File.Exists(userPhoto))
                    File.Copy(sourceFileName: userPhoto, destFileName);
                else
                    destFileName = "sem_foto";
            } 
            finally
            {
                ConnectionNode.ExecuteCommad("INSERT INTO `usuarios`(`usuario`, `nome`, `password`, `email`, `foto`, `funcao`, `contacto`,`endereco`) VALUES ('"
                     + UtilitiesFunctions.str_repl(txtUserName.Text) + "','"
                     + UtilitiesFunctions.str_repl(txtuserFullName.Text)
                     + "','" + UtilitiesFunctions.CreateMD5(txtPassword.Text)
                     + "','" + txtEmail.Text
                     + "','" + destFileName
                     + "','Administrador','"
                     + UtilitiesFunctions.str_repl(txtContactNo.Text)
                     + "','" + UtilitiesFunctions.str_repl(txtAddress.Text)
                     + "')");
            }

           // UtilitiesFunctions.Logger(1, Conversions.ToString(DateAndTime.TimeOfDay), "Dados do Hospital Cadastrado com sucesso");

            #region Permissions
            //TODO implements permission for user
           
            #endregion

            Snackbar.Show(this, "Concluio as configurações do admin\n Aguarde...!", BunifuSnackbar.MessageTypes.Success);

            tickToAppRestart.Interval = 5000; //cinco segundos
            tickToAppRestart.Tick += new EventHandler(appRestart_Tick);
            tickToAppRestart.Start();

        }

        void appRestart_Tick(object sender, EventArgs e)
        {
            Application.Restart();
          

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRePassword.Text))
                txtRePassword.UseSystemPasswordChar = false;
            else
                txtRePassword.UseSystemPasswordChar = true;
        }

        private void FrmFirstOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            UtilitiesFunctions.AppClose(this, e, true);
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtPassword.UseSystemPasswordChar, txtPassword);
        }

        private void txtRePassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtRePassword.UseSystemPasswordChar, txtRePassword);
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Imagem (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName);
                companyPhoto = Path.Combine(OpenFileDialog1.FileName);
            }

        }

        private void btnNextF_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtHospitalName, lblSchoolName);
            TransitionsEffects.ResetColor(txtAddress, lblAddress);
            TransitionsEffects.ResetColor(txtContactNoSchool, lblContactNoSchool);


            
            if (string.IsNullOrEmpty(txtHospitalName.Text))
            {
                Snackbar.Show(this, "Nome do Hospital necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtHospitalName, lblSchoolName);
            }
            else if(pictureBox2.Image.Size.Width == 172 && pictureBox2.Image.Size.Height == 173)
            {
                Snackbar.Show(this, "O logo do Hospital é necessario \n para continuar o cadastro!", BunifuSnackbar.MessageTypes.Error);
              
            }
            else if (!UtilitiesFunctions.EmailCheck(txtHospitalEmail.Text.Trim()))
            {
                Snackbar.Show(this, "Email Invalido!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtHospitalEmail, lbltxtEmailCompany);
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Snackbar.Show(this, "Endereço do Hospital é necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtAddress, lblAddress);
            }
            else if (string.IsNullOrEmpty(txtContactNoSchool.Text))
            {
                Snackbar.Show(this, "Contacto do Hospital é necessario!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtContactNoSchool, lblContactNoSchool);
            }
            else
            {
                if (MessageBox.Show("Deseja confirmar os dados do Hospital " + txtHospitalName.Text + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //Armazena o diretorio para o ficheiro removendo carateres invalidos no formato da hora e data para gerar numeros aleatorios
                    string destFileName = Path.Combine(ConnectionNode.appPathAvatar, "logo "+ UtilitiesFunctions.stringReplaceInvalidSymbols(DateTime.Now.ToString())+ ".png");
                    //upload image
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(companyPhoto) && File.Exists(companyPhoto))
                            File.Copy(sourceFileName: companyPhoto, destFileName);
                        else
                        {
                            MessageBox.Show("Selecione um logo do Hospital valido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }    
                    }
                    finally
                    {   
                        //Salva os dados na base dados
                        ConnectionNode.ExecuteSQLQuery("INSERT INTO hospital (nome, endereco, contactos, nif, Email, logo) VALUES( '" + UtilitiesFunctions.str_repl(txtHospitalName.Text) + "', '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNoSchool.Text) + "', '" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + destFileName + "')");
                  

                    }
                 
                    Snackbar.Show(this, "Hospital registrado com sucesso!", BunifuSnackbar.MessageTypes.Success);
                    stepProgress.SelectedItemIndex = 2;
                    TabContent.SelectedTabPage = Page4;
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void backcolorTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Page3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHospitalEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbltxtEmailSchool_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string destFileName = Path.Combine(ConnectionNode.appPathAvatar, "user " + UtilitiesFunctions.stringReplaceInvalidSymbols(DateTime.Now.ToString()) + ".png");

            //upload image
            try
            {
                if (!String.IsNullOrWhiteSpace(userPhoto) && File.Exists(userPhoto))
                    File.Copy(sourceFileName: userPhoto, destFileName);
                else
                    destFileName = "sem_foto";
            }
            finally
            {
                ConnectionNode.ExecuteCommad("INSERT INTO `usuarios`(`usuario`, `nome`, `password`, `email`, `foto`, `funcao`, `contacto`,`endereco`) VALUES ('"
                    + UtilitiesFunctions.str_repl(txtUserName.Text)+ "','"
                    + UtilitiesFunctions.str_repl(txtuserFullName.Text) 
                    + "','" + UtilitiesFunctions.CreateMD5(txtPassword.Text)
                    + "','" + txtEmail.Text
                    + "','" + destFileName
                    + "','Administrador','"
                    + UtilitiesFunctions.str_repl(txtContactNo.Text)
                    + "','" + UtilitiesFunctions.str_repl(txtAddress.Text)
                    + "')");
            }
        }

        //private void btnEditImage_Click(object sender, EventArgs e)
        //{
        //    if (editDialog.ShowDialog(pictureEdit1.Image) == DialogResult.OK)
        //    {
        //        pictureEdit1.Image = editDialog.Image;
        //    }
        //}
    }
}