using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usDashboard : UserControl
    {
        public usDashboard()
        {
            InitializeComponent();
          
        }
        void loadTotalEmployees()
        {
            ConnectionNode.ExecuteSQLQuery("SELECT EmployeeID FROM `Employee`");
            labelDoutores.Text = ConnectionNode.sqlDT.Rows.Count.ToString();

        }
        void LoadDashboard()
        {
            try
            {
                ConnectionNode.ExecuteSQLQuery("SELECT paciente_id FROM `pacientes`Where estado_eliminado = '0'");
                labelConsultas.Text = ConnectionNode.sqlDT.Rows.Count.ToString();
            }
            finally
            {
                loadTotalEmployees();
               
            }
           
        }

        private void usDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }
    }
}
