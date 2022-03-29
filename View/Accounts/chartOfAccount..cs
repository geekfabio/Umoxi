using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class chartOfAccount : Form
    {
        readonly usAccounts accounts = new usAccounts();
        public chartOfAccount()
        {
            InitializeComponent();
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

        private void chartOfAccount_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            ConnectionNode.FILLComboBox("SELECT   AC_ID, AC_Name  FROM    Accounts", cmbAccount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                Snackbar.Show(this, "Account Name", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtLedgerName.Text))
            {
                Snackbar.Show(this, "Ledger Name", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtOpeningBalance.Text))
            {
                Snackbar.Show(this, "Opening Balance", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!(cmbStatus.Text == "Active" | cmbStatus.Text == "Suspend"))
            {
                Snackbar.Show(this, "Ledger Staus", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        //Create new ledger for transaction
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO ChartOfAccount (AC_ID, LedgerName, LedgerDate, OpeningBalance, Status) VALUES " +
                            " (" + cmbAccount.Text.Split(" # ".ToCharArray()[0])[0] + (", '" + UtilitiesFunctions.str_repl(txtLedgerName.Text) + "', '") + Strings.Format(dtpOpeningDate.DateTime.Date, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(txtOpeningBalance.Text) + "', '" + cmbStatus.Text + "') "));
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateAndTime.TimeOfDay.ToString(), "Add a new a/c head");

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        //Update ledger details
                        ConnectionNode.ExecuteSQLQuery(" UPDATE ChartOfAccount SET  AC_ID=" + cmbAccount.Text.Split(" # ".ToCharArray()[0])[0] + (", LedgerName='" + UtilitiesFunctions.str_repl(txtLedgerName.Text) + "', LedgerDate='") + Strings.Format(dtpOpeningDate.DateTime.Date, "MM/dd/yyyy") + ("', OpeningBalance='" + UtilitiesFunctions.str_repl(txtOpeningBalance.Text) + "', Status='" + cmbStatus.Text + "' ") +
                            " WHERE AC_LEDGER_ID=" + txtACLedgerId.Text + " ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateAndTime.TimeOfDay.ToString(), "Update a/c head");

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterAccounts(accounts.DataGridView1);
        }

        private void FilterAccounts(BunifuDataGridView gridView)
        {
            // get ledger name, filter by account name
            if (!string.IsNullOrEmpty(cmbAccount.Text))
                ConnectionNode.FillDataGrid(" SELECT     ChartOfAccount.AC_LEDGER_ID, Accounts.AC_Name, ChartOfAccount.LedgerName, ChartOfAccount.Status " +
                    " FROM    ChartOfAccount INNER JOIN  Accounts ON ChartOfAccount.AC_ID = Accounts.AC_ID  WHERE        (ChartOfAccount.AC_ID = " + cmbAccount.Text.Split(" # ".ToCharArray()[0])[0] + ")", gridView);

        }

        private void chartOfAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
