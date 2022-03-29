using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usFeesCollection : UserControl
    {
        public usFeesCollection()
        {
            InitializeComponent();
            DataGridView1.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView1.Columns[9].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
        }

        #region instance
        private static usFeesCollection _instance;

        public static usFeesCollection Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usFeesCollection();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.FillDataGrid(" SELECT        StudentLedger.STU_LED_ID, StudentLedger.STUDENT_ID, StudentInformation.StudentName, StudentLedger.EntryDate, StudentLedger.Credit,  " +
                "  StudentLedger.Narration, StudentLedger.Month, StudentLedger.PayMode  FROM            StudentLedger INNER JOIN " +
                " StudentInformation ON StudentLedger.STUDENT_ID = StudentInformation.STUDENT_ID  WHERE        (StudentLedger.PayMode = 'DINHEIRO' OR  StudentLedger.PayMode = 'CARTÃO') AND " +
                "  (StudentLedger.EntryDate >= '" + Strings.Format(dtpFrom.DateTime, "MM/dd/yyyy") + "' AND    StudentLedger.EntryDate <= '" + Strings.Format(dtpTo.DateTime, "MM/dd/yyyy") + "') ", DataGridView1);
        }

        private void btnAddPay_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddFeesCollection frm = new frmAddFeesCollection();
            using (frm)
            {
                frm.ShowDialog();
            }
            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadData();
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
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[6].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" DELETE FROM  StudentLedger WHERE  STU_LED_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + "  ");
                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateAndTime.TimeOfDay.ToString(), "Payment deleted # " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value));
                        LoadData();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Delete"), BunifuSnackbar.MessageTypes.Success);
                    }
                    break;
                case 2:
                    //Report.Student_Fees_Recipt(Convert.ToDouble(DataGridView1.CurrentRow.Cells[2].Value));
                    break;
            }
        }

    }
}
