using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage ="نام کاربری را وارد کنید")]
        [StringLength(30,ErrorMessage ="نام کاربری بیشتر از 30 کاراکتر نمی تواند باشد")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        [Required(ErrorMessage = "وارد کردن ایمیل ضروری است")]
        public string Email { get; set; }
        [Required(ErrorMessage = "وارد کردن گذرواژه ضروری است")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "طول گذرواژه حداقل 6 و حداکثر 50 کاراکتر باشد")]
        public string Password { get; set; }
        [Required(ErrorMessage = "وارد کردن تکرار گذرواژه ضروری است")]
        [Compare(nameof(Password),ErrorMessage ="گذرواژه با تکرارش برابر نیست")]
        public string ConfirmPassword { get; set; }
    }
}
