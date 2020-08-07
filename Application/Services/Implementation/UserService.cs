using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.User;
using Application.Services.Interfaces;
using AutoMapper;
using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementation
{
    public class UsersService : IUserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<ResetPassword> _resetPasswordRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly DatabaseContex _context;

        public UsersService(IRepository<User> userRepository, 
            IMapper mapper, 
            IRepository<ResetPassword> resetPasswordRepository, DatabaseContex context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _resetPasswordRepository = resetPasswordRepository;
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<UserDto> GetById(Expression<Func<User, bool>> predicate)
        {

            var user = await _userRepository.GetAll()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(predicate);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            return _mapper.Map<List<UserDto>>(await _userRepository.GetAll().ToListAsync());
        }

        public async Task UpdateUser(UserUpdateDto model)
        {
            var newUser = new UserUpdateDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                IsEmailConfirmed = model.IsEmailConfirmed
            };

            var user = _mapper.Map<User>(newUser);
            await _userRepository.UpdateAsync(user);
            var affectedRows = await _userRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
        }

        public async Task<UserRegisterDto> AddUser(UserRegisterDto model)
        {
            if (await _userRepository.FindByCondition(u => u.Email == model.Email) == null)
            {
                var user = _mapper.Map<User>(model);
                user.Password = _passwordHasher.HashPassword(user, user.Password);
                user.FirstName = Regex.Replace(user.FirstName, "[ ]+", " ");
                user.LastName = Regex.Replace(user.LastName, "[ ]+", " ");
                _userRepository.Add(user);
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<UserRegisterDto>(user);
            }
            throw new Exception($"User with email {model.Email} exist in db");
        }
        public async Task RemoveUser(Guid id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"There is no user with id = {id} in database");
            }

            _userRepository.Remove(user);
            var affectedRows = await _userRepository.SaveChangesAsync();
            if (affectedRows == 0)
            {
                throw new DbUpdateException();
            }
            await transaction.CommitAsync();
        }

        //ToDo
        public async Task SendPasswordResetConfirmation(string email)
        {
            var user = await _userRepository.FindByCondition(c => c.Email == email);
            var resetPassword = new ResetPassword
            {
                ConfirmationNumber = Guid.NewGuid().ToString(),
                ResetDate = DateTime.UtcNow
            };
            _resetPasswordRepository.Add(resetPassword);
            await _resetPasswordRepository.SaveChangesAsync();
            //await _emailService.SendForPasswordResetAsync(user.FirstName, resetPassword.ConfirmationNumber, email);
        }

        public async Task ResetPassword(ResetPasswordDto newPassword)
        {
            const int EXPIRATION_TIME = 30;
            var user = await _userRepository.FindByCondition(u => u.Email == newPassword.Email);
            var resetPassword =
                _resetPasswordRepository.FindByCondition(c => c.ConfirmationNumber == newPassword.ConfirmationNumber).Result;
            if (resetPassword != null && resetPassword.ConfirmationNumber == newPassword.ConfirmationNumber && resetPassword.ResetDate <= DateTime.Now.AddMinutes(EXPIRATION_TIME))
            {
                user.Password = _passwordHasher.HashPassword(user, newPassword.Password);
                await _userRepository.SaveChangesAsync();
            }
            await _userRepository.SaveChangesAsync();
        }
    }
}
