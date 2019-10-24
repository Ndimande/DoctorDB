using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorDBLibrary.DataAccess
{
    public class CheckQueries
    {
        public string Result { get; set; }

        public async void checkUser(TextBox username, TextBox password)
        {
            using (SqlCommand cmd = new SqlCommand("CheckUser", GlobalConfig.SQLCONN))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);

                GlobalConfig.SQLCONN.Open();
                
                // This so we can read whats coming out
                using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                {
                    while(await sdr.ReadAsync())
                    {
                        Result = sdr["UserExists"].ToString();
                    }
                }
                GlobalConfig.SQLCONN.Close();

            }
        }

        public async void checkUser(string username, string password)
        {
            using (SqlCommand cmd = new SqlCommand("CheckUser", GlobalConfig.SQLCONN))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                GlobalConfig.SQLCONN.Open();

                // This so we can read whats coming out
                using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                {
                    while (await sdr.ReadAsync())
                    {
                        Result = sdr["UserExists"].ToString();
                    }
                }

                GlobalConfig.SQLCONN.Close();

            }
        }
    }
}
