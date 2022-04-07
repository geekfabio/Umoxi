using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Umoxi
{
    class ConnectionNode
    {
        #region Start code

        public static DataTable sqlDT = new DataTable();

        public static string appPathAvatar = Application.StartupPath + @"\avatar\";
        public static string connString = Properties.Settings.Default.dbUmoxiConnectionString;
        public static string sqlString;
        public static string tmpStr;
        public static string xUserPassword;
        public static int userID;
        public static string userName;
        public static string userFullName;
        public static string userFuncao;
        public static string userEmail;
        public static int LOGID;

        ///Metodo para ver o estado da conexão com a base de dados
        ///

        public static void CheckPath()
        {
            if (!Directory.Exists(appPathAvatar))
            {
                Directory.CreateDirectory(appPathAvatar);
            }
        }
        /// <summary>
        /// ConnDB é um valor que recebe quando vai alterar o servidor
        /// assim verifica se a conexão existe ou não
        /// </summary>
        /// <param name="connDb"></param>
        /// <returns></returns>
        public static bool CheckServer(String connDb = "")
        {
            //verifica os diretorios necessário para executar o app
            CheckPath();
            MySqlConnection sqlCon = new MySqlConnection(connString);
            if (connDb == "")
                sqlCon = new MySqlConnection(connString);
            else
                sqlCon = new MySqlConnection(connDb);
            try {
                sqlCon.Open();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        public static void ExecuteCommad(string sqlQuery)
        {
            try
            {
                MySqlConnection sqlCon = new MySqlConnection(connString);
                sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
            #if DEBUG
                MessageBox.Show("Erro : " + ex.Message, "Erro!!! Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
            }         

        }
      

        public static DataTable ExecuteSQLQuery(string sqlQuery)
        {
            try
            {
                MySqlConnection sqlCon = new MySqlConnection(connString);
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(sqlQuery, sqlCon);
                MySqlCommandBuilder sqlCB = new MySqlCommandBuilder(sqlDA);

                sqlDT.Reset(); // refresh 
                sqlDA.Fill(sqlDT);
            }
            catch (Exception ex)
            {
            #if DEBUG
                MessageBox.Show("Erro : " + ex.Message, "Erro!!! Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endif
            }
            
            return sqlDT;
        }

        //Preenche as comboBox com os dados da db
        public static void FILLComboBox(string sql, System.Windows.Forms.ComboBox cb)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            cb.Items.Clear();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cb.Items.Add(rdr[0].ToString() + " # " + rdr[1].ToString());
                rdr.Close();
            }
            catch (Exception ex)
            {
            #if DEBUG
                MessageBox.Show("Erro:" + ex.ToString());
            #endif
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as comboBox com os dados da db
        public static void FILLComboBox2(string sql, System.Windows.Forms.ComboBox cb)
        {
            var conn = new SqlConnection(connString);
            cb.Items.Clear();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cb.Items.Add(rdr[0].ToString());
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as datagridview com os dados da db
        public static void FillDataGrid(string sql, DataGridView dgv)
        {
            var conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var adp = new MySqlDataAdapter();
                var dt = new DataTable();
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                dgv.DataSource = dt;
                adp.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as listbox com os dados da db
        public static void FillListBox(string sql, ListBoxControl lstbox)
        {
            var conn = new SqlConnection(connString);
            lstbox.Items.Clear();
            try
            {
                conn.Open();
                var DT = new DataTable();
                var DS = new DataSet();
                DS.Tables.Add(DT);
                var DA = new SqlDataAdapter(sql, conn);
                DA.Fill(DT);
                foreach (DataRow r in DT.Rows)
                    lstbox.Items.Add(r[0].ToString() + " # " + r[1].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Priencher as listbox com os dados da db
        public static void FillListBox2(string sql, ListBoxControl lstbox)
        {
            var conn = new SqlConnection(connString);
            lstbox.Items.Clear();
            try
            {
                conn.Open();
                var DT = new DataTable();
                var DS = new DataSet();
                DS.Tables.Add(DT);
                var DA = new SqlDataAdapter(sql, conn);
                DA.Fill(DT);
                foreach (DataRow r in DT.Rows)
                    lstbox.Items.Add(r[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //Carregar o logo para db
        public static void UploadCompanyLogo(double id, PictureEdit pictureLogo)
        {
            string appLogo = appPathAvatar + "logo.png";
            MySqlConnection con = new MySqlConnection(connString);
            con.Open();
            string sql = "UPDATE Hospital SET  logo=@photo WHERE SCHOOL_ID=" + id + " ";
            MySqlCommand cmd = new MySqlCommand(sql, con);
          
            //Elimina o ficheiro caso existe
            if (File.Exists(appLogo)) {
                File.Delete(appLogo);
            }
           
            pictureLogo.Image.Save(appLogo); 
            
            cmd.Parameters.Add("@photo", MySqlDbType.String).Value=appLogo;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a photo do usuario
        public static void UploadUserPhoto(double userID, String imagePath)
        {
            string destFileName = Path.Combine(appPathAvatar, "user " + UtilitiesFunctions.stringReplaceInvalidSymbols(DateTime.Now.ToString()) + ".png");
            //upload image
            try
            {
                if (!String.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath)) {
                    File.Copy(sourceFileName: imagePath, destFileName);
                }
                else
                    destFileName = "sem_foto";
            }
            finally { 
            var con = new MySqlConnection(connString);
            con.Open();
            string sql = "UPDATE usuarios SET foto=@photo WHERE usuario_id=" + userID + " ";
            MySqlCommand cmd = new MySqlCommand(sql, con);
               cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@photo",
                    MySqlDbType = MySqlDbType.Text,
                    Value = destFileName
                });
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            }
        }

        //Carregar a imagem do livro
        public static void UploadBookCoverPhoto(double BOOK_ID, PictureEdit imageBitmap)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  BookInfo SET  CoverPhoto=@photo WHERE BOOK_ID=" + BOOK_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            imageBitmap.Image.Save(ms, imageBitmap.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a imagem do estudante
        public static void UploadStudentPhoto(double STUDENT_ID, PictureEdit imageBitmap)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  StudentInformation SET  StudentPicture=@photo WHERE STUDENT_ID=" + STUDENT_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            imageBitmap.Image.Save(ms, imageBitmap.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //Carregar a imagem do funcionario
        public static void UploadEmployeePhoto(double EmployeeID, PictureEdit imageBitmap)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  Employee  SET  EmployeePicture=@photo WHERE EmployeeID=" + EmployeeID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            imageBitmap.Image.Save(ms, imageBitmap.Image.RawFormat);
            var data = ms.GetBuffer();
            var p = new SqlParameter("@photo", SqlDbType.Image)
            {
                Value = data
            };
            cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //fff


        #endregion

       
    }
}
