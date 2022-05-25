using DevExpress.XtraSplashScreen;
using System;
using System.Reflection;

namespace Umoxi
{
    public partial class LoadingScreen : SplashScreen
    {
        public LoadingScreen()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © " + DateTime.Now.Year.ToString();
            this.labelVersion.Text = String.Format("Versão " + AssemblyVersion);
        }

        #region Version
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        #endregion

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {

        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
           
        }
    }
}