﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddDepartment : Form
    {
        public frmAddDepartment()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtDepartmentName, lblDepartmentName);

            if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                TransitionsEffects.ShowTransition(txtDepartmentName, lblDepartmentName);
                Snackbar.Show(this, "Required: Department", BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO Department (Department_Name) VALUES ('" + UtilitiesFunctions.str_repl(txtDepartmentName.Text) + "')  ");
                        UtilitiesFunctions.Audit_Trail(ConnectionNode.xUser_ID, DateTime.Now.ToLongTimeString(), "Departamento adicionado # " + txtDepartmentName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        break;
                    case "Update":
                        ConnectionNode.ExecuteSQLQuery(" UPDATE Department SET Department_Name= '" + UtilitiesFunctions.str_repl(txtDepartmentName.Text) + "' WHERE  DEPARTMENT_ID=" + txtDepID.Text + "  ");
                        UtilitiesFunctions.Audit_Trail(ConnectionNode.xUser_ID, DateTime.Now.ToLongTimeString(), "Departamento atualizado # " + txtDepartmentName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }
    }
}
