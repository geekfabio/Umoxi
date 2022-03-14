using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Xml;
using MySql.Data.MySqlClient;

namespace Umoxi
{
    class ConnectionNode
    {
        #region Start code

        public static DataTable sqlDT = new DataTable();

        public static string appPathAvatar = Application.StartupPath + @"\avatar\";
        public static string connString = "server=localhost;uid=root; database=db_hospital;uid=root;pwd=";
        public static string sqlSTR;
        public static string tmpStr;
        public static string xUserPassword;
        public static int xUser_ID;
        public static string userName;
        public static string fullName;
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
        public static bool CheckServer()
        {
            CheckPath();
            return true;
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

        //Priencher as comboBox com os dados da db
        public static void FILLComboBox(string sql, System.Windows.Forms.ComboBox cb)
        {
            var conn = new SqlConnection(connString);
            cb.Items.Clear();
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    cb.Items.Add(rdr[0].ToString() + " # " + rdr[1].ToString());
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
            var conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                var cmd = new SqlCommand(sql, conn);
                var adp = new SqlDataAdapter();
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
        public static void UploadUserPhoto(double USER_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  Users SET  UserPicture=@photo WHERE User_ID=" + USER_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
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

        //Carregar a imagem do livro
        public static void UploadBookCoverPhoto(double BOOK_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  BookInfo SET  CoverPhoto=@photo WHERE BOOK_ID=" + BOOK_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
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
        public static void UploadStudentPhoto(double STUDENT_ID, PictureEdit PB1)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  StudentInformation SET  StudentPicture=@photo WHERE STUDENT_ID=" + STUDENT_ID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
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
        public static void UploadEmployeePhoto(double EmployeeID, PictureEdit PB1)
        {
            var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE  Employee  SET  EmployeePicture=@photo WHERE EmployeeID=" + EmployeeID + " ";
            var cmd = new SqlCommand(sql, con);
            var ms = new MemoryStream();
            PB1.Image.Save(ms, PB1.Image.RawFormat);
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
