using Application.User.Dtos;
using FluentValidation;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("El email no puede estar vacio")
                .EmailAddress().WithMessage("Debe tener formato de mail");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("El nombre no puede estar vacio")
                .MinimumLength(3).WithMessage("El nombre no puede tener menos de 3 letras")
                .MaximumLength(20).WithMessage("El nombre no puede tener mas de 20 letras");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("El apellido no puede estar vacio")
                .MinimumLength(3).WithMessage("El apellido no puede tener menos de 3 letras")
                .MaximumLength(20).WithMessage("El apellido no puede tener mas de 20 letras");
        }
    }
}
