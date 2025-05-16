using AutoMapper;
using Common.StandardInfrastructure;
using Common.StandardInfrastructure.Communication;
using Common.StandardInfrastructure.RestSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using NETCore.Encrypt;
using Organizations.Data.Entities;
using Organizations.DataAccess;
using Organizations.Service.Dto;
using Organizations.Service.Dto.OtherServices;
using Organizations.Service.Interfaces;
using Organizations.Service.Services.Base;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Service.Services
{
    public class OrganizationLicenseService : BaseServices, IOrganizationLicenseService
    {
        private readonly ISessionStorage _sessionStorage;
        private readonly IConfiguration _config;
        private readonly IRestSharpContainerAdvanced _httpRest;
        private readonly ISendMail _sendEmail;
        public OrganizationLicenseService(IMapper mapper, IUnitOfWork unitOfWork, ISendMail sendEmail,
            ISessionStorage sessionStorage,
            IStringLocalizer<Resources.Organizations> organizationLocalize,
            IStringLocalizer<Common.StandardInfrastructure.Resources.Common> commonLocalize,
            IConfiguration config, IRestSharpContainerAdvanced httpRest

            ) : base(mapper, unitOfWork, organizationLocalize, commonLocalize)
        {
            
            _sessionStorage = sessionStorage;
            _config = config;
            _httpRest = httpRest;
            _sendEmail = sendEmail;
        }

        public async Task<OrganizationLicenseDto> Get(Guid id)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == id, source => source.Include(u => u.Package).Include(u => u.Application));
            return Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(list);
        }       
        
        public async Task<OrganizationLicenseScreenDto> GetOrganizatiolicenseScreen(Guid id)
        {

            var organizational = new OrganizationLicenseScreenDto();
            var list = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(r => r.OrganizationId == id, source => source.Include(u => u.Package).Include(u => u.Application))).ToList();

            var applicationId = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())?.ApplicationId;
            if (applicationId == ApplicationsEnum.Tams.GetEnumGuid())
            {
                organizational.UsersCount = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())?.UsersCount ?? 0;
                organizational.EmployeesCount = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())?.EmployeesCount ?? 0;
                organizational.InquiryUsersCount = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())?.UsersCount ?? 0;
                organizational.ExpireDate = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())?.ExpireDate ?? default;
                organizational.InquiryExpireDate = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())?.ExpireDate ?? default;
            }
            else
            {
                organizational.UsersCount = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())?.UsersCount ?? 0;
                organizational.EmployeesCount = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())?.EmployeesCount ?? 0;
                organizational.ExpireDate = list.FirstOrDefault(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())?.ExpireDate ?? default;

            }


            return organizational;
        }
        public async Task<OrganizationLicenseScreenDto> GetOrganizatiolicenseScreenForAum(Guid id)
        {

            var organizational = new OrganizationLicenseScreenDto();
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == id && r.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid(), source => source.Include(u => u.Package).Include(u => u.Application));         
            organizational.UsersCount = list?.UsersCount ?? 0;
            organizational.EmployeesCount = list?.EmployeesCount ?? 0;
            organizational.ExpireDate = list?.ExpireDate ?? default;           
            return organizational;
        }
        public async Task<IEnumerable<OrganizationLicenseDto>> GetAll()
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().GetAllAsync(source => source
                                                        .Include(u => u.Package)
                                                        .Include(u => u.Organization)
                                                        .Include(u => u.Application));
            return Mapper.Map<IEnumerable<OrganizationLicense>, IEnumerable<OrganizationLicenseDto>>(list);
        }
        public async Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequest()
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FindAsync(a=>a.IsApprove == null,source => source
                                                        .Include(u => u.Package)
                                                        .Include(u => u.Organization)
                                                        .Include(u => u.Application));
            return Mapper.Map<IEnumerable<OrganizationLicenseRequest>, IEnumerable<OrganizationLicenseDto>>(list);
        }
        public async Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequestApproved()
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FindAsync(a => a.IsApprove == true, source => source
                                                        .Include(u => u.Package)
                                                        .Include(u => u.Organization)
                                                        .Include(u => u.Application));
            return Mapper.Map<IEnumerable<OrganizationLicenseRequest>, IEnumerable<OrganizationLicenseDto>>(list);
        }
        public async Task<IEnumerable<OrganizationLicenseDto>> GetAllOrganizationLicenseRequestRejected()
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FindAsync(a => a.IsApprove == false, source => source
                                                        .Include(u => u.Package)
                                                        .Include(u => u.Organization)
                                                        .Include(u => u.Application));
            return Mapper.Map<IEnumerable<OrganizationLicenseRequest>, IEnumerable<OrganizationLicenseDto>>(list);
        }
        public async Task<IEnumerable<OrganizationUnionOrgLicencesDto>> GetAllMergeOrganizationWithLicences()
        {

            var list = await UnitOfWork.GetRepository<OrganizationLicense>().GetAllAsync(source => source.Include(a => a.Organization)
            .Include(a => a.Package).Include(a => a.Application).Include(a => a.OrganizationLicencesModules));
            var listDto = Mapper.Map<IEnumerable<OrganizationLicense>, IEnumerable<OrganizationUnionOrgLicencesDto>>(list);

            var modules = (await UnitOfWork.GetRepository<Module>().GetAllAsync()).ToList();
            listDto.ToList().ForEach(item =>
            {
                var stringBuilderFl = new StringBuilder();
                var stringBuilderSl = new StringBuilder();
                item.OrganizationLicencesModules.ForEach(t =>
                {
                    var module = modules.FirstOrDefault(a => a.Id == t.ModuleId);
                    stringBuilderFl.Append($"{module?.ModuleNameFl},");
                    stringBuilderSl.Append($"{module?.ModuleNameSl},");
                });
                item.ModuleNameFl = stringBuilderFl?.ToString();
                item.ModuleNameSl = stringBuilderSl?.ToString();
            });

            return listDto;
        }

        public async Task<IEnumerable<OrganizationLicenseDto>> OrganizationLicenceExpireWithenMonth()
        {
            DateTime startDate = DateTime.Now.Date;
            DateTime endDate = DateTime.Now.Date.AddDays(30);
            var listOfOrganizationLicense = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(a => a.ExpireDate.Date >= startDate.Date && a.ExpireDate.Date <= endDate.Date, source => source.Include(a => a.Organization).Include(a => a.Package).Include(a => a.Application))).ToList();
            var result = Mapper.Map<IEnumerable<OrganizationLicense>, IEnumerable<OrganizationLicenseDto>>(listOfOrganizationLicense);
            return result;
        }

        //Under Test Mubarak
        public async Task<OrganizationSettingDto> GetOrganizationSetting(Guid id)
        {
            var list = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultAsync(r => r.OrganizationId == id, source => source.Include(a => a.Organization));
            if (list == null)
            {
                return new OrganizationSettingDto();
            }
            else
            {
                if (list.PrimaryKeyId == null)
                {
                    list.PrimaryKeyId = Guid.Empty;
                }
                if (list.ADKeyId == null)
                {
                    list.ADKeyId = Guid.Empty;
                }
                return Mapper.Map<OrganizationSetting, OrganizationSettingDto>(list);

            }
        }
        public async Task<List<OrganizationSettingDto>> GetOrganizationSettingList()
        {
           
            var list = (await UnitOfWork.GetRepository<OrganizationSetting>().FindAsync(r => !r.IsDelete, source => source.Include(a => a.Organization))).ToList();
            list.ForEach(a =>
            {
                if (a.PrimaryKeyId == null)
                {
                    a.PrimaryKeyId = Guid.Empty;
                }
                if (a.ADKeyId == null)
                {
                    a.ADKeyId = Guid.Empty;
                }
            });
          
            return Mapper.Map<List<OrganizationSetting>, List<OrganizationSettingDto>>(list);        
        }
        public async Task<IEnumerable<ActiveDirectoryPrimaryKeyDto>> GetAllPrimaryKey()
        {
            var list = await UnitOfWork.GetRepository<ActiveDirectoryPrimaryKey>().GetAllAsync();
            return Mapper.Map<IEnumerable<ActiveDirectoryPrimaryKey>, IEnumerable<ActiveDirectoryPrimaryKeyDto>>(list);
        }
        public async Task<IEnumerable<ActiveDirectoryKeyDto>> GetAllADKey()
        {
            var list = await UnitOfWork.GetRepository<ActiveDirectoryKey>().GetAllAsync();
            return Mapper.Map<IEnumerable<ActiveDirectoryKey>, IEnumerable<ActiveDirectoryKeyDto>>(list);
        }

        public async Task<string> UpdateSettingOrganization(OrganizationSettingDto organizationSettingDto)
        {
            if (organizationSettingDto.WeekendDayId == organizationSettingDto.RestDayId &&
                organizationSettingDto.WeekendDayId != null && organizationSettingDto.RestDayId != null && organizationSettingDto.WeekendDayId != Guid.Empty && organizationSettingDto.RestDayId != Guid.Empty)
            {
                return CommonLocalize["RestDayandWeekendDayShouldnotbethesameDays"];
            }
            if (organizationSettingDto.ADKeyId == Guid.Empty || organizationSettingDto.PrimaryKeyId == Guid.Empty)
            {
                organizationSettingDto.ADKeyId = null;
                organizationSettingDto.PrimaryKeyId = null;
            }
            var organizationsettingOld = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultAsync(a => a.OrganizationId == organizationSettingDto.OrganizationId,
            source => source.Include(a => a.Organization));
            var organizationSetting = Mapper.Map<OrganizationSettingDto, OrganizationSetting>(organizationSettingDto);
                 
            try
            {
                if (organizationsettingOld == null)
                {                 
                    await UnitOfWork.GetRepository<OrganizationSetting>().AddAsync(organizationSetting);
                    await UnitOfWork.SaveChangesAsync();
                    return null;

                }
            }
            catch (Exception e)
            {

                throw;
            }
            

            organizationSettingDto.Id = organizationsettingOld.Id;
            Mapper.Map(organizationSettingDto, organizationsettingOld);
            await UnitOfWork.SaveChangesAsync();
            return null;

        }
        private async Task SendEmailToAdmin()
        {
            var userInfo = (await UnitOfWork.GetRepository<User>().FindSelectAsync(a => a.UserRoles.Any(g => g.RoleId == RolesEnum.Admin.GetEnumGuid()),
                                                                                                        a => new { a.Email },
                                                                                                        isOrganization: false
                                                                                                  )).Select(a => a?.Email).ToList();
            if (userInfo != null && userInfo.Count > 0)
            {
                foreach (var item in userInfo)
                {
                    await _sendEmail.Send(item, "Please Go to license website to accept  Organization License Request", "New Organization License Request");
                }
            }
        }
        public async Task<OrganizationLicenseDto> GetOrganizationLicenseByOrganizationId(Guid organizationId)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == organizationId);
            return Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(list);
        }
        public async Task<bool> CheckExpireDate(Guid organizationId, Guid applicationId)
        {
            var organization = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == organizationId && r.ApplicationId == applicationId);
            // to skip organization added from seed
            if (organization == null) return true;
            return organization?.ExpireDate.Date >= DateTime.Now.Date;
        }

        public async Task<bool> CheckExpireDateWithSuperAdmin(string code, Guid applicationId)
        {
            var organization = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.Organization.Code == code && r.ApplicationId == applicationId && r.Organization.IsPromise ==true);
            // to skip organization added from seed
            if (organization == null) return true;
            return organization?.ExpireDate.Date >= DateTime.Now.Date;
        }
        public async Task<string> Add(OrganizationLicenseDto organizationLicenseDto)
        {
            
            if(organizationLicenseDto.IsApprove == null)
            {
                organizationLicenseDto.Id = null;
                return await AddOrganizationLicenceRequest(organizationLicenseDto);
            }
            else
            { 
            if (await IsExist(organizationLicenseDto))
            {
                return OrganizationLocalize["OrganizationLicencesExistBeforForThisOrganization"];
            }
            var organizationlicence = Mapper.Map<OrganizationLicenseDto, OrganizationLicense>(organizationLicenseDto);
            organizationlicence = EncryptOrganizationLicense(organizationlicence);
            var result = await UnitOfWork.GetRepository<OrganizationLicense>().AddAsync(organizationlicence);
            await UnitOfWork.SaveChangesAsync();
            var organization = (await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == result.OrganizationId));

            if (!organization.IsPromise && organizationLicenseDto.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())
            {
                await CreateAdminUser(result.Organization.AdminPassword, result.OrganizationId);
                var token = Helper.GenerateToken(organizationLicenseDto.OrganizationId);
                await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, token);
            }
            else if (!organization.IsPromise && organizationLicenseDto.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())
            {
                var adminUserData = new AdminUserData()
                {
                    OrganizationId = result.OrganizationId,
                    AdminPassword = organization.AdminPassword
                };
                await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

            }
            if (organizationLicenseDto.OrganizationHostApis.Any() && organizationLicenseDto.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())
            {
                var OrganizationHostData = Mapper.Map<IEnumerable<OrganizationHostApisDto>, IEnumerable<OrganizationHost>>(organizationLicenseDto.OrganizationHostApis);
                await UnitOfWork.GetRepository<OrganizationHost>().AddRangeAsync(OrganizationHostData);
                await UnitOfWork.SaveChangesAsync();
            }
            if (organizationLicenseDto.IsApprove == true)
            {
                return await OrganizationLicenceRequest(organizationLicenseDto);
            }
                return null;
        }
        }

        private async Task<string> AddOrganizationLicenceRequest(OrganizationLicenseDto organizationLicenseDto)
        {
            try
            {
                if (await IsExistRequest(organizationLicenseDto))
                {
                    return OrganizationLocalize["OrganizationLicencesRequestExistBeforForThisOrganization"];
                }
                var organizationLicenseRequest = Mapper.Map<OrganizationLicenseDto, OrganizationLicenseRequest>(organizationLicenseDto);
                organizationLicenseRequest = EncryptOrganizationLicenseRequest(organizationLicenseRequest);
                await UnitOfWork.GetRepository<OrganizationLicenseRequest>().AddAsync(organizationLicenseRequest);
                await UnitOfWork.SaveChangesAsync();

                if (organizationLicenseDto.OrganizationHostApis !=null && organizationLicenseDto.OrganizationHostApis.Any() && organizationLicenseDto.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())
                {
                    var organizationHostRequest = Mapper.Map<IEnumerable<OrganizationHostApisDto>, IEnumerable<OrganizationHostRequest>>(organizationLicenseDto.OrganizationHostApis);
                    await UnitOfWork.GetRepository<OrganizationHostRequest>().AddRangeAsync(organizationHostRequest);
                    await UnitOfWork.SaveChangesAsync();
                }
                if (organizationLicenseDto.IsApprove == null)
                {
                    await SendEmailToAdmin();
                }
                if (organizationLicenseDto.IsApprove == true)
                {
                    var organizationLicenseRequestOld = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FirstOrDefaultAsync(a => a.Id == organizationLicenseDto.Id);
                    var message = "Your Organization License New Request Approved";
                    await SendEmailToUser(organizationLicenseRequestOld.CreatedBy, message);
                }
                return null;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public async Task<string> Update(OrganizationLicenseDto organizationLicenseDto)
        {
            if(organizationLicenseDto.IsApprove == null)
            {
                return await OrganizationLicenceRequest(organizationLicenseDto);
            }
            else
            { 
            if (await IsExist(organizationLicenseDto))
            {
                return OrganizationLocalize["OrganizationLicencesExistBeforForThisOrganization"];
            }
            var organizationLicenseOld = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(a => a.Id == organizationLicenseDto.Id, source => source.Include(r => r.OrganizationLicencesModules).Include(r => r.Organization));
            var organizationId = organizationLicenseOld.OrganizationId;
            await UnitOfWork.GetRepository<OrganizationLicencesModule>().RemoveRangeAsync(organizationLicenseOld.OrganizationLicencesModules);
            await UnitOfWork.SaveChangesAsync();
            var organizationlicenseNew = Mapper.Map<OrganizationLicenseDto, OrganizationLicense>(organizationLicenseDto);
            organizationlicenseNew = EncryptOrganizationLicense(organizationlicenseNew);
            var organizationlicenseDtoNew = Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(organizationlicenseNew);
            var result = Mapper.Map(organizationlicenseDtoNew, organizationLicenseOld);
            await UnitOfWork.SaveChangesAsync();
            
             if (!result.Organization.IsPromise && organizationLicenseDto.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())
            {
                await CreateAdminUser(result.Organization.AdminPassword, organizationId);
                var token = Helper.GenerateToken(organizationId);
                //await _serviceCommunication.Execute("AbsencesRegulations/AddDefaultRegulations", token);
                await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, token);


            }
            if (!result.Organization.IsPromise && organizationLicenseDto.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())
            {
                var adminUserData = new AdminUserData()
                {
                    OrganizationId = organizationId,
                    AdminPassword = result.Organization.AdminPassword
                };
               // var aumURL = _config["APIAumService"];
               // await _serviceCommunication.GetPridicateWithCompleteUrl<string, AdminUserData>($"{aumURL}UserMangments/CreateAdminUserForAum", adminUserData, _sessionStorage.Token);
                await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, _sessionStorage.Token, obj: adminUserData);

            }
            if (organizationLicenseDto.OrganizationHostApis.Any() && organizationLicenseDto.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())
            {
                var OrganizationHostOld = await UnitOfWork.GetRepository<OrganizationHost>().FindAsync(a => a.OrganizationId == organizationLicenseDto.OrganizationId);
                await UnitOfWork.GetRepository<OrganizationHost>().RemoveRangeAsync(OrganizationHostOld);
                await UnitOfWork.SaveChangesAsync();
                var OrganizationHostData = Mapper.Map<IEnumerable<OrganizationHostApisDto>, IEnumerable<OrganizationHost>>(organizationLicenseDto.OrganizationHostApis);
                await UnitOfWork.GetRepository<OrganizationHost>().AddRangeAsync(OrganizationHostData);
                await UnitOfWork.SaveChangesAsync();
            }              
                return null;
            }
        }

        private async Task<string> OrganizationLicenceRequest(OrganizationLicenseDto organizationLicenseDto)
        {
           
            if (organizationLicenseDto.IsApprove == null && await IsExistRequest(organizationLicenseDto))
            {
                return OrganizationLocalize["OrganizationLicencesRequestExistBeforForThisOrganization"];
            }
            var organizationLicenseRequestOld = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FirstOrDefaultAsync(a => a.Id == organizationLicenseDto.Id, source => source.Include(r => r.OrganizationLicencesModules).Include(r => r.Organization));
            if (organizationLicenseRequestOld != null)
            {
                await UnitOfWork.GetRepository<OrganizationLicencesModuleRequest>().RemoveRangeAsync(organizationLicenseRequestOld.OrganizationLicencesModules);
                await UnitOfWork.SaveChangesAsync();
                var organizationlicenseRequestNew = Mapper.Map<OrganizationLicenseDto, OrganizationLicenseRequest>(organizationLicenseDto);
                organizationlicenseRequestNew = EncryptOrganizationLicenseRequest(organizationlicenseRequestNew);
                var organizationlicenseRequestDtoNew = Mapper.Map<OrganizationLicenseRequest, OrganizationLicenseDto>(organizationlicenseRequestNew);
                Mapper.Map(organizationlicenseRequestDtoNew, organizationLicenseRequestOld);
                await UnitOfWork.SaveChangesAsync();
                if (organizationLicenseDto.IsApprove == null)
                {
                    await SendEmailToAdmin();
                }
                if (organizationLicenseDto.IsApprove == true)
                {
                    var message = "Your Organization License New Request Approved";
                    await SendEmailToUser(organizationLicenseRequestOld.CreatedBy, message);
                }
            }
            else
            {
                return await AddOrganizationLicenceRequest(organizationLicenseDto);
            }

            if (organizationLicenseDto.OrganizationHostApis.Any() && organizationLicenseDto.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid())
            {
                var OrganizationHostOld = await UnitOfWork.GetRepository<OrganizationHostRequest>().FindAsync(a => a.OrganizationId == organizationLicenseDto.OrganizationId);
                await UnitOfWork.GetRepository<OrganizationHostRequest>().RemoveRangeAsync(OrganizationHostOld);
                await UnitOfWork.SaveChangesAsync();
                var OrganizationHostData = Mapper.Map<IEnumerable<OrganizationHostApisDto>, IEnumerable<OrganizationHostRequest>>(organizationLicenseDto.OrganizationHostApis);
                await UnitOfWork.GetRepository<OrganizationHostRequest>().AddRangeAsync(OrganizationHostData);
                await UnitOfWork.SaveChangesAsync();
            }

            return null;
        }
        private async Task SendEmailToUser(Guid? userId, string message)
        {
            var userInfo = (await UnitOfWork.GetRepository<User>().FirstOrDefaultSelectAsync(a => a.Id == userId, a => new { a.Email }, isOrganization: false)).Email;
            if (userInfo != null)
            {
                await _sendEmail.Send(userInfo, message, "New Organization License Request");
            }
        }
        public async Task<string> ApproveOrganizationLicenseRequest(OrganizationLicenseDto organizationLicenseDto)
        {
            if (organizationLicenseDto.IsApprove == true)
            {
                organizationLicenseDto.IsApprove = true;
                var organizationLicenseOld = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(a => a.ApplicationId == organizationLicenseDto.ApplicationId
            && a.OrganizationId == organizationLicenseDto.OrganizationId, isOrganization: false);
                if (organizationLicenseOld == null)
                    return await Add(organizationLicenseDto);
                else
                {
                    
                    await OrganizationLicenceRequest(organizationLicenseDto);                   
                    organizationLicenseDto.Id = organizationLicenseOld.Id;
                    return await Update(organizationLicenseDto);
                }
                

            }
            else
            {
                return await RemoveOrgLicenceRequests(organizationLicenseDto);
            }
        }

        private async Task<string> RemoveOrgLicenceRequests(OrganizationLicenseDto organizationLicenseDto)
        {
            var organizationLicenseRequestOld = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FirstOrDefaultAsync(a => a.Id == organizationLicenseDto.Id, source => source.Include(r => r.OrganizationLicencesModules));
            if(organizationLicenseRequestOld != null)
            {
             var message = "Your Organization License New Request Rejected";
             await SendEmailToUser(organizationLicenseRequestOld.CreatedBy, message);
            await UnitOfWork.GetRepository<OrganizationLicencesModuleRequest>().RemoveRangeAsync(organizationLicenseRequestOld?.OrganizationLicencesModules);
            var OrganizationHostOld = await UnitOfWork.GetRepository<OrganizationHostRequest>().FindAsync(a => a.OrganizationId == organizationLicenseDto.OrganizationId);
            await UnitOfWork.GetRepository<OrganizationHostRequest>().RemoveRangeAsync(OrganizationHostOld);
            await UnitOfWork.GetRepository<OrganizationLicenseRequest>().RemoveAsync(organizationLicenseRequestOld);
            await UnitOfWork.SaveChangesAsync();
            return null;
            }
            return null;
        }

        private async Task CreateAdminUser(string adminPassword, Guid? id)
        {
            Log.Information($"password encrypted is {adminPassword}");
            var newId = Guid.NewGuid();
            var user = new AdminUserDto()
            {
                Id = newId,
                Username = "Admin",
                Password = EncryptProvider.AESDecrypt(adminPassword, Constants.EncryptDecryptKey),
                IsActive = true,
                ExpireDate = new DateTime(3000, 1, 1),
                IsEndOfContract = false,
                IsCivilId = false,
                IsSuperAdmin = EncryptProvider.AESEncrypt($"{newId}Admin", Constants.EncryptDecryptKey),
                OrganizationId = id
            };
            Log.Information($"password decrypted is {user.Password}");
            // call addAdminUser from users service
            //await _serviceCommunication.GetObjectPridicate<string, AdminUserDto>("Users/AddUserAdmin", user, Helper.GenerateToken(id));
            await _httpRest.SendRequest<string>("Users/AddUserAdmin", Method.POST, CommuncationDecision.TamsUrl, Helper.GenerateToken(id), user);

        }


        public async Task Delete(Guid id)
        {
            var organizationLicenseDto = await UnitOfWork.GetRepository<OrganizationLicense>().GetAsync(id);
            if (organizationLicenseDto != null)
            {
                await UnitOfWork.GetRepository<OrganizationLicense>().RemoveAsync(organizationLicenseDto);
                await UnitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteOrganizationLicenseRequest(Guid id)
        {
            var organizationLicenseDto = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().GetAsync(id);
            if (organizationLicenseDto != null)
            {
                await UnitOfWork.GetRepository<OrganizationLicenseRequest>().RemoveAsync(organizationLicenseDto);
                await UnitOfWork.SaveChangesAsync();
            }
        }
        public async Task<OrganizationLicenseDto> GetById(Guid id)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.Id == id, source => source
                                                             .Include(u => u.Package)
                                                             .Include(u => u.Application)
                                                             .Include(u => u.OrganizationLicencesModules));
            return Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(list);
        }
        public async Task<OrganizationLicenseDto> GetByIdOrganizationLicenseRequest(Guid id)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicenseRequest>().FirstOrDefaultAsync(r => r.Id == id, source => source
                                                             .Include(u => u.Package)
                                                             .Include(u => u.Application)
                                                             .Include(u => u.OrganizationLicencesModules));
            return Mapper.Map<OrganizationLicenseRequest, OrganizationLicenseDto>(list);
        }
        public async Task<EncryptedLicences> VerifyEncryptionWithApplication(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            var result = new EncryptedLicences();
            var organizationLicense = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == encryptedLicencesFilter.OrganizationId && r.ApplicationId == encryptedLicencesFilter.ApplicationId, source => source.Include(r => r.OrganizationLicencesModules));
            if (organizationLicense == null) return result;
            foreach (var item in organizationLicense.OrganizationLicencesModules.Where(item => item.Encryption != item.ModuleId.ToString().Encrypt()))
            {
                result.EncruptedTrue = false;
            }
            var mainData = string.Concat(organizationLicense.ApplicationId, organizationLicense.PackageId, organizationLicense.EmployeesCount, organizationLicense.UsersCount, organizationLicense.ExpireDate.Date.ToString("ddMMyyyy"));
            var encryptData = EncryptProvider.AESDecrypt(organizationLicense.Encryption, Constants.EncryptDecryptKey);
            if (encryptData != mainData)
            {
                result.EncruptedTrue = false;
            }
            result.OrganizationLicense = Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(organizationLicense);
            return result;
        }
        private static OrganizationLicenseRequest EncryptOrganizationLicenseRequest(OrganizationLicenseRequest organizationLicense)
        {
            foreach (var item in organizationLicense.OrganizationLicencesModules)
            {
                item.Encryption = item.ModuleId.ToString().Encrypt();
            }
            var encryption = string.Concat(organizationLicense.ApplicationId, organizationLicense.PackageId, organizationLicense.EmployeesCount, organizationLicense.UsersCount, organizationLicense.ExpireDate.Date.ToString("ddMMyyyy"));
            organizationLicense.Encryption = EncryptProvider.AESEncrypt(encryption, Constants.EncryptDecryptKey);
            return organizationLicense;
        }
        private static OrganizationLicense EncryptOrganizationLicense(OrganizationLicense organizationLicense)
        {
            foreach (var item in organizationLicense.OrganizationLicencesModules)
            {
                item.Encryption = item.ModuleId.ToString().Encrypt();
            }
            var encryption = string.Concat(organizationLicense.ApplicationId, organizationLicense.PackageId, organizationLicense.EmployeesCount, organizationLicense.UsersCount, organizationLicense.ExpireDate.Date.ToString("ddMMyyyy"));
            organizationLicense.Encryption = EncryptProvider.AESEncrypt(encryption, Constants.EncryptDecryptKey);
            return organizationLicense;
        }

        public async Task<List<Guid>> Getsecreenlicences(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            var organizationLicense = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == encryptedLicencesFilter.OrganizationId && r.ApplicationId == encryptedLicencesFilter.ApplicationId,
                source => source.Include(r => r.OrganizationLicencesModules).ThenInclude(r => r.Module).ThenInclude(r => r.ModuleScreens).ThenInclude(a => a.Screen));
            //var modules = organizationLicense?.OrganizationLicencesModules.Select(q => q.Module).ToList();
            //var test = modules.Select(a => a.Id).ToList();
            //var eee = modules.SelectMany(a => a.ModuleScreens.Select(r => r.Screen).ToList()).ToList();
            //var testfff = eee.FirstOrDefault(a => a.Id.ToString() == "36aab155-d4fd-4508-8e8a-590dabaa6b44");

            var screensIds = organizationLicense?.OrganizationLicencesModules.SelectMany(q => q.Module.ModuleScreens.Select(t => t.ScreenId)).ToList();
            return screensIds;
        }
        private async Task<bool> IsExist(OrganizationLicenseDto organizationLicenseDto)
        {
            return await UnitOfWork.GetRepository<OrganizationLicense>().IsExistAnyAsync(a => a.ApplicationId == organizationLicenseDto.ApplicationId
            && a.OrganizationId == organizationLicenseDto.OrganizationId &&
            ((organizationLicenseDto.Id == null) || (organizationLicenseDto.Id != null && a.Id != organizationLicenseDto.Id)));
        }
        private async Task<bool> IsExistRequest(OrganizationLicenseDto organizationLicenseDto)
        {          
            return await UnitOfWork.GetRepository<OrganizationLicenseRequest>().IsExistAnyAsync(a => a.ApplicationId == organizationLicenseDto.ApplicationId
            && a.OrganizationId == organizationLicenseDto.OrganizationId && a.IsApprove == null && 
            ((organizationLicenseDto.Id == null) || (organizationLicenseDto.Id != null && a.Id != organizationLicenseDto.Id)));
        }
        public async Task<List<Guid?>> GetAllWorkflowModuleIds()
        {
            var modulesIds = (await UnitOfWork.GetRepository<OrganizationLicencesModule>().FindSelectAsync(r => r.OrganizationLicense.OrganizationId == _sessionStorage.OrganizationId 
            && r.OrganizationLicense.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid(), a =>  new { a.ModuleId })).Select(a=>a?.ModuleId).ToList();
            return modulesIds;
        }

        public async Task<MobileModuleDto> GetMobileModulesForOrganization()
        {
            var allRequestValues = Enum.GetValues(typeof(RequestTypeEnum));
            var allRequestIds = (from object enumItem in allRequestValues
                                 select new DropdownDto() { Id = ((RequestTypeEnum)enumItem).GetEnumGuid() }).Select(a => a.Id).ToList();
            var modulesDetailsIds = (await UnitOfWork.GetRepository<OrganizationLicencesModule>().FindSelectAsync(r => r.OrganizationLicense.OrganizationId == _sessionStorage.OrganizationId
                             && r.OrganizationLicense.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()
                             && allRequestIds.Contains(r.ModuleId)
                             , a => new { a.ModuleId })).Select(a => a?.ModuleId).ToList();
            var modulesIds = (await UnitOfWork.GetRepository<OrganizationLicencesModule>().FindSelectAsync(r => r.OrganizationLicense.OrganizationId == _sessionStorage.OrganizationId
            && r.OrganizationLicense.ApplicationId == ApplicationsEnum.Mobile.GetEnumGuid(), a => new { a.ModuleId })).Select(a => a?.ModuleId).ToList();
            var result = new MobileModuleDto()
            {
                mobileModuleRequestDto = new MobileModuleRequestDto()
            };
            var allmodules = modulesIds.Union(modulesDetailsIds).ToList();
            allmodules.ForEach(moduleId =>
            {
                result = SetMobilePage(moduleId, result);
            });
            return result;
        }

        private MobileModuleDto SetMobilePage(Guid? moduleId, MobileModuleDto result)
        {
            if (moduleId == MobileModuleEnum.MyInquiry.GetEnumGuid()) result.IsMyInquiry = true;
            else if (moduleId == MobileModuleEnum.MyAdministration.GetEnumGuid()) result.IsMyAdministration = true;
            else if (moduleId == MobileModuleEnum.Requests.GetEnumGuid())
            {
                result.IsRequests = true;
                result.IsDelgation = true;
            }
            else if (moduleId == MobileModuleEnum.Sign.GetEnumGuid()) result.IsSign = true;
            else if (moduleId == MobileModuleEnum.Face.GetEnumGuid()) result.IsFace = true;
            else if (moduleId == RequestTypeEnum.PartialPermission.GetEnumGuid()) result.mobileModuleRequestDto.IsPartDayPermission = true;
            else if (moduleId == RequestTypeEnum.Leave.GetEnumGuid()) result.mobileModuleRequestDto.IsLeave = true;
            else if (moduleId == RequestTypeEnum.FullDayPermision.GetEnumGuid()) result.mobileModuleRequestDto.IsFullDayPermission = true;
            else if (moduleId == RequestTypeEnum.LeaveReturn.GetEnumGuid()) result.mobileModuleRequestDto.IsReturnLeave = true;
            else if (moduleId == RequestTypeEnum.Overtime.GetEnumGuid()) result.mobileModuleRequestDto.IsOverTime = true;
            else if (moduleId == RequestTypeEnum.ForgetSign.GetEnumGuid()) result.mobileModuleRequestDto.IsForgetSign = true;
            else if (moduleId == RequestTypeEnum.Allowances.GetEnumGuid()) result.mobileModuleRequestDto.IsAllowance = true;
            return result;
        }



        public async Task<IEnumerable<HostApiDataDto>> GetDropdownHostApiData(Guid organizationId)
        {
            try
            {
                var result = GetAllHostApiData();

                //var list = await UnitOfWork.GetRepository<HostApiData>().GetAllAsync(isOrganization:false);
                //var result = Mapper.Map<IEnumerable<HostApiDataDto>>(list);
                var OrganizationHosts = (await UnitOfWork.GetRepository<OrganizationHost>().FindAsync(a => a.OrganizationId == organizationId)).ToList();

                result.ForEach(host =>
                {
                    var hostData = OrganizationHosts.FirstOrDefault(a => a.HostApiDataId == host.Id);
                    host.Value = hostData != null ? hostData.Value : "";
                });
                return result;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public List<HostApiDataDto> GetAllHostApiData()
        {
            var enums = Enum.GetValues(typeof(HostApiDataEnum));
            var res = (from object enumItem in enums
                       select new HostApiDataDto()
                       {
                           Id = ((HostApiDataEnum)enumItem).GetEnumGuid(),
                           NameFl = ((HostApiDataEnum)enumItem).GetName(true)[0],
                           NameSl = ((HostApiDataEnum)enumItem).GetName(true)[1],
                           Value = ""
                       }).ToList();
            return res;
        }
        public async Task<Guid?> GetOrganizationLogTypeMobileId()
        {
            var logTypeMobileId = (await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.OrganizationId == _sessionStorage.OrganizationId,q => new { q.LogTypeMobileId })).LogTypeMobileId;
            return logTypeMobileId == null ? LogTypeMobileForOrganizationEnum.F1.GetEnumGuid() : logTypeMobileId;
        }


        public async Task<bool> CheckMailingNdhrModule(Guid orgId)
        {
            var orgLicense = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(q => q.OrganizationId == orgId && q.PackageId == new Guid("21df3c86-c767-4dde-989e-f8675987dcad"));
            if (orgLicense != null)
            {
                return await UnitOfWork.GetRepository<OrganizationLicencesModule>().IsExistAnyAsync(q => q.ModuleId == new Guid("db80524c-f508-491a-1a79-a9a1914bc1fc") && q.OrganizationLicenseId == orgLicense.Id);
            
            }
            return false;

        }

        public async Task<bool> CheckSignInModule(Guid orgId)
        {
            var orgLicense = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(q => q.OrganizationId == orgId && q.PackageId == new Guid("21df3c86-c767-4dde-989e-f8675987dcad"));
            if (orgLicense != null)
            {
                return await UnitOfWork.GetRepository<OrganizationLicencesModule>().IsExistAnyAsync(q => q.ModuleId == new Guid("db79524c-f508-481a-8a89-a8a1904bc1fc") && q.OrganizationLicenseId == orgLicense.Id);

            }
            return false;

        }
        public async Task<bool> CheckFaceModule(Guid orgId)
        {
            var orgLicense = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(q => q.OrganizationId == orgId && q.PackageId == new Guid("21df3c86-c767-4dde-989e-f8675987dcad"));
            if (orgLicense != null)
            {
                return await UnitOfWork.GetRepository<OrganizationLicencesModule>().IsExistAnyAsync(q => q.ModuleId == new Guid("db89524c-f508-481a-8a89-a8a1904bc2fc") && q.OrganizationLicenseId == orgLicense.Id);

            }
            return false;

        }
        public async Task<int?> NumberOfUserHaveFace(Guid orgId)
        {
            var numberOfUsersHaveFaceModule = (await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultSelectAsync(q => q.OrganizationId == orgId&& q.PackageId == new Guid("21df3c86-c767-4dde-989e-f8675987dcad")
                && q.OrganizationLicencesModules.Any(m => m.ModuleId == new Guid("db89524c-f508-481a-8a89-a8a1904bc2fc")),a => new { a.NumberOfUsersHaveFaceModule }))?.NumberOfUsersHaveFaceModule;
            if (numberOfUsersHaveFaceModule != null)
            {
                return numberOfUsersHaveFaceModule;
            }
            return 0;

        }
        public async Task<OrganizationLicenseDto> GetOrganizationDataById(Guid orgId)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == orgId, source => source
                                                             .Include(u => u.Package)
                                                             .Include(u => u.Application)
                                                             .Include(u => u.OrganizationLicencesModules));
            return Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(list);
        }
        public async Task<OrganizationLicenseDto> GetOrganizationDataByIdAndApplicationId(EncryptedLicencesFilter encryptedLicencesFilter)
        {
            var list = await UnitOfWork.GetRepository<OrganizationLicense>().FirstOrDefaultAsync(r => r.OrganizationId == encryptedLicencesFilter.OrganizationId && r.ApplicationId == encryptedLicencesFilter.ApplicationId, source => source
                                                             .Include(u => u.Package)
                                                             .Include(u => u.Application)
                                                             .Include(u => u.OrganizationLicencesModules));
            return Mapper.Map<OrganizationLicense, OrganizationLicenseDto>(list);
        }
    }
}
