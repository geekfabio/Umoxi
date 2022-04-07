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
    public partial class frmAddClass : Form
    {
        public frmAddClass()
        {
            InitializeComponent();
            loadData();
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

        private void loadData()
        {
            ConnectionNode.FILLComboBox("SELECT CLASS_TYPE_ID, Class_Type FROM ClassType", cmbClassName);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtClassName, lblClassName);

            if (string.IsNullOrEmpty(txtClassName.Text))
            {
                TransitionsEffects.ShowTransition(txtClassName, lblClassName);
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClassName.Text))
            {
                Snackbar.Show(this, "Required: Cycle", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO ClassName (CLASS_TYPE_ID, Class_name) VALUES (" + cmbClassName.Text.Split(" # ".ToCharArray()[0])[0] + (" , '" + UtilitiesFunctions.str_repl(txtClassName.Text) + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Add class # " + txtClassName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  ClassName SET  CLASS_TYPE_ID=" + cmbClassName.Text.Split(" # ".ToCharArray()[0])[0] + (" , Class_name= '" + UtilitiesFunctions.str_repl(txtClassName.Text) + "' WHERE      CLASS_ID =  ") + txtClassID.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Updated class # " + txtClassName.Text);

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

        private void frmAddClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
