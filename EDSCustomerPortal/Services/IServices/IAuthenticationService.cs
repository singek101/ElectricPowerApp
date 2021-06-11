using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.Services.IServices
{
    public interface IAuthenticationService
    {
        string RegisterUser(CustomerModel model);

        CustomerModel GetCustomerByEmail(string email);

        CustomerModel GetCustomerById(string customerId);

        string RegisterSubscription(ElectricityTariffPayment electricityTariffPayment);

        ElectricityTariffPayment ViewCustomerSubscriptionByMeterNumber(string meterNumber);

        void DeleteSubscription(string metreId);
    }
}
