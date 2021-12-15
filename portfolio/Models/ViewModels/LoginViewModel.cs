using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace portfolio.Models.ViewModels
{
    public class LoginViewModel
    {

        public string ReturnUrl { get; set; }
        [EmailAddress(ErrorMessage ="ایمیل معتبر نیست")]
        [Required(ErrorMessage = "وارد کردن ایمیل ضروری است")]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن گذرواژه ضروری است")]
        [StringLength(50,MinimumLength =6,ErrorMessage = "طول گذرواژه حداقل 6 و حداکثر 50 کاراکتر باشد")]
        public string Password { get; set; }
    }
}
