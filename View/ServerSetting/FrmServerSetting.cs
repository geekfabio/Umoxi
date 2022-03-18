using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Umoxi
{
    public partial class FrmServerSetting : DevExpress.XtraBars.ToolbarForm.ToolbarForm
    {
        public FrmServerSetting()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmServerSetting defaultInstance;

        /// <summary>
        /// default instance behavour in C#
        /// </summary>
        public static FrmServerSetting Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmServerSetting();
                    defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        public void SaveConfig()
        {
            Properties.Settings.Default.dbUmoxiConnectionString = txtconnString.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("O registro foi armazenado com sucesso", "salvo com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();

            if (string.IsNullOrEmpty(txtconnString.Text))
            {
                splashScreenManager1.CloseWaitForm();

                MessageBox.Show("Por favor introduza uma String de conexão valida...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          
            }
            else if (ConnectionNode.CheckServer())
            {
                SaveConfig();
                splashScreenManager1.CloseWaitForm();

            }
            else
            {
                splashScreenManager1.CloseWaitForm();

                MessageBox.Show("Por favor introduza uma String de conexão valida...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
          //  splashScreenManager1.CloseWaitForm();
        }

        public void ReadConnectionString()
        {
            try {
               txtconnString.Text = Properties.Settings.Default.dbUmoxiConnectionString;
            }
            catch
            {
                MessageBox.Show("Nenhuma configuração da base de dados encontrada", "Base de dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        public void frmServerSetting_Load(Object sender, System.EventArgs e)
        {
            ReadConnectionString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
