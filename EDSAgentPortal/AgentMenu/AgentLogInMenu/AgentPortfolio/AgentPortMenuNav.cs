using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.AgentMenu.AgentLogInMenu.AgentPortfolio
{
    public class AgentPortMenuNav
    {
        readonly AgentPortMenu agentPortMenu = new AgentPortMenu();

       // readonly LogInMenuNav logInMenuNav = new LogInMenuNav();

        public void AgentPortPageMenuNav(string id, string firstName, string lastName)
        {

            bool inLoginPage = true;

            while (inLoginPage)
            {
                Console.Clear();
                Console.WriteLine($"Welcome Agent {firstName} {lastName}");
                Console.WriteLine("Choose an Option : \n1. View Data      \n2. Update Information    \n3. Back To LogIn Menu");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        agentPortMenu.ViewAgentData(id);
                        break;
                    case "2":
                        agentPortMenu.UpdatePersonalInfo(id);
                        break;
                    case "3":
                        // logInMenuNav.LogInPageMenuNav();
                        inLoginPage = false;
                        break;
                }


            }

        }
    }
}
