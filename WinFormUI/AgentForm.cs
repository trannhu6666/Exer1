using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class AgentForm : Form
    {
        private readonly AgentService _agentService = new AgentService();
        public AgentForm()
        {
            InitializeComponent();
        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() 
        {
            dgvAgents.DataSource = _agentService.GetAllAgents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đối tượng Agent khớp với Database
                Agent newAgent = new Agent
                {
                    AgentName = txtName.Text,    // Tương ứng ô Name
                    Address = txtAddress.Text    // Tương ứng ô Address
                };

                _agentService.AddAgent(newAgent);
                MessageBox.Show("Added successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
