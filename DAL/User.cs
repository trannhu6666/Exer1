using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool @lock { get; set; } // Thêm chữ @ vì lock là từ khóa cấm của C#
    }
}
