using System;
using System.Collections.Generic;
using System.Data;
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

        //Add Record
        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    //here use the Sotred_Procedure "Employee_DetailsPro"
                    SqlCommand command = new SqlCommand("dbo.Employee_DetailsPro", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.employeeName);
                    command.Parameters.AddWithValue("@Basic_Pay", model.basicPay);
                    //command.Parameters.AddWithValue("@EmployeeId", model.id_num);
                    command.Parameters.AddWithValue("@StartDate", model.startDate);
                    //command.Parameters.AddWithValue("@Salary", model.Salary);
                    //command.Parameters.AddWithValue("@Phone", model.PhoneNumber);
                    // command.Parameters.AddWithValue("@address", model.Address);
                    //command.Parameters.AddWithValue("@department", model.Department);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    //command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    //command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    //command.Parameters.AddWithValue("@incomeTax", model.IncomeTax);
                    //command.Parameters.AddWithValue("@Taxable_pay", model.TaxablePay);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Succesfull inserted record");
                    }
                    else
                    {
                        Console.WriteLine("Unsuccesfull");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        // updete record
        public void UpdateSalary(EmployeeModel model)
        {
            try
            {

                using (this.sqlConnection)
                {
                    //here use the Sotred_Procedure "Employee_DetailsPro"
                    EmployeeModel displeymodel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("dbo.spUpdateEmployeeDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.employeeName);
                    command.Parameters.AddWithValue("@Basic_Pay", model.basicPay);
                    //command.Parameters.AddWithValue("@EmployeeId", model.id_num);
                    //command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    //command.Parameters.AddWithValue("@Salary", model.Salary);
                    //command.Parameters.AddWithValue("@Phone", model.PhoneNumber);
                    // command.Parameters.AddWithValue("@address", model.Address);
                    //command.Parameters.AddWithValue("@department", model.Department);
                    //command.Parameters.AddWithValue("@gender", model.Gender);
                    //command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    //command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    //command.Parameters.AddWithValue("@incomeTax", model.IncomeTax);
                    //command.Parameters.AddWithValue("@Taxable_pay", model.TaxablePay);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Succesfull Updeted record");
                    }
                    else
                    {
                        Console.WriteLine("Unsuccesfull");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        // delete record
        public void DeleteRecord(EmployeeModel model)
        {
            try
            {

                using (this.sqlConnection)
                {
                    EmployeeModel displeymodel = new EmployeeModel();
                    //here use the Sotred_Procedure "Employee_DetailsPro"
                    SqlCommand command = new SqlCommand("dbo.spDeleteEmployeeDetails1", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@name", model.Name);
                    //command.Parameters.AddWithValue("@Basic_Pay", model.Basic_Pay);
                    command.Parameters.AddWithValue("@employeeName", model.employeeName);
                    //command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    //command.Parameters.AddWithValue("@Salary", model.Salary);
                    //command.Parameters.AddWithValue("@Phone", model.PhoneNumber);
                    // command.Parameters.AddWithValue("@address", model.Address);
                    //command.Parameters.AddWithValue("@department", model.Department);
                    //command.Parameters.AddWithValue("@gender", model.Gender);
                    //command.Parameters.AddWithValue("@Deduction", model.Deduction);
                    //command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    //command.Parameters.AddWithValue("@incomeTax", model.IncomeTax);
                    //command.Parameters.AddWithValue("@Taxable_pay", model.TaxablePay);
                    sqlConnection.Open();
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Succesfull Deleted record");
                    }
                    else
                    {
                        Console.WriteLine("Unsuccesfull");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

    }
}
