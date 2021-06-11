using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.AgentServices.IServices
{
    public interface IAgentCustomerServices
    {
        string RegisterCustomer(CustomerModel customer);

        List<CustomerModel> GetAllRegisteredCustomer();

        CustomerModel GetCustomerById(string customerId);

        CustomerModel GetCustomerByEmail(string email);

        string UpdateCustomer(CustomerModel modifiedcustomer);
    }
}
