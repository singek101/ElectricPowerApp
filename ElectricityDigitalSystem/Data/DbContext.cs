using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Data
{
    public class DbContext
    {
        public List<AgentsModel> Agents { get; set; } = new List<AgentsModel>();

        public List<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
        
        public List<TarriffModel> Tariffs { get; set; } = new List<TarriffModel>();

        public List<Subscriptions> Subcriptions { get; set; } = new List<Subscriptions>();

        public List<ElectricityTariffPayment> TariffPayments { get; set; } = new List<ElectricityTariffPayment>();


    }


}
