using EDSCustomerPortal.Services;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSCustomerPortal.Menu
{
    public class MenuNav
    {
        bool appIsRunning = true;

        public void PageMenu()
        {
            Menu menu = new Menu();

            while (appIsRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS CUSTOMER PORTAL.");
                Console.WriteLine("Choose an Option : \n1. Login \n2. Register \n3. Close the App");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        menu.LoginNavigationPage();
                        break;
                    case "2":
                        menu.RegistrationNavigationPage();
                        break;
                    case "3":
                        appIsRunning = false;
                        break;
                }
            }
        }

        
    }
}
