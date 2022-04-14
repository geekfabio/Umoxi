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
    public partial class usDepartment : UserControl
    {
        public usDepartment()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usDepartment _instance;

        public static usDepartment Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDepartment();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT DEPARTMENT_ID, Department_Name FROM Department", DataGridView1);
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            frmAddDepartment department = new frmAddDepartment();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (department)
            {
                department.ShowDialog();
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
                        frmAddDepartment department = new frmAddDepartment();
                        department.txtDepID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        department.txtDepartmentName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        department.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (department)
                        {
                            department.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
