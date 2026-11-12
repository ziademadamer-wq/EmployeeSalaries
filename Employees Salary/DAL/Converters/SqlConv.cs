using Employees_Salary.Domains;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Employees_Salary.DAL.Converters
{
    public class SqlConv : IConverter
    {
        public List<Employee> Deserialize(string content)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new EmployeeConverter() },
                WriteIndented = true
            };
            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(content,options);
            return employees;
        }

        public string Serialize(List<Employee> employees)
        {
            string File = JsonSerializer.Serialize(employees);
            return File;
        }

       
    }
}
