using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Application.User.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(CreateUserDto userDto)
        {
            var userExist = await _userRepository.FindByEmail(userDto.Email);

            if (userExist != null) 
            {
                throw new BadRequestException($"El usuario con el mail {userDto.Email} ya existe");
            }

            var newUser = _mapper.Map<UserEntity>(userDto);

            return await _userRepository.AddAsync(newUser);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.FindOneAsync(id);

            if (user != null)
            {
                throw new NotFoundException("El usuario no existe");
            }

            return await _userRepository.RemoveAsync(user);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _userRepository.FindOneAsync(id);

            if (user != null)
            {
                throw new NotFoundException("El usuario no existe");
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _userRepository.FindAsync();

            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<bool> UpdateUser(UpdateUserDto userDto)
        {
            var existingUser = await _userRepository.FindOneAsync(userDto.Id);

            if (existingUser != null)
            {
                throw new NotFoundException("El usuario no existe");
            }

            var userExist = await _userRepository.FindByEmail(userDto.Email);

            if (userExist != null)
            {
                throw new BadRequestException($"El usuario con el mail {userDto.Email} ya existe");
            }

            _mapper.Map(userDto, existingUser); 

            return await _userRepository.UpdateAsync(existingUser);
        }
    }
}
