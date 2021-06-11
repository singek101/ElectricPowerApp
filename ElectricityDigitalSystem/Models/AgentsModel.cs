using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Models
{
    public class AgentsModel : BaseUserModel
    {
        public AgentsModel() => Id = "AGT-" + Guid.NewGuid().ToString();

        public string Password { get; set; }

    }
}
