using Common.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторить пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Роль")]
        public string Role { get; set; }

        public List<string> Roles { get; set; }

        public static User ConvertModelToUser(UserModel model)
        {
            User user = new User();

            user.Id = model.Id;
            user.Login = model.Login;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Role = model.Role;
           
            return user;
        }

        public static UserModel ConvertUserToModel(User user)
        {
            UserModel model = new UserModel();

            model.Id = user.Id;
            model.Login = user.Login;
            model.Email = user.Email;
            model.Role = user.Role;

            return model;
        }
    }
}
