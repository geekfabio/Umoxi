using Bunifu.UI.WinForms;
using DevExpress.XtraBars.Navigation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddPermission : Form
    {
        public BunifuDropdown permission;
        public int currentP;
        public frmAddPermission()
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

        #region AllToggleSwitch
        private void toggleSwitchcSchool_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchcSchool.IsOn)
            {
                case true:
                    #region True
                    chk101.Checked = true;
                    chk102.Checked = true;
                    chk103.Checked = true;
                    chk104.Checked = true;
                    chk105.Checked = true;
                    chk106.Checked = true;
                    chk107.Checked = true;
                    chk108.Checked = true;
                    chk109.Checked = true;
                    chk110.Checked = true;
                    chk111.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk101.Checked = false;
                    chk102.Checked = false;
                    chk103.Checked = false;
                    chk104.Checked = false;
                    chk105.Checked = false;
                    chk106.Checked = false;
                    chk107.Checked = false;
                    chk108.Checked = false;
                    chk109.Checked = false;
                    chk110.Checked = false;
                    chk111.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchStudent_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchStudent.IsOn)
            {
                case true:
                    #region True
                    chk301.Checked = true;
                    chk302.Checked = true;
                    chk303.Checked = true;
                    chk304.Checked = true;
                    chk305.Checked = true;
                    chk306.Checked = true;
                    chk307.Checked = true;
                    chk308.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk301.Checked = false;
                    chk302.Checked = false;
                    chk303.Checked = false;
                    chk304.Checked = false;
                    chk305.Checked = false;
                    chk306.Checked = false;
                    chk307.Checked = false;
                    chk308.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchEmployee_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchEmployee.IsOn)
            {
                case true:
                    #region True
                    chk401.Checked = true;
                    chk402.Checked = true;
                    chk403.Checked = true;
                    chk404.Checked = true;
                    chk405.Checked = true;
                    chk406.Checked = true;
                    chk407.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk401.Checked = false;
                    chk402.Checked = false;
                    chk403.Checked = false;
                    chk404.Checked = false;
                    chk405.Checked = false;
                    chk406.Checked = false;
                    chk407.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchLibrary_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchLibrary.IsOn)
            {
                case true:
                    #region True
                    chk501.Checked = true;
                    chk502.Checked = true;
                    chk503.Checked = true;
                    chk504.Checked = true;
                    chk505.Checked = true;
                    chk506.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk501.Checked = false;
                    chk502.Checked = false;
                    chk503.Checked = false;
                    chk504.Checked = false;
                    chk505.Checked = false;
                    chk506.Checked = false;
                    #endregion
                    break;
            }
        }
        private void toggleSwitchAccount_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchAccount.IsOn)
            {
                case true:
                    #region True
                    chk601.Checked = true;
                    chk602.Checked = true;
                    chk603.Checked = true;
                    chk604.Checked = true;
                    chk605.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk601.Checked = false;
                    chk602.Checked = false;
                    chk603.Checked = false;
                    chk604.Checked = false;
                    chk605.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchSMS_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchSMS.IsOn)
            {
                case true:
                    #region True
                    chk701.Checked = true;
                    chk702.Checked = true;
                    chk703.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk701.Checked = false;
                    chk702.Checked = false;
                    chk703.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchEmail_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchEmail.IsOn)
            {
                case true:
                    #region True
                    chk801.Checked = true;
                    chk802.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk801.Checked = false;
                    chk802.Checked = false;
                    #endregion
                    break;
            }
        }

        private void toggleSwitchUser_Toggled(object sender, EventArgs e)
        {
            switch (toggleSwitchUser.IsOn)
            {
                case true:
                    #region True
                    chk901.Checked = true;
                    chk902.Checked = true;
                    chk903.Checked = true;
                    chk904.Checked = true;
                    #endregion
                    break;
                case false:
                    #region False
                    chk901.Checked = false;
                    chk902.Checked = false;
                    chk903.Checked = false;
                    chk904.Checked = false;
                    #endregion
                    break;
            }
        }
        #endregion

        private void NavigationBar_SelectedItemChanged(object sender, NavigationBarItemEventArgs e)
        {
            #region tabNavegate
            if (NavigationBar.SelectedItem == tabSchool)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabStudent)
            {
                TabContent.SelectedTabPage = Page2;
            }
            else if (NavigationBar.SelectedItem == tabEmployee)
            {
                TabContent.SelectedTabPage = Page3;
            }
            else if (NavigationBar.SelectedItem == tabLibrary)
            {
                TabContent.SelectedTabPage = Page4;
            }
            else if (NavigationBar.SelectedItem == tabAccount)
            {
                TabContent.SelectedTabPage = Page5;
            }
            else if (NavigationBar.SelectedItem == tabSMS)
            {
                TabContent.SelectedTabPage = Page6;
            }
            else if (NavigationBar.SelectedItem == tabEmail)
            {
                TabContent.SelectedTabPage = Page7;
            }
            else if (NavigationBar.SelectedItem == tabUser)
            {
                TabContent.SelectedTabPage = Page8;
            }
            #endregion
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Permissions

            // Primary set up
            // -------ACTION-CODE- 101
            if (chk101.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 101)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 101) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 101)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 101) ");
                }
                else
                {
                }
            }
            // -------ACTION-CODE- 102
            if (chk102.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 102)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 102) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 102)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 102) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 103
            if (chk103.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 103)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 103) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 103)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 103) ");
                }
                else
                {
                }
            }
            // -------ACTION-CODE- 104
            if (chk104.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 104)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 104) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 104)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 104) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 105
            if (chk105.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 105)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 105) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 105)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 105) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 106
            if (chk106.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 106)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 106) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 106)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 106) ");
                }
                else
                {
                }
            }


            // -------ACTION-CODE- 107
            if (chk107.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 107)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 107) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 107)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 107) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 108
            if (chk108.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 108)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 108) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 108)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 108) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 109
            if (chk109.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 109)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 109) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 109)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 109) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 110
            if (chk110.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 110)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 110) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 110)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 110) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 111
            if (chk111.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 111)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 111) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 111)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 111) ");
                }
                else
                {
                }
            }



            // Student
            // -------ACTION-CODE- 301
            if (chk301.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 301)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 301) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 301)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 301) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 302
            if (chk302.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 302)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 302) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 302)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 302) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 303
            if (chk303.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 303)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 303) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 303)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 303) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 304
            if (chk304.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 304)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 304) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 304)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 304) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 305
            if (chk305.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 305)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 305) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 305)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 305) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 306
            if (chk306.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 306)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 306) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 306)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 306) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 307
            if (chk307.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 307)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 307) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 307)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 307) ");
                }
                else
                {
                }
            }


            // -------ACTION-CODE- 308
            if (chk308.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 308)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 308) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 308)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 308) ");
                }
                else
                {
                }
            }


            // Employee
            // -------ACTION-CODE- 401
            if (chk401.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 401)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 401) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 401)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 401) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 402
            if (chk402.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 402)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 402) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 402)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 402) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 403
            if (chk403.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 403)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 403) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 403)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 403) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 404
            if (chk404.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 404)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 404) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 404)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 404) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 405
            if (chk405.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 405)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 405) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 405)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 405) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 406
            if (chk406.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 406)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 406) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 406)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 406) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 407
            if (chk407.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 407)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 407) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 407)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 407) ");
                }
                else
                {
                }
            }


            // Library
            // -------ACTION-CODE- 501
            if (chk501.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 501)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 501) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 501)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 501) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 502
            if (chk502.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 502)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 502) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 502)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 502) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 503
            if (chk503.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 503)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 503) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 503)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 503) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 504
            if (chk504.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 504)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 504) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 504)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 504) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 505
            if (chk505.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 505)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 505) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 505)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 505) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 506
            if (chk506.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 506)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 506) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 506)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 506) ");
                }
                else
                {
                }
            }


            // Accounts
            // -------ACTION-CODE- 601
            if (chk601.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 601)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 601) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 601)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 601) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 602
            if (chk602.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 602)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 602) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 602)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 602) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 603
            if (chk603.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 603)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 603) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 603)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 603) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 604
            if (chk604.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 604)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 604) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 604)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 604) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 605
            if (chk605.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 605)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 605) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 605)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 605) ");
                }
                else
                {
                }
            }


            // sms
            // -------ACTION-CODE- 701
            if (chk701.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 701)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 701) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 701)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 701) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 702
            if (chk702.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 702)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 702) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 702)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 702) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 703
            if (chk703.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 703)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 703) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 703)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 703) ");
                }
                else
                {
                }
            }


            // Email
            // -------ACTION-CODE- 801
            if (chk801.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 801)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 801) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 801)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 801) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 802
            if (chk802.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 802)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 802) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 802)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 802) ");
                }
                else
                {
                }
            }


            // Administration
            // -------ACTION-CODE- 901
            if (chk901.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 901)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 901) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 901)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 901) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 902
            if (chk902.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 902)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 902) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 902)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 902) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 903
            if (chk903.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 903)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 903) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 903)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 903) ");
                }
                else
                {
                }
            }

            // -------ACTION-CODE- 904
            if (chk904.Checked)
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 904)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                }
                else
                {
                    ConnectionNode.ExecuteSQLQuery(" INSERT INTO permission ( User_ID, AccessKey) VALUES (" + permission.Text.Split()[0] + ", 904) ");
                }
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            permission   WHERE        (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 904)");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteSQLQuery(" DELETE FROM permission WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 904) ");
                }
                else
                {
                }
            }

            UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "user permission modified " + permission.Text + ".");

            this.Close();
            Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            #endregion
        }

        private void LoadToggleSwitch()
        {
            #region AllTabs
            //School
            if ((chk101.Checked == true) && (chk102.Checked == true) && (chk103.Checked == true) && (chk104.Checked == true) && (chk105.Checked == true) && (chk106.Checked == true) && (chk107.Checked == true) && (chk108.Checked == true) && (chk109.Checked == true) && (chk110.Checked == true) && (chk111.Checked == true))
            {
                toggleSwitchcSchool.IsOn = true;
            }
            else
            {
                toggleSwitchcSchool.IsOn = false;
            }
            //Student
            if ((chk301.Checked == true) && (chk302.Checked == true) && (chk303.Checked == true) && (chk304.Checked == true) && (chk305.Checked == true) && (chk306.Checked == true) && (chk307.Checked == true) && (chk308.Checked == true))
            {
                toggleSwitchStudent.IsOn = true;
            }
            else
            {
                toggleSwitchStudent.IsOn = false;
            }
            //Employee
            if ((chk401.Checked == true) && (chk402.Checked == true) && (chk403.Checked == true) && (chk404.Checked == true) && (chk405.Checked == true) && (chk406.Checked == true) && (chk407.Checked == true))
            {
                toggleSwitchEmployee.IsOn = true;
            }
            else
            {
                toggleSwitchEmployee.IsOn = false;
            }
            //Library
            if ((chk501.Checked == true) && (chk502.Checked == true) && (chk503.Checked == true) && (chk504.Checked == true) && (chk505.Checked == true) && (chk506.Checked == true))
            {
                toggleSwitchLibrary.IsOn = true;
            }
            else
            {
                toggleSwitchLibrary.IsOn = false;
            }
            //Account
            if ((chk601.Checked == true) && (chk602.Checked == true) && (chk603.Checked == true) && (chk604.Checked == true) && (chk605.Checked == true))
            {
                toggleSwitchAccount.IsOn = true;
            }
            else
            {
                toggleSwitchAccount.IsOn = false;
            }
            //SMS
            if ((chk701.Checked == true) && (chk702.Checked == true) && (chk703.Checked == true))
            {
                toggleSwitchSMS.IsOn = true;
            }
            else
            {
                toggleSwitchSMS.IsOn = false;
            }
            //Email
            if ((chk801.Checked == true) && (chk802.Checked == true))
            {
                toggleSwitchEmail.IsOn = true;
            }
            else
            {
                toggleSwitchEmail.IsOn = false;
            }
            //User
            if ((chk901.Checked == true) && (chk902.Checked == true) && (chk903.Checked == true) && (chk904.Checked == true))
            {
                toggleSwitchUser.IsOn = true;
            }
            else
            {
                toggleSwitchUser.IsOn = false;
            }
            #endregion
        }

        public void LoadAccessKey()
        {
            #region LoadAcess
            // primary set up
            // -------ACTION-CODE- 101
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 101)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk101.Checked = true;
            }
            else
            {
                chk101.Checked = false;
            }
            // -------ACTION-CODE- 102
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 102)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk102.Checked = true;
            }
            else
            {
                chk102.Checked = false;
            }
            // -------ACTION-CODE- 103
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 103)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk103.Checked = true;
            }
            else
            {
                chk103.Checked = false;
            }
            // -------ACTION-CODE- 104
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 104)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk104.Checked = true;
            }
            else
            {
                chk104.Checked = false;
            }

            // -------ACTION-CODE- 105
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 105)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk105.Checked = true;
            }
            else
            {
                chk105.Checked = false;
            }

            // -------ACTION-CODE- 106
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 106)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk106.Checked = true;
            }
            else
            {
                chk106.Checked = false;
            }

            // -------ACTION-CODE- 107
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 107)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk107.Checked = true;
            }
            else
            {
                chk107.Checked = false;
            }

            // -------ACTION-CODE- 108
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 108)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk108.Checked = true;
            }
            else
            {
                chk108.Checked = false;
            }

            // -------ACTION-CODE- 109
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 109)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk109.Checked = true;
            }
            else
            {
                chk109.Checked = false;
            }

            // -------ACTION-CODE- 110
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 110)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk110.Checked = true;
            }
            else
            {
                chk110.Checked = false;
            }

            // -------ACTION-CODE- 111
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 111)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk111.Checked = true;
            }
            else
            {
                chk111.Checked = false;
            }

            // Student

            // -------ACTION-CODE- 301
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 301)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk301.Checked = true;
            }
            else
            {
                chk301.Checked = false;
            }
            // -------ACTION-CODE- 302
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 302)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk302.Checked = true;
            }
            else
            {
                chk302.Checked = false;
            }
            // -------ACTION-CODE- 303
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 303)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk303.Checked = true;
            }
            else
            {
                chk303.Checked = false;
            }

            // -------ACTION-CODE- 304
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 304)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk304.Checked = true;
            }
            else
            {
                chk304.Checked = false;
            }

            // -------ACTION-CODE- 305
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 305)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk305.Checked = true;
            }
            else
            {
                chk305.Checked = false;
            }

            // -------ACTION-CODE- 306
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 306)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk306.Checked = true;
            }
            else
            {
                chk306.Checked = false;
            }

            // -------ACTION-CODE- 307
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 307)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk307.Checked = true;
            }
            else
            {
                chk307.Checked = false;
            }



            // -------ACTION-CODE- 308
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 308)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk308.Checked = true;
            }
            else
            {
                chk308.Checked = false;
            }

            // Employee

            // -------ACTION-CODE- 401
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 401)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk401.Checked = true;
            }
            else
            {
                chk401.Checked = false;
            }
            // -------ACTION-CODE- 402
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 402)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk402.Checked = true;
            }
            else
            {
                chk402.Checked = false;
            }
            // -------ACTION-CODE- 403
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 403)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk403.Checked = true;
            }
            else
            {
                chk403.Checked = false;
            }

            // -------ACTION-CODE- 404
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 404)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk404.Checked = true;
            }
            else
            {
                chk404.Checked = false;
            }

            // -------ACTION-CODE- 405
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 405)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk405.Checked = true;
            }
            else
            {
                chk405.Checked = false;
            }

            // -------ACTION-CODE- 406
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 406)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk406.Checked = true;
            }
            else
            {
                chk406.Checked = false;
            }

            // -------ACTION-CODE- 407
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 407)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk407.Checked = true;
            }
            else
            {
                chk407.Checked = false;
            }

            // Library

            // -------ACTION-CODE- 501
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 501)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk501.Checked = true;
            }
            else
            {
                chk501.Checked = false;
            }
            // -------ACTION-CODE- 402
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 502)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk502.Checked = true;
            }
            else
            {
                chk502.Checked = false;
            }
            // -------ACTION-CODE- 503
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 503)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk503.Checked = true;
            }
            else
            {
                chk503.Checked = false;
            }

            // -------ACTION-CODE- 504
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 504)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk504.Checked = true;
            }
            else
            {
                chk504.Checked = false;
            }

            // -------ACTION-CODE- 505
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 505)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk505.Checked = true;
            }
            else
            {
                chk505.Checked = false;
            }

            // -------ACTION-CODE- 506
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 506)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk506.Checked = true;
            }
            else
            {
                chk506.Checked = false;
            }

            // Account

            // -------ACTION-CODE- 601
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 601)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk601.Checked = true;
            }
            else
            {
                chk601.Checked = false;
            }
            // -------ACTION-CODE- 602
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 602)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk602.Checked = true;
            }
            else
            {
                chk602.Checked = false;
            }
            // -------ACTION-CODE- 603
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 603)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk603.Checked = true;
            }
            else
            {
                chk603.Checked = false;
            }

            // -------ACTION-CODE- 604
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 604)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk604.Checked = true;
            }
            else
            {
                chk604.Checked = false;
            }

            // -------ACTION-CODE- 605
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 605)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk605.Checked = true;
            }
            else
            {
                chk605.Checked = false;
            }


            // SMS

            // -------ACTION-CODE- 701
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 701)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk701.Checked = true;
            }
            else
            {
                chk701.Checked = false;
            }
            // -------ACTION-CODE- 702
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 702)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk702.Checked = true;
            }
            else
            {
                chk702.Checked = false;
            }
            // -------ACTION-CODE- 703
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 703)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk703.Checked = true;
            }
            else
            {
                chk703.Checked = false;
            }


            // EMAIL

            // -------ACTION-CODE- 801
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 801)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk801.Checked = true;
            }
            else
            {
                chk801.Checked = false;
            }
            // -------ACTION-CODE- 802
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 802)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk802.Checked = true;
            }
            else
            {
                chk802.Checked = false;
            }

            // Administration
            // -------ACTION-CODE- 901
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 901)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk901.Checked = true;
            }
            else
            {
                chk901.Checked = false;
            }
            // -------ACTION-CODE- 602
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 902)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk902.Checked = true;
            }
            else
            {
                chk902.Checked = false;
            }
            // -------ACTION-CODE- 903
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 903)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk903.Checked = true;
            }
            else
            {
                chk903.Checked = false;
            }

            // -------ACTION-CODE- 904
            ConnectionNode.ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    permission  WHERE (User_ID = " + permission.Text.Split()[0] + ") AND (AccessKey = 904)");
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                chk904.Checked = true;
            }
            else
            {
                chk904.Checked = false;
            }
            #endregion
            LoadToggleSwitch();
        }

        public void ViewAcess()
        {
            usPermission usPermission = new usPermission();
            LoadAccessKey();
            if ((chk101.Checked == true) && (chk102.Checked == true) && (chk103.Checked == true) && (chk104.Checked == true) && (chk105.Checked == true) && (chk106.Checked == true) && (chk107.Checked == true) && (chk108.Checked == true) && (chk109.Checked == true) && (chk110.Checked == true) && (chk111.Checked == true))
            {
                currentP = 1;
            }
        }
        private void frmAddPermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
