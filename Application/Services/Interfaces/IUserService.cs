using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Dto.User;
using Data.Entities;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {

        Task<List<UserDto>> GetAllUsers();

        Task<UserDto> GetById(Expression<Func<User, bool>> predicate);

        Task UpdateUser(UserUpdateDto model);

        Task<UserRegisterDto> AddUser(UserRegisterDto model);

        Task RemoveUser(Guid id);

        Task SendPasswordResetConfirmation(string email);

        Task ResetPassword(ResetPasswordDto model);
    }
}
