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
            ConnectionNode.FillDataGrid("SELECT usuario_id, usuario, nome, email, contacto, ativo FROM usuarios", DataGridView1);
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
                    if (MessageBox.Show("Deseja atualizar os dados do usuario " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery("SELECT *  FROM usuarios WHERE usuario_id =" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " limit 1");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddUser frm = new frmAddUser();
                            frm.txtUserID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["usuario_id"]);
                            frm.txtUserName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["usuario"]);
                            frm.txtuserFullName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["nome"]);
                            frm.txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["email"]);
                            frm.txtContactNo.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["contacto"]);

                            //txtPassword.Text = System.Convert.ToString(ConnectionNode.sqlDT.Rows[0]["password"]);
                            if (File.Exists(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"])))
                            {
                                frm.PictureBox1.Image = Image.FromFile(Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]));
                                frm.userPhoto = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["foto"]);
                            }
                            else frm.userPhoto = "sem_foto";
                            frm.txtUserName.Enabled = false;
                            frm.btnSave.Text = "Atualizar";

                            #region Check
                            if ((string)ConnectionNode.sqlDT.Rows[0]["ativo"] == "Y")
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

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
    }
}
