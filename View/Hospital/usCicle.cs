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
    public partial class usCicle : UserControl
    {
        public usCicle()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usCicle _instance;

        public static usCicle Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usCicle();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT CLASS_TYPE_ID, Class_Type FROM ClassType", DataGridView1);
        }

        private void btnAddCicle_Click(object sender, EventArgs e)
        {
            frmAddCicle cicle = new frmAddCicle();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (cicle)
            {
                cicle.ShowDialog();
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
                        frmAddCicle cicle = new frmAddCicle();

                        cicle.txtClassID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        cicle.txtClassName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        cicle.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (cicle)
                        {
                            cicle.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
