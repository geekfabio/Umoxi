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
    public partial class usDocuments : UserControl
    {
        public usDocuments()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usDocuments _instance;

        public static usDocuments Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDocuments();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT ENDORSEMENT_ID, Endorsement FROM Endorsement", DataGridView1);
        }

        private void btnAddDocuments_Click(object sender, EventArgs e)
        {
            frmAddDocuments documents = new frmAddDocuments();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (documents)
            {
                documents.ShowDialog();
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
                        frmAddDocuments documents = new frmAddDocuments();
                        documents.txtENID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        documents.txtEnName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        documents.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (documents)
                        {
                            documents.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
