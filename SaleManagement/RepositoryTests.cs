using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System.Linq;

namespace SaleManagement.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _userRepo;

        [TestInitialize]
        public void Setup()
        {
            _userRepo = new UserRepository();
        }

        [TestMethod]
        public void Login_ValidUser_ReturnsTrue()
        {
            bool result = _userRepo.Login("marketing@gmail.com", "123");
            Assert.IsTrue(result, "Đăng nhập hợp lệ phải trả về True.");
        }

        [TestMethod]
        public void Login_InvalidUser_ReturnsFalse()
        {
            bool result = _userRepo.Login("sai_email@gmail.com", "sai_pass");
            Assert.IsFalse(result, "Đăng nhập sai phải trả về False.");
        }
    }

    [TestClass]
    public class AgentRepositoryTests
    {
        private AgentRepository _agentRepo;

        [TestInitialize]
        public void Setup()
        {
            _agentRepo = new AgentRepository();
        }

        [TestMethod]
        public void AddAgent_ValidAgent_IncreasesTotalAgents()
        {
            int initialCount = _agentRepo.GetAllAgents().Count;

            var newAgent = new Agent { AgentName = "Test Agent", Address = "123 Street" };
            _agentRepo.AddAgent(newAgent);

            int newCount = _agentRepo.GetAllAgents().Count;
            Assert.AreEqual(initialCount + 1, newCount, "Số lượng đại lý phải tăng lên 1.");
        }
    }
}