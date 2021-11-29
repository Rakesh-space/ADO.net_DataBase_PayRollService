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
        //uc 1 ADO.NET Connection databse
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=PayRoll_Service1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // createdconnection objto connect with database
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void GetAllEmployeeDetails()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                string query = @"select * from PayRoll_Serive";
                //command obj forexecuting query against database
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                //Executing command obj
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.employeeId = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                        model.employeeName = reader["name"] == DBNull.Value ? default : reader["name"].ToString();
                        model.employeeSalary = (float)Convert.ToDouble(reader["employeeSalary"] == DBNull.Value ? default : reader["employeeSalary"]);
                        model.startDate = (DateTime)((reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]));
                        model.gender = reader["gender"] == DBNull.Value ? default : reader["gender"].ToString();
                        model.phoneNumber = (long)Convert.ToDouble(reader["phone"] == DBNull.Value ? default : reader["phone"]);
                        model.department = reader["department"] == DBNull.Value ? default : reader["department"].ToString();
                        model.address = reader["address"] == DBNull.Value ? default : reader["address"].ToString();
                        model.taxeablePay = Convert.ToDouble(reader["Taxable_Pay"] == DBNull.Value ? default : reader["Taxable_Pay"]);
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.employeeId, model.employeeName, model.employeeSalary, model.startDate, model.gender, model.phoneNumber, model.department, model.address, model.taxeablePay);
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    Console.WriteLine("No rows present");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sqlConnection.Close();  //here Close the SQL Connection
            }
        }
    }
}
