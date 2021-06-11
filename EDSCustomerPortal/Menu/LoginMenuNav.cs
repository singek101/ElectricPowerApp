using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.Menu
{
    public class LoginMenuNav
    {
        readonly LoginMenu loginMenu = new LoginMenu();

        public void PageMenu(string id, string firstName, string lastName, string meterNumber)
        {

            bool inLoginPage = true;

            while (inLoginPage)
            {
                Console.Clear();
                Console.WriteLine($"welcome {firstName} {lastName}");
                Console.WriteLine("Welcome To CUSTOMER PORTAL.\n");
                Console.WriteLine("Choose an Option : 1. View Data      2. Update Information       3. Make Subscription\n4. Cancel Subscription      5. View Subscription         6. Log Out");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        loginMenu.ViewCustomerData(id);
                        break;
                    case "2":
                        LoginMenu.UpdatePersonalInfo(id);
                        break;
                    case "3":
                        loginMenu.MakeSubscription(meterNumber);
                        break;
                    case "4":
                        loginMenu.CancelSubscription(meterNumber);
                        break;
                    case "5":
                        loginMenu.ViewSubscription(meterNumber);
                        break;
                    case "6":
                        inLoginPage = false;
                        break;
                }
            

            }

        }
    }
}
