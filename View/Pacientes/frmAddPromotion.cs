using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddPromotion : Form
    {
        public BunifuDropdown school;
        public BunifuDropdown classe;
        public BunifuDropdown session;
        public BunifuDataGridView DataGridView1;

        public frmAddPromotion()
        {
            InitializeComponent();
        }

        #region DontMove
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        #endregion

        public void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool1);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClass1);
            ConnectionNode.FILLComboBox("SELECT        BATCH_ID, BatchName  FROM            Batch", cmbSession1);
        }

        private void frmAddPromotion_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool1.Text))
            {
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass1.Text))
            {
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSession1.Text))
            {
                Snackbar.Show(this, "Required: Session", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                foreach (DataGridViewRow row in DataGridView1.Rows)
                {
                    double STUDENT_ID = Convert.ToDouble(row.Cells[1].Value);
                    ConnectionNode.ExecuteSQLQuery(" SELECT   *  FROM            Promotion " +
                        " WHERE        (TO_SCHOOL_ID = " + school.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (TO_CLASS_ID = " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (TO_BATCH_ID = " + session.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (STUDENT_ID = " + Convert.ToString(STUDENT_ID) + ") ");
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    { }
                    // new promotion
                    else
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //insert data into promotion table
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO Promotion (FORM_SCHOOL_ID, FROM_CLASS_ID, FROM_BATCH_ID, TO_SCHOOL_ID, TO_CLASS_ID, TO_BATCH_ID, STUDENT_ID, User_ID, Year, Activity) VALUES ( " +
                                " " + school.Text.Split(" # ".ToCharArray()[0])[0] + ", " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ", " + session.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSchool1.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbClass1.Text.Split(" # ".ToCharArray()[0])[0] + ",  " + " " + cmbSession1.Text.Split(" # ".ToCharArray()[0])[0] + ", " + Convert.ToString(STUDENT_ID) + " , " + Convert.ToString(ConnectionNode.userID) + ", '" + Strings.Format(DateTime.Now, "yyyy") + "', 'Promoted' )");
                            //update data into student table
                            ConnectionNode.ExecuteSQLQuery(" UPDATE   StudentInformation SET  SCHOOL_ID=" + cmbSchool1.Text.Split(" # ".ToCharArray()[0])[0] + ", CLASS_ID=" + cmbClass1.Text.Split(" # ".ToCharArray()[0])[0] + ", BATCH_ID=" + cmbSession1.Text.Split(" # ".ToCharArray()[0])[0] + ", Status='Y' " +
                                " WHERE        (STUDENT_ID = " + Convert.ToString(STUDENT_ID) + ") ");
                        }
                        else
                        {
                            //insert data into promotion table
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO Promotion (FORM_SCHOOL_ID, FROM_CLASS_ID, FROM_BATCH_ID, TO_SCHOOL_ID, TO_CLASS_ID, TO_BATCH_ID, STUDENT_ID, User_ID, Year, Activity) VALUES ( " +
                                " " + school.Text.Split(" # ".ToCharArray()[0])[0] + ", " + classe.Text.Split(" # ".ToCharArray()[0])[0] + ", " + session.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSchool1.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbClass1.Text.Split(" # ".ToCharArray()[0])[0] + ",  " + " " + cmbSession1.Text.Split(" # ".ToCharArray()[0])[0] + ", " + Convert.ToString(STUDENT_ID) + " , " + Convert.ToString(ConnectionNode.userID) + ", '" + Strings.Format(DateTime.Now, "yyyy") + "', 'Not Promoted' )");
                            //update data into student table
                            ConnectionNode.ExecuteSQLQuery(" UPDATE   StudentInformation SET  SCHOOL_ID=" + cmbSchool1.Text.Split(" # ".ToCharArray()[0])[0] + ", CLASS_ID=" + cmbClass1.Text.Split(" # ".ToCharArray()[0])[0] + ", BATCH_ID=" + cmbSession1.Text.Split(" # ".ToCharArray()[0])[0] + ", Status='BY' " +
                                " WHERE        (STUDENT_ID = " + Convert.ToString(STUDENT_ID) + ") ");
                        }
                    }
                }

                this.Close();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void frmAddPromotion_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
