using System;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.Utils.Controls;
using System.Windows.Forms;

namespace Umoxi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            WindowsFormsSettings.ForceDirectXPaint();
            WindowsFormsSettings.SetDPIAware();
            WindowsFormsSettings.EnableFormSkins();
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
            WindowsFormsSettings.CustomizationFormSnapMode = SnapMode.OwnerControl;
            WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True;

            if (!ConnectionNode.CheckServer())
                Application.Run(new FrmServerSetting());
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT usuario_id FROM usuarios limit 1");
                if (ConnectionNode.sqlDT.Rows.Count == 1)
                    Application.Run(new frmLogIn());
                else
                    Application.Run(new FrmFirstOpen());
            }
        }
    }
}