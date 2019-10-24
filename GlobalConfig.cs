using DoctorDBLibrary.DataAccess;
using System.Data.SqlClient;
using System.Configuration;
using DoctorDBLibrary.Logic.Events;

namespace DoctorDBLibrary
{
    // Static class so that we dont have to instantiate all the time
    public static class GlobalConfig
    {

        // This will be a static Sql connection that we can use anywhere in our PROJECT
        public static SqlConnection SQLCONN { get; set; } = Conn();

        public static CheckQueries CheckQueries { get; set; } = new CheckQueries();
        public static DeleteQueries DeleteQueries { get; set; } = new DeleteQueries();
        public static EditQueries EditQueries { get; set; } = new EditQueries();
        public static GetQueries GetQueries { get; set; } = new GetQueries();
        public static InsertQueries InsertQueries { get; set; } = new InsertQueries();
        public static ClickEvents ClickEvents { get; set; } = new ClickEvents();
        public static ClearEvents ClearEvents { get; set; } = new ClearEvents();
     



        public static SqlConnection Conn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DoctorDB"].ConnectionString);

        }
    }
}
