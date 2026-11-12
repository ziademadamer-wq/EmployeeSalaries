using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
namespace Employees_Salary.DAL.Readers
{
    public class FileReader :IHelper
    {
        private static readonly Encoding Utf8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);
     
        public string Read(string FileName,out string message)
        {
            //intialize message to empty string
            message = string.Empty;

            //I already wrote the Folder Name and File Name here, you can change it if you want to read from another Source
            string FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonData");
            if (!Path.Exists(FolderPath))
            {
                message = "The folder of the DataFile does not exist.";
                return string.Empty;
            }
            string FullPath = Path.Combine(FolderPath, $"{FileName}.json");      
            if (!File.Exists(FullPath))
            {
                message = "Employees.json file does not exist.";
                return string.Empty;
            }
            //read the content of the file and check if it is empty, if so return a message
            var content = File.ReadAllText(FullPath, Utf8NoBOM);

            if (string.IsNullOrEmpty(content))
            {
               message  = "Employees.json file is empty.";
            }
            return content;
        }    
        

    }
}
