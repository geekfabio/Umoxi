using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usSchool : UserControl
    {
        public usSchool()
        {
            InitializeComponent(); 
            LoadData();
            DataGridView1.Columns[7].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usSchool _instance;

        public static usSchool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usSchool();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT  SCHOOL_ID, School_Name, Address, Contact_No, FAX, Email, Web  FROM    SchoolInformation", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddSchool_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddSchool school = new frmAddSchool();
            using (school)
            {
                school.ShowDialog();
            }
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region Edit
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" SELECT * FROM SchoolInformation  WHERE SCHOOL_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddSchool school = new frmAddSchool();

                            school.txtSchoolID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SCHOOL_ID"]);
                            school.txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                            school.txtAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                            school.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Contact_No"]);
                            school.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                            school.txtFAX.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FAX"]);
                            school.txtWeb.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Web"]);
                            byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["SCH_LOGO"]);
                            MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                            school.PictureBox1.Image = Image.FromStream(stmBLOBData);
                            
                            school.btnSave.Text = "Update";

                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (school)
                            {
                                school.ShowDialog();
                            }
                            LoadData();
                            #endregion

                        }
                    }
#endregion
                    break;
                default:
                    #region View
                    ConnectionNode.ExecuteSQLQuery(" SELECT * FROM SchoolInformation  WHERE SCHOOL_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                        txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["School_Name"]);
                        txtAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                        txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Contact_No"]);
                        txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                        txtFAX.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FAX"]);
                        txtWeb.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Web"]);
                        byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["SCH_LOGO"]);
                        MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                        PictureBox1.Image = Image.FromStream(stmBLOBData);
                    }
                    #endregion
                    break;
            }
        }

    }
}
