using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepository;

        public ItemService()
        {
            _itemRepository = new ItemRepository();
        }

        public List<Item> GetAllItems()
        {
            return _itemRepository.GetAllItems();
        }

        public void AddItem(Item item)
        {
            // Tầng BLL có thể chứa logic kiểm tra. Ví dụ: Không cho phép tên trống
            if (string.IsNullOrWhiteSpace(item.ItemName))
            {
                throw new System.Exception("Tên mặt hàng không được để trống!");
            }
            _itemRepository.AddItem(item);
        }
    }
}
