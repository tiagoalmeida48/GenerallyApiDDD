using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no maximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(10, ErrorMessage = "O e-mail deve ter no minimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O e-mail deve ter no maximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O e-mail informado é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6 caracteres")]
        [MaxLength(30, ErrorMessage = "A senha deve ter no maximo 30 caracteres")]
        public string Password { get; set; }
    }
}
