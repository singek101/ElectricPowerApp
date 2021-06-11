using EDSCustomerPortal.Services.IServices;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.Services
{
    public class AuthenticationService : IAuthenticationService
    {    
        public string RegisterUser(CustomerModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                CustomerService service = new CustomerService();
                string id = service.RegisterCustomer(model);
                return id == null ? "Failed" : "Success";
            }
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            CustomerService service = new CustomerService();
            var customerfound = service.GetCustomerByEmail(email);
            return customerfound;
        }

        public CustomerModel GetCustomerById(string customerId)
        {
            CustomerService service = new CustomerService();
            var customerfound = service.GetCustomerById(customerId);
            return customerfound;   
        }

        //Having Issue when I call the Update method from here
        //public static  UpdateCustomerData(CustomerModel model)
        //{
        //    CustomerService service = new CustomerService();
        //    service.UpdateCustomer(model);
        //    return true;
        //}

        public string RegisterSubscription(ElectricityTariffPayment electricityTariffPayment)
        {
            if (electricityTariffPayment == null )
            {
                throw new ArgumentNullException(nameof(electricityTariffPayment));
            }
            else
            {
                CustomerService service = new CustomerService();
                string meterNumber = service.RegisterCustomerSubcription(electricityTariffPayment);
                return meterNumber == null ? "Failed" : "Success";
            }
        }

        public ElectricityTariffPayment ViewCustomerSubscriptionByMeterNumber(string meterNumber)
        {
            CustomerService service = new CustomerService();
            var customerMeterNumber = service.ViewCustomerSubcriptionStatus(meterNumber);  

            if (customerMeterNumber == null)
            {
                throw new ArgumentNullException(nameof(customerMeterNumber));
            }
            else
            {
                return customerMeterNumber;
            }

        }

        public void DeleteSubscription(string metreId)
        {
            CustomerService service = new CustomerService();

            var customerNumber = service.ViewCustomerSubcriptionStatus(metreId);

            if (customerNumber == null)
            {
                throw new ArgumentNullException(nameof(customerNumber));
            }
            else
            {
                service.DeleteSubcription(customerNumber);
              
            }
        }
    }
}
