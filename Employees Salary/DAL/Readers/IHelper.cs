using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.DAL.Readers
{
    public interface IHelper
    {
        public string Read(string DataSourceName, out string message);
      
    }
}
