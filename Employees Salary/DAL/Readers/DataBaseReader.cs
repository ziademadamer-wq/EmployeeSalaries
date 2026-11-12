using Employees_Salary.DAL;
using Employees_Salary.DAL.Converters;
using Employees_Salary.Domains;
using Employees_Salary.Utilizes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.Json;

namespace Employees_Salary.DAL.Readers
{
    public class DataBaseReader : IHelper
    {
        IConverter _Converter;
        public DataBaseReader(IConverter converter)
        {
            _Converter = converter;
        }
        public string Read(string DataBaseName, out string message)
        {
            string ConnectionString = ($"Server=DESKTOP-DE3M387;Database={DataBaseName};Trusted_Connection=True;TrustServerCertificate=True;");
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                //open the connection 
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from TbEmployees", conn))
                {
                    DataSet ds = new DataSet("Employees"); // that is just a Name for dataset that will receive the data
                    adapter.Fill(ds);

                    // Convert DataTable rows into Employee subclasses
                    var employees = Conversion(ds);

                    var File = _Converter.Serialize(employees);
                    message = "";
                    return File;
                }
            }

        }
        private List<Employee> Conversion (DataSet ds)
        {
            var employees = ds.Tables[0].AsEnumerable()
                    .Select<DataRow, Employee>(row =>
                    {
                        string job = row.Field<string>("Job");
                        job = Helper.Trim(job);

                        return job switch
                        {
                            "Admin" => new Admin
                            {
                                Name = row.Field<string>("Name"),
                                Job = job,
                                BasicSalary = row.Field<decimal>("BasicSalary"),
                                DaysLate = row.Field<int>("DaysLate"),
                                DaysAbsence = row.Field<int>("DaysAbsence"),
                                TotalPenalties = row.Field<decimal>("TotalPenalties"),
                                TotalSales = row.Field<decimal>("TotalSales"),
                                FinalSalary = row.Field<decimal>("FinalSalary")
                            },
                            "Engineer" => new Engineer
                            {
                                Name = row.Field<string>("Name"),
                                Job = job,
                                BasicSalary = row.Field<decimal>("BasicSalary"),
                                DaysLate = row.Field<int>("DaysLate"),
                                DaysAbsence = row.Field<int>("DaysAbsence"),
                                TotalPenalties = row.Field<decimal>("TotalPenalties"),
                                TotalSales = row.Field<decimal>("TotalSales"),
                                FinalSalary = row.Field<decimal>("FinalSalary"),
                                Bonus = row.Field<decimal?>("Bonus") ?? 0
                            },
                            "Sales" => new SalesManager
                            {
                                Name = row.Field<string>("Name"),
                                Job = job,
                                BasicSalary = row.Field<decimal>("BasicSalary"),
                                DaysLate = row.Field<int>("DaysLate"),
                                DaysAbsence = row.Field<int>("DaysAbsence"),
                                TotalPenalties = row.Field<decimal>("TotalPenalties"),
                                TotalSales = row.Field<decimal>("TotalSales"),
                                FinalSalary = row.Field<decimal>("FinalSalary"),
                                CommissionPercent = row.Field<decimal?>("CommissionPercent") ?? 0
                            },
                            _ => throw new Exception($"Unknown Job type: {job}")
                        };
                    }).ToList();
            return employees;
        }
    
    }
}
