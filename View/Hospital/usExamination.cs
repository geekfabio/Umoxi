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
    public partial class usExamination : UserControl
    {
        public usExamination()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usExamination _instance;

        public static usExamination Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usExamination();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid(" SELECT        EXAM_ID, ExaminationName, HeldDate, ResultPublishDate, StartTime, EndTime, SuperName, Status  FROM            Examination ", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddExamination_Click(object sender, EventArgs e)
        {
            frmAddExamination exame = new frmAddExamination();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (exame)
            {
                exame.ShowDialog();
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
                        frmAddExamination exame = new frmAddExamination();
                        
                        ConnectionNode.ExecuteSQLQuery(" SELECT   * FROM    Examination WHERE EXAM_ID = " + System.Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            exame.txtExamID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EXAM_ID"]);
                            exame.txtExamName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ExaminationName"]);
                            exame.cmbStatus.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Status"]);
                            exame.txtSuperName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SuperName"]);
                            exame.dtpHeldDate.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["HeldDate"]);
                            exame.dtpStartTime.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["StartTime"]);
                            exame.dtpEndTime.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["EndTime"]);
                            exame.dtpPublishDate.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["ResultPublishDate"]);
                            exame.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (exame)
                            {
                                exame.ShowDialog();
                            }
                            LoadData();
                        }
                    }
                    break;
            }
        }
    }
}
