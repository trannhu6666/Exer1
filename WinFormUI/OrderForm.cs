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
    public partial class OrderForm : Form
    {
        private readonly AgentService _agentService = new AgentService();
        private readonly ItemService _itemService = new ItemService();

        // Khai báo một Database Context ở đây để lưu đơn hàng (Nếu bạn có OrderService rồi thì dùng Service nhé)
        private readonly SaleDbContext _context = new SaleDbContext();

        // Tạo một list đóng vai trò là "Giỏ hàng" lưu tạm các món khách chọn
        private List<CartItem> _cart = new List<CartItem>();

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // 1. Load danh sách Đại lý vào ComboBox Agent
            cmbAgent.DataSource = _agentService.GetAllAgents();
            cmbAgent.DisplayMember = "AgentName";
            cmbAgent.ValueMember = "AgentID";

            // 2. Load danh sách Mặt hàng vào ComboBox Item
            cmbItem.DataSource = _itemService.GetAllItems();
            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemID";
        }

        
        // Hàm vẽ lại DataGridView
        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;
        }


        private void btnAddtoCart_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbItem.SelectedValue == null) return;

                // Lấy thông tin từ giao diện
                int itemId = (int)cmbItem.SelectedValue;
                string itemName = cmbItem.Text;
                int quantity = int.Parse(txtQuantity.Text);
                decimal price = decimal.Parse(txtPrice.Text);

                // Kiểm tra xem món này đã có trong giỏ hàng chưa
                var existingItem = _cart.FirstOrDefault(c => c.ItemID == itemId);
                if (existingItem != null)
                {
                    // Nếu có rồi thì cộng dồn số lượng
                    existingItem.Quantity += quantity;
                }
                else
                {
                    // Nếu chưa có thì thêm mới vào giỏ
                    _cart.Add(new CartItem
                    {
                        ItemID = itemId,
                        ItemName = itemName,
                        Quantity = quantity,
                        UnitPrice = price
                    });
                }

                // Cập nhật lại cái bảng DataGridView để hiện giỏ hàng
                RefreshCartGrid();

                // Xóa trắng ô nhập liệu để nhập món khác
                txtQuantity.Clear();
                txtPrice.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số cho Số lượng và Đơn giá!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSaveOrder_Click_1(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng thêm món hàng trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Tạo 1 đối tượng Order mới (Đơn hàng cha)
                Order newOrder = new Order
                {
                    AgentID = (int)cmbAgent.SelectedValue,
                    OrderDate = dtpOrderDate.Value // Lấy ngày từ DateTimePicker
                };

                // 2. Duyệt qua từng món trong Giỏ hàng để chuyển thành OrderDetail
                foreach (var item in _cart)
                {
                    OrderDetail detail = new OrderDetail
                    {
                        ItemID = item.ItemID,
                        Quantity = item.Quantity,
                        UnitAmount = item.UnitPrice
                    };

                    // Nối chi tiết vào đơn hàng cha
                    newOrder.OrderDetails.Add(detail);
                }

                // 3. Lưu toàn bộ xuống Database
                _context.Orders.Add(newOrder);
                _context.SaveChanges(); // Entity Framework sẽ tự động lo việc cấp OrderID

                MessageBox.Show("Đã lưu đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Dọn dẹp lại form để chuẩn bị cho đơn hàng tiếp theo
                _cart.Clear();
                RefreshCartGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Class phụ để cấu trúc dữ liệu giỏ hàng hiện lên DataGridView cho đẹp
    public class CartItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => Quantity * UnitPrice; // Tự động tính thành tiền
    }
}
