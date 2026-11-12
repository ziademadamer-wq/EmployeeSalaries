using Employees_Salary.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Data;
namespace Employees_Salary.DAL.Converters
{
    public class JsonConv : IConverter
    {
        public string Serialize(List<Employee> employees)
        {
          var options = new JsonSerializerOptions
          {
            Converters = { new EmployeeConverter() },
            WriteIndented = true
          };
           return JsonSerializer.Serialize(employees, options);
        }
        public List<Employee> Deserialize(string json)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new EmployeeConverter() },
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Employee>>(json, options);
        }


    }
}

