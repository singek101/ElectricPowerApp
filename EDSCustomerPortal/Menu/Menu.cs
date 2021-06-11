using EDSCustomerPortal.Services;
using EDSCustomerPortal.Services.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSCustomerPortal.Menu
{
    public class Menu
    {
        readonly MenuNav menuNav = new MenuNav();

        readonly IAuthenticationService authenticationService = new AuthenticationService();

        readonly LoginMenuNav loginMenuNav = new LoginMenuNav();

        public void LoginNavigationPage()
        {
            Dictionary<string, string> navItemDic = new Dictionary<string, string>();

            List<string> navigationItem = new List<string>
            {
                "Email", "Password"
            };
            
            Console.Clear();
            Console.WriteLine("Please Login with your Email and Password");

            for (var i = 0; i < navigationItem.Count; i++)
            {
                Console.Write($"Please Enter your {navigationItem[i]} : ");
                var value = Console.ReadLine();
                navItemDic.Add(navigationItem[i], value);
            }

            string Email, Password;

            Email = navItemDic["Email"];
            Password = navItemDic["Password"];

            var customer = authenticationService.GetCustomerByEmail(Email);
            if (customer == null)
            {
                Console.WriteLine("No Email Found");
                Thread.Sleep(3000);

                menuNav.PageMenu();
            }
            else
            {
                if (customer.Password != Password)
                {
                    Console.WriteLine("Invalid Login Credentials Please Try Again");
                    Thread.Sleep(3000);

                    menuNav.PageMenu();
                }
                else
                {
                    loginMenuNav.PageMenu(customer.Id, customer.FirstName, customer.LastName, customer.MeterNumber);
                        
                }
            }    
        }


        public void RegistrationNavigationPage()
        {
            Dictionary<string, string> navItemDIc = new Dictionary<string, string>();
            List<string> navigationItems = new List<string>
            {
                "FirstName", "LastName", "Email", "Password", "PhoneNumber"
            };
            Console.Clear();
            Console.WriteLine("Please Provide your Details");

            for (int i = 0; i < navigationItems.Count; i++)
            {
                Console.Write($"Enter your {navigationItems[i]} : ");
                var value = Console.ReadLine();
                navItemDIc.Add(navigationItems[i], value);
            }

            string FirstName, LastName, Email, Password, PhoneNumber;
            FirstName = navItemDIc["FirstName"];
            LastName = navItemDIc["LastName"];
            Email = navItemDIc["Email"];
            Password = navItemDIc["Password"];
           // MeterNumber = navItemDIc["MeterNumber"];
            PhoneNumber = navItemDIc["PhoneNumber"];

            CustomerModel model = new CustomerModel
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                Password = Password,
               // MeterNumber = MeterNumber,
                PhoneNumber = PhoneNumber,
            };

            string registrationResponds = authenticationService.RegisterUser(model);
            if (registrationResponds == "Success")
            {
                Console.WriteLine("Registration Successful");
                Console.WriteLine("Redirecting you to Home Page....");
                Thread.Sleep(3000);
            }
            else
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");
 
           menuNav.PageMenu();

        }
    }
}
