using Employees_Salary.DAL.Converters;
using Employees_Salary.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Employees_Salary.DAL
{
    public class EmployeeConverter :JsonConverter<Employee>
    {
        public override Employee Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                string jobType = root.GetProperty("Job").GetString();

                return jobType switch
                {
                    "Admin" => JsonSerializer.Deserialize<Admin>(root.GetRawText(), options),
                    "Engineer" => JsonSerializer.Deserialize<Engineer>(root.GetRawText(), options),
                    "Sales" => JsonSerializer.Deserialize<SalesManager>(root.GetRawText(), options),
                    _ => throw new JsonException($"Unknown JobType: {jobType}")
                };        }   }
        public override void Write(Utf8JsonWriter writer, Employee value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
