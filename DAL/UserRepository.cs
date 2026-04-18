using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        private readonly SaleDbContext _context;

        public UserRepository()
        {
            _context = new SaleDbContext();
        }

        // Hàm kiểm tra đăng nhập
        public bool Login(string email, string password)
        {
            // Tìm user có email, password khớp và tài khoản không bị khóa (@lock == false)
            var user = _context.Users.FirstOrDefault(u =>
                u.email == email &&
                u.password == password &&
                u.@lock == false
            );

            // Nếu tìm thấy user hợp lệ thì trả về true, ngược lại là false
            return user != null;
        }
    }
}
