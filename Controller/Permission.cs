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
                FrmMain.Default.ChangePasswordToolStripMenuItem.Enabled = true;
                //FrmMain.Default.llChangePassword.Enabled = true;
        }
        #endregion
    }
}