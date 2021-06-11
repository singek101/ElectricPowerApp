using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.AgentServices.IServices
{
    public interface IAgentServices
    {
        string RegisterAgent(AgentsModel agent);

        AgentsModel GetAgentById(string agentId);

        AgentsModel GetAgentByEmail(string email);

        string UpdateAgent(AgentsModel modifiedAgent);
    }
}
