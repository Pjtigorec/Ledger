using System.ComponentModel.DataAnnotations;

namespace Common.AccountModels
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
