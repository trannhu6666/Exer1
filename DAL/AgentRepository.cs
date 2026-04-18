using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AgentRepository
    {
        private readonly SaleDbContext _context;

        public AgentRepository()
        {
            _context = new SaleDbContext();
        }

        // Lấy danh sách tất cả đại lý
        public List<Agent> GetAllAgents()
        {
            return _context.Agents.ToList();
        }

        // Thêm đại lý mới
        public void AddAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }
    }
}
