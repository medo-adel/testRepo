using AutoMapper;
using Common.StandardInfrastructure;
using CryptoHelper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Organizations.Data.Entities;
using Organizations.DataAccess;
using Organizations.Service.Dto;
using Organizations.Service.FilterDto;
using Organizations.Service.Interfaces;
using Organizations.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Organizations.Service.Services
{
    public class UserManagementService : BaseServices, IUserManagementService
    {
        private readonly ISendMail _sendEmail;
        private readonly ISessionStorage _sessionStorage;
        public UserManagementService(IMapper mapper,
                                   IUnitOfWork unitOfWork, ISendMail sendEmail,
                                   IStringLocalizer<Resources.Organizations> organizationLocalize,
                                   IStringLocalizer<Common.StandardInfrastructure.Resources.Common> commonLocalize,
                                   ISessionStorage sessionStorage
                                   ) : base(mapper, unitOfWork, organizationLocalize, commonLocalize)
        {
            _sendEmail = sendEmail;
            _sessionStorage = sessionStorage;

        }
        public async Task<IEnumerable<UserMangmentDto>> GetAll()
        {
            var list = await UnitOfWork.GetRepository<User>().FindAsync(a=>!a.IsDelete && a.Id != ReturenUserIdToken(), source => source.Include(u => u.UserRoles).ThenInclude(u => u.Roles));

            return Mapper.Map<IEnumerable<User>, IEnumerable<UserMangmentDto>>(list);
        }

        public async Task<IEnumerable<DropdownDto>> GetAllRoles()
        {
            var list = await UnitOfWork.GetRepository<Roles>().GetAllAsync();
            return Mapper.Map<IEnumerable<DropdownDto>>(list);
        }
        public async Task<UserMangmentDto> Get(Guid id)
        {
            var user = await UnitOfWork.GetRepository<User>().FirstOrDefaultAsync(a => a.Id == id, source => source.Include(u => u.UserRoles));
            return Mapper.Map<User, UserMangmentDto>(user);
        }
        public async Task<string> Add(UserMangmentDto userManagementDto)
        {
            var newPassword = userManagementDto.Password;           
            if (await IsUserNameExists(userManagementDto.UserName))
            {
                return OrganizationLocalize["User_Name_Already_Exist"];
            }

            userManagementDto.Password = HashPassword(userManagementDto.Password);
            var user = Mapper.Map<UserMangmentDto, User>(userManagementDto);
            await UnitOfWork.GetRepository<User>().AddAsync(user);
            await UnitOfWork.SaveChangesAsync();
            try
            {
                var body = $" <p> Your User Name : {userManagementDto.UserName}</p> <br> <p> Your Password is : {newPassword}</p>";
                _sendEmail.Send(mailTo: userManagementDto.Email, subject: "Your PassWord", body: body, supportHtml: true);
                return null;

            }
            catch (Exception)
            {
                return "Your E-mail is Not Registered";
            }

        }
        async Task<bool> IsUserNameExists(string userName) => await UnitOfWork.GetRepository<User>().IsExistAnyAsync(c => c.UserName.Trim().ToLower() == userName.Trim().ToLower());
        private string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }
        public async Task Update(UserMangmentDto userManagementDto)
        {
            var userOld = await UnitOfWork.GetRepository<User>().FirstOrDefaultAsync(u => u.Id == userManagementDto.Id, source => source.Include(u => u.UserRoles));

            if (userOld?.Password != userManagementDto.Password)
            {
                userManagementDto.Password = string.IsNullOrEmpty(userManagementDto.Password) ? userOld?.Password : HashPassword(userManagementDto.Password);
            }
            Mapper.Map(userManagementDto, userOld);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {

            var user = await UnitOfWork.GetRepository<User>().GetAsync(id);

            if (user != null)
            {
                await UnitOfWork.GetRepository<User>().RemoveAsync(user);
                await UnitOfWork.SaveChangesAsync();
            }
        }
        public async Task<PagedListDto<UserMangmentDto>> GetAllUserManagementPaged(UserMangmentFilterDto filteringDto, PagingSortingDto pagingSortingDto)
        {
            var predicate = Helper.GetPredicate<User, UserMangmentFilterDto>(filteringDto);
            var (list, count) = await UnitOfWork.GetRepository<User>().GetPagedListAsync(predicate, pagingSortingDto);
            var listDto = Mapper.Map<IEnumerable<User>, IEnumerable<UserMangmentDto>>(list);
            return new PagedListDto<UserMangmentDto> { List = listDto, Count = count };
        }

        public Guid ReturenUserIdToken()
        {
            return _sessionStorage.UserId;


        }
    }
}
