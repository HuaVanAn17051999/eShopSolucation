using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolucation.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        [Display(Name = "SDT")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tài Khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Display(Name = "Xác nhận mật khẩu ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
