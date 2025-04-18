using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserEntity>> FindAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> FindOneAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(UserEntity user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UserEntity user)
        {
            UserEntity existUser = await FindOneAsync(user.Id);

            _context.Entry(existUser).CurrentValues.SetValues(user.Id);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
