using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddVoucher : Form
    {
        public frmAddVoucher()
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

        string BankReconciliation;

        private void cmbVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbVoucherType.Text))
            {
                lblVoucCaption.Text = "RECEIVE FORM / PAY TO";
            }
            else if (cmbVoucherType.Text == "Payment")
            {
                lblVoucCaption.Text = "PAY TO";
            }
            else if (cmbVoucherType.Text == "Receive")
            {
                lblVoucCaption.Text = "RECEIVE FORM";
            }
            else
            {
                lblVoucCaption.Text = "RECEIVE FORM / PAY TO";
            }
        }
        private void chkStatus()
        {
            if (chkChequeStatus.Checked)
            {
                dtpChequeDate.Enabled = true;
                BankReconciliation = "Y";
            }
            else
            {
                dtpChequeDate.Enabled = false;
                BankReconciliation = "N";
            }
        }

        private void chkChequeStatus_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            chkStatus();
        }

        private void frmAddVoucher_Load(object sender, EventArgs e)
        {
            chkStatus();
        }

        private void txtRecPay_Click(object sender, EventArgs e)
        {
            ConnectionNode.FillListBox("SELECT        AC_LEDGER_ID, LedgerName FROM            ChartOfAccount  ORDER BY LedgerName", lstPayRecAc);
            lstPayRecAc.Visible = true;
        }

        private void txtRecPay_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecPay.Text))
            {
                txtRecPayID.Text = "";
                lstPayRecAc.Visible = false;
                ConnectionNode.FillListBox("SELECT        AC_LEDGER_ID, LedgerName FROM            ChartOfAccount  ORDER BY LedgerName", lstPayRecAc);
            }
            else
            {
                lstPayRecAc.Visible = true;
                ConnectionNode.FillListBox("SELECT   AC_LEDGER_ID, LedgerName FROM   ChartOfAccount WHERE  (LedgerName LIKE '%" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtRecPay.Text)) + "%') ORDER BY LedgerName", lstPayRecAc);
            }
        }

        private void txtRecPay_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keydata = e.KeyData;
            if (keydata == Keys.Down)
            {
                if (lstPayRecAc.Items.Count > 0)
                {
                    lstPayRecAc.Visible = true;
                    lstPayRecAc.SelectedIndex = 0;
                    lstPayRecAc.Select();
                }
            }
        }

        private void txtRecPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                lstPayRecAc.Visible = false;
            }
        }

        private void lstPayRecAc_DoubleClick(object sender, EventArgs e)
        {
            if (lstPayRecAc.Items.Count > 0)
            {
                txtRecPayID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstPayRecAc.SelectedItem), " # ")[0]);
                txtRecPay.Text = Convert.ToString(Strings.Split(Convert.ToString(lstPayRecAc.SelectedItem), " # ")[1]);
                lstPayRecAc.Visible = false;
                txtCashBank.Select();
            }
        }

        private void lstPayRecAc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                if (lstPayRecAc.Items.Count > 0)
                {
                    txtRecPayID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstPayRecAc.SelectedItem), " # ")[0]);
                    txtRecPay.Text = Convert.ToString(Strings.Split(Convert.ToString(lstPayRecAc.SelectedItem), " # ")[1]);
                    lstPayRecAc.Visible = false;
                    txtCashBank.Select();
                }
            }
        }

        private void txtCashBank_Click(object sender, EventArgs e)
        {
            ConnectionNode.FillListBox("SELECT        AC_LEDGER_ID, LedgerName FROM            ChartOfAccount WHERE  (AC_ID = 1000)   ORDER BY LedgerName", lstCashBankAc);
            lstCashBankAc.Visible = true;
        }

        private void txtCashBank_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keydata = e.KeyData;
            if (keydata == Keys.Down)
            {
                if (lstCashBankAc.Items.Count > 0)
                {
                    lstCashBankAc.Visible = true;
                    lstCashBankAc.SelectedIndex = 0;
                    lstCashBankAc.Select();
                }
            }
        }

        private void txtCashBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                lstCashBankAc.Visible = false;
            }
        }

        private void txtCashBank_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCashBank.Text))
            {
                txtCashBankID.Text = "";
                lstCashBankAc.Visible = false;
                ConnectionNode.FillListBox("SELECT        AC_LEDGER_ID, LedgerName FROM            ChartOfAccount WHERE  (AC_ID = 1000)   ORDER BY LedgerName", lstCashBankAc);
            }
            else
            {
                lstCashBankAc.Visible = true;
                ConnectionNode.FillListBox("SELECT   AC_LEDGER_ID, LedgerName FROM   ChartOfAccount WHERE  (LedgerName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtCashBank.Text)) + "%') AND  (AC_ID = 1000)  ORDER BY LedgerName", lstCashBankAc);
            }
        }

        private void lstCashBankAc_DoubleClick(object sender, EventArgs e)
        {
            if (lstCashBankAc.Items.Count > 0)
            {
                txtCashBankID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstCashBankAc.SelectedItem), " # ")[0]);
                txtCashBank.Text = Convert.ToString(Strings.Split(Convert.ToString(lstCashBankAc.SelectedItem), " # ")[1]);
                lstCashBankAc.Visible = false;
                txtReciptNO.Select();
            }
        }

        private void lstCashBankAc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                if (lstCashBankAc.Items.Count > 0)
                {
                    txtCashBankID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstCashBankAc.SelectedItem), " # ")[0]);
                    txtCashBank.Text = Convert.ToString(Strings.Split(Convert.ToString(lstCashBankAc.SelectedItem), " # ")[1]);
                    lstCashBankAc.Visible = false;
                    txtReciptNO.Select();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Load Check status
            chkStatus();
            // Validate data
            if (string.IsNullOrEmpty(cmbVoucherType.Text))
            {
                Snackbar.Show(this, "Required: Voucher Type", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtRecPayID.Text))
            {
                Snackbar.Show(this, "Required: Pay/Receive Account", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtCashBankID.Text))
            {
                Snackbar.Show(this, "Required: Cash/Bank Account", BunifuSnackbar.MessageTypes.Error);
            }
            else if (!Information.IsNumeric(txtAmount.Text))
            {
                Snackbar.Show(this, "Required: Amount", BunifuSnackbar.MessageTypes.Error);
            }
            else if (Conversion.Val(txtAmount.Text) <= 0d)
            {
                Snackbar.Show(this, "Required: Amount", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        //Add new voucher
                        if (cmbVoucherType.Text == "Payment")
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO Voucher (User_ID, Voucher_Type, Voucher_Date, Rec_Paid_ID, CashBank_ID, ReceiptChqNo, ChequeDate, PayAmount, RecAmount, Narration,  BankReconciliation, Approval) VALUES " +
                                " (" + Convert.ToString(ConnectionNode.userID) + ", '" + cmbVoucherType.Text + "', '" + Strings.Format(dtpVocuherDate.DateTime.Date, "MM/dd/yyyy") + "', " + txtRecPayID.Text + ", " + txtCashBankID.Text + (", '" + UtilitiesFunctions.str_repl(txtReciptNO.Text) + "', '") + Strings.Format(dtpChequeDate.DateTime.Date, "MM/dd/yyyy") + "', " + System.Convert.ToString(UtilitiesFunctions.str_repl(txtAmount.Text)) + (", 0, '" + UtilitiesFunctions.str_repl(txtNarration.Text) + "', '" + BankReconciliation + "', 'N') "));
                            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), " Add a new voucher.");

                            this.Close();
                            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        }
                        else if (cmbVoucherType.Text == "Receive")
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO Voucher (User_ID, Voucher_Type, Voucher_Date, Rec_Paid_ID, CashBank_ID, ReceiptChqNo, ChequeDate, PayAmount, RecAmount, Narration,  BankReconciliation, Approval) VALUES " +
                                " (" + Convert.ToString(ConnectionNode.userID) + ", '" + cmbVoucherType.Text + "', '" + Strings.Format(dtpVocuherDate.DateTime.Date, "MM/dd/yyyy") + "', " + txtRecPayID.Text + ", " + txtCashBankID.Text + (", '" + UtilitiesFunctions.str_repl(txtReciptNO.Text) + "', '") + Strings.Format(dtpChequeDate.DateTime.Date, "MM/dd/yyyy") + "', 0, " + System.Convert.ToString(UtilitiesFunctions.str_repl(txtAmount.Text)) + (", '" + UtilitiesFunctions.str_repl(txtNarration.Text) + "', '" + BankReconciliation + "', 'N') "));
                            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), " Add a new voucher.");

                            this.Close();
                            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        }
                        else
                        {
                            Snackbar.Show(this, "Illegal Operation!", BunifuSnackbar.MessageTypes.Error);
                        }
                        break;
                    case "Update":
                        //Voucher upadte statement
                        if (cmbVoucherType.Text == "Payment")
                        {
                            ConnectionNode.ExecuteSQLQuery(" UPDATE Voucher SET User_ID=" + Convert.ToString(ConnectionNode.userID) + ", Voucher_Type='" + cmbVoucherType.Text + "', Voucher_Date='" + Strings.Format(dtpVocuherDate.DateTime.Date, "MM/dd/yyyy") + "', Rec_Paid_ID=" + txtRecPayID.Text + ", CashBank_ID= " + txtCashBankID.Text + (", ReceiptChqNo='" + UtilitiesFunctions.str_repl(txtReciptNO.Text) + "',  ") +
                                " ChequeDate='" + Strings.Format(dtpChequeDate.DateTime.Date, "MM/dd/yyyy") + "', PayAmount=" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtAmount.Text)) + (", RecAmount=0, Narration='" + UtilitiesFunctions.str_repl(txtNarration.Text) + "',  BankReconciliation='" + BankReconciliation + "', Approval ='N'  WHERE        (VOUCHER_ID = ") + txtVoucherNO.Text + ") ");
                            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), " update voucher." + txtVoucherNO.Text);

                            this.Close();
                            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        }
                        else if (cmbVoucherType.Text == "Receive")
                        {
                            ConnectionNode.ExecuteSQLQuery(" UPDATE Voucher SET User_ID=" + Convert.ToString(ConnectionNode.userID) + ", Voucher_Type='" + cmbVoucherType.Text + "', Voucher_Date='" + Strings.Format(dtpVocuherDate.DateTime.Date, "MM/dd/yyyy") + "', Rec_Paid_ID=" + txtRecPayID.Text + ", CashBank_ID= " + txtCashBankID.Text + (", ReceiptChqNo='" + UtilitiesFunctions.str_repl(txtReciptNO.Text) + "',  ") +
                                " ChequeDate='" + Strings.Format(dtpChequeDate.DateTime.Date, "MM/dd/yyyy") + "', PayAmount=0, RecAmount=" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtAmount.Text)) + (", Narration='" + UtilitiesFunctions.str_repl(txtNarration.Text) + "',  BankReconciliation='" + BankReconciliation + "', Approval ='N'  WHERE        (VOUCHER_ID = ") + txtVoucherNO.Text + ") ");
                            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), " update voucher." + txtVoucherNO.Text);

                            this.Close();
                            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        }
                        else
                        {
                            Snackbar.Show(this, "Illegal Operation!", BunifuSnackbar.MessageTypes.Error);
                        }
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
