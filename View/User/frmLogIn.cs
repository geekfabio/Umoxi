using Bunifu.UI.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Umoxi.Controller;

namespace Umoxi
{
    public partial class frmLogIn : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
       
        //caso o numero de tantivas para fazer login seja maior q 10 então aplicação fecha
        private int numero_de_tentativas;
     
        public bool CheckUser;

        public frmLogIn()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        #region Default Instance

        private static frmLogIn defaultInstance;

        /// <summary>
        /// default instance behavour in C#
        /// </summary>
        public static frmLogIn Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmLogIn();
                    defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            if (Properties.Settings.Default.App_UserRemember)
            {
                txtUserName.Text = Properties.Settings.Default.App_UserName;
                txtPassword.Text = Properties.Settings.Default.App_UserPassword;
                chkRememberMe.Checked = Properties.Settings.Default.App_UserRemember;
               
            }
            
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            

        }

        private void lblForgotPass_LinkClicked(object sender, EventArgs e)
        {
          
        }

        private void txtPassword_OnIconRightClick(object sender, EventArgs e)
        {
            UtilitiesFunctions.ViewPassword(txtPassword.UseSystemPasswordChar, txtPassword);
        }


        void _validarCampos() {

            TransitionsEffects.ResetColor(txtUserName, lblUserName);
            TransitionsEffects.ResetColor(txtPassword, lblPassword);
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text))
            {
                Snackbar.Show(this, "O campo usúario é necessário!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtUserName, lblUserName);
            }
            else if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                Snackbar.Show(this, "Password inválida!!!", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtPassword, lblPassword);

            }
            else
            {
             
                _iniciarSessao();
            }
          

        }

        private void _iniciarSessao()
        {
            Waiting.ShowWaitForm();
            ///MD5 PASSWORD ENCRYPT
            //            ConnectionNode.sqlString = "SELECT * FROM usuarios WHERE usuario='" + Convert.ToString(UtilitiesFunctions.str_repl(txtUserName.Text)) + "' AND password ='" + Convert.ToString(UtilitiesFunctions.CreateMD5(txtPassword.Text)) + "' AND (ativo = 'Y')";

            ConnectionNode.sqlString = "SELECT * FROM usuarios WHERE usuario='" + Convert.ToString(UtilitiesFunctions.str_repl(txtUserName.Text)) + "' AND password ='" + Convert.ToString(UtilitiesFunctions.CreateMD5(txtPassword.Text)) + "' AND (ativo = 'Y')";

            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {

                salvarDadosUsuario();
                #region Logger e LoadUserPermission
              
                UtilitiesFunctions.Logger(ConnectionNode.userID, Convert.ToString(DateTime.Now.ToLongTimeString()), "Usuario: " + txtUserName.Text + ", iniciou sessão no sistema ");
                if (chkRememberMe.Checked)
                {                    
                    Properties.Settings.Default.App_UserName = txtUserName.Text;
                }
                else
                {
                    Properties.Settings.Default.App_UserName = null;
                    Properties.Settings.Default.App_UserPassword = null;
                }
                Properties.Settings.Default.App_UserRemember = chkRememberMe.Checked;
                Properties.Settings.Default.Save();

                FrmMain.Default.Show();
                this.Hide();
            }
            else
            {
                Snackbar.Show(this, "Usúario ou Password incorretos!!!", BunifuSnackbar.MessageTypes.Error);
                numero_de_tentativas++;
                if (numero_de_tentativas >= 6)
                {
                    Snackbar.Show(this, "Demasiadas tentativas incorretas!!!", BunifuSnackbar.MessageTypes.Error);
                    Snackbar.Show(this, "Você não tem permissão para usar o sistema \n" +
                        "Para mais informações por favor, contacte \n" +
                        "O administrador do sistema!", BunifuSnackbar.MessageTypes.Warning);
                    Application.Exit();
                }
            }
            Waiting.CloseWaitForm();

        }

        private void salvarDadosUsuario()
        {
            ConnectionNode.userName = txtUserName.Text;
            ConnectionNode.userFullName = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nome"]);
            ConnectionNode.userFuncao = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["funcao"]) ?? "Usúario";
            ConnectionNode.userEmail = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["email"]);
            ConnectionNode.userID = Convert.ToInt32(ConnectionNode.sqlDT.Rows[0]["usuario_id"]);
            UserPermission.LoadUserPermission();
           
            string photoUser = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]);
            if(photoUser == "sem_foto" || photoUser == ""){
                FrmMain.Default.UserPictureBox.Image = Properties.Resources.icons8_user_name_240px;
                FrmMain.Default.PictureBox1.Image = Umoxi.Properties.Resources.icons8_user_name_240px; 
             //   FrmMain.Default.currentUser.ImageOptions.Image = Properties.Resources.icons8_user_name_240px;
            }
            else
            {
                if (File.Exists(photoUser))
                {
                    FrmMain.Default.UserPictureBox.Image = Image.FromFile(photoUser);
                    FrmMain.Default.PictureBox1.Image = Image.FromFile(photoUser);
                   // FrmMain.Default.currentUser.ImageOptions.Image = Image.FromFile(photoUser);

                }
            }
            FrmMain.Default.toastNotificationsManager1.Notifications[0].AppLogoImage = Properties.Resources.logo_255px;
            FrmMain.Default.labelOff.Text = "Login";


            FrmMain.Default.LogOffToolStripMenuItem.Caption = "Terminar sessão " + ConnectionNode.userName;
            FrmMain.Default.currentUser.Caption = "Bem-vindo(a) " + ConnectionNode.userName;
            FrmMain.Default.toastNotificationsManager1.Notifications[0].Header = "Bem-vindo(a)" + ConnectionNode.userName;
            FrmMain.Default.toastNotificationsManager1.Notifications[0].Body = "Umoxi - Sistema de gestão hospital || " + ConnectionNode.userName;

            this.notifyUmoxi.BalloonTipText = "Bem-vindo(a)" + ConnectionNode.userFullName;
            this.notifyUmoxi.BalloonTipTitle = "Umoxi - Gestão hospital || " + ConnectionNode.userName; ;
            this.notifyUmoxi.BalloonTipIcon = ToolTipIcon.Info;
            this.notifyUmoxi.ShowBalloonTip(5000);

            FrmMain.Default.lblUserName.Text = ConnectionNode.userEmail;
            FrmMain.Default.lbluserFullName.Text = ConnectionNode.userFullName;
            FrmMain.Default.lblUserEmail.Text = ConnectionNode.userEmail;
            FrmMain.Default.lblUser_name.Text = ConnectionNode.userName;
            #endregion
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            _validarCampos();
            btnLogin.Enabled = true;
            txtUserName.Focus();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.Enter) {

                if (String.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    txtUserName.Focus();
                }
                else if (String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.Focus();
                }
                else
                {
                    bunifuButton1_Click(sender, e);

                }
            }
        }
    }
}
