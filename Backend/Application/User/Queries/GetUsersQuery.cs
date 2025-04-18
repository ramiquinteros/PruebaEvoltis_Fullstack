using Application.Common.Interfaces.Services;
using Application.Common.Models;
using MediatR;
using System.Net;

namespace Application.User.Queries
{
    public class GetUsersQuery : IRequest<Result> { }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "lista de usuarios",
                Response = await _userService.GetUsers()
            };
        }
    }
}
