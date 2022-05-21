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
    public partial class usDepartment : UserControl
    {
        string departamentoID = "";
        public usDepartment()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usDepartment _instance;

        public static usDepartment Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDepartment();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT departamento_id, descricao FROM departamentos", DataGridView1);
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
          
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
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddDepartment department = new frmAddDepartment();
                        department.txtDepID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        department.txtDepartmentName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        department.btnSave.Text = "Atualizar";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (department)
                        {
                            department.ShowDialog();
                        }
                        LoadData();
                    }
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDepartment department = new frmAddDepartment();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (department)
            {
                department.ShowDialog();
            }
            LoadData();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(departamentoID))
            {
                if (MessageBox.Show("Dejesa realmente eliminar o departamento?", "Paciente", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    ConnectionNode.ExecuteCommad("DELETE FROM `departamentos` WHERE departamento_id = '" + departamentoID + "'");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Selecione o departamento para eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
