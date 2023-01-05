using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PageGalleryCore.Utility
{
    public class Database
    {
        String connectionString = "Persist Security Info=False;Integrated Security=true;  Initial Catalog = Gallery; Server=localhost\\MSSQLSERVER01";
        String cmd;
        public SqlConnection sqlConnection;
        public Database(String cmd)
        {
            this.cmd = cmd;
            sqlConnection = new SqlConnection(connectionString);
        }
        public SqlDataReader selector()
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            return dr;
        }
    }
}
