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
    public partial class usAllowances : UserControl
    {
        public usAllowances()
        {
            InitializeComponent();
            DataGridView2.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            LoadData();
        }

        #region instance
        private static usAllowances _instance;

        public static usAllowances Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usAllowances();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
		{
            ConnectionNode.FILLComboBox("SELECT departamento_id, descricao FROM departamentos", txtDepartamento);

            ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name  FROM            Employee INNER JOIN " +
				" Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
				" WHERE        (Employee.Status = 'Y')  ", DataGridView1);
			txtAmount.Text = null;
			txtAllowances.Text = null;
			dtpEntryDate.DateTime = DateTime.Now;
		}

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabList)
            {
                TabContent.SelectedTabPage = Page2;
            }
        }

        private void btnFindSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartamento.Text))
                Snackbar.Show(FrmMain.Default, "Por favor selecione o departamento", BunifuSnackbar.MessageTypes.Success);
            else
                ConnectionNode.FillDataGrid(" SELECT        Employee.EmployeeID, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name  FROM            Employee INNER JOIN " +
                " Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
                " WHERE        (Employee.Status = 'Y') AND (Employee.SCHOOL_ID = " + txtDepartamento.Text.Split(" # ".ToCharArray()[0])[0] + ") ", DataGridView1);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartamento.Text))
                Snackbar.Show(FrmMain.Default, "Por favor selecione o departamento", BunifuSnackbar.MessageTypes.Success);
            else if (string.IsNullOrEmpty(txtAllowances.Text))
                Snackbar.Show(FrmMain.Default, "Obrigatório: Subsídio", BunifuSnackbar.MessageTypes.Success);
            else if (!Information.IsNumeric(txtAmount.Text))
                Snackbar.Show(FrmMain.Default, "Obrigatório: Quantia", BunifuSnackbar.MessageTypes.Success);
            else if (Conversion.Val(txtAmount.Text) <= 0d)
                Snackbar.Show(FrmMain.Default, "Obrigatório: Quantia", BunifuSnackbar.MessageTypes.Success);
            else
            {
                if (DataGridView1.RowCount > 0)
                {
                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        double EmployeeID = Convert.ToDouble(row.Cells[1].Value);

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            ConnectionNode.ExecuteSQLQuery(" INSERT INTO    EmployeeLedger (EmployeeID, User_ID, EntryDate, Month, PostingType, Debit, Credit, Narration) VALUES " +
                                " (" + Convert.ToString(EmployeeID) + ", " + Convert.ToString(ConnectionNode.userID) + ", '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '" + DateTime.Now.ToString("MMMM") + "', 'Allowances', '" + UtilitiesFunctions.str_repl(txtAmount.Text) + "', 0, '" + UtilitiesFunctions.str_repl(txtAllowances.Text) + "') "));
                        }
                    }
                    UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "add  allowances # " + txtAllowances.Text);
                    LoadData();
                    Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    Snackbar.Show(FrmMain.Default, "Nenhum funcionário foi encontrado.", BunifuSnackbar.MessageTypes.Information);
                }
            }
        }

        private void btnFindData_Click(object sender, EventArgs e)
        {
            ConnectionNode.FillDataGrid(" SELECT        EmployeeLedger.EMP_LED_ID, EmployeeLedger.EntryDate, Employee.EmployeeName, Designation.Designation_Name, Department.Department_Name, " +
            " EmployeeLedger.Month, EmployeeLedger.Debit, EmployeeLedger.Credit FROM            EmployeeLedger INNER JOIN " +
            " Employee ON EmployeeLedger.EmployeeID = Employee.EmployeeID INNER JOIN Department ON Employee.DEPARTMENT_ID = Department.DEPARTMENT_ID INNER JOIN  Designation ON Employee.DESIGNATION_ID = Designation.DESIGNATION_ID " +
            " WHERE        (EmployeeLedger.PostingType = 'Allowances') AND (EmployeeLedger.EntryDate >= '" + Strings.Format(dtpFrom.DateTime, "MM/dd/yyyy") + "' AND   EmployeeLedger.EntryDate <= '" + Strings.Format(dtpTo.DateTime, "MM/dd/yyyy") + "') ", DataGridView2);
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Tem certeza de que deseja excluir " + Convert.ToString(DataGridView2.CurrentRow.Cells[3].Value) + " ? ", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" DELETE FROM EmployeeLedger WHERE (EMP_LED_ID = " + Convert.ToString(DataGridView2.CurrentRow.Cells[1].Value) + ") ");
                        btnFindData.PerformClick();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Delete"), BunifuSnackbar.MessageTypes.Information);
                    }
                    break;
            }
        }
    }
}
