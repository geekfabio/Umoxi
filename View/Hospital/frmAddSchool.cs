using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Bunifu.UI.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddSchool : Form
    {
        public frmAddSchool()
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

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtSchoolName, lblSchoolName);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);
            TransitionsEffects.ResetColor(txtEmail, lblEmail);

            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                TransitionsEffects.ShowTransition(txtSchoolName, lblSchoolName);
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                Snackbar.Show(this, "Required: Contact", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                TransitionsEffects.ShowTransition(txtEmail, lblEmail);
                Snackbar.Show(this, "Required: Email", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        #region Salvar
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO SchoolInformation (School_Name, Address, Contact_No, FAX, Email, Web) VALUES " + (
                        " ('" + UtilitiesFunctions.str_repl(txtSchoolName.Text) + "', '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', '" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + UtilitiesFunctions.str_repl(txtWeb.Text) + "') "));
                        //get last inserted id
                        ConnectionNode.ExecuteSQLQuery("SELECT   SCHOOL_ID  FROM   SchoolInformation  ORDER BY SCHOOL_ID DESC");
                        double SCHOOL_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"]);
                        //upload image
                        ConnectionNode.UploadCompanyLogo(SCHOOL_ID, PictureBox1);
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "escola adicionada # " + txtSchoolName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                    case "Update":
                        #region Atualizar
                        ConnectionNode.ExecuteSQLQuery(" UPDATE SchoolInformation  SET  School_Name='" + UtilitiesFunctions.str_repl(txtSchoolName.Text) + "', Address='" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', Contact_No='" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', FAX='" + UtilitiesFunctions.str_repl(txtFAX.Text) + "', Email='" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', Web='" + UtilitiesFunctions.str_repl(txtWeb.Text) + "' " +
                        " WHERE SCHOOL_ID=" + txtSchoolID.Text + " ");

                        //update image
                        ConnectionNode.UploadCompanyLogo(double.Parse(txtSchoolID.Text), PictureBox1);
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Escola Atualizada  # " + txtSchoolName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddSchool_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
