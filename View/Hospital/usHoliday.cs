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
    public partial class usHoliday : UserControl
    {
        public usHoliday()
        {
            InitializeComponent();
            loadData();
            DataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usHoliday _instance;

        public static usHoliday Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usHoliday();
                return _instance;
            }
        }
        #endregion

        private void loadData()
        {
            ConnectionNode.FillDataGrid("SELECT HOLIDAY_ID, Description, HolidayDate FROM Holiday", DataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddHoliday_Click(object sender, EventArgs e)
        {
            frmAddHoliday holiday = new frmAddHoliday();

            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
            using (holiday)
            {
                holiday.ShowDialog();
            }
            loadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[3].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddHoliday holiday = new frmAddHoliday();

                        ConnectionNode.ExecuteSQLQuery(" SELECT * FROM Holiday WHERE HOLIDAY_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
                        holiday.txtHolidayID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["HOLIDAY_ID"]);
                        holiday.txtHoliday.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Description"]);
                        holiday.dtpHolidayDate.DateTime = Convert.ToDateTime(ConnectionNode.sqlDT.Rows[0]["HolidayDate"]);

                        holiday.btnSave.Text = "Update";

                        OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                        using (holiday)
                        {
                            holiday.ShowDialog();
                        }
                        loadData();
                    }
                    break;
            }

        }
    }
}
