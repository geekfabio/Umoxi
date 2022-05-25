using System;
using System.Drawing;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usDesignation : UserControl
    {
        string designacaoID = "";
        public usDesignation()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usDesignation _instance;

        public static usDesignation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usDesignation();
                return _instance;
            }
        }
        #endregion


        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT DESIGNATION_ID, Designation_Name FROM Designation", DataGridView1);
        }

        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            frmAddDesignation designation = new frmAddDesignation();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            using (designation)
            {
                designation.ShowDialog();
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
                    if (MessageBox.Show("Tem certeza de que deseja editar" + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddDesignation designation = new frmAddDesignation();
                        designation.txtDegID.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value);
                        designation.txtDesignationName.Text = Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value);
                        designation.btnSave.Text = "Atualizar";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (designation)
                        {
                            designation.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(""))
            {
                if (MessageBox.Show("Dejesa realmente eliminar o departamento?", "Paciente", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    ConnectionNode.ExecuteCommad("DELETE FROM `designation` WHERE DESIGNATION_ID = '" + designacaoID + "'");
                   // LoadData();
                }
            }
            else
            {
                MessageBox.Show("Selecione o departamento para eliminar", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
