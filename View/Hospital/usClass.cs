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
    public partial class usClass : UserControl
    {
        public usClass()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usClass _instance;

        public static usClass Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usClass();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid(" SELECT    CLASS_ID, Class_Type, Class_name " + " FROM ClassType INNER JOIN  ClassName ON ClassType.CLASS_TYPE_ID = ClassName.CLASS_TYPE_ID ", DataGridView1);
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            frmAddClass addClass = new frmAddClass();
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (addClass)
            {
                addClass.ShowDialog();
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
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[3].Value) + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddClass addClass = new frmAddClass();

                        ConnectionNode.ExecuteSQLQuery(" SELECT ClassName.CLASS_ID, ClassName.Class_name, ClassName.CLASS_TYPE_ID, ClassType.Class_Type  FROM ClassType INNER JOIN " +
                        " ClassName ON ClassType.CLASS_TYPE_ID = ClassName.CLASS_TYPE_ID   WHERE        (ClassName.CLASS_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            addClass.txtClassID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["CLASS_ID"]);
                            addClass.txtClassName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Class_name"]);
                            //addClass.cmbClassName.Items.Clear();
                            //addClass.cmbClassName.Items.Add(ConnectionNode.sqlDT.Rows[0]["CLASS_TYPE_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_Type"]);
                            addClass.cmbClassName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["CLASS_TYPE_ID"] + " # " + ConnectionNode.sqlDT.Rows[0]["Class_Type"]);

                            addClass.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (addClass)
                            {
                                addClass.ShowDialog();
                            }
                            loadData();
                        }
                    }
                    break;
            }
        }
    }
}
