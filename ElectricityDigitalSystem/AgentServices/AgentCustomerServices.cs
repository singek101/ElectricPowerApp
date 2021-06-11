using ElectricityDigitalSystem.AgentServices.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricityDigitalSystem.AgentServices
{
    public class AgentCustomerServices : AgentServicesAPI, IAgentCustomerServices
    {

        public string RegisterCustomer(CustomerModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            //This will Handle registration of a customer
            else
            {
                fileService.Database.Customers.Add(customer);

                fileService.SaveChanges();
                return customer.Id == null ? "Failed" : "Success";
            }
        }

        public CustomerModel GetCustomerById(string customerId)
        {
            CustomerModel foundcustomer = fileService.Database.Customers.Find(c => c.Id == customerId);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        public List<CustomerModel> GetAllRegisteredCustomer()
        {
            var allCustomers = fileService.Database.Customers.ToList();
            return allCustomers;
        }

        //Find Customer via Email
        public CustomerModel GetCustomerByEmail(string email)
        {
            CustomerModel foundcustomer = fileService.Database.Customers.Find(c => c.EmailAddress == email);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        public string UpdateCustomer(CustomerModel modifiedcustomer)
        {
            CustomerModel foundCustomer = this.GetCustomerById(modifiedcustomer.Id);
            if (foundCustomer != null)
            {
                //fileService.Database.Customers.IndexOf(foundCustomer);
                //fileService.Database.Customers.Insert(indexOfFoundCustomer, foundCustomer);
                fileService.SaveChanges();
                return "SUCCESS";
            }

            return "FAILURE NOT FOUND";
        }
    }
}
