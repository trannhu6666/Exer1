using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemRepository
    {
        private readonly SaleDbContext _context;

        public ItemRepository()
        {
            _context = new SaleDbContext();
        }

        // Lấy toàn bộ danh sách sản phẩm
        public List<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        // Thêm một sản phẩm mới
        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges(); // Lệnh này bắt buộc phải có để lưu xuống SQL
        }
    }
}
