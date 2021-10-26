using AutoMapper;
using Core.Exceptions;
using Domain.Entities;
using EscNet.Cryptography.Interfaces;
using Infra.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserServices : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRijndaelCryptography _rijndaelCryptography;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository, IRijndaelCryptography rijndaelCryptography)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _rijndaelCryptography = rijndaelCryptography;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);
            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password));

            var userCreated = await _userRepository.Create(user);
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUsers = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUsers = await _userRepository.SearchByEmail(name);
            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);
            if (userExists == null)
                throw new DomainException("Não existe o usuário informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password));

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}
