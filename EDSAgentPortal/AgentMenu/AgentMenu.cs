using EDSAgentPortal.AgentMenu.AgentLogInMenu;
using EDSAgentPortal.Validation;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.AgentServices.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSAgentPortal.AgentMenu
{
    public class AgentMenu
    {

        readonly IAgentServices agentServices = new AgentServices();

        readonly AgentMenuNav agentMenuNav = new AgentMenuNav();

        readonly ValidationClass validation = new ValidationClass();

        readonly LogInMenuNav loginMenuNav = new LogInMenuNav();

        public void RegisterAgent()
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

            validation.CheckInput(FirstName);
            validation.CheckInput(LastName);
            validation.CheckInput(Email);
            validation.CheckInput(Password);
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

            AgentsModel model = new AgentsModel
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailAddress = Email,
                Password = Password,
                PhoneNumber = number.ToString("00000000000"),
            };

            string registrationResponds = agentServices.RegisterAgent(model);
            if (registrationResponds == "Success")
            {
                Console.WriteLine();
                Console.WriteLine("Registration Successful");
                Console.WriteLine("Redirecting you to Home Page....");
                Thread.Sleep(3000);
            }
            else
                Console.WriteLine("An Error occured While Trying to Create your Account Please try Again");

            agentMenuNav.PageMenuNav();
           
        }

        public void LoginAgent()
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

            var agent = agentServices.GetAgentByEmail(Email);
            
            if (agent == null)
            {
                Console.WriteLine("No Email Found");
                Thread.Sleep(3000);

                agentMenuNav.PageMenuNav();
            }
            else
            {
                if (agent.Password != Password)
                {
                    Console.WriteLine("Invalid Login Credentials Please Try Again");
                    Thread.Sleep(3000);

                    agentMenuNav.PageMenuNav();
                }
                else
                {
                    //call the loginPageNav
                    loginMenuNav.LogInPageMenuNav(agent.Id, agent.FirstName, agent.LastName);

                }
            }
        }



    }
}

