using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Application.User.Dtos;
using MediatR;
using System.Net;

namespace Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : UpdateUserDto, IRequest<Result> { }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUserService _userService;
        
        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Usuario actualizado",
                Response = await _userService.UpdateUser(request),
            };
        }
    }
}
