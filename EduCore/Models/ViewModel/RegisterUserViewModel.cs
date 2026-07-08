using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Models.ViewModel
{
    public class RegisterUserViewModel 
    {
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
