using ElectricityDigitalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricityDigitalSystem.ClientServices
{
    public class CustomerService : ClientServicesAPI
    {
        public string RegisterCustomer(CustomerModel customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            //This will Handle registration of a customer
            else
            {
                //customer.Id = "CUS-" + Guid.NewGuid().ToString();
                //customer.MeterNumber = "EDS-" + Guid.NewGuid().ToString();
                fileService.Database.Customers.Add(customer);

                fileService.SaveChanges();
                return customer.Id;
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

        public string RegisterCustomerSubcription(ElectricityTariffPayment electricityTariffPayment)
        {
           
            if (electricityTariffPayment == null)
            {
                throw new ArgumentNullException(nameof(electricityTariffPayment));
            }
            //This ill Handle registration of a customer
            else
            {
                fileService.Database.TariffPayments.Add(electricityTariffPayment);
                fileService.SaveChanges();
                return electricityTariffPayment.MeterNumber;
            }
   
        }

        public ElectricityTariffPayment ViewCustomerSubcriptionStatus(string meterNumber)
        {

            ElectricityTariffPayment customerMeterNumber = fileService.Database.TariffPayments.Find(c => c.MeterNumber == meterNumber);
            if (customerMeterNumber != null)
            {
                return customerMeterNumber;
            }
            return null;
        }

        public bool DeleteSubcription(ElectricityTariffPayment electricityTariffPayment)
        {
            fileService.Database.TariffPayments.Remove(electricityTariffPayment);
            fileService.SaveChanges();
            return true;
        }

    }
}
