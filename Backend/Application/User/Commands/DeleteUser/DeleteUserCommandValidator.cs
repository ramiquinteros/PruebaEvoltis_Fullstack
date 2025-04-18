using FluentValidation;

namespace Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("El id no puede estar vacio");
        }
    }
}
