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
    public partial class frmAddEmployee : Form
    {
        private string ChekValues;

        public frmAddEmployee()
        {
            InitializeComponent();
           
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
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

        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT departamento_id, descricao FROM departamentos", cmbDepartment);
            ConnectionNode.FILLComboBox("SELECT DESIGNATION_ID, Designation_Name FROM Designation", cmbDesignation);
            ConnectionNode.FILLComboBox2("SELECT Nationality FROM  Nationality", cmbNationality);
        }

        private void LoadCheckVal()
        {
            if (rbActive.Checked)
            {
                ChekValues = "Y";
            }
            else
            {
                ChekValues = "N";
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                PictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

        }

        private void rbActive_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            LoadCheckVal();
        }

        private void rbDeActive_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            LoadCheckVal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadCheckVal();
            TransitionsEffects.ResetColor(txtEmployeeName, lblEmployeeName);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);
            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                TransitionsEffects.ShowTransition(txtEmployeeName, lblEmployeeName);
                Snackbar.Show(FrmMain.Default, "Required: Name", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbGender.Text))
                Snackbar.Show(FrmMain.Default, "Required: Gender", BunifuSnackbar.MessageTypes.Error);
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                Snackbar.Show(FrmMain.Default, "Required: Contact", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSchool.Text)) {
                NavigationBar.SelectedItem = tabAddInfo;
                Snackbar.Show(FrmMain.Default, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbDepartment.Text)) {
                NavigationBar.SelectedItem = tabAddInfo;
                Snackbar.Show(FrmMain.Default, "Required: Department", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbDesignation.Text)) {
                NavigationBar.SelectedItem = tabAddInfo;
                Snackbar.Show(FrmMain.Default, "Required: Designation", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Salvar":
                        #region save
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Employee (AC_ID, EmployeeName, FathersName, MothersName, Gender, BloodGroup, DateOfBirth, Nationality, Address, ContactNo, Email, JoiningDate, Status,  SCHOOL_ID, DEPARTMENT_ID, DESIGNATION_ID) VALUES " + (
                        " ( 6000, '" + UtilitiesFunctions.str_repl(txtEmployeeName.Text) + "', '" + UtilitiesFunctions.str_repl(txtFathersName.Text) + "', '" + UtilitiesFunctions.str_repl(txtMothersName.Text) + "', '" + UtilitiesFunctions.str_repl(cmbGender.Text) + "', '" + UtilitiesFunctions.str_repl(cmbBloodGroup.Text) + "', '") + Strings.Format(dtpDateOfBirth.EditValue, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(cmbNationality.Text) + "' ") + (
                        " , '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '") + Strings.Format(dtpJoiningDate.EditValue, "MM/dd/yyyy") + ("', '" + ChekValues + "', ") + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbDepartment.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbDesignation.Text.Split(" # ".ToCharArray()[0])[0] + " )");
                        ConnectionNode.ExecuteSQLQuery("SELECT  EmployeeID  FROM    Employee  ORDER BY EmployeeID DESC");
                        var EmployeeID = ConnectionNode.sqlDT.Rows[0]["EmployeeID"];
                       // ConnectionNode.UploadEmployeePhoto(Convert.ToDouble(EmployeeID), PictureBox1);

                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Funcionario adicionado # " + txtEmployeeName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                    case "Atualizar":
                        #region update
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  Employee SET EmployeeName= '" + UtilitiesFunctions.str_repl(txtEmployeeName.Text) + "', FathersName='" + UtilitiesFunctions.str_repl(txtFathersName.Text) + "', MothersName= '" + UtilitiesFunctions.str_repl(txtMothersName.Text) + "', Gender= '" + UtilitiesFunctions.str_repl(cmbGender.Text) + "', BloodGroup='" + UtilitiesFunctions.str_repl(cmbBloodGroup.Text) + "', DateOfBirth= '" + Strings.Format(dtpDateOfBirth.EditValue, "MM/dd/yyyy") + ("', Nationality= '" + UtilitiesFunctions.str_repl(cmbNationality.Text) + "' ") + (
                            " , Address= '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "', ContactNo= '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "', Email= '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', JoiningDate= '") + Strings.Format(dtpJoiningDate.EditValue, "MM/dd/yyyy") + ("', Status= '" + ChekValues + "', SCHOOL_ID= ") + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", DEPARTMENT_ID= " + cmbDepartment.Text.Split(" # ".ToCharArray()[0])[0] + ", DESIGNATION_ID= " + cmbDesignation.Text.Split(" # ".ToCharArray()[0])[0] + "   WHERE EmployeeID=" + txtEmployeeID.Text + "   ");
                       // ConnectionNode.UploadEmployeePhoto(double.Parse(txtEmployeeID.Text), PictureBox1);

                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Funcionario adicionado # " + txtEmployeeName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabAddInfo)
            {
                TabContent.SelectedTabPage = Page2;
            }
            else if (NavigationBar.SelectedItem == tabBarSalario)
            {
                TabContent.SelectedTabPage = xtraTabPage1;
            }
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
           OverlayFormShow.Instance.ShowFormOverlay(this);
           new frmAddDepartment().ShowDialog();
           OverlayFormShow.Instance.CloseProgressPanel();

        }
    }
}
