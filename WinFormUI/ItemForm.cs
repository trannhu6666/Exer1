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
using DAL;
namespace WinFormUI
{
    public partial class ItemForm : Form
    {
        private ItemService _itemService = new ItemService();
        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Gọi Service để lấy dữ liệu và gán vào DataGridView
            var data = _itemService.GetAllItems();
            dgvItems.DataSource = data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đối tượng Item khớp với các thuộc tính trong Database
                Item newItem = new Item
                {
                    ItemName = txtName.Text,    // Tương ứng ô Name
                    Size = txtSize.Text,        // Tương ứng ô Size
                };

                _itemService.AddItem(newItem);
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
