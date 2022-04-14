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
    public partial class usNationality : UserControl
    {
        public usNationality()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usNationality _instance;

        public static usNationality Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usNationality();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT NATION_ID, Nationality FROM Nationality", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddNationality_Click(object sender, EventArgs e)
        {
            frmAddNationality nationality = new frmAddNationality();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (nationality)
            {
                nationality.ShowDialog();
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
                        frmAddNationality nationality = new frmAddNationality();
                        nationality.txtNationID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        nationality.txtNationality.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        nationality.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (nationality)
                        {
                            nationality.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }
    }
}
