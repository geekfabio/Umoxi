using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddFees : Form
    {
        public frmAddFees()
        {
            InitializeComponent();
            LoadData();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClass);
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
            TransitionsEffects.ResetColor(txtFeeType, lblFeeType);

            if (string.IsNullOrEmpty(txtFeeType.Text))
            {
                TransitionsEffects.ShowTransition(txtFeeType, lblFeeType);
                Snackbar.Show(this, "Required: Fee", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSchool.Text))
            {
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbMonth.Text))
            {
                Snackbar.Show(this, "Required: Month", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtFees.Text))
            {
                TransitionsEffects.ShowTransition(txtFees, lblFees);
                Snackbar.Show(this, "Required: Fee", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO SchoolFees ( Fee_Type, SCHOOL_ID, CLASS_ID, Month, Amount) VALUES  " + (
                        " ( '" + UtilitiesFunctions.str_repl(txtFeeType.Text) + "', ") + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + (", '" + cmbMonth.Text + "' , '" + UtilitiesFunctions.str_repl(txtFees.Text) + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToShortTimeString(), "Add fee # " + txtFees.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE SchoolFees SET  Fee_Type='" + UtilitiesFunctions.str_repl(txtFeeType.Text) + "', SCHOOL_ID=" + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", CLASS_ID=" + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + (", Month='" + cmbMonth.Text + "', Amount= '" + UtilitiesFunctions.str_repl(txtFees.Text) + "'  ") +
                        " WHERE FEES_ID=" + txtFeeID.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToShortTimeString(), "Updated fee # " + txtFees.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddFees_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
