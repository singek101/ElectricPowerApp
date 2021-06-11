using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Common.ISubTarServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricityDigitalSystem.Common
{
    public class SubscriptionServices : AgentServicesAPI, ISubscriptionServices
    {
        public void MakeSubscription(Subscriptions subscription)
        {
            fileService.Database.Subcriptions.Add(subscription);
            fileService.SaveChanges();
        }
        public List<Subscriptions> GetAllSubscription()
        {
            var customerSubscription = fileService.Database.Subcriptions.ToList();
            return customerSubscription;
        }

        public List<Subscriptions> GetCustomerSubscription(string customerId)
        {
            var customerSubscription = fileService.Database.Subcriptions.Where(c => c.CustomerId == customerId).ToList();
            return customerSubscription;
        }

        public Subscriptions FindSubscription(string customerId)
        {
            var subscription = fileService.Database.Subcriptions.Find(s => s.CustomerId == customerId);
            return subscription;
        }

        public void CancelSubcription(string id)
        {
            var subToCancel = FindSubscription(id);
            subToCancel.SubscriptionStatus = "InActive";
        }

        public List<Subscriptions> CheckActiveSubscription(string customerId)
        {
            var activeSubscription = fileService.Database.Subcriptions.Where(x => x.CustomerId == customerId).ToList();
            var Sub = activeSubscription.Where(x => x.SubscriptionStatus == "Active").ToList();
            return Sub;
        }

        public string UpdateSubscription(Subscriptions modifiedSubscription)
        {

            if (modifiedSubscription != null)
            {
               // int indexOfCustomer = fileService.Database.Subcriptions.IndexOf(modifiedSubscription);
                //fileService.database.Customers.Insert(indexOfCustomer, modifiedCustomer);
                fileService.SaveChanges();
                return "SUCCESSFULLY UPDATED";
            }
            return "Failed, Customer not found";
        }
    }
}
