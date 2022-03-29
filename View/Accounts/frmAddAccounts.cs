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
    public partial class frmAddAccounts : Form
    {
        public frmAddAccounts()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
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
            ConnectionNode.FillDataGrid("SELECT AC_ID, AC_Name FROM Accounts", DataGridView1);
        }
        private void frmAddAccounts_Load(object sender, EventArgs e)
        {
            DefaultAC();
            LoadData();
        }

        private void DefaultAC()
        {
            #region account types
            //CASH & BANK ACCOUNTS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 1000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group) VALUES (1000, 'CASH & BANK ACCOUNTS', 'ASSETS')");
            }

            //EXPENSES ACCOUNT
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 2000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (2000, 'EXPENSES ACCOUNT ', 'EXPENSES')");
            }


            //CURRENT ASSETS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 3000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (3000, 'CURRENT ASSETS', 'ASSETS')");
            }

            //CAPITAL ACCOUNTS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 4000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (4000, 'CAPITAL ACCOUNTS ', 'LIABILITIES')");
            }

            //LOAN ACCOUNTS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 5000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (5000, 'LOAN ACCOUNTS ', 'LIABILITIES')");
            }

            //EMPLOYEE ACCOUNTS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 6000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (6000, 'EMPLOYEE ACCOUNTS ', 'LIABILITIES')");
            }

            //REVENUE ACCOUNTS
            ConnectionNode.ExecuteSQLQuery("SELECT        AC_ID, AC_Name  FROM            Accounts  WHERE        (AC_ID = 7000)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO  Accounts (AC_ID, AC_Name, Ac_Group)  VALUES (7000, 'REVENUE ACCOUNTS ', 'INCOME')");
            }
            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtAcName, lblCategoryName);

            if (string.IsNullOrEmpty(txtAcName.Text))
            {
                TransitionsEffects.ShowTransition(txtAcName, lblCategoryName);
                Snackbar.Show(this, "Required: ACCOUNTS NAME", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("UPDATE Accounts SET AC_Name='" + UtilitiesFunctions.str_repl(txtAcName.Text) + "' WHERE AC_ID=" + txtAcId.Text + " ");
                UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Update A/c name " + txtAcName.Text);

                this.Close();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region edit account
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtAcId.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        txtAcName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                    }
                    #endregion
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddAccounts_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
