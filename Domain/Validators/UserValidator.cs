using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // SEPARAR AS MENSAGENS EM UM ARQUIVO DIFERENTE PARA MELHOR ORGANIZAÇÃO
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")
                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                .MinimumLength(3)
                .WithMessage("O nome deve ter no minimo 3 caracteres")
                .MaximumLength(80)
                .WithMessage("O nome deve ter no maximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio")
                .NotNull()
                .WithMessage("O email não pode ser nulo")
                .MinimumLength(10)
                .WithMessage("O email deve ter no minimo 10 caracteres")
                .MaximumLength(180)
                .WithMessage("O email deve ter no maximo 180 caracteres")
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O e-mail está inválido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")
                .NotNull()
                .WithMessage("A senha não pode ser nula")
                .MinimumLength(6)
                .WithMessage("A senha deve ter no minimo 6 caracteres")
                .MaximumLength(30)
                .WithMessage("A senha deve ter no maximo 30 caracteres");
        }
    }
}
