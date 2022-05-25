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
    public partial class usBookCategory : UserControl
    {
        public usBookCategory()
        {
            InitializeComponent(); 
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usBookCategory _instance;

        public static usBookCategory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBookCategory();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT BOOK_CAT_ID, Category_Name FROM BookCategory", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmAddBookCategory category = new frmAddBookCategory();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (category)
            {
                category.ShowDialog();
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
                        frmAddBookCategory category = new frmAddBookCategory();
                        category.txtCatID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        category.txtCategoryName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        category.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (category)
                        {
                            category.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
