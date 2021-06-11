using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.AgentMenu
{
    public class AgentMenuNav
    {
        readonly bool appIsRunning = true;

        public void PageMenuNav()
        {
            AgentMenu agentMenu = new AgentMenu();

            while (appIsRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS AGENT PORTAL.");
                Console.WriteLine("Choose an Option : \n1. Register \n2. Login \n3. Close the App");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        agentMenu.RegisterAgent();
                        break;
                    case "2":
                        agentMenu.LoginAgent();
                        break;
                    case "3":
                        Environment.Exit(0);
                        //appIsRunning = false;
                        break;
                }
            }
        }
    }
}
