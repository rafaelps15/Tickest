using System.ComponentModel.DataAnnotations;

namespace Tickest.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required( ErrorMessage = "Campo email não preenchido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo senha não preenchido")]
        public string Senha { get; set; }
        public string RedirectToUrl { get; set; }
    }
}
