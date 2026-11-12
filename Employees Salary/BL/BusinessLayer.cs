using Employees_Salary.DAL;
using Employees_Salary.DAL.Converters;
using Employees_Salary.Domains;
using Employees_Salary.Domains.Validation;
using Employees_Salary.DAL.Readers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace Employees_Salary.BL
{
    public class BusinessLayer
    {
       private readonly Repository _Repository;

        public BusinessLayer(StorageType storageType)
        {
            switch(storageType)
            {
                case StorageType.Json:
                    var FileSerilizer = new JsonConv();
                    _Repository = new Repository(FileSerilizer, new FileReader(), "EmployeeSalaries"); //I put the file Name here 
                    break;
                case StorageType.Database:
                    var SqlSerilizer = new SqlConv();
                    _Repository = new Repository(SqlSerilizer, new DataBaseReader(SqlSerilizer), "EmployeeSalaries");  //I already wrote DataBase Name , enter to DataBaseReader to type your Server Name 
                    break;
            }
        }
        public List<Employee> GetAll(out string message)
        {
            var lstemployees = _Repository.GetAll(out message);

            if (!string.IsNullOrEmpty(message))
                return new List<Employee>();

            if(IsValid(lstemployees,out message))  
              foreach (var employee in lstemployees)
              {
                 //4. calculate salary according to job through switch statement
                 employee.CaluculateSalary();
              }

            return lstemployees;
        }
        public bool IsValid (List<Employee>lstEmployees,out string message)
        {
            IValidator validator = new Validator();
           return validator.Validate(lstEmployees,out message);     
        }


    }
}
