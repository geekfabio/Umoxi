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
    public partial class frmAddBookReturn : Form
    {
        public frmAddBookReturn()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                Snackbar.Show(this, "Required: Book", BunifuSnackbar.MessageTypes.Error);
                txtStudentName.Select();
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery(" INSERT INTO BookReturn (BK_ISSU_ID, ReturnDate) VALUES (" + txtIssueID.Text + ", '" + Strings.Format(dtpReturnDate.DateTime, "MM/dd/yyyy") + "' ) ");
                ConnectionNode.ExecuteSQLQuery(" UPDATE BookIssue SET Remarks='" + UtilitiesFunctions.str_repl(txtRemarks.Text) + "', Status='Returned', ExpectedRtnDate= '" + Strings.Format(dtpReturnDate.DateTime, "MM/dd/yyyy") + "'  WHERE        (BK_ISSU_ID = " + txtIssueID.Text + ") ");
                ConnectionNode.ExecuteSQLQuery(" UPDATE  BookInfo SET QtyAvailable=QtyAvailable + 1  WHERE        (BOOK_ID = " + txtBookID.Text + ")");

                this.Close();
                Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
                TabContent.SelectedTabPage = Page1;
            else if (NavigationBar.SelectedItem == tabBeneficiary)
                TabContent.SelectedTabPage = Page2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddBookReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
