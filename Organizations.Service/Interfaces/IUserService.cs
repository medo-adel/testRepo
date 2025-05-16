using Organizations.Service.Dto;
using System.Threading.Tasks;

namespace Organizations.Service.Interfaces
{
    public interface IUserService
    {
        Task<LoginReturnDto> Authenticate(UserDto authentication);
        Task<bool> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<string> CanSendEmailForUser(string email);
    }
}