using Application.User.Dtos;
using FluentValidation;

namespace Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("El email no puede estar vacio")
                .EmailAddress().WithMessage("Debe tener formato de mail");

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("El id no puede estar vacio");

            RuleFor(c => c.Name)
                .MinimumLength(3).WithMessage("El nombre no puede tener menos de 3 letras")
                .MaximumLength(20).WithMessage("El nombre no puede tener mas de 20 letras");

            RuleFor(c => c.LastName)
                .MinimumLength(3).WithMessage("El apellido no puede tener menos de 3 letras")
                .MaximumLength(20).WithMessage("El apellido no puede tener mas de 20 letras");
        }
    }
}
