using AutoMapper;
using Common.StandardInfrastructure;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Organizations.Data.Entities;
using Organizations.DataAccess;
using Organizations.Service.Dto;
using Organizations.Service.Interfaces;
using Organizations.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable StringLiteralTypo

namespace Organizations.Service.Services
{
    public class UserService : BaseServices, IUserService
    {
        private readonly ISendMail _sendMail;
        private readonly DateTime _sessionRememberEndTime = DateTime.Now.AddDays(30);
        private readonly DateTime _sessionEndTime = DateTime.Now.AddHours(10);
        private readonly ISessionStorage _sessionStorage;
        public UserService(IMapper mapper,
                                   IUnitOfWork unitOfWork,
                                   IStringLocalizer<Resources.Organizations> organizationLocalize,
                                   IStringLocalizer<Common.StandardInfrastructure.Resources.Common> commonLocalize, ISessionStorage sessionStorage,
              ISendMail sendMail) : base(mapper, unitOfWork, organizationLocalize, commonLocalize)
        {
            _sessionStorage = sessionStorage;
            _sendMail = sendMail;
        }

        public async Task<LoginReturnDto> Authenticate(UserDto authentication)
        {
            var result = new LoginReturnDto();
            var (isAuthenticated, user) = await IsAuthenticated(authentication.UserName, authentication.Password);
            if (isAuthenticated)
            {
                await SetUserLoggedIn(user, authentication.RememberMe);
                var tokenString = JwtGenerateToken(user, authentication.RememberMe);
                result.Token = tokenString;
                result.UserRoles = (await UnitOfWork.GetRepository<UserRoles>().FindAsync
               (a => a.User.UserName.ToLower() == authentication.UserName.ToLower(),
               source => source.Include(r => r.User).Include(r => r.Roles))).Select(a => a.Roles.RoleNameFl).ToList();

                result.UserName = (await UnitOfWork.GetRepository<User>().FirstOrDefaultAsync
                    (a => a.UserName.ToLower() == authentication.UserName.ToLower())).UserName;
            }
            else
            {
                result.Message = OrganizationLocalize["Invalidusernamepassword"];
            }
            return result;
        }
        private string JwtGenerateToken(User user, bool remeberMe = false)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryDifficultSuperSecretKey"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            // how to send data like admin or roles with the token
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44364",
                audience: "http://localhost:44364",
                claims: GetClaims(user),
                expires: remeberMe ? _sessionRememberEndTime : _sessionEndTime,
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserName", user.UserName)
            };
            var userId = user.Id.ToString();
            claims.Add(new Claim("UserId", userId));

            return claims;
        }
        private async Task SetUserLoggedIn(User user, bool remeberMe = false)
        {
            if (user == null) return;

            user.IsLoggedIn = true;
            user.SessionEndTime = remeberMe ? _sessionRememberEndTime : _sessionEndTime;

            await UnitOfWork.SaveChangesAsync();
        }
        private async Task<(bool, User)> IsAuthenticated(string username, string password)
        {
            var user = await UnitOfWork.GetRepository<User>().FirstOrDefaultAsync(c => !c.IsDelete && c.UserName == username.Trim());
            return (VerifyPassword(user?.Password, password), user);
        }
        private bool VerifyPassword(string hash, string password) => Crypto.VerifyHashedPassword(hash ?? "", password);

        public async Task<bool> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await UnitOfWork.GetRepository<User>().GetAsync(_sessionStorage.UserId);
            var isValid = VerifyPassword(user.Password, changePasswordDto.CurrentPassword);
            if (!isValid) return false;

            user.Password = HashPassword(changePasswordDto.NewPassword);
            await UnitOfWork.SaveChangesAsync();

            return true;
        }
        private static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }
        public async Task<string> CanSendEmailForUser(string email)
        {
            var user = await UnitOfWork.GetRepository<User>().FirstOrDefaultAsync(q => q.Email == email);
            if (user == null) return "Your E-mail is Not Registered";
            try
            {
                var token = JwtGenerateToken(user);
                _sendMail.Send(user.Email, subject: "Password Reset", body: _sendMail.GetBody(token), supportHtml: true);
                return null;
            }
            catch (Exception)
            {
                return "Your E-mail is Not Registered";
            }
        }
    }
}
