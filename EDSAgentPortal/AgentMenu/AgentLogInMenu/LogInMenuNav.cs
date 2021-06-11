using EDSAgentPortal.AgentMenu.AgentLogInMenu.AgentPortfolio;
using EDSAgentPortal.AgentMenu.AgentLogInMenu.CustomerPortfolio;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.AgentMenu.AgentLogInMenu
{
    public class LogInMenuNav
    { 

        public void LogInPageMenuNav(string id, string firstName, string lastName)
        {
            AgentPortMenuNav agentPortMenuNav = new AgentPortMenuNav();

            CustomerPortMenuNav customerPortMenuNav = new CustomerPortMenuNav();

            bool inLoginPage = true;

            while (inLoginPage)
            {
                Console.Clear();
                Console.WriteLine($"{firstName} {lastName}");
                Console.WriteLine("Welcome To AGENT PORTAL.\n");
                Console.WriteLine("Choose an Option : \n1. AGENT Dashboard     \n2. CUSTOMER Dashboard   \n3. Log Out");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        agentPortMenuNav.AgentPortPageMenuNav(id, firstName, lastName);
                        break;
                    case "2":
                        customerPortMenuNav.CustomerPortPageMenuNav(id);
                        break;
                    case "3":
                        inLoginPage = false;
                        break;
                }


            }

        }
    }
}
