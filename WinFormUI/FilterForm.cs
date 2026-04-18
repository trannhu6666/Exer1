using BLL;
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
    public partial class FilterForm : Form
    {
        private ReportService _reportService = new ReportService();
        private AgentService _agentService = new AgentService();
        private ItemService _itemService = new ItemService();
        public FilterForm()
        {
            InitializeComponent();
        }

        private void btnBestItems_Click(object sender, EventArgs e)
        {
            dgvFilter.DataSource = _reportService.GetBestSellingItems();
        }

        private void btnFilterByAgent_Click(object sender, EventArgs e)
        {
            if (cmbAgents.SelectedValue != null)
            {
                // Dùng int.TryParse hoặc kiểm tra kiểu trước khi ép kiểu
                if (int.TryParse(cmbAgents.SelectedValue.ToString(), out int agentId))
                {
                    dgvFilter.DataSource = _reportService.GetItemsByAgent(agentId);
                }
            }
            else
            {
                MessageBox.Show("Please select an Agent from the list!", "Warning");
            }
        }

        private void btnFilterByItem_Click(object sender, EventArgs e)
        {
            if (cmbItems.SelectedValue != null)
            {
                if (int.TryParse(cmbItems.SelectedValue.ToString(), out int itemId))
                {
                    dgvFilter.DataSource = _reportService.GetAgentsByItem(itemId);
                }
            }
            else
            {
                MessageBox.Show("Please select an Item from the list!", "Warning");
            }
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            cmbAgents.DataSource = _agentService.GetAllAgents();
            cmbAgents.DisplayMember = "AgentName"; // Tên hiện lên
            cmbAgents.ValueMember = "AgentID";     // GIÁ TRỊ ẨN (Để lấy SelectedValue)

            cmbItems.DataSource = _itemService.GetAllItems();
            cmbItems.DisplayMember = "ItemName";
            cmbItems.ValueMember = "ItemID";       // GIÁ TRỊ ẨN
        }
    }
}
