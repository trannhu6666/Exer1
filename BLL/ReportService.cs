using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportService
    {
        private readonly ReportRepository _reportRepo;

        public ReportService()
        {
            _reportRepo = new ReportRepository();
        }

        // --- DÙNG CHO CÂU 3: IN ĐƠN HÀNG ---
        public IList GetOrderDetailsForPrinting(int orderId)
        {
            return _reportRepo.GetOrderDetailsForPrinting(orderId);
        }

        // --- DÙNG CHO CÂU 4: LỌC VÀ THỐNG KÊ ---

        // 4.1. Lấy danh sách mặt hàng bán chạy nhất
        public IList GetBestSellingItems()
        {
            return _reportRepo.GetBestSellingItems();
        }

        // 4.2. Lấy danh sách món một đại lý đã mua
        public IList GetItemsByAgent(int agentId)
        {
            return _reportRepo.GetItemsByAgent(agentId);
        }

        // 4.3. Lấy danh sách đại lý đã mua một mặt hàng cụ thể
        public IList GetAgentsByItem(int itemId)
        {
            return _reportRepo.GetAgentsByItem(itemId);
        }
    }
}
