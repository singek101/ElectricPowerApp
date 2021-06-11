using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Models
{
    public class CustomerModel : BaseUserModel
    {
        readonly Random meterNumber = new Random();

       public CustomerModel()
       {
           this.Id = "CUS-" + Guid.NewGuid().ToString();
           this.MeterNumber = ($"EDS-{meterNumber.Next(100000000, 999999999)}");
        }

        public string MeterNumber { get; set; }

        public string AgentId { get; set; }

        public string Password { get; set; }




    }
}
