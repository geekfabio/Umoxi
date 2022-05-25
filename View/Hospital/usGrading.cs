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
    public partial class usGrading : UserControl
    {
        public usGrading()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usGrading _instance;

        public static usGrading Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usGrading();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT  GRADE_ID, Grade, MarkFrom, MarkTo, GPA, Status  FROM     GradingLevel", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddGrading_Click(object sender, EventArgs e)
        {
            frmAddGrading grading = new frmAddGrading();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (grading)
            {
                grading.ShowDialog();
            }
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[3].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddGrading grading = new frmAddGrading();

                        grading.txtFrom.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[3].Value);
                        grading.txtGPA.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[5].Value);
                        grading.txtGradeID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        grading.txtGradeName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        grading.txtStatus.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[6].Value);
                        grading.txtTo.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[4].Value);
                        grading.txtGradeName.Select();
                        grading.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (grading)
                        {
                            grading.ShowDialog();
                        }
                        LoadData();
                    }
                    break;
            }

        }
    }
}
