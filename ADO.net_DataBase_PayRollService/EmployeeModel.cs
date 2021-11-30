using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net_DataBase_PayRollService
{
    public class EmployeeModel
    {
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public float employeeSalary { get; set; }
        public DateTime startDate { get; set; }
        public string gender { get; set; }
        public long phoneNumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public double basicPay { get; set; }
        public double deduction { get; set; }
        public double taxeablePay { get; set; }
        public double incomeTax { get; set; }
        public double netPay { get; set; }
    }
}
