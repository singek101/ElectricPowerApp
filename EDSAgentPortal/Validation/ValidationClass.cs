using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.Validation
{
    public class ValidationClass
    {
        public string CheckInput(string value)
        {
            while (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"{value} cannot be left blank");
                Console.Write($" {value} : ");
                value = Console.ReadLine();
            }
            return value;
        }
    }
}
