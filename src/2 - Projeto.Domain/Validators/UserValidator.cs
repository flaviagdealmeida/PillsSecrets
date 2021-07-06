using FluentValidation;
using Projeto.Domain.Entities;

namespace Projeto.Domain.Validators{
    public class UserValidator: AbstractValidator<Users>{
        public UserValidator(){
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
                .WithMessage("O nome deve conter pelo menos 3 caracteres")
                .MaximumLength(80)
                .WithMessage("O nome deve conter no máximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail não pode ser vazio")
                .NotNull()
                .WithMessage("O e-mail não pode ser nulo")
                .MinimumLength(10)
                .WithMessage("O e-mail deve conter pelo menos 10 caracteres")
                .MaximumLength(180)
                .WithMessage("O e-mail deve conter no máximo 180 caracteres")
                .Matches(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i")  //pode ser substituido por .EmailAddress()
                .WithMessage("O e-mail informado não é valido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")
                .NotNull()
                .WithMessage("A senha não pode ser nula")
                .MinimumLength(6)
                .WithMessage("A senha deve conter pelo menos 6 caracteres")
                .MaximumLength(30)
                .WithMessage("A senha deve conter no máximo 30 caracteres");
        }
    }

}