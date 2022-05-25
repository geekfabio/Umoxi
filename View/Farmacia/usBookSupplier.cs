using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usBookSupplier : UserControl
    {
        public usBookSupplier()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usBookSupplier _instance;

        public static usBookSupplier Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBookSupplier();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT  BOOK_SUPP_ID, Supplier_Name, Address, Contact_No, FAX, Email  FROM    BookSupplier", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmAddBookSupplier supplier = new frmAddBookSupplier();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (supplier)
            {
                supplier.ShowDialog();
            }
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT * FROM BookSupplier  WHERE BOOK_SUPP_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddBookSupplier supplier = new frmAddBookSupplier();
                            supplier.txtSupplierID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BOOK_SUPP_ID"]);
                            supplier.txtSupplierName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Supplier_Name"]);
                            supplier.txtAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                            supplier.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Contact_No"]);
                            supplier.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                            supplier.txtFAX.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FAX"]);
                            supplier.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (supplier)
                            {
                                supplier.ShowDialog();
                            }
                            LoadData();
                        }
                    }
                    break;
            }
        }
    }
}
