using cmtech_backend.Models.Converter.Implementations;
using cmtech_backend.Models.Dtos;
using cmtech_backend.Models.Entitys;
using cmtech_backend.Repositories.Interfaces;
using cmtech_backend.Services.Interfaces;
using System;

namespace cmtech_backend.Services.Implementations
{
    public class UserServiceImpl : IUserService
    {
        private readonly IRepository<User> _userRepository;

        private readonly IRepository<Org> _orgRepository;

        private readonly IRepository<Profile> _profileRepository;

        private readonly IRepository<Department> _departmentRepository;

        private readonly UserConverter _userConverter;

        public UserServiceImpl(IRepository<User> userRepository, IRepository<Org> orgRepository, IRepository<Profile> profileRepository, IRepository<Department> departmentRepository)
        {
            _userRepository = userRepository;
            _orgRepository = orgRepository;
            _profileRepository = profileRepository;
            _userConverter = new UserConverter();
            _departmentRepository = departmentRepository;
        }
        public async Task<UserDto> Create(UserDto user)
        {
            User newUser = await NewUser(user);
            return _userConverter.Parse(await _userRepository.Create(newUser));
        }

        public async Task<List<User>> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<List<User>> FindAll()
        {
            return await _userRepository.FindAll();
        }

        public async Task<User> Update(UserDto user)
        {
            User newUser = await NewUser(user);
            return await _userRepository.Update(newUser);
        }

        private async Task<User> NewUser(UserDto user)
        {
            Org org = await _orgRepository.FindById(user.OrgId);

            Profile profile = await _profileRepository.FindById(user.ProfileId);

            Department department = await _departmentRepository.FindById(user.DepartamentId);

            User newUser = _userConverter.Parse(user);
            newUser.Org = org;
            newUser.Profile = profile;
            newUser.Department = department;
            return newUser;
        }
    }
}