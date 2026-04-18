using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepository
    {
        private readonly SaleDbContext _context;

        public OrderRepository()
        {
            _context = new SaleDbContext();
        }

        // Hàm này sẽ nhận vào 1 Order (Thông tin chung) và 1 danh sách OrderDetail (Các mặt hàng mua)
        public bool CreateOrder(Order newOrder, List<OrderDetail> orderDetails)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Thêm Order vào trước
                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                    // Lúc này newOrder.OrderID đã tự động có giá trị mới nhất từ SQL

                    // 2. Gán OrderID vừa tạo cho từng chi tiết đơn hàng rồi lưu lại
                    foreach (var detail in orderDetails)
                    {
                        detail.OrderID = newOrder.OrderID;
                        _context.OrderDetails.Add(detail);
                    }
                    _context.SaveChanges();

                    // 3. Xác nhận hoàn tất
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // Nếu lỗi (vd: rớt mạng giữa chừng), hủy bỏ toàn bộ, không lưu rác vào DB
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
