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
    public partial class usDesignation : UserControl
    {
        public usDesignation()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usDesignation _instance;

        public static usDesignation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDesignation();
                return _instance;
            }
        }
        #endregion


        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT DESIGNATION_ID, Designation_Name FROM Designation", DataGridView1);
        }

        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            frmAddDesignation designation = new frmAddDesignation();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (designation)
            {
                designation.ShowDialog();
            }
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddDesignation designation = new frmAddDesignation();
                        designation.txtDegID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        designation.txtDesignationName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        designation.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (designation)
                        {
                            designation.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
