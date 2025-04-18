using Application.Common.Models;
using Application.User.Commands.CreateUser;
using Application.User.Commands.DeleteUser;
using Application.User.Commands.UpdateUser;
using Application.User.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Result>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.Code, result);
        }

        [HttpGet]
        public async Task<ActionResult<Result>> GetUsers([FromQuery] GetUsersQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.Code, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetUserById([FromRoute] GetUserByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.Code, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> DeleteUser([FromRoute] DeleteUserCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.Code, result);
        }

        [HttpPut]

        public async Task<ActionResult<Result>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.Code, result);
        }
    }
}
