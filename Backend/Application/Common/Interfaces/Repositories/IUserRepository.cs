using Domain.Entities;

namespace Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(UserEntity user);

        Task<bool> UpdateAsync(UserEntity user);

        Task<bool> RemoveAsync(UserEntity user);

        Task<UserEntity> FindOneAsync(int id);

        Task<List<UserEntity>> FindAsync();

        Task<UserEntity> FindByEmail(string email);
    }
}
