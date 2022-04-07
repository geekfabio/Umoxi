using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usVoucherList : UserControl
    {
        public usVoucherList()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[7].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView1.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usVoucherList _instance;

        public static usVoucherList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usVoucherList();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.sqlString = " SELECT        Voucher.VOUCHER_ID, Voucher.Voucher_Type, Voucher.Voucher_Date, ChartOfAccount.LedgerName, ChartOfAccount_1.LedgerName AS Expr1, Voucher.PayAmount,   Voucher.RecAmount FROM            Voucher INNER JOIN " +
                " ChartOfAccount ON Voucher.Rec_Paid_ID = ChartOfAccount.AC_LEDGER_ID INNER JOIN  ChartOfAccount AS ChartOfAccount_1 ON Voucher.CashBank_ID = ChartOfAccount_1.AC_LEDGER_ID " +
                " WHERE        (Voucher.Voucher_Date >= '" + Strings.Format(dtpFrom.DateTime.Date, "MM/dd/yyyy") + "' AND Voucher.Voucher_Date <= '" + Strings.Format(dtpTo.DateTime.Date, "MM/dd/yyyy") + "') ";
            ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                lblCount.Text = ConnectionNode.sqlDT.Rows.Count + " Voucher(s).";
            }
            else
            {
                lblCount.Text = "Voucher not found.";
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddVoucher voucher = new frmAddVoucher();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (voucher)
            {
                voucher.ShowDialog();
            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(btnSearch))
            {
                LoadData();
            }
            else
            {
                ConnectionNode.sqlString = " SELECT        Voucher.VOUCHER_ID, Voucher.Voucher_Type, Voucher.Voucher_Date, ChartOfAccount.LedgerName, ChartOfAccount_1.LedgerName AS Expr1, Voucher.PayAmount,   Voucher.RecAmount FROM            Voucher INNER JOIN " +
                    " ChartOfAccount ON Voucher.Rec_Paid_ID = ChartOfAccount.AC_LEDGER_ID INNER JOIN  ChartOfAccount AS ChartOfAccount_1 ON Voucher.CashBank_ID = ChartOfAccount_1.AC_LEDGER_ID " +
                    " WHERE  Voucher.VOUCHER_ID=" + btnSearch.Text + "   ";
                ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region edit
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //check the voucher if already approved
                        ConnectionNode.ExecuteSQLQuery("SELECT    * FROM            Voucher  WHERE        (VOUCHER_ID = " + System.Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") AND (Approval = 'Y')");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            Snackbar.Show(FrmMain.Default, "Voucher already approved.", BunifuSnackbar.MessageTypes.Error);
                        }
                        else
                        {
                            //check the voucher if already void
                            ConnectionNode.ExecuteSQLQuery("SELECT    * FROM            Voucher  WHERE        (VOUCHER_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") AND (Approval = 'C')");
                            if (ConnectionNode.sqlDT.Rows.Count > 0)
                            {
                                Snackbar.Show(FrmMain.Default, "Voucher already approved", BunifuSnackbar.MessageTypes.Error);
                            }
                            else
                            {
                                //--------------------------------
                                ConnectionNode.ExecuteSQLQuery(" SELECT        Voucher.VOUCHER_ID, Voucher.Voucher_Type, Voucher.Voucher_Date, Voucher.Rec_Paid_ID, ChartOfAccount.LedgerName, Voucher.CashBank_ID,  " +
                                    " ChartOfAccount_1.LedgerName AS Expr1, Voucher.ReceiptChqNo, Voucher.ChequeDate, Voucher.PayAmount, Voucher.RecAmount, Voucher.Narration,  Voucher.BankReconciliation " +
                                    " FROM            Voucher INNER JOIN  ChartOfAccount ON Voucher.Rec_Paid_ID = ChartOfAccount.AC_LEDGER_ID INNER JOIN " +
                                    " ChartOfAccount AS ChartOfAccount_1 ON Voucher.CashBank_ID = ChartOfAccount_1.AC_LEDGER_ID  WHERE        (Voucher.VOUCHER_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + ") ");
                                if (ConnectionNode.sqlDT.Rows.Count > 0)
                                {
                                    frmAddVoucher voucher = new frmAddVoucher();

                                    voucher.txtVoucherNO.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["VOUCHER_ID"]);
                                    voucher.cmbVoucherType.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Voucher_Type"]);
                                    voucher.dtpVocuherDate.DateTime = (DateTime)(ConnectionNode.sqlDT.Rows[0]["Voucher_Date"]);

                                    voucher.txtRecPayID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Rec_Paid_ID"]);
                                    voucher.txtRecPay.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["LedgerName"]);

                                    voucher.txtCashBankID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["CashBank_ID"]);
                                    voucher.txtCashBank.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Expr1"]);

                                    voucher.txtReciptNO.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ReceiptChqNo"]);
                                    voucher.dtpChequeDate.DateTime = (DateTime)(ConnectionNode.sqlDT.Rows[0]["ChequeDate"]);

                                    if ((string)ConnectionNode.sqlDT.Rows[0]["Voucher_Type"] == "Receive")
                                    {
                                        voucher.txtAmount.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["RecAmount"]);
                                    }
                                    else if ((string)ConnectionNode.sqlDT.Rows[0]["Voucher_Type"] == "Payment")
                                    {
                                        voucher.txtAmount.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PayAmount"]);
                                    }

                                    if ((string)ConnectionNode.sqlDT.Rows[0]["BankReconciliation"] == "Y")
                                    {
                                        voucher.chkChequeStatus.Checked = true;
                                    }
                                    else if ((string)ConnectionNode.sqlDT.Rows[0]["BankReconciliation"] == "N")
                                    {
                                        voucher.chkChequeStatus.Checked = false;
                                    }

                                    voucher.txtNarration.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Narration"]);
                                    voucher.lstCashBankAc.Visible = false;
                                    voucher.lstPayRecAc.Visible = false;
                                    voucher.btnSave.Text = "Update";
                                }
                                //--------------------------------
                            }
                        }
                    }
                    #endregion
                    break;
                case 1:
                    break;
            }

        }

    }
}
