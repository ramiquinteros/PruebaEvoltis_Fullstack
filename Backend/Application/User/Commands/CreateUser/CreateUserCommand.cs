using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Application.User.Dtos;
using MediatR;
using System.Net;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommand : CreateUserDto, IRequest<Result> { }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUser(request);

            return new Result()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Usuario creado exitosamente",
                Response = result
            };
        }
    }
}
