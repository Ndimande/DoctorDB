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
    public class EditQueries
    {

        public string Result { get; set; }

        public async void changePassword(TextBox username, TextBox password, TextBox email, TextBox contactNo)
        {
            using (SqlCommand cmd = new SqlCommand("ChangePassword", GlobalConfig.SQLCONN))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                cmd.Parameters.AddWithValue("@ContactNo", contactNo.Text);

                await GlobalConfig.SQLCONN.OpenAsync();

                using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                {
                    while(await sdr.ReadAsync())
                    {
                        Result = sdr["UserTest"].ToString();
                    }

                }
            }
        }
    }
}
