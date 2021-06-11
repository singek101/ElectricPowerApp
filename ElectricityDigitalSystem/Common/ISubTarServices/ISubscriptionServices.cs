using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Common.ISubTarServices
{
    public interface ISubscriptionServices
    {
        void MakeSubscription(Subscriptions subcription);

        List<Subscriptions> GetAllSubscription();

        List<Subscriptions> GetCustomerSubscription(string customerId);

        Subscriptions FindSubscription(string customerId);

        void CancelSubcription(string id);

        List<Subscriptions> CheckActiveSubscription(string customerId);

        string UpdateSubscription(Subscriptions modifiedSubscription);
    }
}
