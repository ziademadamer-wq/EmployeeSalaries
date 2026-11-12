using Employees_Salary.DAL.Converters;
using Employees_Salary.DAL.Readers;
using Employees_Salary.Domains;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Documents;

namespace Employees_Salary.DAL
{
    public class Repository
    {
      private readonly  IConverter _Converter;
      private readonly IHelper _Helper;
        private readonly string _DataSourceName;
        public Repository(IConverter converter,IHelper reader,string dataSourceName)
        {
            _Converter = converter;
            _Helper = reader;
            _DataSourceName = dataSourceName;
        }

        //CRUD operations
        public List<Employee> GetAll(out string message)
        {
            try 
            {
                //1. open json file 
                string jsonContent = _Helper.Read(_DataSourceName, out message);

                if (!string.IsNullOrEmpty(message))
                {
                  return new List<Employee>();
                }

                //2. deserialize json file to list of employees
                var lstemployees = _Converter.Deserialize(jsonContent);

                return lstemployees; 
            }
            catch(SerializationException ex)
            {
                message = "An error occurred while extracting items from data source.";
                return new List<Employee>();
            }
            catch (Exception ex)
            {
                message ="An error occurred while extracting items from data source.";
                return new List<Employee>();
            }
        }
        
    }
}
