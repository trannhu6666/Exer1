using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public bool CreateOrder(Order order, List<OrderDetail> details)
        {
            // Kiểm tra: Đơn hàng phải có ít nhất 1 sản phẩm
            if (details == null || !details.Any())
            {
                throw new System.Exception("Đơn hàng phải có ít nhất một mặt hàng!");
            }

            // Gọi DAL để lưu vào Database
            return _orderRepository.CreateOrder(order, details);
        }
    }
}
