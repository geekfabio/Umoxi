using Bunifu.UI.WinForms;
using PasswordStrengthControlLib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddUser : Form
    {
        string chkVAL;
        public string userPhoto = "";
        public frmAddUser()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void TabSelect(string tab)
        {
            switch (tab)
            {
                case "User":
                    NavigationBar.SelectedItem = tabUser;
                    break;
                case "Pass":
                    NavigationBar.SelectedItem = tabPass;
                    break;
                default:
                    break;
            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabUser)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabPhoto)
            {
                TabContent.SelectedTabPage = Page2;
            }
            else if (NavigationBar.SelectedItem == tabPass)
            {
                TabContent.SelectedTabPage = Page3;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

            switch (txtPassword.UseSystemPasswordChar)
            {
                case true:
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.IconRight = Properties.Resources.icons8_invisible_24px_1;
                    break;
                case false:
                    txtPassword.UseSystemPasswordChar = true;
                    txtPassword.IconRight = Properties.Resources.icons8_eye_24px_1;
                    break;
            }
        }

        private void txtRePassword_TextChanged(object sender, EventArgs e)
        {

            switch (txtRePassword.UseSystemPasswordChar)
            {
                case true:
                    txtRePassword.UseSystemPasswordChar = false;
                    txtRePassword.IconRight = Properties.Resources.icons8_invisible_24px_1;
                    break;
                case false:
                    txtRePassword.UseSystemPasswordChar = true;
                    txtRePassword.IconRight = Properties.Resources.icons8_eye_24px_1;
                    break;
            }

        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtPassword.UseSystemPasswordChar, txtPassword);
        }

        private void txtRePassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtRePassword.UseSystemPasswordChar, txtRePassword);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkActive_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkActive.Checked == false)
                Snackbar.Show(this, "Usuário desativado", BunifuSnackbar.MessageTypes.Information, 5000, "Active").Then((result) =>
                {
                    if (result == BunifuSnackbar.SnackbarResult.ActionClicked)
                        chkActive.Checked = true;
                    chkVAL = "Y";
                });
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

        private void frmAddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtuserFullName, lbluserFullName);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);
            TransitionsEffects.ResetColor(txtEmail, lblEmail);

            switch (btnSave.Text)
            {
                case "Salvar":
                    #region Salvar                    
                    if (string.IsNullOrWhiteSpace(txtUserName.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtUserName, lblUserName);
                        Snackbar.Show(this, "Por favor preencha o campo Usúario", BunifuSnackbar.MessageTypes.Error);
                        txtUserName.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(txtuserFullName.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtuserFullName, lbluserFullName);
                        Snackbar.Show(this, "Por favor preencha o campo nome completo", BunifuSnackbar.MessageTypes.Error);
                        txtuserFullName.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                        Snackbar.Show(this, "O campo Contacto é necessário", BunifuSnackbar.MessageTypes.Error);
                        txtContactNo.Focus();
                    }
                    else if (!UtilitiesFunctions.EmailCheck(txtEmail.Text.Trim()))
                    {
                        TabSelect("User");
                        lblEmail.ForeColor = Color.Red;
                        TransitionsEffects.ShowTransition(txtEmail, lblEmail);
                        Snackbar.Show(this, "Email Incorreto", BunifuSnackbar.MessageTypes.Error);
                    }
                    else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        TabSelect("Pass");
                        lblEmail.ForeColor = Color.Red;
                        TransitionsEffects.ShowTransition(txtEmail, lblEmail);
                        Snackbar.Show(this, "Required: Password", BunifuSnackbar.MessageTypes.Error);
                    }
                    else
                    {
                        if (chkActive.Checked == false)
                        {
                            chkVAL = "N";
                            Snackbar.Show(this, "Usuário desativado", BunifuSnackbar.MessageTypes.Information, 5000, "Ativar").Then((result) =>
                            {
                                if (result == BunifuSnackbar.SnackbarResult.ActionClicked)
                                    chkActive.Checked = true;
                                chkVAL = "Y";
                            });
                        }

                        ConnectionNode.ExecuteSQLQuery("SELECT usuario  FROM Usuarios WHERE (usuario = '" + Convert.ToString(UtilitiesFunctions.str_repl(txtUserName.Text)) + "')");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            Snackbar.Show(this, "Este usúario já existe!!!", BunifuSnackbar.MessageTypes.Warning);
                        }
                        else
                        {
                            if (txtPassword.Text == txtRePassword.Text)
                            {
                                ConnectionNode.ExecuteSQLQuery("INSERT INTO  usuarios (usuario, password, nome, email, contacto, ativo) VALUES ('" + UtilitiesFunctions.str_repl(txtUserName.Text) + "', '" + UtilitiesFunctions.CreateMD5(txtPassword.Text) + "', '" + UtilitiesFunctions.str_repl(txtuserFullName.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', '" + chkVAL + "')");
                                //get last inserted id
                                ConnectionNode.ExecuteSQLQuery("SELECT usuario_id  FROM   usuarios  ORDER BY usuario_id DESC");
                                double user_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["usuario_id"]);
                                //upload image
                                ConnectionNode.UploadUserPhoto(user_ID, userPhoto);

                                UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Usuario: " + txtUserName.Text + " adicionado por " + ConnectionNode.userName);
                                this.Close();
                                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Usuário cadastrado com sucesso"), BunifuSnackbar.MessageTypes.Success);

                            }
                            else
                                Snackbar.Show(this, "Password não coincidem!", BunifuSnackbar.MessageTypes.Error);


                        }

                    }
                    #endregion
                    break;
                case "Atualizar":
                    #region Atualizar
                    #region check
                    if (string.IsNullOrWhiteSpace(txtUserName.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtUserName, lblUserName);
                        Snackbar.Show(this, "Nome do Usuário Obrigatorio", BunifuSnackbar.MessageTypes.Error);
                    }
                    else if (string.IsNullOrWhiteSpace(txtuserFullName.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtuserFullName, lbluserFullName);
                        Snackbar.Show(this, "Contacto Obrigatoria", BunifuSnackbar.MessageTypes.Error);
                    }
                    else if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                    {
                        TabSelect("User");
                        TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                        Snackbar.Show(this, "Contacto Obrigatorio", BunifuSnackbar.MessageTypes.Error);
                    }
                    //else if (!UtilitiesFunctions.EmailCheck(txtEmail.Text.Trim()))
                    //{
                    //    TabSelect("User");
                    //    lblEmail.ForeColor = Color.Red;
                    //    TransitionsEffects.ShowTransition(txtEmail, lblEmail);
                    //    Snackbar.Show(this, "Email Incorreto", BunifuSnackbar.MessageTypes.Error);
                    //}
                    #endregion
                    if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
                    {
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  usuarios SET  nome='" + UtilitiesFunctions.str_repl(txtuserFullName.Text) + "', email='" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', contacto='" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', ativo='" + chkVAL + "' WHERE  usuario_id=" + txtUserID.Text + " ");
                        //Atualiza a foto de perfil se o ficheiro existe                                
                        if(File.Exists(userPhoto))
                            ConnectionNode.UploadUserPhoto(double.Parse(txtUserID.Text), userPhoto);

                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "User updated # " + txtUserName.Text);
                       
                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                    }
                    else
                    {
                        if (txtPassword.Text == txtRePassword.Text)
                        {
                            ConnectionNode.ExecuteSQLQuery(" UPDATE  usuarios SET  password='" + UtilitiesFunctions.CreateMD5(txtPassword.Text) + "', nome='" + UtilitiesFunctions.str_repl(txtuserFullName.Text) + "', email='" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', contacto='" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', ativo='" + chkVAL + "' WHERE  usuario_id=" + txtUserID.Text + " ");
                            //Atualiza a foto de perfil se o ficheiro existe                                
                            if (File.Exists(userPhoto))
                                ConnectionNode.UploadUserPhoto(double.Parse(txtUserID.Text), userPhoto);

                            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "User updated # " + txtUserName.Text);
                            this.Close();
                            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        }
                        else
                        {
                            Snackbar.Show(this, "A senhas não coincidem!", BunifuSnackbar.MessageTypes.Error);
                        }

                    }
                    #endregion
                    break;
                default:
                    break;
            }

        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
