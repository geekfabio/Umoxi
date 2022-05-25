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
    public partial class usSession : UserControl
    {
        public usSession()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usSession _instance;

        public static usSession Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usSession();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT BATCH_ID, BatchName FROM Batch", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            frmAddSession session = new frmAddSession();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (session)
            {
                session.ShowDialog();
            }
            loadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddSession session = new frmAddSession();

                        session.txtBatchID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        session.txtBatchName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        session.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (session)
                        {
                            session.ShowDialog();
                        }
                        loadData();
                    }
                        break;
            }
        }

    }
}
