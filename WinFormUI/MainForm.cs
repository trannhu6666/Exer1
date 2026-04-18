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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void manageItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm f = new ItemForm();
            f.Show();
        }

        private void manageAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgentForm f = new AgentForm();
            f.Show();
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm f = new OrderForm();
            f.Show();
        }

        private void printOrderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm();
            f.Show();
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterForm f = new FilterForm();
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
