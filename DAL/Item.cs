using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        // Thêm cái này để chắc chắn ItemName cũng lưu được tiếng Việt
        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        // Cấu hình để EF hiểu đây là nvarchar(50) trong SQL
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Size { get; set; }
    }
}
