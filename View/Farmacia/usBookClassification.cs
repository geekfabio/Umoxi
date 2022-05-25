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
    public partial class usBookClassification : UserControl
    {
        public usBookClassification()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usBookClassification _instance;

        public static usBookClassification Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBookClassification();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT BOOK_CLASSF_ID, Book_Classf_Type FROM BookClassification", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddClassification_Click(object sender, EventArgs e)
        {
            frmAddBookClassification classification = new frmAddBookClassification();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (classification)
            {
                classification.ShowDialog();
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
                        frmAddBookClassification classification = new frmAddBookClassification();
                        classification.txtClassfID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        classification.txtClassfName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        classification.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (classification)
                        {
                            classification.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
