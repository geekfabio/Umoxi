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
    public partial class usBus : UserControl
    {
        public usBus()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usBus _instance;

        public static usBus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBus();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid("SELECT    BUS_ID, Bus_no, Driver_Name, Driver_Contact, Supervisor, SupervisorContact  FROM            SchoolBus", DataGridView1);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddBus bus = new frmAddBus();
            using (bus)
            {
                bus.ShowDialog();
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
                        frmAddBus bus = new frmAddBus();
                        
                        ConnectionNode.ExecuteSQLQuery(" SELECT   * FROM            SchoolBus   WHERE        (BUS_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + ") ");
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            bus.txtBusID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BUS_ID"]);
                            bus.txtBusNO.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Bus_no"]);
                            bus.txtDriverContact.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Driver_Contact"]);
                            bus.txtDriverName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Driver_Name"]);
                            bus.txtSupervisorContact.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SupervisorContact"]);
                            bus.txtSupervisorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Supervisor"]);

                            bus.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (bus)
                            {
                                bus.ShowDialog();
                            }
                            LoadData();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
