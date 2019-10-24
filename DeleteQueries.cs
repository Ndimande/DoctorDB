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
    public class DeleteQueries
    {
        public string Result { get; set; }

        public async void deleteUsers(TextBox username)
        {
            try
            {
                using(SqlCommand cmd = new SqlCommand("DeletePatient", GlobalConfig.SQLCONN))
                {
                    // This will allow us to call the STORED PROCEDURE
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding the method parameters to the STORED PROCEDURE
                    cmd.Parameters.AddWithValue("", username);
                    //cmd.Parameters.AddWithValue();

                    // This opens up the database connection
                    GlobalConfig.SQLCONN.Open();
                    // This will execute the Non Query using async
                    await cmd.ExecuteNonQueryAsync();
                    // This will close off the connection (Always close off the connection)
                    GlobalConfig.SQLCONN.Close();
                }
            }
            catch (Exception ex)
            {
                // Using string interperlation to display the message
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
