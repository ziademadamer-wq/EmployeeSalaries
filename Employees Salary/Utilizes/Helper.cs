using System;
using System.Collections.Generic;
using System.Text;

namespace Employees_Salary.Utilizes
{
    public static class Helper
    {
        public static string Trim(string Value)
        {
            int StartPosition = 0;
            int EndPosition = Value.Length - 1;

            while (Value[StartPosition] == ' ' && StartPosition != Value.Length) StartPosition++;

            while (Value[EndPosition] == ' ' && EndPosition != -1) EndPosition--;

            char[] newArray = new char[EndPosition - StartPosition + 1];

            for (int i = StartPosition; i <= EndPosition; i++)
                newArray[i - StartPosition] = Value[i];

            return new string(newArray);
        }
    }
}
