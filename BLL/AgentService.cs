using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AgentService
    {
        private readonly AgentRepository _agentRepository;

        public AgentService()
        {
            _agentRepository = new AgentRepository();
        }

        public List<Agent> GetAllAgents()
        {
            return _agentRepository.GetAllAgents();
        }

        public void AddAgent(Agent agent)
        {
            if (string.IsNullOrWhiteSpace(agent.AgentName))
            {
                throw new System.Exception("Tên đại lý không được để trống!");
            }
            _agentRepository.AddAgent(agent);
        }
    }
}
