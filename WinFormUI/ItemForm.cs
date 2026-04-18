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
                // Kiểm tra validation nhẹ trước khi thêm
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSize.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên và Size!");
                    return;
                }

                Item newItem = new Item
                {
                    ItemName = txtName.Text.Trim(), // Dùng Trim() để xóa khoảng trắng thừa
                    Size = txtSize.Text.Trim(),
                };

                _itemService.AddItem(newItem);
                MessageBox.Show("Thêm sản phẩm thành công!"); // Chỉnh lại tiếng Việt cho đồng bộ nè

                // Sau khi thêm xong nên xóa trắng ô nhập để người dùng nhập món tiếp theo
                txtName.Clear();
                txtSize.Clear();
                txtName.Focus();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
