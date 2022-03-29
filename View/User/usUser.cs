using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usUser : UserControl
    {
        public usUser()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usUser _instance;

        public static usUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usUser();
                return _instance;
            }
        }
        #endregion

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (frm)
            {
                frm.ShowDialog();
            }
            LoadData();
        }

        public void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT User_ID, user_name,full_name, e_mail, contact_no, status  FROM Users", DataGridView1);
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Deseja editar os dados do usuario " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery("SELECT *  FROM Users WHERE User_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddUser frm = new frmAddUser();
                            frm.txtUserID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["User_ID"]);
                            frm.txtUserName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["user_name"]);
                            frm.txtuserFullName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["full_name"]);
                            frm.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["e_mail"]);
                            frm.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["contact_no"]);
                            //txtPassword.Text = System.Convert.ToString(ConnectionNode.sqlDT.Rows[0]["password"]);
                            byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["UserPicture"]);
                            MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                            frm.PictureBox1.Image = Image.FromStream(stmBLOBData);
                            frm.txtUserName.Enabled = false;
                            frm.btnSave.Text = "Update";

                            #region Check
                            if ((string)ConnectionNode.sqlDT.Rows[0]["status"] == "Y")
                            {
                                frm.chkActive.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
                            }
                            else
                            {
                                frm.chkActive.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
                            }
                            #endregion

                            #region OpenDialog
                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (frm)
                            {
                                frm.ShowDialog();
                            }
                            LoadData();
                            #endregion
                        }
                    }
                    break;
                default:
                    break;

            }

        }
    }
}
