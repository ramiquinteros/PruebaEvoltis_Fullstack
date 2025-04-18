using Application.Common.Interfaces.Services;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }

    public class DeleteUserCommandHanlder : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHanlder(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Usuario eliminado correctamente",
                Response = await _userService.DeleteUser(request.Id)
            };
        }
    }
}
