using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderReportItem
    {
        public string AgentName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ItemName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
    }
    public class ReportRepository
    {
        private readonly SaleDbContext _context;

        public ReportRepository()
        {
            _context = new SaleDbContext();
        }

        // --- CÂU 3: IN ĐƠN HÀNG (REPORT) ---
        public IList GetOrderDetailsForPrinting(int orderId)
        {
            var result = (from od in _context.OrderDetails
                          join i in _context.Items on od.ItemID equals i.ItemID
                          join o in _context.Orders on od.OrderID equals o.OrderID
                          join a in _context.Agents on o.AgentID equals a.AgentID
                          where od.OrderID == orderId
                          select new OrderReportItem
                          {
                              AgentName = a.AgentName,        // Tên khách
                              OrderDate = o.OrderDate,        // Ngày lập
                              ItemName = i.ItemName,
                              Quantity = od.Quantity,
                              Price = od.UnitAmount,          // Đơn giá
                              Total = od.Quantity * od.UnitAmount
                          }).ToList();
            return result;
        }

        // --- CÂU 4: LỌC VÀ THỐNG KÊ (FILTER) ---

        // 4.1. Lọc mặt hàng bán chạy nhất (Best items) 
        public IList GetBestSellingItems()
        {
            var result = (from od in _context.OrderDetails
                          join i in _context.Items on od.ItemID equals i.ItemID
                          group od by i.ItemName into g
                          select new
                          {
                              ItemName = g.Key,
                              TotalSold = g.Sum(x => x.Quantity)
                          }).OrderByDescending(x => x.TotalSold).ToList();
            return result;
        }

        // 4.2. Lọc các món mà 1 Đại lý đã mua (Items purchased by customers) ---
        public IList GetItemsByAgent(int agentId)
        {
            var result = (from o in _context.Orders
                          join od in _context.OrderDetails on o.OrderID equals od.OrderID
                          join i in _context.Items on od.ItemID equals i.ItemID
                          where o.AgentID == agentId
                          select new
                          {
                              OrderDate = o.OrderDate,
                              ItemName = i.ItemName,
                              Quantity = od.Quantity
                          }).ToList();
            return result;
        }

        // 4.3. Lọc các Đại lý đã mua 1 mặt hàng cụ thể (Customer purchases items) 
        public IList GetAgentsByItem(int itemId)
        {
            var result = (from o in _context.Orders
                          join od in _context.OrderDetails on o.OrderID equals od.OrderID
                          join a in _context.Agents on o.AgentID equals a.AgentID
                          where od.ItemID == itemId
                          select new
                          {
                              OrderDate = o.OrderDate,
                              AgentName = a.AgentName,
                              Quantity = od.Quantity
                          }).ToList();
            return result;
        }
    }
}
