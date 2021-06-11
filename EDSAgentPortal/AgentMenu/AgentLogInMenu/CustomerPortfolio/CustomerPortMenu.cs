using EDSAgentPortal.Validation;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.AgentServices.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSAgentPortal.AgentMenu.AgentLogInMenu.CustomerPortfolio
{
    public class CustomerPortMenu
    {
        readonly IAgentCustomerServices agentCustomerServices = new AgentCustomerServices();

        readonly ValidationClass validationClass = new ValidationClass();

        readonly CustomerPortMenuNav customerPortMenuNav = new CustomerPortMenuNav();

        public void RegisterCustomer(string registeringAgent)
        {
            Dictionary<string, string> navItemDIc = new Dictionary<string, string>();
            List<string> navigationItems = new List<string>
            {
                "FirstName", "LastName", "Email", "Password", "PhoneNumber"
            };
            Console.Clear();
            Console.WriteLine("Please Provide your Details : ");

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
            PhoneNumber = navItemDIc["PhoneNumber"];

            validationClass.CheckInput(FirstName);
            validationClass.CheckInput(LastName);
            validationClass.CheckInput(Email);
            validationClass.CheckInput(Password);
            //while (string.IsNullOrEmpty(FirstName))
            //{
            //    Console.WriteLine("\n\n\t\tFirst name cannot be left blank");
            //    Console.Write("\t\tFirst Name : ");
            //    FirstName = Console.ReadLine();
            //}

            //while (string.IsNullOrEmpty(LastName))
            //{
            //    Console.WriteLine("\n\t\tLast name cannot be left blank");
            //    Console.Write("\t\tLast Name : ");
            //    LastName = Console.ReadLine();
            //}

            //while (string.IsNullOrEmpty(Email))
            //{
            //    Console.WriteLine("\n\t\tEmail cannot be left blank");
            //    Console.Write("\t\tEmail : ");
            //    Email = Console.ReadLine();
            //}

            //while (string.IsNullOrEmpty(Password))
            //{
            //    Console.WriteLine("\n\t\tPassword cannot be left blank");
            //    Console.Write("\t\tPassword : ");
            //    Password = Console.ReadLine();
            //}

            ulong number;
            while (!ulong.TryParse(PhoneNumber, out number))
            {
                Console.WriteLine("Please enter an 11 digit number");
                Console.Write("Phone Number : ");
                PhoneNumber = Console.ReadLine();
            }

            CustomerModel model = new CustomerModel
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                Password = Password,
                PhoneNumber = number.ToString("00000000000"),
                AgentId = registeringAgent
            };

            string registrationResponds = agentCustomerServices.RegisterCustomer(model);

            if (registrationResponds == "Success")
            {
                Console.WriteLine();
                Console.WriteLine("Registration Successful");
                Console.WriteLine("Redirecting you to Home Page....");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");

                customerPortMenuNav.CustomerPortPageMenuNav(registeringAgent);
            }
                

        }

        public void ViewCustomerInfo()
        {
            string result = EmailCheck();

            if (result == "Failed")
            {
                Console.WriteLine("No Valid Email Found");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{"Full Name",-20} : {agentCustomerServices.GetCustomerByEmail(result).FirstName} {agentCustomerServices.GetCustomerByEmail(result).LastName}");
                Console.WriteLine($"{"Email Address",-20} : {agentCustomerServices.GetCustomerByEmail(result).EmailAddress} ");
                Console.WriteLine($"{"Phone Number",-20} : {agentCustomerServices.GetCustomerByEmail(result).PhoneNumber} ");
                Console.WriteLine($"{"Meter Number",-20} : {agentCustomerServices.GetCustomerByEmail(result).MeterNumber} ");
                Console.WriteLine($"{"Registered Agent Id",-20} : {agentCustomerServices.GetCustomerByEmail(result).AgentId} ");
                Console.WriteLine($"{"Created Date Time",-20} : {agentCustomerServices.GetCustomerByEmail(result).CreatedDateTime} ");
                Console.WriteLine($"{"Modified Date Time",-20} : {agentCustomerServices.GetCustomerByEmail(result).ModifiedDateTime} ");

                Console.ReadKey();
            }  
        }

        public void ViewAllRegisteredCustomer()
        {
            var values = agentCustomerServices.GetAllRegisteredCustomer();

            if (values == null)
            {
                Console.WriteLine("No Customer Registered!!!!");
            }
            else
            {
                foreach (var item in values)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{"Full Name",-20} : {item.FirstName} {item.LastName}");
                    Console.WriteLine($"{"Email Address",-20} : {item.EmailAddress} ");
                    Console.WriteLine($"{"Phone Number",-20} : {item.PhoneNumber} ");
                    Console.WriteLine($"{"Meter Number",-20} : {item.MeterNumber} ");
                    Console.WriteLine($"{"Registered Agent Id",-20} : {item.AgentId} ");
                    Console.WriteLine($"{"Created Date Time",-20} : {item.CreatedDateTime} ");
                    Console.WriteLine($"{"Modified Date Time",-20} : {item.ModifiedDateTime} "); 
                }
                Console.ReadKey();
            }  
        }

        public void UpdatePersonalInfo()
        {
            string result = EmailCheck();

            if (result == "Failed")
            {
                Console.WriteLine("No Valid Email Found");
                Thread.Sleep(3000);
            }
            else
            {
                var customerEmail = agentCustomerServices.GetCustomerByEmail(result);

                bool inputAnother;

                do
                {
                    Console.WriteLine($"What would you like to Update?\n 1. First Name      2. Last Name        3. Email Address        4. Phone Number     5. Password");
                    string response = Console.ReadLine();

                    switch (response)
                    {
                        case "1":
                            Console.WriteLine("Please enter your new First Name :");
                            customerEmail.FirstName = Console.ReadLine();
                            customerEmail.ModifiedDateTime = DateTime.Now;
                            break;
                        case "2":
                            Console.WriteLine("Please enter your new Last Name :");
                            customerEmail.LastName = Console.ReadLine();
                            customerEmail.ModifiedDateTime = DateTime.Now;
                            break;
                        case "3":
                            Console.WriteLine("Please enter your new Email Address :");
                            customerEmail.EmailAddress = Console.ReadLine();
                            customerEmail.ModifiedDateTime = DateTime.Now;
                            break;
                        case "4":
                            Console.WriteLine("Please enter your new Phone Number :");
                            customerEmail.PhoneNumber = Console.ReadLine();
                            customerEmail.ModifiedDateTime = DateTime.Now;
                            break;
                        case "5":
                            Console.WriteLine("Please enter your new Password :");
                            customerEmail.Password = Console.ReadLine();
                            customerEmail.ModifiedDateTime = DateTime.Now;
                            break;
                    }

                    Console.WriteLine("Would you like to update another information? (Y/N)");
                    var continueEditing = Console.ReadLine();

                    if (continueEditing.ToLower() == "y")
                    {
                        inputAnother = true;
                    }
                    else
                    {
                        inputAnother = false;
                    }

                } while (inputAnother);

                agentCustomerServices.UpdateCustomer(customerEmail);

                Console.WriteLine("Successful!!!");
                Thread.Sleep(3000);
            }
        }

        private string EmailCheck()
        {
            Dictionary<string, string> navItemDic = new Dictionary<string, string>();

            List<string> navigationItem = new List<string>
            {
                "Email"
            };

            Console.Clear();
            Console.WriteLine("Please Can I have your Email you used in Registering :");

            for (var i = 0; i < navigationItem.Count; i++)
            {
                Console.Write($"Please Enter your {navigationItem[i]} : ");
                var value = Console.ReadLine();
                navItemDic.Add(navigationItem[i], value);
            }

            string Email;

            Email = navItemDic["Email"];
            // Password = navItemDic["Password"];

            var customer = agentCustomerServices.GetCustomerByEmail(Email);

            if (customer == null)
            {
                return "Failed";
               // Console.WriteLine("No Valid Email Found");
               // Thread.Sleep(3000);
            }
            else
            {
                return customer.EmailAddress;
            }
        }




    }
}
