using EDSCustomerPortal.Services;
using EDSCustomerPortal.Services.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSCustomerPortal.Menu
{
    public class SubscriptionMenu
    {
        readonly IAuthenticationService authenticationService = new AuthenticationService();

        public void AddSubscription(string meterId, string tariffId, string pricePerUnit, string billCharged, string numberOfUnit)
        {
            Dictionary<string, string> navItemDIc = new Dictionary<string, string>();
            List<string> navigationItems = new List<string>
            {
                "MeterNumber","TariffId", "PricePerUnit", "AmountPaid", "NumberOfUnit"
            };
            Console.Clear();

            navItemDIc.Add(navigationItems[0], meterId);
            navItemDIc.Add(navigationItems[1], tariffId);
            navItemDIc.Add(navigationItems[2], pricePerUnit);
            navItemDIc.Add(navigationItems[3], billCharged);
            navItemDIc.Add(navigationItems[4], numberOfUnit);


            string MeterNumber, TariffId, PricePerUnit, NumberOfUnit, AmountPaid;
            MeterNumber = navItemDIc["MeterNumber"];
            TariffId = navItemDIc["TariffId"];
            PricePerUnit = navItemDIc["PricePerUnit"];
            AmountPaid = navItemDIc["AmountPaid"];
            NumberOfUnit = navItemDIc["NumberOfUnit"];

            ElectricityTariffPayment electricityTariffPayment = new ElectricityTariffPayment()
            {
                MeterNumber = MeterNumber,
                TariffId = TariffId,
                PricePerUnit = PricePerUnit,
                AmountPaid = AmountPaid,
                NumberOfUnit = NumberOfUnit,
            };

            authenticationService.RegisterSubscription(electricityTariffPayment);

            //var checkMeterNumberExist = AuthenticationService.ViewCustomerSubscriptionByMeterNumber(MeterNumber);

            //if (checkMeterNumberExist == null)
            //{
            //    AuthenticationService.RegisterSubscription(electricityTariffPayment);
            //}
            //else
            //{
            //    if (checkMeterNumberExist.MeterNumber == MeterNumber)
            //    {
            //        Console.WriteLine($" Bill Cancelled!!!\nYou're on Subscription... Redirecting...");
            //        Thread.Sleep(3000);

            //    }
            //    else
            //    {
            //        Console.WriteLine($" Validated!!!\n Payment Successfull!!!");
            //        AuthenticationService.RegisterSubscription(electricityTariffPayment);
            //    }
            //}

        }

        public void CalculateElectricityBill(string metreId)
        {
            
                double selectedTariffPlan; string tariffId = null; 
                string numberOfUnit; string priceperUnit = null;
                double billCharged = 0.0d;

                Console.WriteLine("Enter 1. Single Phase     2. Three Phase");
                selectedTariffPlan = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter the number of units you want");
                 numberOfUnit = Console.ReadLine();
                switch (selectedTariffPlan)
                {
                    case 1:
                        Console.WriteLine("You will be charged 25 Naira per Unit.");
                         tariffId = "SP";
                        priceperUnit = "25";
                        billCharged = Convert.ToInt32(numberOfUnit) * Convert.ToInt32(priceperUnit);
                        Console.WriteLine($"Your Bill is : {billCharged}\n Click Enter to Validate and Make Payment ");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("You will be charged 30 Naira per Unit.");
                        tariffId = "TP";
                        priceperUnit = "30";
                        billCharged = Convert.ToInt32(numberOfUnit) * Convert.ToInt32(priceperUnit);
                        Console.WriteLine($"Your Bill is : {billCharged}\n Click Enter to Validate and Make Payment ");
                        Console.ReadKey();
                    break;
                }

            AddSubscription( metreId, tariffId, priceperUnit, billCharged.ToString(), numberOfUnit);
        }
    }
}
