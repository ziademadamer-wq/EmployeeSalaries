using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains
{
    public class Admin:Employee
    {
        public Admin()
        {
            Job = "Admin";
        }
        public override decimal CaluculateSalary()
        {
            FinalSalary = BasicSalary - DaysAbsence * 2 - DaysLate * 1.5m - TotalPenalties;
            return FinalSalary;
        }
    }
}
