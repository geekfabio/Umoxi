using Bunifu.UI.WinForms;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usUserLog : UserControl
    {
        public usUserLog()
        {
            InitializeComponent();
         
        }

        #region instance
        private static usUserLog _instance;

        public static usUserLog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usUserLog();
                return _instance;
            }
        }
        #endregion

        public void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT usuario_id, usuario FROM usuarios", cmbUserName);
            ConnectionNode.FillDataGrid("SELECT usuario_log.Date as Data, usuario_log.Action as Atividade, usuarios.nome FROM usuario_log INNER JOIN usuarios ON usuario_log.usuario_id = usuarios.usuario_id " +
                  " LIMIT 100", DataGridView1);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                Snackbar.Show(FrmMain.Default, "Selecione o usúario", BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                ConnectionNode.FillDataGrid("SELECT usuario_log.Date as Data, usuario_log.Action as Atividade, usuarios.nome FROM usuario_log INNER JOIN usuarios ON usuario_log.usuario_id = usuarios.usuario_id " +
                    " WHERE  usuario_log.usuario_id = '" + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + "'  ", DataGridView1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCleanLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUserName.Text))
            {
                Snackbar.Show(FrmMain.Default, "Selecione o usúario", BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                ConnectionNode.ExecuteSQLQuery("SELECT usuario_id FROM usuarios  WHERE (usuario_id = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ")");
                if (ConnectionNode.sqlDT.Rows.Count > 0)
                {
                    ConnectionNode.ExecuteCommad(" DELETE FROM `usuario_log` WHERE (`usuario_id` = " + cmbUserName.Text.Split(" # ".ToCharArray()[0])[0] + ")");
                    btnSubmit.PerformClick();
                    Snackbar.Show(FrmMain.Default, "Logs eliminado com sucesso", BunifuSnackbar.MessageTypes.Information);
                }
                else
                {
                    Snackbar.Show(FrmMain.Default, "O registo do usuário selecionado não foi encontrado", BunifuSnackbar.MessageTypes.Information);
                }
            }
        }

        private void usUserLog_Load(object sender, EventArgs e)
        {
            LoadData();
           

        }
    }
}
