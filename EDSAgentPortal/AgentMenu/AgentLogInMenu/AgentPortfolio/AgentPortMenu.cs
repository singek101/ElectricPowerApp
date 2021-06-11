using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.AgentServices.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EDSAgentPortal.AgentMenu.AgentLogInMenu.AgentPortfolio
{
    public class AgentPortMenu
    {
        readonly IAgentServices agentServices = new AgentServices();

        readonly AgentMenuNav agentMenuNav = new AgentMenuNav();

        public void ViewAgentData(string id)
        {
            Console.WriteLine();
            Console.WriteLine($"{"Full Name",-20} : {agentServices.GetAgentById(id).FirstName} {agentServices.GetAgentById(id).LastName}");
            Console.WriteLine($"{"Email Address",-20} : {agentServices.GetAgentById(id).EmailAddress} ");
            Console.WriteLine($"{"Phone Number",-20} : {agentServices.GetAgentById(id).PhoneNumber} "); 
            Console.WriteLine($"{"Created Date Time",-20} : {agentServices.GetAgentById(id).CreatedDateTime} ");
            Console.WriteLine($"{"Modified Date Time",-20} : {agentServices.GetAgentById(id).ModifiedDateTime} ");

            Console.ReadKey();
        }

        public void UpdatePersonalInfo(string id)
        {
            var customerDetail = agentServices.GetAgentById(id);
            
            bool inputAnother;

            do
            {
                Console.WriteLine($"What would you like to Update?\n 1. First Name      2. Last Name        3. Email Address        4. Phone Number     5. Password");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.WriteLine("Please enter your new First Name :");
                        customerDetail.FirstName = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "2":
                        Console.WriteLine("Please enter your new Last Name :");
                        customerDetail.LastName = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "3":
                        Console.WriteLine("Please enter your new Email Address :");
                        customerDetail.EmailAddress = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "4":
                        Console.WriteLine("Please enter your new Phone Number :");
                        customerDetail.PhoneNumber = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
                        break;
                    case "5":
                        Console.WriteLine("Please enter your new Password :");
                        customerDetail.Password = Console.ReadLine();
                        customerDetail.ModifiedDateTime = DateTime.Now;
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

            agentServices.UpdateAgent(customerDetail);
            
            Console.WriteLine("Successful!!!\nLogging Out....");
            Thread.Sleep(2000);
            agentMenuNav.PageMenuNav();
            
        }
    }
}
