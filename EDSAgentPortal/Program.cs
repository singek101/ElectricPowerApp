using EDSAgentPortal.AgentMenu;
using ElectricityDigitalSystem.Common;
using ElectricityDigitalSystem.Common.ISubTarServices;
using System;

namespace EDSAgentPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            ITariffServices tariffServices = new TariffServices();
            tariffServices.AddTariffToService();

            AgentMenuNav agentMenuNav = new AgentMenuNav();
            agentMenuNav.PageMenuNav();
        }
    }
}
