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
    public partial class usSubject : UserControl
    {
        public usSubject()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usSubject _instance;

        public static usSubject Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usSubject();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid(" SELECT        Subject.SUBJECT_ID, Subject.SubjectCode, Subject.SubjectName, SchoolInformation.School_Name, Batch.BatchName, ClassName.Class_name  FROM            Subject INNER JOIN " + " ClassName ON Subject.CLASS_ID = ClassName.CLASS_ID INNER JOIN   Batch ON Subject.BATCH_ID = Batch.BATCH_ID INNER JOIN " + " SchoolInformation ON Subject.SCHOOL_ID = SchoolInformation.SCHOOL_ID ", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddSubject subject = new frmAddSubject();
            using (subject)
            {
                subject.ShowDialog();
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
                        frmAddSubject subject = new frmAddSubject();

                        ConnectionNode.ExecuteSQLQuery(" SELECT        Subject.SUBJECT_ID, Subject.SubjectCode, Subject.SubjectName, Subject.SCHOOL_ID, SchoolInformation.School_Name, Subject.BATCH_ID, Batch.BatchName,  Subject.CLASS_ID, ClassName.Class_name " +
                        " FROM            Subject INNER JOIN ClassName ON Subject.CLASS_ID = ClassName.CLASS_ID INNER JOIN  Batch ON Subject.BATCH_ID = Batch.BATCH_ID INNER JOIN " +
                        " SchoolInformation ON Subject.SCHOOL_ID = SchoolInformation.SCHOOL_ID  WHERE        (Subject.SUBJECT_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            subject.txtSubjectID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SUBJECT_ID"]);
                            subject.txtSubjectCode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SubjectCode"]);
                            subject.txtSubjectName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SubjectName"]);
                            subject.cmbSchool.Text = ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["School_Name"];
                            subject.cmbClass.Text = ConnectionNode.sqlDT.Rows[0]["CLASS_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_name"];
                            subject.cmbBatch.Text = ConnectionNode.sqlDT.Rows[0]["BATCH_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["BatchName"];
                            subject.txtSubjectCode.Select();

                            subject.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (subject)
                            {
                                subject.ShowDialog();
                            }
                            loadData();
                        }
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
