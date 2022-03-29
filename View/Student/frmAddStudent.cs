using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using DevExpress.XtraBars.Navigation;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddStudent : Form
    {
        string ChekValue;
        public frmAddStudent()
        {
            InitializeComponent();
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;

            DataGridView1.Columns[2].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView2.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView2.Columns[7].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView4.Columns[6].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
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
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchool);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClass);
            ConnectionNode.FILLComboBox("SELECT        BATCH_ID, BatchName  FROM            Batch", cmbSession);
            ConnectionNode.FILLComboBox2("SELECT Nationality FROM  Nationality", cmbNationality);
        }

        private void LoadUpdateData()
        {
            ConnectionNode.FILLComboBox("SELECT ENDORSEMENT_ID, Endorsement FROM Endorsement", cmbEndorsement);
            ConnectionNode.FILLComboBox("SELECT        SCHOOL_ID, School_Name  FROM            SchoolInformation", cmbSchoolFees);
            ConnectionNode.FILLComboBox("SELECT        CLASS_ID, Class_name  FROM            ClassName", cmbClassFees);
            ConnectionNode.FillDataGrid(" SELECT        StudentEndorsement.AUTO_ID, Endorsement.Endorsement  FROM            StudentEndorsement INNER JOIN " + " Endorsement ON StudentEndorsement.ENDORSEMENT_ID = Endorsement.ENDORSEMENT_ID  WHERE        (StudentEndorsement.STUDENT_ID = " + txtStudentID.Text + ") ", DataGridView1);
            ConnectionNode.FillDataGrid("SELECT        AUTO_ID_LST_ACA, SchoolName, ClassName, PassYear, Result, Board  FROM            StudentLastAttended  WHERE        (STUDENT_ID = " + txtStudentID.Text + ")", DataGridView2);

            ConnectionNode.ExecuteSQLQuery(" SELECT  * FROM            StudentParentDetails  WHERE        (STUDENT_ID = " + txtStudentID.Text + ") ");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                txtFathersName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FathersName"]);
                txtFathersOccupation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["FathersOccupation"]);
                txtMothersName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["MothersName"]);
                txtMothersOccupation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["MothersOccupation"]);
                txtContactNoParent.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ContactNo"]);
                txtAddress.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Address"]);
                txtEmail.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Email"]);
                btnParentDetails.Text = "Update";
            }
            else
            {
                btnParentDetails.Text = "Save";
            }
        }

        private void frmAddStudent_Load(object sender, EventArgs e)
        {
            switch (btnSave.Text)
            {
                case "Add":
                    LoadData();
                    break;
                case "Update":
                    LoadData();
                    LoadUpdateData();
                    LoadStudentFees();
                    break;
            }
        }

        private void LoadStudentFees()
        {
            ConnectionNode.FillDataGrid(" SELECT        StudentLedger.STU_LED_ID, StudentLedger.EntryDate, StudentLedger.Month, SchoolFees.Fee_Type, StudentLedger.Debit, StudentLedger.Narration " +
                " FROM            StudentLedger INNER JOIN  SchoolFees ON StudentLedger.FEES_ID = SchoolFees.FEES_ID   WHERE        (StudentLedger.STUDENT_ID = " + txtStudentID.Text + ") ", DataGridView4);
        }

        private void rbActive_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            LoaCheckVal();
        }

        private void rbBulkActive_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            LoaCheckVal();
        }

        private void rbDeActive_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            LoaCheckVal();
        }

        private void LoaCheckVal()
        {
            if (rbActive.Checked)
            {
                ChekValue = "Y";
            }
            else if (rbBulkActive.Checked)
            {
                ChekValue = "BY";
            }
            else if (rbDeActive.Checked)
            {
                ChekValue = "N";
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtAdmissionNO, lblAdmissionNO);
            TransitionsEffects.ResetColor(txtStudentName, lblStudentName);
            TransitionsEffects.ResetColor(txtPresentAddress, lblPresentAddress);
            TransitionsEffects.ResetColor(txtContactNo, lblContactNo);

            if (string.IsNullOrEmpty(txtAdmissionNO.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                TransitionsEffects.ShowTransition(txtAdmissionNO, lblAdmissionNO);
                Snackbar.Show(this, "Required: Admission No", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSchool.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbSession.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                Snackbar.Show(this, "Required: Session", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtStudentName.Text))
            {
                NavigationBar.SelectedItem = tabStudent;
                TransitionsEffects.ShowTransition(txtStudentName, lblStudentName);
                Snackbar.Show(this, "Required: Student name", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbGender.Text))
            {
                NavigationBar.SelectedItem = tabStudent;
                Snackbar.Show(this, "Required: Gender", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtPresentAddress.Text))
            {
                NavigationBar.SelectedItem = tabStudent;
                TransitionsEffects.ShowTransition(txtPresentAddress, lblPresentAddress);
                Snackbar.Show(this, "Required: Address", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbNationality.Text))
            {
                NavigationBar.SelectedItem = tabStudent;
                Snackbar.Show(this, "Required: Nationality", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                NavigationBar.SelectedItem = tabStudent;
                TransitionsEffects.ShowTransition(txtContactNo, lblContactNo);
                Snackbar.Show(this, "Required: Contact", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(cmbBloodGroup.Text))
                    cmbBloodGroup.Text = "";
                switch (btnSave.Text)
                {
                    case "Add":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO  StudentInformation (  AdmissionNo, AdmisionDate, SCHOOL_ID, CLASS_ID, BATCH_ID, StudentName, Gender, DateOfBirth, PresentAddress, Nationality, ContactNO,  " +
                        " Email, BloodGroup, Height, Weight, SpecialNote, Status  ) VALUES ( " + (
                        " '" + UtilitiesFunctions.str_repl(txtAdmissionNO.Text) + "', '") + Strings.Format(dtpAdmissionDate.EditValue, "MM/dd/yyyy") + "', " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbSession.Text.Split(" # ".ToCharArray()[0])[0] + (", '" + UtilitiesFunctions.str_repl(txtStudentName.Text) + "', '" + UtilitiesFunctions.str_repl(cmbGender.Text) + "', '") + Strings.Format(dtpDateOfBirth.EditValue, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(txtPresentAddress.Text) + "', '" + UtilitiesFunctions.str_repl(cmbNationality.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "',   ") + (
                        "   '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', '" + UtilitiesFunctions.str_repl(cmbBloodGroup.Text) + "', '" + UtilitiesFunctions.str_repl(txtHeight.Text) + "', '" + UtilitiesFunctions.str_repl(txtWeight.Text) + "', '" + UtilitiesFunctions.str_repl(txtSpecialNote.Text) + "', '" + ChekValue + "' )"));
                        ConnectionNode.ExecuteSQLQuery("SELECT  STUDENT_ID FROM     StudentInformation  ORDER BY STUDENT_ID DESC");
                        double STUDENT_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["STUDENT_ID"]);
                        ConnectionNode.UploadStudentPhoto(STUDENT_ID, PictureBox1);
                        txtStudentID.Text = Convert.ToString(STUDENT_ID);


                        LoadUpdateData();
                        LoadStudentFees();
                        UtilitiesFunctions.StudentBanalce(double.Parse(txtStudentID.Text), txtBalance);
                        TabContent.SelectedTabPage = Page3;
                        btnSave.Text = "Salvar";
                        Snackbar.Show(this, "Estudante " + txtStudentName + " adicionado", BunifuSnackbar.MessageTypes.Success);
                        break;

                    case "Save":
                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  StudentInformation SET  AdmissionNo='" + UtilitiesFunctions.str_repl(txtAdmissionNO.Text) + "', AdmisionDate='" + Strings.Format(dtpAdmissionDate.EditValue, "MM/dd/yyyy") + "', SCHOOL_ID= " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ", CLASS_ID= " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ", BATCH_ID= " + cmbSession.Text.Split(" # ".ToCharArray()[0])[0] + (", StudentName='" + UtilitiesFunctions.str_repl(txtStudentName.Text) + "', Gender= '" + UtilitiesFunctions.str_repl(cmbGender.Text) + "', DateOfBirth= '") + Strings.Format(dtpDateOfBirth.EditValue, "MM/dd/yyyy") + ("', PresentAddress='" + UtilitiesFunctions.str_repl(txtPresentAddress.Text) + "', Nationality= '" + UtilitiesFunctions.str_repl(cmbNationality.Text) + "', ContactNO = '" + UtilitiesFunctions.str_repl(txtContactNo.Text) + "',   ") + (
                        " Email=  '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "', BloodGroup = '" + UtilitiesFunctions.str_repl(cmbBloodGroup.Text) + "', Height= '" + UtilitiesFunctions.str_repl(txtHeight.Text) + "', Weight='" + UtilitiesFunctions.str_repl(txtWeight.Text) + "', SpecialNote= '" + UtilitiesFunctions.str_repl(txtSpecialNote.Text) + "', Status= '" + ChekValue + "'   WHERE        (STUDENT_ID = ") + txtStudentID.Text + ")");

                        ConnectionNode.UploadStudentPhoto(double.Parse(txtStudentID.Text), PictureBox1);
                        //txtStudentID.Text = this.txtStudentID.Text;


                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabStudent)
            {
                TabContent.SelectedTabPage = Page2;
            }
            else if (NavigationBar.SelectedItem == tabDocs)
            {
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {
                    Snackbar.Show(this, "Required: Add student first", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                    TabContent.SelectedTabPage = Page3;
            }
            else if (NavigationBar.SelectedItem == tabAcadeInfo)
            {
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {
                    Snackbar.Show(this, "Required: Add student first", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                    TabContent.SelectedTabPage = Page4;
            }
            else if (NavigationBar.SelectedItem == tabParents)
            {
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {
                    Snackbar.Show(this, "Required: Add student first", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                    TabContent.SelectedTabPage = Page5;
            }
            else if (NavigationBar.SelectedItem == tabFees)
            {
                if (string.IsNullOrEmpty(txtStudentID.Text))
                {
                    Snackbar.Show(this, "Required: Add student first", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                    TabContent.SelectedTabPage = Page6;
            }
        }

        private void btnSaveEndorsment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEndorsement.Text))
            {
                Snackbar.Show(this, "Required: Document", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT  * FROM            StudentEndorsement  WHERE        (STUDENT_ID = " + txtStudentID.Text + ") AND (ENDORSEMENT_ID = " + cmbEndorsement.Text.Split(" # ".ToCharArray()[0])[0] + ") ");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    Snackbar.Show(this, "Document already exist", BunifuSnackbar.MessageTypes.Warning);
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO   StudentEndorsement ( STUDENT_ID, ENDORSEMENT_ID) VALUES (" + txtStudentID.Text + ", " + cmbEndorsement.Text.Split(" # ".ToCharArray()[0])[0] + ") ");
                    LoadUpdateData();
                    Snackbar.Show(this, "Document adicioned", BunifuSnackbar.MessageTypes.Success);
                }

            }
        }

        private void btnAcademicInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtPassingYear.Text))
            {
                Snackbar.Show(this, "Required: Passing year", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtResult.Text))
            {
                Snackbar.Show(this, "Required: Result", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtBoardUniversity.Text))
            {
                Snackbar.Show(this, "Required: Board", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnAcademicInfo.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO StudentLastAttended (STUDENT_ID, SchoolName, ClassName, PassYear, Result, Board) VALUES " +
                        " (" + txtStudentID.Text + (", '" + UtilitiesFunctions.str_repl(txtSchoolName.Text) + "', '" + UtilitiesFunctions.str_repl(txtClassName.Text) + "', '" + UtilitiesFunctions.str_repl(txtPassingYear.Text) + "', '" + UtilitiesFunctions.str_repl(txtResult.Text) + "', '" + UtilitiesFunctions.str_repl(txtBoardUniversity.Text) + "') "));
                        LoadUpdateData();
                        txtAcaID.Text = null;
                        txtSchoolName.Text = null;
                        txtClassName.Text = null;
                        txtPassingYear.Text = null;
                        txtResult.Text = null;
                        txtBoardUniversity.Text = null;
                        Snackbar.Show(this, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE   StudentLastAttended SET SchoolName='" + UtilitiesFunctions.str_repl(txtSchoolName.Text) + "', ClassName='" + UtilitiesFunctions.str_repl(txtClassName.Text) + "', PassYear='" + UtilitiesFunctions.str_repl(txtPassingYear.Text) + "', Result='" + UtilitiesFunctions.str_repl(txtResult.Text) + "', Board= '" + UtilitiesFunctions.str_repl(txtBoardUniversity.Text) + "' " +
                        " WHERE  AUTO_ID_LST_ACA=" + txtAcaID.Text + " ");
                        LoadUpdateData();
                        txtAcaID.Text = null;
                        txtSchoolName.Text = null;
                        txtClassName.Text = null;
                        txtPassingYear.Text = null;
                        txtResult.Text = null;
                        txtBoardUniversity.Text = null;
                        txtAcaID.Text = null;
                        Snackbar.Show(this, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void btnParentDetails_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFathersName.Text))
            {
                Snackbar.Show(this, "Required: Father", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtMothersName.Text))
            {
                Snackbar.Show(this, "Required: Mother", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                Snackbar.Show(this, "Required: Contact", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT  * FROM            StudentParentDetails  WHERE        (STUDENT_ID = " + txtStudentID.Text + ") ");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" UPDATE  StudentParentDetails SET   FathersName='" + UtilitiesFunctions.str_repl(txtFathersName.Text) + "', FathersOccupation='" + UtilitiesFunctions.str_repl(txtFathersOccupation.Text) + "', " + (
                        "   MothersName='" + UtilitiesFunctions.str_repl(txtMothersName.Text) + "', MothersOccupation= '" + UtilitiesFunctions.str_repl(txtMothersOccupation.Text) + "', ContactNo='" + UtilitiesFunctions.str_repl(txtContactNoParent.Text) + "' , Address='" + UtilitiesFunctions.str_repl(txtAddress.Text) + "' , Email='" + UtilitiesFunctions.str_repl(txtEmail.Text) + "' WHERE STUDENT_ID= ") + txtStudentID.Text + " ");
                    LoadData();
                    Snackbar.Show(this, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO  StudentParentDetails (STUDENT_ID, FathersName, FathersOccupation, MothersName, MothersOccupation, ContactNo, Address,  Email) VALUES " +
                        " ( " + txtStudentID.Text + (", '" + UtilitiesFunctions.str_repl(txtFathersName.Text) + "', '" + UtilitiesFunctions.str_repl(txtFathersOccupation.Text) + "', '" + UtilitiesFunctions.str_repl(txtMothersName.Text) + "', '" + UtilitiesFunctions.str_repl(txtMothersOccupation.Text) + "', '" + UtilitiesFunctions.str_repl(txtContactNoParent.Text) + "' , '" + UtilitiesFunctions.str_repl(txtAddress.Text) + "' , '" + UtilitiesFunctions.str_repl(txtEmail.Text) + "') "));
                    LoadData();
                    Snackbar.Show(this, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                }
            }
        }

        private void btnAddFees_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchool.Text))
            {
                Snackbar.Show(this, "Required: School", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbClass.Text))
            {
                Snackbar.Show(this, "Required: Class", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(cmbFees.Text))
            {
                Snackbar.Show(this, "Required: Fees", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" SELECT  * FROM            SchoolFees  WHERE        (FEES_ID = " + cmbFees.Text.Split(" # ".ToCharArray()[0])[0] + ") ");
                string xMonth = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Month"]);
                double xAmount = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["Amount"]);

                ConnectionNode.ExecuteSQLQuery(" INSERT INTO StudentLedger (STUDENT_ID, FEES_ID, EntryDate, EntryTime, User_ID, Debit, Credit, Narration, Month) VALUES  " +
                    " (" + txtStudentID.Text + ", " + cmbFees.Text.Split(" # ".ToCharArray()[0])[0] + ",  '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '" + DateAndTime.TimeOfDay + "', ") + System.Convert.ToString(ConnectionNode.userID) + ", " + System.Convert.ToString(xAmount) + (", 0, '" + UtilitiesFunctions.str_repl(txtRemarks.Text) + "', '") + xMonth + "' ) ");

                LoadStudentFees();
                UtilitiesFunctions.StudentBanalce(double.Parse(txtStudentID.Text), txtBalance);
                txtRemarks.Text = null;
                Snackbar.Show(this, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void cmbClassFees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSchoolFees.Text))
            {
                cmbFees.Items.Clear();
            }
            else if (string.IsNullOrEmpty(cmbClassFees.Text))
            {
                cmbFees.Items.Clear();
            }
            else
            {
                ConnectionNode.FILLComboBox(" SELECT        FEES_ID, Fee_Type  FROM            SchoolFees  WHERE        (SCHOOL_ID = " + cmbSchool.Text.Split(" # ".ToCharArray()[0])[0] + ") AND (CLASS_ID = " + cmbClass.Text.Split(" # ".ToCharArray()[0])[0] + ")  ", cmbFees);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                ConnectionNode.ExecuteSQLQuery(" DELETE StudentEndorsement WHERE  AUTO_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[1].Value) + " ");
            LoadUpdateData();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    ConnectionNode.ExecuteSQLQuery(" SELECT * FROM StudentLastAttended  WHERE  AUTO_ID_LST_ACA=" + Convert.ToString(DataGridView2.CurrentRow.Cells[2].Value) + " ");
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                        txtAcaID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AUTO_ID_LST_ACA"]);
                        txtSchoolName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["SchoolName"]);
                        txtClassName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ClassName"]);
                        txtPassingYear.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PassYear"]);
                        txtResult.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Result"]);
                        txtBoardUniversity.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Board"]);
                        txtAcaID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["AUTO_ID_LST_ACA"]);
                    }
                    btnAcademicInfo.Text = "Update";
                    txtSchoolName.Select();
                    break;
                case 1:
                    ConnectionNode.ExecuteSQLQuery(" DELETE StudentLastAttended WHERE  AUTO_ID_LST_ACA=" + Convert.ToString(DataGridView2.CurrentRow.Cells[2].Value) + " ");
                    LoadUpdateData();
                    break;
            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (MessageBox.Show("Are you sure you want to delete " + Convert.ToString(DataGridView4.CurrentRow.Cells[4].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.ExecuteSQLQuery(" DELETE StudentLedger WHERE   (STU_LED_ID = " + Convert.ToString(DataGridView4.CurrentRow.Cells[1].Value) + ") ");
                        LoadStudentFees();
                        Snackbar.Show(this, MessageDialog.TextMessage("Delete"), BunifuSnackbar.MessageTypes.Information);
                    }
                    break;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
