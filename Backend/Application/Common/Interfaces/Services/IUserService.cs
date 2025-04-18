using Application.Common.Models;
using Application.User.Dtos;

namespace Application.Common.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserDto userDto);

        Task<bool> UpdateUser(UpdateUserDto userDto);

        Task<bool> DeleteUser(int id);

        Task<UserModel> GetUserById(int id);

        Task<List<UserModel>> GetUsers();
    }
}
