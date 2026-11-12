using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Employees_Salary.Domains;
namespace Employees_Salary.DAL.Converters
{
    public interface IConverter
    {
        public string Serialize(List<Employee> employees);
        public List<Employee> Deserialize(string content);

    }
}
