using Application.Common.Interfaces.Services;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.User.Queries
{
    public class GetUserByIdQuery : IRequest<Result>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result>
    {

        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return new Result()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "usuario encontrado",
                Response = await _userService.GetUserById(request.Id),
            };
        }
    }
}
