using AutoMapper;
using Common.StandardInfrastructure;
using Common.StandardInfrastructure.CommonDto;
using Common.StandardInfrastructure.Communication;
using CryptoHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NETCore.Encrypt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Organizations.Data.Entities;
using Organizations.DataAccess;
using Organizations.Service.Dto;
using Organizations.Service.Dto.OtherServices;
using Organizations.Service.FilterDto;
using Organizations.Service.Interfaces;
using Organizations.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Common.StandardInfrastructure.RestSharp;
using RestSharp;
using DocumentFormat.OpenXml.Office2010.Excel;
using RTools_NTS.Util;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace Organizations.Service.Services
{
    public class OrganizationService : BaseServices, IOrganizationService
    {
        private readonly IUploadConfig _imageConfig;
        private const string FolderName = "Files/";
        private const string JsonFilePath = "Packagelicense.json";
        private readonly ISessionStorage _sessionStorage;
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRestSharpContainerAdvanced _httpRest;
        private readonly ISendMail _sendEmail;

        public OrganizationService(IMapper mapper,
                                   IUnitOfWork unitOfWork, ISendMail sendEmail,
                                   IStringLocalizer<Resources.Organizations> organizationLocalize,
                                   IStringLocalizer<Common.StandardInfrastructure.Resources.Common> commonLocalize,
                                   IUploadConfig imageConfig, IHostingEnvironment hostingEnvironment,
                                   ISessionStorage sessionStorage, IConfiguration config, IRestSharpContainerAdvanced httpRest

            ) : base(mapper, unitOfWork, organizationLocalize, commonLocalize)
        {
            _imageConfig = imageConfig;
            _sessionStorage = sessionStorage;
            _config = config;
            _hostingEnvironment = hostingEnvironment;
            _httpRest = httpRest;
            _sendEmail = sendEmail;
        }
        public async Task<IEnumerable<OrganizationDto>> GetAll()
        {
            var list = await UnitOfWork.GetRepository<Organization>().GetAllAsync();
            var organizationDto = Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationDto>>(list);
            organizationDto.FirstOrDefault().LogoURLFl = _imageConfig.ConvertToBase64String(organizationDto.FirstOrDefault().LogoURLFl, FolderName, organizationDto.FirstOrDefault().Id);
            organizationDto.FirstOrDefault().LogoURLSl = _imageConfig.ConvertToBase64String(organizationDto.FirstOrDefault().LogoURLSl, FolderName, organizationDto.FirstOrDefault().Id);
            return organizationDto;
        }
        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequest()
        {
            var list = await UnitOfWork.GetRepository<OrganizationRequest>().FindAsync(a=>a.IsApprove == null);
            var organizationDto = Mapper.Map<IEnumerable<OrganizationRequest>, IEnumerable<OrganizationDto>>(list);            
            return organizationDto;
        }
        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequestApproved()
        {
            var list = await UnitOfWork.GetRepository<OrganizationRequest>().FindAsync(a => a.IsApprove == true);
            var organizationDto = Mapper.Map<IEnumerable<OrganizationRequest>, IEnumerable<OrganizationDto>>(list);
            return organizationDto;
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationRequestRejeted()
        {
            var list = await UnitOfWork.GetRepository<OrganizationRequest>().FindAsync(a => a.IsApprove == false);
            var organizationDto = Mapper.Map<IEnumerable<OrganizationRequest>, IEnumerable<OrganizationDto>>(list);
            return organizationDto;
        }
        public async Task<bool> OrganizationCount()
        {
            var count = await UnitOfWork.GetRepository<Organization>().GetCountAsync(isOrganization: false);
            return count > 1;
        }
        public async Task<IEnumerable<DropdownDto>> GetDropdownListOrganization()
        {
            var list = await UnitOfWork.GetRepository<Organization>().GetAllAsync();
            return Mapper.Map<IEnumerable<DropdownDto>>(list);
        }
        public async Task<IEnumerable<DropdownDto>> GetDropdownListApplication()
        {
            var list = await UnitOfWork.GetRepository<Application>().GetAllAsync();
            return Mapper.Map<IEnumerable<DropdownDto>>(list);
        }
        public async Task<IEnumerable<PackageModuleDto>> GetDropdownListModule()
        {
            var list = await UnitOfWork.GetRepository<Module>().GetAllAsync(source => source.Include(a => a.PackageModules));
            var result = Mapper.Map<IEnumerable<PackageModuleDto>>(list);
            return result;
        }
        public async Task<IEnumerable<PackageModuleCheckedDto>> GetDropdownListModuleChecked(Guid packageId)
        {
            var list = await UnitOfWork.GetRepository<PackageModule>().FindAsync(a => a.PackageId == packageId, source => source.Include(a => a.Module));
            var result = Mapper.Map<IEnumerable<PackageModuleCheckedDto>>(list);
            return result.OrderByDescending(a => a.IsChecked).ThenBy(a => a.NameFl).ToList();
        }
        public async Task<IEnumerable<PackageDto>> GetDropdownListPackage()
        {
            var list = await UnitOfWork.GetRepository<Package>().GetAllAsync();
            return Mapper.Map<IEnumerable<PackageDto>>(list);
        }
        public async Task<OrganizationDto> Get(Guid id)
        {
            var organization = await UnitOfWork.GetRepository<Organization>().GetAsync(id);
            return Mapper.Map<Organization, OrganizationDto>(organization);
        }
        public async Task<OrganizationDto> GetOrganizationRequest(Guid id)
        {
            var organization = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(id);
            return Mapper.Map<OrganizationRequest, OrganizationDto>(organization);
        }
        public async Task<string> Add(OrganizationDto organizationDto)
        {
            string fileFl = null;
            if (!string.IsNullOrWhiteSpace(organizationDto.LogoURLFl))
            {
                fileFl = _imageConfig.SaveBase64(organizationDto.LogoURLFl, $"Organization-{Guid.NewGuid()}", FolderName, organizationDto.Id);
            }
            organizationDto.LogoURLFl = fileFl;

            string fileSl = null;
            if (!string.IsNullOrWhiteSpace(organizationDto.LogoURLSl))
            {
                fileSl = _imageConfig.SaveBase64(organizationDto.LogoURLSl, $"Organization-{Guid.NewGuid()}", FolderName, organizationDto.Id);

            }
            organizationDto.LogoURLSl = fileSl;
            var orgRequestold = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(organizationDto.Id);
            if(orgRequestold !=null && organizationDto.IsApprove == true)
            { 
            if (orgRequestold?.AdminPassword != organizationDto.AdminPassword)
            {
                if (string.IsNullOrEmpty(organizationDto.AdminPassword))
                {
                    organizationDto.AdminPassword = orgRequestold?.AdminPassword;
                }
                else
                {
                    organizationDto.AdminPassword = EncryptProvider.AESEncrypt(organizationDto.AdminPassword, Constants.EncryptDecryptKey);

                }
            }
            }
            else
            {
                organizationDto.AdminPassword = EncryptProvider.AESEncrypt(organizationDto.AdminPassword, Constants.EncryptDecryptKey);
            }
            if (organizationDto.IsApprove == null)
            {
                return await AddOrganizationNewRequest(organizationDto);
            }
            else
            {
                if (await UnitOfWork.GetRepository<Organization>().IsExistAsync(organizationDto))
                {
                    return OrganizationLocalize["OrganizationService_IsExists"];
                }
                var organization = Mapper.Map<OrganizationDto, Organization>(organizationDto);
                organization.Encryption = EncryptOrganization(organization);
                await UnitOfWork.GetRepository<Organization>().AddAsync(organization);
                if (orgRequestold != null && organizationDto.IsApprove == true)
                {
                    return await UpdateOrganizationRequest(organizationDto);
                }
                await UnitOfWork.SaveChangesAsync();

                return null;
            }
          
        }

        private async Task<string> AddOrganizationNewRequest(OrganizationDto organizationDto)
        {
            try
            {
                if (await UnitOfWork.GetRepository<OrganizationRequest>().IsExistAsync(organizationDto))
                {
                    return OrganizationLocalize["OrganizationRequest_IsExists"];
                }
                var organizationRequest = Mapper.Map<OrganizationDto, OrganizationRequest>(organizationDto);
                organizationRequest.Encryption = EncryptOrganizationRequest(organizationRequest);
                await UnitOfWork.GetRepository<OrganizationRequest>().AddAsync(organizationRequest);
                if(organizationDto.IsApprove == null)
                {
                    await SendEmailToAdmin();
                }
                await UnitOfWork.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {

                throw;
            }
            
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
                    await _sendEmail.Send(item, "Please Go to license website to accept  Organization Request", "New Organization Request");
                }
            }
        }
        private async Task SendEmailToUser(Guid? userId,string message)
        {
            var userInfo = (await UnitOfWork.GetRepository<User>().FirstOrDefaultSelectAsync(a => a.Id == userId, a => new { a.Email },isOrganization: false)).Email;
            if (userInfo != null)
            {                
               await _sendEmail.Send(userInfo, message, "New Organization Request");               
            }
        }
        public async Task<string> Update(OrganizationDto organizationDto)
        {
            string? Password = organizationDto.AdminPassword;
            string fileFl = null;
            if (!string.IsNullOrWhiteSpace(organizationDto.LogoURLFl))
            {
                fileFl = _imageConfig.SaveBase64(organizationDto.LogoURLFl, $"Organization-{Guid.NewGuid()}", FolderName, organizationDto.Id);
            }

            string fileSl = null;
            if (!string.IsNullOrWhiteSpace(organizationDto.LogoURLSl))
            {
                fileSl = _imageConfig.SaveBase64(organizationDto.LogoURLSl, $"Organization-{Guid.NewGuid()}", FolderName, organizationDto.Id);
            }         
            if (await UnitOfWork.GetRepository<Organization>().IsExistAsync(organizationDto))
            {
                return OrganizationLocalize["OrganizationService_IsExists"];
            }
            if (organizationDto.IsApprove == null)
            {
                return await UpdateOrganizationRequest(organizationDto);

            }
            var organizationOld = await UnitOfWork.GetRepository<Organization>().GetAsync(organizationDto.Id );

            if (organizationOld?.AdminPassword != organizationDto.AdminPassword)
            {
                organizationDto.AdminPassword = string.IsNullOrEmpty(organizationDto.AdminPassword) ? organizationOld?.AdminPassword : EncryptProvider.AESEncrypt(organizationDto.AdminPassword, Constants.EncryptDecryptKey);
            }
            if (!string.IsNullOrWhiteSpace(organizationOld.LogoURLFl))
            {
               _imageConfig.RemoveFile(organizationOld.LogoURLFl, FolderName,organizationDto.Id);
            }
            if (!string.IsNullOrWhiteSpace(organizationOld.LogoURLSl))
            {
                _imageConfig.RemoveFile(organizationOld.LogoURLSl, FolderName, organizationDto.Id);
            }
            organizationDto.LogoURLFl = fileFl != null ? fileFl : organizationOld.LogoURLFl;
            organizationDto.LogoURLSl = fileSl != null ? fileSl : organizationOld.LogoURLSl;
            var organizationNew = Mapper.Map<OrganizationDto, Organization>(organizationDto);
            var tt = EncryptOrganization(organizationNew);
            organizationDto.Encryption = tt;
            if (!organizationDto.IsPromise   && !string.IsNullOrWhiteSpace(Password))
            {
                await CreateAdminUserNotPrimse(organizationDto.AdminPassword, organizationOld.Id);
            }            
            Mapper.Map(organizationDto, organizationOld);
            await UnitOfWork.SaveChangesAsync();
            var organizationRequest = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(organizationDto.Id);
            if(organizationRequest != null && organizationDto.IsApprove == true)
            {
                return await UpdateOrganizationRequest(organizationDto);
            }
           
            return null;
        }

        private async Task<string> UpdateOrganizationRequest(OrganizationDto organizationDto)
        {           
            var organizationRequestOld = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(organizationDto.Id);
            if (organizationRequestOld == null)
            {
                var organizationRequest = Mapper.Map<OrganizationDto, OrganizationRequest>(organizationDto);
                organizationRequest.Encryption = EncryptOrganizationRequest(organizationRequest);
                await UnitOfWork.GetRepository<OrganizationRequest>().AddAsync(organizationRequest);
                if (organizationDto.IsApprove == null)
                {
                    await SendEmailToAdmin();
                }               
                await UnitOfWork.SaveChangesAsync();
            }
            else
            {
                if (organizationRequestOld?.AdminPassword != organizationDto.AdminPassword)
                {
                    organizationDto.AdminPassword = string.IsNullOrEmpty(organizationDto.AdminPassword) ? organizationRequestOld?.AdminPassword : EncryptProvider.AESEncrypt(organizationDto.AdminPassword, Constants.EncryptDecryptKey);
                }
                var organizationNewRequest = Mapper.Map<OrganizationDto, OrganizationRequest>(organizationDto);

                organizationDto.Encryption = EncryptOrganizationRequest(organizationNewRequest);
                Mapper.Map(organizationDto, organizationRequestOld);
                if (organizationDto.IsApprove == null)
                {
                    await SendEmailToAdmin();
                }
                await UnitOfWork.SaveChangesAsync();
            }
            if (organizationDto.IsApprove == true)
            {
                var message = "Your Organization New Request Approved";

                await SendEmailToUser(organizationRequestOld.CreatedBy, message);
            }
            return null;

        }

        public async Task<string> ApproveOrganizationRequest(OrganizationDto organizationDto)
        {
            if(organizationDto.IsApprove == true)
            {
                organizationDto.IsApprove = true;
                var organizationOld = await UnitOfWork.GetRepository<Organization>().GetAsync(organizationDto.Id);
                if(organizationOld == null)               
                    return await Add(organizationDto);               
                else
                    return await Update(organizationDto);

            }
            else
            {
                var organizationRequestOld = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(organizationDto.Id);
                var organizationNewRequest = Mapper.Map<OrganizationDto, OrganizationRequest>(organizationDto);
                organizationDto.Encryption = EncryptOrganizationRequest(organizationNewRequest);
                organizationNewRequest.IsApprove = false;
                Mapper.Map(organizationDto, organizationRequestOld);
                await UnitOfWork.SaveChangesAsync();               
                var message = "Your Organization New Request Rejected";
                await SendEmailToUser(organizationRequestOld.CreatedBy, message);          
                return null;
          
            }
        }
        public async Task<OrganizationDto> GetCode(string code)
        {
            try
            {

            
            var organization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Code == code, include: source => source.Include(a => a.OrganizationSettings).ThenInclude(a => a.ActiveDirectoryKey));
            var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
            if (organizationDto == null) return null;
            organizationDto.LogoURLFl = _imageConfig.ConvertToBase64String(organizationDto.LogoURLFl, FolderName, organizationDto.Id);
            organizationDto.LogoURLSl = _imageConfig.ConvertToBase64String(organizationDto.LogoURLSl, FolderName, organizationDto.Id);

            return organizationDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Organization> CheckCode(string code)
        {
            var organization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Code == code);
            if (organization == null)
            {
                return null;
            }
            return organization;
        }
        public async Task<OrganizationWithHostsDto> GetOrganizationWithHostsByCode(string code)
        {
            var organization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Code == code, include: r => r.Include(a => a.OrganizationHosts));
            var organizationDto = Mapper.Map<Organization, OrganizationWithHostsDto>(organization);
            if (organizationDto == null) return null;
            organizationDto.LogoURLFl = _imageConfig.ConvertToBase64String(organizationDto.LogoURLFl, FolderName, organizationDto.Id);
            organizationDto.LogoURLSl = _imageConfig.ConvertToBase64String(organizationDto.LogoURLSl, FolderName, organizationDto.Id);
            return organizationDto;
        }
        public async Task<OrganizationDto> GetByOrganizationId()
        {
            var id = _sessionStorage.OrganizationId;
            var organization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == id);
            var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
            if (organizationDto == null) return null;
            organizationDto.LogoURLFl = _imageConfig.ConvertToBase64String(organization.LogoURLFl, FolderName, organization.Id);
            organizationDto.LogoURLSl = _imageConfig.ConvertToBase64String(organization.LogoURLSl, FolderName, organization.Id);
            organizationDto.LogoPath = _hostingEnvironment.ContentRootPath + '/' + FolderName + '/' + organization.LogoURLFl;
            return organizationDto;
        }
        public async Task<OrganizationCodeDto> GetOrganizationCode(Guid organizationId)
        {
            try
            {
                var organizationCode = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.Id == organizationId, q => new { q.Code, q.IsPromise });
                return new OrganizationCodeDto { Code = organizationCode?.Code, IsPromise = organizationCode?.IsPromise ?? false };
                //return (organizationCode?.Code, organizationCode?.IsPromise ?? false);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
        public async Task Delete(Guid id)
        {
            var organizationDto = await UnitOfWork.GetRepository<Organization>().GetAsync(id);
            if (organizationDto != null)
            {
                await UnitOfWork.GetRepository<Organization>().RemoveAsync(organizationDto);
                await UnitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteOrganizationRequest(Guid id)
        {
            var organizationDto = await UnitOfWork.GetRepository<OrganizationRequest>().GetAsync(id);
            if (organizationDto != null)
            {
                await UnitOfWork.GetRepository<OrganizationRequest>().RemoveAsync(organizationDto);
                await UnitOfWork.SaveChangesAsync();
            }
        }
        public async Task<PagedListDto<OrganizationDto>> GetAllOrganizationsPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto)
        {
            var predicate = Helper.GetPredicate<Organization, OrganizationFilterDto>(filteringDto);
            var (list, count) = await UnitOfWork.GetRepository<Organization>().GetPagedListAsync(predicate, pagingSortingDto, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.Package));
            var listDto = Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationDto>>(list);
            return new PagedListDto<OrganizationDto> { List = listDto, Count = count };
        }
        
        public async Task<Stream> GenerateJsonFile(string code)
        {

            const string folderName = "LicenseInfo";
            var organization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(r => r.Code == code, source => source.Include(r => r.OrganizationLicenses).ThenInclude(r => r.OrganizationLicencesModules));
            var organizationJsone = JsonConvert.SerializeObject(Mapper.Map<OrganizationJsonFileDto>(organization));
            var organizationJson = JsonConvert.SerializeObject(Mapper.Map<OrganizationJsonFileDto>(organization));
            File.WriteAllText($"{folderName}/{JsonFilePath}", organizationJson);
            var stream = _imageConfig.ConvertToStream(JsonFilePath, folderName, organization.Id);
            return stream;
        }

        public Stream DownLoadOrganizationServer(string code, bool hash)
        {
            var folderName = "ServerLicense";
            var jsonFilePath = hash ? code + "-ServerInfo-License.json" : code + "-ServerInfo.json";
            var stream = _imageConfig.ConvertToStream(jsonFilePath, folderName);
            return stream;
        }

        public async Task<(Organization, string)> UpdateOrganizationFromJsonFile(IFormFile file)
        {
            var path = _imageConfig.SaveFile(file, "Organization", null, $"{_sessionStorage.OrganizationId}-{file.FileName}", out _);
            var json = File.ReadAllText(path);
            var jsonObj = JObject.Parse(json);
            var organization = jsonObj.ToObject<Organization>();
            var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
            var oldOrganization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));
            var isAuthentication = await _httpRest.SendRequest<bool>($"Users/IsAuthentication/{organization.Code}", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
            //if (!isAuthentication)
            //{
            //    return (null, "Server not authenticated");
            //}

            // if organization already exists, update it
            var oldOrganizationLicences = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(q => q.OrganizationId == oldOrganization.Id, source => source.Include(a => a.OrganizationLicencesModules))).ToList();
            if (oldOrganizationLicences.Any())
            {
                await UnitOfWork.GetRepository<OrganizationLicense>().RemoveRangeAsync(oldOrganizationLicences);
                await UnitOfWork.SaveChangesAsync();
            }
            if (organizationDto.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid())
            {
                var oldOrganizationRemove = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise && q.OrganizationTypeId == null);
                if (oldOrganizationRemove != null)
                {
                    await UnitOfWork.GetRepository<Organization>().RemovePhysicalAsync(oldOrganizationRemove);
                    await UnitOfWork.SaveChangesAsync();
                }
                var organizationNew = new Organization();
                var organizationIsExist = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == organizationDto.Id, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));
                if (organizationIsExist == null)
                {
                    organizationNew = Mapper.Map<OrganizationDto, Organization>(organizationDto);
                    var organizationLicense = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(organizationLicense);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.GetRepository<Organization>().AddAsync(organizationNew);
                    await UnitOfWork.SaveChangesAsync();

                }

                // add user admin with AdminPassword
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
                {
                    await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                    await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
                }
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
                {
                    var adminUserData = new AdminUserData()
                    {
                        OrganizationId = organizationNew.Id,
                        AdminPassword = organizationNew.AdminPassword
                    };
                    await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

                }
                return (organization, null);

            }
            else
            {
                organizationDto.Id = oldOrganization.Id;
                organizationDto.LogoURLFl = oldOrganization.LogoURLFl;
                organizationDto.LogoURLSl = oldOrganization.LogoURLSl;
                var org = Mapper.Map(organizationDto, oldOrganization);
                var orgSetting = org.OrganizationLicenses.Select(q =>
                {
                    q.OrganizationId = org.Id;
                    return q;
                });
                await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(orgSetting);
                org.OrganizationLicenses = null;
                try
                {
                    await UnitOfWork.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                // add user admin with AdminPassword
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
                {
                    await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                    await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
                }
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
                {
                    var adminUserData = new AdminUserData()
                    {
                        OrganizationId = org.Id,
                        AdminPassword = org.AdminPassword
                    };
                    await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

                }
                return (organization, null);
            }
        }

        public async Task<(Organization, string)> UpdateOrganizationFromJsonFileLicence(JObject organizationobject)
        {
            var organization = organizationobject.ToObject<Organization>();
            var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
            var oldOrganization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));

            var isAuthentication = await _httpRest.SendRequest<bool>($"Users/IsAuthentication/{organization.Code}", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
            //if (!isAuthentication)
            //{
            //    return (null, "Server not authenticated");
            //}
            // if organization already exists, update it
            var oldOrganizationLicences = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(q => q.OrganizationId == oldOrganization.Id, source => source.Include(a => a.OrganizationLicencesModules))).ToList();
            if (oldOrganizationLicences.Any())
            {
                await UnitOfWork.GetRepository<OrganizationLicense>().RemoveRangeAsync(oldOrganizationLicences);
                await UnitOfWork.SaveChangesAsync();
            }
            if (organizationDto.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid())
            {
                var oldOrganizationRemove = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise && q.OrganizationTypeId == null);
                if (oldOrganizationRemove != null)
                {
                    await UnitOfWork.GetRepository<Organization>().RemovePhysicalAsync(oldOrganizationRemove);
                    await UnitOfWork.SaveChangesAsync();
                }
                var organizationNew = new Organization();
                var organizationIsExist = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == organizationDto.Id, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));
                if (organizationIsExist == null)
                {
                    organizationNew = Mapper.Map<OrganizationDto, Organization>(organizationDto);
                    var organizationLicense = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(organizationLicense);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.GetRepository<Organization>().AddAsync(organizationNew);
                    await UnitOfWork.SaveChangesAsync();

                }

                // add user admin with AdminPassword
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
                {
                    await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                    await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
                }
                if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
                {
                    var adminUserData = new AdminUserData()
                    {
                        OrganizationId = organizationNew.Id,
                        AdminPassword = organizationNew.AdminPassword
                    };
                    await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

                }
                return (organization, null);

            }
            else
            {                      
            organizationDto.Id = oldOrganization.Id;           
            organizationDto.LogoURLFl = oldOrganization.LogoURLFl;
            organizationDto.LogoURLSl = oldOrganization.LogoURLSl;
            var org = Mapper.Map(organizationDto, oldOrganization);
            var orgSetting = org.OrganizationLicenses.Select(q =>
            {
                q.OrganizationId = org.Id;
                return q;
            });
           
            await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(orgSetting);
            org.OrganizationLicenses = null;            
            try
            {

                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // add user admin with AdminPassword
            if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
            {
                await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
            }
            if (organizationDto.IsPromise && organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
            {
                var adminUserData = new AdminUserData()
                {
                    OrganizationId = org.Id,
                    AdminPassword = org.AdminPassword
                };
                await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);
            }           
            return (organization, null);
            }
        }
        //remove mubarak     
        private async Task<string> CreateAdminUser(string adminPassword, Guid? id)
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
            //var tt = await _serviceCommunication.GetObjectPridicate<string, AdminUserDto>("Users/AddUserAdmin", user, _sessionStorage.Token);
            var tt = await _httpRest.SendRequest<string>("Users/AddUserAdmin", Method.POST, CommuncationDecision.TamsUrl, _sessionStorage.Token, user);

            return tt;
        }

        private async Task<string> CreateAdminUserNotPrimse(string adminPassword, Guid? id)
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
            //var tt = await _serviceCommunication.GetObjectPridicate<string, AdminUserDto>("Users/AddUserAdmin", user, _sessionStorage.Token);
            var tt = await _httpRest.SendRequest<string>("Users/AddAdminUserIncludeOrg", Method.POST, CommuncationDecision.TamsUrl, _sessionStorage.Token, user);

            return tt;
        }
        public Stream UploadServerLicenseFromJsonFile(IFormFile file, string organizationCode)
        {
            const string folderName = "ServerLicense";
            _imageConfig.RemoveFile($"{organizationCode}-ServerInfo.json", folderName);
            var path = _imageConfig.SaveFile(file, folderName, null, $"{organizationCode}-ServerInfo.json", out var newFileName);
            var fileNameSplit = newFileName.Split('.');
            var copyFileName = $"{fileNameSplit[0]}-License.json";
            var destFileName = $"{_imageConfig.ServerPath(folderName)}/{copyFileName}";
            File.Copy(path, destFileName);
            var json = File.ReadAllText(path);
            var jsonObj = JObject.Parse(json);
            var serverLicense = jsonObj.ToObject<ServerLicenseDto>();
            var newServerLicense = new ServerLicenseDto() { MacAddress = new List<string>(), Processor = new List<string>(), MotherBoard = new List<string>() };
            foreach (var item in serverLicense.MacAddress) newServerLicense.MacAddress.Add((organizationCode + item).Encrypt());
            foreach (var item in serverLicense.Processor) newServerLicense.Processor.Add((organizationCode + item).Encrypt());
            foreach (var item in serverLicense.MotherBoard) newServerLicense.MotherBoard.Add((organizationCode + item).Encrypt());
            var license = JsonConvert.SerializeObject(newServerLicense);
            using (var sw = File.CreateText(destFileName)) sw.Write(license);
            var stream = _imageConfig.ConvertToStream(copyFileName, folderName);
            // _imageConfig.RemoveFile(copyFileName, folderName);
            return stream;
        }

        public Stream UpdateAdminPasswordFile(string newPassword)
        {
            const string folderName = "ServerLicense";
            var copyFileName = "serverUpdateData.json";
            var destFileName = $"{_imageConfig.ServerPath(folderName)}/{copyFileName}";
            var passHash = HashPassword(newPassword);
            var newServerLicense = new PasswordHashDto() { PasswordHash = passHash };
            var license = JsonConvert.SerializeObject(newServerLicense);
            using (var sw = File.CreateText(destFileName)) sw.Write(license);
            var stream = _imageConfig.ConvertToStream(copyFileName, folderName);
            return stream;
        }


        public async Task<bool> VerifyEncryption(Guid id)
        {
            var organization = await UnitOfWork.GetRepository<Organization>().GetAsync(id);
            var organizationEncrypt = string.Concat(organization.Code, organization.RegistrationEmail, organization.PrimaryLanguage, organization.SecondaryLanguage, organization.IsPromise);
            var encryption = EncryptProvider.AESDecrypt(organization.Encryption, Constants.EncryptDecryptKey);
            return organizationEncrypt == encryption;
        }

        private static string EncryptOrganization(Organization organization)
        {
            var organizationEncrypt = string.Concat(organization.Code, organization.RegistrationEmail, organization.PrimaryLanguage, organization.SecondaryLanguage, organization.IsPromise);
            return EncryptProvider.AESEncrypt(organizationEncrypt, Constants.EncryptDecryptKey);
        }
        private static string EncryptOrganizationRequest(OrganizationRequest organization)
        {
            var organizationEncrypt = string.Concat(organization.Code, organization.RegistrationEmail, organization.PrimaryLanguage, organization.SecondaryLanguage, organization.IsPromise);
            return EncryptProvider.AESEncrypt(organizationEncrypt, Constants.EncryptDecryptKey);
        }

        private static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public async Task<IEnumerable<TimeZonesDto>> GetTimeZones()
        {
            var list = await UnitOfWork.GetRepository<TimeZones>().GetAllAsync();
            return Mapper.Map<IEnumerable<TimeZonesDto>>(list);
        }
        public async Task<List<SettingActualWorkingDto>> GetSettingActualWorking(Guid organizationId)
        {
            var list = (await UnitOfWork.GetRepository<SettingActualWorking>().FindAsync(r => r.OrganizationId == organizationId)).ToList();
            if (list.Count == 0)
            {
                return new List<SettingActualWorkingDto>();
            }
            return Mapper.Map<List<SettingActualWorking>, List<SettingActualWorkingDto>>(list);
        }

        public async Task<List<SettingActualWorkingDto>> GetSettingActualWorkingAnonymous()
        {
            var list = (await UnitOfWork.GetRepository<SettingActualWorking>().GetAllAsync(isOrganization:false)).ToList();
            if (list.Count() == 0)
            {
                return new List<SettingActualWorkingDto>();
            }
            return Mapper.Map<List<SettingActualWorking>, List<SettingActualWorkingDto>>(list);
        }

        public async Task<string> AddSettingActualWorking(List<SettingActualWorkingDto> settingActualWorkingDto)
        {
            var settingActualWorkingOld = (await UnitOfWork.GetRepository<SettingActualWorking>().GetAllAsync(isOrganization: false)).ToList();
            if (settingActualWorkingOld.Any())
            {
                await UnitOfWork.GetRepository<SettingActualWorking>().RemoveRangeAsync(settingActualWorkingOld);
            }
            var settingActualWorking = Mapper.Map<List<SettingActualWorkingDto>, List<SettingActualWorking>>(settingActualWorkingDto);
            await UnitOfWork.GetRepository<SettingActualWorking>().AddRangeAsync(settingActualWorking);
            await UnitOfWork.SaveChangesAsync();
            return null;
        }
        public async Task<bool> GetOrganizationIsShowWordAndExcel(Guid? organizaionId)
        {
            var isShowWordAndExcel = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.OrganizationId == organizaionId.Value, q => new { q.IsShowWordAndExcel });
            return isShowWordAndExcel?.IsShowWordAndExcel ?? false;
        }
        public async Task<IEnumerable<Guid>> GetOrganizationIdsList()
        {
            var list = (await UnitOfWork.GetRepository<Organization>().FindSelectAsync(r => !r.IsDelete, r => new { r.Id })).Select(r=>r.Id).ToList();
            return list;
        }
        public List<DropdownDto> GetLogTypeMobileForOrganization()
        {
            
            var enums = Enum.GetValues(typeof(LogTypeMobileForOrganizationEnum));
            var res = (from object enumItem in enums
                       select new DropdownDto()
                       {
                           Id = ((LogTypeMobileForOrganizationEnum)enumItem).GetEnumGuid(),
                           NameFl =  ((LogTypeMobileForOrganizationEnum)enumItem).GetName(true)[0] ,
                           NameSl = ((LogTypeMobileForOrganizationEnum)enumItem).GetName(true)[1] ,
                       }).ToList();
            var resDto = Mapper.Map<List<DropdownDto>>(res);
            return resDto;
        }
        public async Task<string> GetOrganizationTimeZone(Guid id)
        {
            var organization = (await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(a=>a.Id == id ,include: source => source.Include(a => a.TimeZones)))?.TimeZones?.TimeZone;
            return organization != null ? organization : "Arab Standard Time";
        }

        public async Task<bool> GetOrganizationIsShowActualWorkingDay(Guid? organizaionId)
        {
            var isShowWordAndExcel = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.OrganizationId == organizaionId.Value,select: q => new { q.IsShowActualWorkingDay },isOrganization:false);
            return isShowWordAndExcel?.IsShowActualWorkingDay ?? false;
        }

        public async Task<bool> GetOrganizationIsAllowPasswordConstraints(Guid? organizaionId)
        {
            var allowPassword = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.OrganizationId == organizaionId.Value, q => new { q.AllowPasswordConstraints });
            return allowPassword?.AllowPasswordConstraints ?? false;
        } 
        public async Task<bool> GetOrganizationIsUseOneDeviceForUserInquiry(Guid? organizaionId)
        {
            var useOneDeviceForUserInquiry = await UnitOfWork.GetRepository<OrganizationSetting>().FirstOrDefaultSelectAsync(q => !q.IsDelete && q.OrganizationId == organizaionId.Value, q => new { q.UseOneDeviceForUserInquiry });
            return useOneDeviceForUserInquiry?.UseOneDeviceForUserInquiry ?? false;
        }

        public  List<DropdownDto> GetAllOrganizationTypeEnum()
        {
            var enums = Enum.GetValues(typeof(OrganizationTypeEnum));
            var res = (from object enumItem in enums
                       select new DropdownDto()
                       {
                           Id = ((OrganizationTypeEnum)enumItem).GetEnumGuid(),
                           NameFl = ((OrganizationTypeEnum)enumItem).GetName(true)[Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? 1 : 0],
                           NameSl = ((OrganizationTypeEnum)enumItem).GetName(true)[Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? 0 : 1],
                       }).ToList();
            return res;
        }
        public async Task<IEnumerable<DropdownDto>> GetAllOrganizaionCloud()
        {
            var list = await UnitOfWork.GetRepository<Organization>().FindAsync(a=>a.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid());
            var organizationDto = Mapper.Map<IEnumerable<Organization>, IEnumerable<DropdownDto>>(list);
            return organizationDto;
        }
        public async Task<IEnumerable<DropdownDto>> GetAllOrganizaionRequestCloud()
        {
            var list = await UnitOfWork.GetRepository<OrganizationRequest>().FindAsync(a => a.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid() && a.IsApprove == true);
            var organizationDto = Mapper.Map<IEnumerable<OrganizationRequest>, IEnumerable<DropdownDto>>(list);
            return organizationDto;
        }
        public async Task<PagedListDto<OrganizationDto>> GetAllOrganizationCrossCloudPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto)
        {
            //var predicate = PredicateBuilder.New<Organization>(true);
            var predicate = Helper.GetPredicate<Organization, OrganizationFilterDto>(filteringDto);
            Organization organizationWithCode = null;            
            organizationWithCode = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(a => a.Id == _sessionStorage.OrganizationId && a.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()), source => source.Include(a => a.OrganizationLicenses.Where(ol => ol.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())));
            predicate = predicate.And(a => a.OrganizationId == organizationWithCode.Id);
            predicate = predicate.And(org => org.OrganizationLicenses.Any(license => license.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()));

            var (list, count) = await UnitOfWork.GetRepository<Organization>().GetPagedListAsync(predicate, pagingSortingDto, source => source.Include(a => a.OrganizationLicenses.Where(ol => ol.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid())));
            list = list.Append(organizationWithCode);
            count++;
            var listDto = Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationDto>>(list);
            return new PagedListDto<OrganizationDto> { List = listDto, Count = count };
        }
        public async Task<PagedListDto<OrganizationDto>> GetAllOrganizationCrossCloudForAumPaged(OrganizationFilterDto filteringDto, PagingSortingDto pagingSortingDto)
        {
            try
            {
                var predicate = Helper.GetPredicate<Organization, OrganizationFilterDto>(filteringDto);
                Organization organizationWithCode = null;
                organizationWithCode = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(a => a.Id == filteringDto.OrganizationId && a.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()), source => source.Include(a => a.OrganizationLicenses.Where(ol => ol.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())), isOrganization: false);
                if (organizationWithCode != null)
                {
                    predicate = predicate.And(org => org.OrganizationId == organizationWithCode.Id);
                }
                predicate = predicate.And(org => org.OrganizationLicenses.Any(license => license.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()));
                var (list, count) = await UnitOfWork.GetRepository<Organization>().GetPagedListAsync(predicate, pagingSortingDto, source => source.Include(a => a.OrganizationLicenses.Where(ol => ol.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid())), isOrganization: false);                        
                list = list.Append(organizationWithCode);
                count++;               
                var listDto = Mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationDto>>(list);            
                return new PagedListDto<OrganizationDto> { List = listDto, Count = count };
            }
            catch (Exception e)
            {

                throw;
            }
      
        }
        public async Task<bool> IsOrganizaionCrossCloud()
        {
            var org = await UnitOfWork.GetRepository<Organization>().IsExistAnyAsync(a => a.Id == _sessionStorage.OrganizationId &&  a.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid());            
            return org;
        }
        public async Task<bool> IsOrganizaionCrossCloudClient()
        {
            var org = await UnitOfWork.GetRepository<Organization>().IsExistAnyAsync(a => a.Id == _sessionStorage.OrganizationId && a.OrganizationTypeId == OrganizationTypeEnum.CrossCloudClient.GetEnumGuid());
            return org;
        }

        public async Task<bool> IsOrganizaionCrossCloudForAum(Guid? orgId)
        {
            var org = await UnitOfWork.GetRepository<Organization>().IsExistAnyAsync(a => a.Id == orgId && a.OrganizationTypeId == OrganizationTypeEnum.CrossCloud.GetEnumGuid(),isOrganization:false);
            return org;
        }
        public async Task<bool> IsOrganizaionCrossCloudClientForAum(Guid? orgId)
        {
            var org = await UnitOfWork.GetRepository<Organization>().IsExistAnyAsync(a => a.Id == orgId && a.OrganizationTypeId == OrganizationTypeEnum.CrossCloudClient.GetEnumGuid(), isOrganization: false);
            return org;
        }
        public async Task<(Organization, string)> UpdateOrganizationCrossCloudFromJsonFile(JObject organizationobject)
        {
            try
            {
                var organization = organizationobject.ToObject<Organization>();
                var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
                var oldOrganization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise && q.OrganizationTypeId == null, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));

                // if organization already exists, update it
                var oldOrganizationLicences = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(q => oldOrganization !=null ? q.OrganizationId == oldOrganization.Id : q.OrganizationId == organizationDto.Id, source => source.Include(a => a.OrganizationLicencesModules))).ToList();
                if (oldOrganizationLicences.Any())
                {
                    await UnitOfWork.GetRepository<OrganizationLicense>().RemoveRangeAsync(oldOrganizationLicences);
                    await UnitOfWork.SaveChangesAsync();
                }
                if (oldOrganization != null)
                {
                    await UnitOfWork.GetRepository<Organization>().RemovePhysicalAsync(oldOrganization);
                    await UnitOfWork.SaveChangesAsync();
                }
                var organizationNew = new Organization();
                var organizationIsExist = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == organizationDto.Id, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));
                if (organizationIsExist == null)
                {
                    organizationNew = Mapper.Map<OrganizationDto, Organization>(organizationDto);
                    var organizationLicense = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(organizationLicense);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.GetRepository<Organization>().AddAsync(organizationNew);
                    await UnitOfWork.SaveChangesAsync();

                }
                else
                {
                    organizationDto.Id = organizationIsExist.Id;
                    organizationDto.LogoURLFl = organizationIsExist.LogoURLFl;
                    organizationDto.LogoURLSl = organizationIsExist.LogoURLSl;
                    organizationNew = Mapper.Map(organizationDto, organizationIsExist);
                    var orgSetting = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(orgSetting);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.SaveChangesAsync();
                }



                // add user admin with AdminPassword
                if (organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
                {
                    await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                    await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
                }
                if (organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
                {
                    var adminUserData = new AdminUserData()
                    {
                        OrganizationId = organizationNew.Id,
                        AdminPassword = organizationNew.AdminPassword
                    };
                    await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

                }
                return (organization, null);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public async Task<(Organization, string)> UpdateOrganizationCrossCloudFromJsonFile(IFormFile file)
        {
            try
            {
                var path = _imageConfig.SaveFile(file, "Organization", null, $"{_sessionStorage.OrganizationId}-{file.FileName}", out _);
                var json = File.ReadAllText(path);
                var jsonObj = JObject.Parse(json);
                var organization = jsonObj.ToObject<Organization>();
                var organizationDto = Mapper.Map<Organization, OrganizationDto>(organization);
                var oldOrganization = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.IsPromise && q.OrganizationTypeId == null, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));

                // if organization already exists, update it
                var oldOrganizationLicences = (await UnitOfWork.GetRepository<OrganizationLicense>().FindAsync(q => oldOrganization != null ? q.OrganizationId == oldOrganization.Id : q.OrganizationId == organizationDto.Id, source => source.Include(a => a.OrganizationLicencesModules))).ToList();
                if (oldOrganizationLicences.Any())
                {
                    await UnitOfWork.GetRepository<OrganizationLicense>().RemoveRangeAsync(oldOrganizationLicences);
                    await UnitOfWork.SaveChangesAsync();
                }
                if (oldOrganization != null)
                {
                    await UnitOfWork.GetRepository<Organization>().RemovePhysicalAsync(oldOrganization);
                    await UnitOfWork.SaveChangesAsync();
                }
                var organizationNew = new Organization();
                var organizationIsExist = await UnitOfWork.GetRepository<Organization>().FirstOrDefaultAsync(q => q.Id == organizationDto.Id, source => source.Include(a => a.OrganizationLicenses).ThenInclude(a => a.OrganizationLicencesModules));
                if (organizationIsExist == null)
                {
                    organizationNew = Mapper.Map<OrganizationDto, Organization>(organizationDto);
                    var organizationLicense = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(organizationLicense);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.GetRepository<Organization>().AddAsync(organizationNew);
                    await UnitOfWork.SaveChangesAsync();

                }
                else
                {
                    organizationDto.Id = organizationIsExist.Id;
                    organizationDto.LogoURLFl = organizationIsExist.LogoURLFl;
                    organizationDto.LogoURLSl = organizationIsExist.LogoURLSl;
                    organizationNew = Mapper.Map(organizationDto, organizationIsExist);
                    var orgSetting = organizationNew.OrganizationLicenses.Select(q =>
                    {
                        q.OrganizationId = organizationNew.Id;
                        return q;
                    });
                    await UnitOfWork.GetRepository<OrganizationLicense>().AddRangeAsync(orgSetting);
                    organizationNew.OrganizationLicenses = null;
                    await UnitOfWork.SaveChangesAsync();
                }



                // add user admin with AdminPassword
                if (organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Tams.GetEnumGuid()))
                {
                    await CreateAdminUser(organizationDto.AdminPassword, organization.Id);
                    await _httpRest.SendRequestWithFullResponse("AbsencesRegulations/AddDefaultRegulations", Method.GET, CommuncationDecision.TamsUrl, _sessionStorage.Token);
                }
                if (organizationDto.OrganizationLicenses.Any(a => a.ApplicationId == ApplicationsEnum.Aum.GetEnumGuid()))
                {
                    var adminUserData = new AdminUserData()
                    {
                        OrganizationId = organizationNew.Id,
                        AdminPassword = organizationNew.AdminPassword
                    };
                    await _httpRest.SendRequest<string>("UserMangments/CreateAdminUserForAum", Method.POST, CommuncationDecision.AumUrl, obj: adminUserData);

                }
                return (organization, null);
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task<List<Guid>> GetAllOrganizationIds()
        {
            var orgIds = (await UnitOfWork.GetRepository<Organization>().FindSelectAsync(q => !q.IsDelete, q => new { q.Id })).Select(o => o.Id).ToList();
            return orgIds;
        }

        public async Task<AddOrganizationSettingDto> GetOrganizationSetting(Guid id) {
            var organization = await UnitOfWork.GetRepository<OrganizationSetting>()
                .FirstOrDefaultAsync(r => r.OrganizationId == id);
            if (organization != null) {
                return Mapper.Map<AddOrganizationSettingDto>(organization);
            }
            return null;
        }
    }
}
