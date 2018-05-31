using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLMT.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập tên đăng nhập")]

        public string TenDangNhap { set; get; }
        [Required(ErrorMessage = "Nhập mật khẩu")]

        public string MatKhau { set; get; }
        public string HoVaTen { set; get; }
        public string Quyen { set; get; }
    }
    class UserDao
    {
        DBConnection db;
        public UserDao()
        {
            db = new DBConnection();
        }
       
    }
   
}
