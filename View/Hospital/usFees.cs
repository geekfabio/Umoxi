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
    public partial class usFees : UserControl
    {
        public usFees()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usFees _instance;

        public static usFees Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usFees();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid(" SELECT        SchoolFees.FEES_ID, SchoolFees.Fee_Type, SchoolFees.Month, SchoolInformation.School_Name, ClassName.Class_name, SchoolFees.Amount  FROM            SchoolFees INNER JOIN " + " ClassName ON SchoolFees.CLASS_ID = ClassName.CLASS_ID INNER JOIN  SchoolInformation ON SchoolFees.SCHOOL_ID = SchoolInformation.SCHOOL_ID ", DataGridView1);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddFees_Click(object sender, EventArgs e)
        {
            frmAddFees fees = new frmAddFees();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (fees)
            {
                fees.ShowDialog();
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
                        frmAddFees fees = new frmAddFees();

                        ConnectionNode.ExecuteSQLQuery(" SELECT        SchoolFees.FEES_ID, SchoolFees.Fee_Type, SchoolFees.Month, SchoolInformation.School_Name, ClassName.Class_name, SchoolFees.SCHOOL_ID,   SchoolFees.CLASS_ID, SchoolFees.Amount " +
                        " FROM            SchoolFees INNER JOIN  ClassName ON SchoolFees.CLASS_ID = ClassName.CLASS_ID INNER JOIN  SchoolInformation ON SchoolFees.SCHOOL_ID = SchoolInformation.SCHOOL_ID " +
                        " WHERE        (SchoolFees.FEES_ID =  " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            fees.txtFeeID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FEES_ID"]);
                            fees.txtFeeType.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Fee_Type"]);
                            fees.txtFees.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Amount"]);
                            fees.cmbMonth.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Month"]);
                            fees.cmbSchool.Text=ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["School_Name"];
                            fees.cmbClass.Text=ConnectionNode.sqlDT.Rows[0]["CLASS_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_name"];
                            fees.btnSave.Text = "Update";
                            fees.txtFeeType.Select();


                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (fees)
                            {
                                fees.ShowDialog();
                            }
                            LoadData();
                        }

                    }
                    break;
                default:
                    break;
            }

        }
    }
}
