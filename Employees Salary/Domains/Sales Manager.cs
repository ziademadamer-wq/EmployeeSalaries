using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains
{
    public class SalesManager:Employee
    {
        public SalesManager()
        {
            Job = "SalesManager";
        }
        public decimal CommissionPercent { get; set; }
        public override decimal CaluculateSalary()
        {
            FinalSalary = BasicSalary - TotalPenalties + (TotalSales * CommissionPercent);
            return FinalSalary;
        }
    }
}
