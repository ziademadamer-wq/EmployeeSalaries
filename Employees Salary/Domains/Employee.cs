using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains
{
    public abstract class Employee
    {
        public string Name { get; set; } ="";
       public string Job { get; set; } = "";
        public decimal BasicSalary { get; set; }
        public int DaysLate { get; set; }
        public int DaysAbsence { get; set; }
        public decimal TotalPenalties { get; set; } 
        public decimal TotalSales { get; set; }
        public decimal FinalSalary { get; set; }

        public abstract decimal CaluculateSalary();

    }
   
}
