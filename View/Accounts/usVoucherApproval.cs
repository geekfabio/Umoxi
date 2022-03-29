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
    public partial class usVoucherApproval : UserControl
    {
        public usVoucherApproval()
        {
            InitializeComponent();
        }

        #region instance
        private static usVoucherApproval _instance;

        public static usVoucherApproval Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usVoucherApproval();
                return _instance;
            }
        }
        #endregion

        readonly private double ITEM_COST;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtVoucherAmount.Text = null;
            txtVoucherType.Text = null;
            txtVoucherDate.Text = null;
            txtVoucherNO.Text = null;
            if (chkAll.Checked)
            {
                ConnectionNode.FillListBox2("SELECT   VOUCHER_ID FROM  Voucher WHERE (Approval = 'N')  ORDER BY VOUCHER_ID", ListBox1);
            }
            else
            {
                ConnectionNode.FillListBox2(" SELECT  VOUCHER_ID FROM      Voucher  WHERE   (Approval = 'N') AND  " +
                    " (Voucher_Date >= '" + Strings.Format(dtpFrom.DateTime.Date, "MM/dd/yyyy") + "' AND Voucher_Date <= '" + Strings.Format(dtpTo.DateTime.Date, "MM/dd/yyyy") + "')  ORDER BY VOUCHER_ID ", ListBox1);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count > 0)
                txtVoucherNO.Text = Convert.ToString(ListBox1.SelectedItem);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to approve voucher # " + txtVoucherNO.Text + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConnectionNode.ExecuteSQLQuery(" UPDATE    Voucher SET Approval='Y'  WHERE        (VOUCHER_ID = " + txtVoucherNO.Text + " )");
                UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Voucher Approved. " + txtVoucherNO.Text);
                btnSearch.PerformClick();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
            }
        }
    }
}
