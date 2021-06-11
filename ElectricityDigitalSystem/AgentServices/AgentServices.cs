using ElectricityDigitalSystem.AgentServices.IServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.AgentServices
{
    public class AgentServices : AgentServicesAPI, IAgentServices
    {
        public string RegisterAgent(AgentsModel agent)
        {
            if (agent == null)
            {
                throw new ArgumentNullException(nameof(agent));
            }
            //This will Handle registration of an Agent
            else
            {
                fileService.Database.Agents.Add(agent);

                fileService.SaveChanges();
                return agent.Id == null ? "Failed" : "Success";
            }
        }

        public AgentsModel GetAgentById(string agentId)
        {
            AgentsModel foundAgent = fileService.Database.Agents.Find(c => c.Id == agentId);

            if (foundAgent != null)
            {
                return foundAgent;
            }
            return null;
        }

        //Find Agent via Email
        public AgentsModel GetAgentByEmail(string email)
        {
            AgentsModel foundAgentEmail = fileService.Database.Agents.Find(c => c.EmailAddress == email);
            if (foundAgentEmail != null)
            {
                return foundAgentEmail;
            }
            return null;
        }

        public string UpdateAgent(AgentsModel modifiedAgent)
        {

            AgentsModel foundAgent = this.GetAgentById(modifiedAgent.Id);
            if (foundAgent != null)
            {
                //fileService.Database.Customers.IndexOf(foundCustomer);
                //fileService.Database.Customers.Insert(indexOfFoundCustomer, foundCustomer);
                fileService.SaveChanges();
                return "SUCCESS";
            }

            return "FAILURE NOT FOUND";
        }
    }
}
