using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using DevExpress.XtraSplashScreen;
using Bunifu.UI.WinForms;

namespace Umoxi
{
    class UserPermission
    {
        #region Start code
        public static void LoadUserPermission()
        {
            
            if(ConnectionNode.userFuncao == "Admin")
            {

            }
            else if (ConnectionNode.userFuncao == "Medico")
            {

            }
            else if (ConnectionNode.userFuncao == "Laboratório")
            {

            }
            else if (ConnectionNode.userFuncao  == "Infermeiro")
            {

            }
            else if (ConnectionNode.userFuncao  == "Farmaceutico")
            {

            }
            else
            {

            }
            FrmMain.Default.ChangePasswordToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llChangePassword.Enabled = true;
        }
        #endregion
    }
}