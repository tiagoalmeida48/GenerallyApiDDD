using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é abrigatória")]
        public string Password { get; set; }
    }
}
