using Microsoft.VisualBasic;
using System;
using System.Text;
using Bunifu.UI.WinForms;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data.Utils;
using DevExpress.Utils.Animation;
using System.Drawing;
using System.IO;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Customization;
using Umoxi.Controller;

namespace Umoxi
{
    class UtilitiesFunctions
    {
        public static bool IsNumeric(object Expression)
        {
            int retNum;

            bool isNum = int.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static void ResetAllTexts(Form form)
        {
            int i = 0;
            foreach (Control control in form.Controls)
            {
                i++; Console.WriteLine(i.ToString());
                if (control is BunifuTextBox)
                {
                    Console.WriteLine("*////");
                    BunifuTextBox textBox = (BunifuTextBox)control;
                    textBox.Text = string.Empty;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }

        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }
        public static void AppClose(Form control, FormClosingEventArgs e, bool exit = false)
        {
            if(exit) { Environment.Exit(0); return; }
           
            FlyoutAction action = new FlyoutAction() { Caption = "      Sair do aplicativo?", Description = "Deseja realmente sair da aplicação?" };
            action.ImageOptions.Image = Properties.Resources.icons8_cancel;
            Predicate<DialogResult> predicate = canCloseFunc;
            FlyoutCommand command1 = new FlyoutCommand() { Text = "Sair", Result = DialogResult.Yes };
            FlyoutCommand command2 = new FlyoutCommand() { Text = "Cancelar", Result = DialogResult.No };
            action.Commands.Add(command1);
            action.Commands.Add(command2);
            FlyoutProperties properties = new FlyoutProperties();
            properties.ButtonSize = new Size(100, 40);
            properties.Style = FlyoutStyle.MessageBox;
            if (FlyoutDialog.Show(control, action, properties, predicate) == DialogResult.Yes)
            {
                e.Cancel = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region copyImage
        /// <summary>
        /// Copia imagem para o diretorio Avatar
        /// </summary>
        /// <param name="filePath">string do diretorio do ficheiro</param>
        public static bool CopyImageToPathAvatar(Image image, string filename)
        {
            try { 
                image.Save(ConnectionNode.appPathAvatar + filename, System.Drawing.Imaging.ImageFormat.Png);
                return true;
            }
            catch { return false; }
            }



        public static bool CopyImageToPathAvatar(string filePath, string filename)
        {                
          try  {
                if(!File.Exists(ConnectionNode.appPathAvatar + filename))
                {
                    File.Copy(filePath, ConnectionNode.appPathAvatar + filename);                
                }
                return true;

            }
            catch { return false; }
        }

        #endregion

        #region Password view

        public static void ViewPassword(bool status, BunifuTextBox textBox)
        {
            switch (status)
            {
                case true:
                    textBox.UseSystemPasswordChar = false;
                    textBox.IconRight = Properties.Resources.icons8_invisible_24px_1;
                    break;
                case false:
                    textBox.UseSystemPasswordChar = true;
                    textBox.IconRight = Properties.Resources.icons8_eye_24px_1;
                    break;
            }
        }
        #endregion

        #region replace
        public static object str_repl(string str)
        {
            return str.Replace("'", "").Replace(",", ",").Replace("`", "");
        }
        public static string stringReplacePath(string str)
        {

            return str.Replace(@"\", "/");
         }
        /// <summary>
        /// Usar para tirar formatos de hora e data : / pq o ficheiro n pode conter esses caracters 
        /// </summary>
        /// <param name="str">string para ser formatada</param>
        /// <returns></returns>
        public static string stringReplaceInvalidSymbols(string str)
        {   
            
            return str.Replace("/", "").Replace(":", "").Replace("`", "");
        }
        #endregion

        #region EmailCheck
        public static bool EmailCheck(string emailAddress)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var emailAddressMatch = Regex.Match(emailAddress, pattern);
            if (emailAddressMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Criptograpic
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        #endregion

        #region ExportToExcel
        public static void ExportDataToExcelSheet(DataGridView dgv)
        {
            //VERIFY Rows
            if(dgv.RowCount > 0) { 
            dynamic Exp_Xls = default(dynamic);
            int lig_cpt = 0;
            int Col_cpt = 0;
            Exp_Xls = Interaction.CreateObject("Excel.Application");
            Exp_Xls.Workbooks.add();
            Exp_Xls.Visible = true;
            try
            {
                //----------------
                for (Col_cpt = 0; Col_cpt <= dgv.ColumnCount - 4; Col_cpt++)
                {
                    Exp_Xls.ActiveSheet.Cells(1, Col_cpt + 1).value = dgv.Columns[Col_cpt].HeaderText;
                }
                for (lig_cpt = 0; lig_cpt <= dgv.Rows.Count - 1; lig_cpt++)
                {
                    for (Col_cpt = 0; Col_cpt <= dgv.ColumnCount - 4; Col_cpt++)
                    {
                        if (Information.IsNumeric(dgv[Col_cpt, lig_cpt].Value))
                        {
                            Exp_Xls.ActiveSheet.Cells(lig_cpt + 2, Col_cpt + 1).value = System.Convert.ToDouble(dgv[Col_cpt, lig_cpt].Value);
                        }
                        else
                        {
                            Exp_Xls.ActiveSheet.Cells(lig_cpt + 2, Col_cpt + 1).value = dgv[Col_cpt, lig_cpt].Value;
                        }
                    }
                }
                //----------------
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            }
        }
        #endregion

        #region name

        /// <summary>
        /// Registra ação de um usúario no sistema
        /// </summary>
        /// <param name="user_ID">ID do usúario logado no sistema</param>
        public static void Logger(int user_ID, string xtime = "", string actionUser = "")
        {
          
            ConnectionNode.sqlString = "INSERT INTO `usuario_log`(`usuario_id`, `action`, `date`) VALUES ('" + Convert.ToInt32(user_ID) + "','" + actionUser + "','" + DateTime.Now + "')";
            ConnectionNode.ExecuteCommad(ConnectionNode.sqlString);
        }


        /// <summary>
        /// Salva todas as ações de um usúario
        /// </summary>
        public static void Logger(string action) {

            //se o user_id for nullo então registra o usúario como desconhecido
            ConnectionNode.ExecuteCommad("INSERT INTO UserLog (usuario_id, Action, Date) VALUES (" + ConnectionNode.userID ?? 0 + ", '"+ action + "','" + DateTime.Now.ToLongTimeString() + "')");
        
        }
        #endregion

        #region Open Form
       
        public static void OpenForm(Control control, Form form)
        {
            MemoryManagement memoryManagement = new MemoryManagement();
            OverlayFormShow.Instance.ShowFormOverlay(control);
            using (form)
            {
                form.ShowDialog();
            }
            OverlayFormShow.Instance.CloseProgressPanel();
            memoryManagement.FlushMemory();
        } 
        #endregion

    }
}
