using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains.Validation
{
    public class Validator : IValidator
    {
        public bool Validate(List<Employee> lstEmployees, out string message)
        {
            message = string.Empty;
            if (lstEmployees == null || lstEmployees.Count == 0)
            {
                message = "No employees found in the list of employees.";
                return false;
            }
            return true;
        }
    }
}
