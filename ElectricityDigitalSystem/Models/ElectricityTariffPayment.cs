using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Models
{
   public class ElectricityTariffPayment
    {
        public string MeterNumber { get; set; }

        public string TariffId { get; set; }

        public string PricePerUnit { get; set; }

        public string AmountPaid { get; set; }

        public string NumberOfUnit { get; set; }

        public DateTime DateOfPayment { get; set; } = DateTime.Now;


    }
}
