using System;

namespace ADO.net_DataBase_PayRollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeRepository connection = new EmployeeRepository();
            connection.GetAllEmployeeDetails();
            Console.ReadLine();

            EmployeeModel model = new EmployeeModel();
            model.employeeName = "tester";
            model.basicPay = 3560.50;
            model.gender = "M";
            model.startDate = DateTime.Now;
         

            EmployeeRepository Repo = new EmployeeRepository();
            Repo.AddEmployee(model);
            Console.ReadLine();
        }
    }
}

