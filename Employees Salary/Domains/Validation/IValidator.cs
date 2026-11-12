using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Domains.Validation
{
    public interface IValidator
    {
        public bool Validate(List<Employee> lstEmployees, out string message);
    }
}
