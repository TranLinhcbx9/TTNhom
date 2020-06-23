using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập UserName")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập Password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}