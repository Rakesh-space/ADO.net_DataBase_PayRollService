using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_DataBase_PayRollService
{
    class EmployeeRepository
    {
        //here Sql connection provide by using " Sqlconnection " class
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=PayRoll_Serive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

    }
}
