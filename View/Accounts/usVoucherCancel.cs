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
    public partial class usVoucherCancel : UserControl
    {
        public usVoucherCancel()
        {
            InitializeComponent();
        }

        #region instance
        private static usVoucherCancel _instance;

        public static usVoucherCancel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usVoucherCancel();
                return _instance;
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtVoucherAmount.Text = "";
            txtVoucherType.Text = "";
            txtVoucherDate.Text = "";
            txtVoucherNO.Text = "";

            if (chkAll.Checked)
            {
                ConnectionNode.FillListBox2("SELECT   VOUCHER_ID FROM  Voucher WHERE   (NOT (Approval = 'C'))  ORDER BY VOUCHER_ID ", ListBox1);
            }
            else
            {
                ConnectionNode.FillListBox2(" SELECT  VOUCHER_ID FROM      Voucher  WHERE  (NOT (Approval = 'C')) AND " +
                    " (Voucher_Date >= '" + Strings.Format(dtpFrom.DateTime.Date, "MM/dd/yyyy") + "' AND Voucher_Date <= '" + Strings.Format(dtpTo.DateTime.Date, "MM/dd/yyyy") + "')  ORDER BY VOUCHER_ID ", ListBox1);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count > 0)
            {
                txtVoucherNO.Text = Convert.ToString(ListBox1.SelectedItem);
            }
        }

        private void txtVoucherNO_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVoucherNO.Text))
            {
                txtVoucherAmount.Text = "";
                txtVoucherType.Text = "";
                txtVoucherDate.Text = "";
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT  * FROM    Voucher  WHERE        (VOUCHER_ID = " + txtVoucherNO.Text + ") ");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    txtVoucherType.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Voucher_Type"]);
                    txtVoucherDate.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Voucher_Date"]);
                    if ((string)ConnectionNode.sqlDT.Rows[0]["Voucher_Type"] == "Payment")
                    {
                        txtVoucherAmount.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PayAmount"]);
                    }
                    else if ((string)ConnectionNode.sqlDT.Rows[0]["Voucher_Type"] == "Receive")
                    {
                        txtVoucherAmount.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["RecAmount"]);
                    }
                }
            }
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to void voucher # " + txtVoucherNO.Text + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConnectionNode.ExecuteSQLQuery(" UPDATE    Voucher SET Approval='C'  WHERE        (VOUCHER_ID = " + txtVoucherNO.Text + " )");
                UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Voucher Approved. " + txtVoucherNO.Text);
                btnSearch.PerformClick();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
            }
        }
    }
}
