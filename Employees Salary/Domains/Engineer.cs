using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains
{
    public class Engineer:Employee
    {
        public Engineer()
        {
            Job = "Engineer";
        }
        public decimal Bonus { get; set; }
        public override decimal CaluculateSalary()
        {
            FinalSalary = BasicSalary + Bonus - DaysAbsence - TotalPenalties;
            return FinalSalary;
        }
    }
}
