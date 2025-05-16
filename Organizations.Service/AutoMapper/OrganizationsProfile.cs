using AutoMapper;
using Common.StandardInfrastructure;
using Organizations.Data.Entities;
using Organizations.Service.Dto;
using System.Linq;


namespace Organizations.Service.AutoMapper
{
    public class OrganizationsProfile : Profile
    {
        public OrganizationsProfile()
        {
            CreateMap<Organization, Organization>().ReverseMap();
            CreateMap<OrganizationDto, Organization>().ReverseMap()
                
               .ForMember(p => p.UsersCount, d => d.MapFrom(u => u.OrganizationLicenses[0].UsersCount))
               .ForMember(p => p.EmployeesCount, d => d.MapFrom(u => u.OrganizationLicenses[0].EmployeesCount))
               .ForMember(p => p.ExpireDate, d => d.MapFrom(u => u.OrganizationLicenses[0].ExpireDate))

                .ForMember(p => p.PackageNameFl, d => d.MapFrom(u => u.OrganizationLicenses[0].Package.PackageNameFl))
                .ForMember(p => p.PackageNameSl, d => d.MapFrom(u => u.OrganizationLicenses[0].Package.PackageNameSl))
               .ForMember(p => p.IsPromise, d => d.MapFrom(u => u.IsPromise))
                .ForMember(p => p.AdminPassword, d => d.MapFrom(u => u.AdminPassword))
                .ForMember(p => p.IsActiveDirectory, d => d.MapFrom(u => u.OrganizationSettings !=null ? u.OrganizationSettings.FirstOrDefault().IsActiveDirectory : false))
                .ForMember(p => p.AdDomainName, d => d.MapFrom(u => u.OrganizationSettings != null ? u.OrganizationSettings.FirstOrDefault().AdDomainName : ""))
                 .ForMember(p => p.PrimaryKeyId, d => d.MapFrom(u => u.OrganizationSettings != null ? ( (u.OrganizationSettings != null && u.OrganizationSettings.FirstOrDefault().IsActiveDirectory == true) ? u.OrganizationSettings.FirstOrDefault().PrimaryKeyId : System.Guid.Empty) :System.Guid.Empty))
                .ForMember(p => p.ActiveDirectoryKeyNameEn, d => d.MapFrom(u => u.OrganizationSettings != null ? ( (u.OrganizationSettings != null && u.OrganizationSettings.FirstOrDefault().IsActiveDirectory == true) ? u.OrganizationSettings.FirstOrDefault().ActiveDirectoryKey.ActiveDirectoryKeyNameFl : ""): ""))
                .ForMember(p => p.ActiveDirectoryKeyNameAr, d => d.MapFrom(u => u.OrganizationSettings != null ? ( (u.OrganizationSettings != null && u.OrganizationSettings.FirstOrDefault().IsActiveDirectory == true) ? u.OrganizationSettings.FirstOrDefault().ActiveDirectoryKey.ActiveDirectoryKeyNameSl : ""): ""))
                .ForMember(dest => dest.OrganizationNameFl, opt => opt.MapFrom(src =>
                     Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? src.OrganizationNameSl : src.OrganizationNameFl))
                .ForMember(dest => dest.OrganizationNameSl, opt => opt.MapFrom(src =>
                     Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? src.OrganizationNameFl : src.OrganizationNameSl));
            CreateMap<OrganizationJsonFileDto, Organization>().ReverseMap();
            CreateMap<TimeZonesDto, TimeZones>().ReverseMap();
            CreateMap<OrganizationLicenseOriginalDto, OrganizationLicense>().ReverseMap();
            CreateMap<OrganizationLicencesModuleOriginalDto, OrganizationLicencesModule>().ReverseMap();

            CreateMap<OrganizationUnionOrgLicencesDto, OrganizationLicense>().ReverseMap()
                 .ForMember(dest => dest.OrganizationId, opts => opts.MapFrom(src => src.OrganizationId))

              .ForMember(dest => dest.OrganizationLicencesId, opts => opts.MapFrom(src => src.Id))
              .ForMember(p => p.PackageNameSl, d => d.MapFrom(
                           u => u.Package.PackageNameSl
                           ))
                           .ForMember(p => p.PackageNameFl, d => d.MapFrom(
                           u => u.Package.PackageNameFl
                           ))
                            .ForMember(p => p.OrganizationNameSl, d => d.MapFrom(
                           u => u.Organization.OrganizationNameSl
                           ))
                           .ForMember(p => p.OrganizationNameFl, d => d.MapFrom(
                           u => u.Organization.OrganizationNameFl
                           ))
                            .ForMember(p => p.Code, d => d.MapFrom(
                           u => u.Organization.Code
                           ))
                             .ForMember(p => p.NickName, d => d.MapFrom(
                           u => u.Organization.NickName
                           ))
                              .ForMember(p => p.RegistrationEmail, d => d.MapFrom(
                           u => u.Organization.RegistrationEmail
                           ))

                           .ForMember(p => p.AlternativeEmail, d => d.MapFrom(
                           u => u.Organization.AlternativeEmail
                           ))
                            .ForMember(p => p.IsPromise, d => d.MapFrom(
                           u => u.Organization.IsPromise
                           ))
                            .ForMember(p => p.ApplicationNameFl, d => d.MapFrom(
                           u => u.Application.ApplicationNameFl
                           ))
                             .ForMember(p => p.ApplicationNameSl, d => d.MapFrom(
                           u => u.Application.ApplicationNameSl
                           ));


            




            CreateMap<DropdownDto, Organization>().ReverseMap()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))               
              .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.OrganizationNameFl + "==>" + src.Code))
              .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.OrganizationNameSl + "==>" + src.Code));

            CreateMap<DropdownDto, OrganizationRequest>().ReverseMap()
              .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
             .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.OrganizationNameFl + "==>" + src.Code))
             .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.OrganizationNameSl + "==>" + src.Code));

            CreateMap<ActiveDirectoryKeyDto, ActiveDirectoryKey>().ReverseMap()
                .ForMember(dest => dest.ActiveDirectoryKeyNameFl, opts => opts.MapFrom<ActiveDirectoryKeyNameFl<ActiveDirectoryKeyDto>>()) 
                .ForMember(dest => dest.ActiveDirectoryKeyNameSl, opts => opts.MapFrom<ActiveDirectoryKeyNameSl<ActiveDirectoryKeyDto>>());


            CreateMap<DropdownDto, DropdownDto>().ReverseMap()
   .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                         .ForMember(dest => dest.NameFl, opt => opt.MapFrom(src =>
                     Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? src.NameSl : src.NameFl))
                .ForMember(dest => dest.NameSl, opt => opt.MapFrom(src =>
                     Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn ? src.NameFl : src.NameSl));
                //.ForMember(dest => dest.NameFl, opts => opts.MapFrom<DropDownNameFl<DropdownDto>>())
                //.ForMember(dest => dest.NameSl, opts => opts.MapFrom<DropDownNameSl<DropdownDto>>());

            CreateMap<ActiveDirectoryPrimaryKeyDto, ActiveDirectoryPrimaryKey>().ReverseMap()
            .ForMember(dest => dest.PrimaryKeyNameFl, opts => opts.MapFrom<PrimaryKeyNameFl<ActiveDirectoryPrimaryKeyDto>>())
            .ForMember(dest => dest.PrimaryKeyNameSl, opts => opts.MapFrom<PrimaryKeyNameSl<ActiveDirectoryPrimaryKeyDto>>());
            CreateMap<OrganizationLicencesModuleDto, OrganizationLicencesModule>().ReverseMap();

            CreateMap<OrganizationSettingDto, OrganizationSetting>().ReverseMap()
                .ForMember(p => p.RestDayId, d => d.MapFrom(u => u.RestDayId))
                .ForMember(p => p.WeekendDayId, d => d.MapFrom(u => u.WeekendDayId)).
                ForMember(p => p.IsReviewLogs, d => d.MapFrom(u => u.IsReviewLogs));

           

            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserMangmentDto, User>().ReverseMap();

            CreateMap<UserRoleDto, UserRoles>().ReverseMap()
               .ForMember(p => p.RoleNameFl, d => d.MapFrom(u => u.Roles == null ? null : u.Roles.RoleNameFl))
               .ForMember(p => p.RoleNameSl, d => d.MapFrom(u => u.Roles == null ? null : u.Roles.RoleNameSl));

           
            CreateMap<RoleDto, Roles>().ReverseMap();

            CreateMap<DropdownDto, Roles>().ReverseMap()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.RoleNameFl))
               .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.RoleNameSl));


            CreateMap<DropdownDto, Application>().ReverseMap()
             .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.ApplicationNameFl))
            .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.ApplicationNameSl));

            CreateMap<PackageModuleDto, Module>().ReverseMap()
             .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
             .ForMember(dest => dest.PackageId, opts => opts.MapFrom(src => src.PackageModules.Select(a=>a.PackageId)))
            .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.ModuleNameFl))
            .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.ModuleNameSl));
            CreateMap<PackageModuleCheckedDto, PackageModule>().ReverseMap()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ModuleId))
           .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.Module.ModuleNameFl))
           .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.Module.ModuleNameSl));

            CreateMap<PackageDto, Package>().ReverseMap()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
           .ForMember(dest => dest.NameFl, opts => opts.MapFrom(src => src.PackageNameFl))
           .ForMember(dest => dest.NameSl, opts => opts.MapFrom(src => src.PackageNameSl))
           .ForMember(dest => dest.ApplicationId, opts => opts.MapFrom(src => src.ApplicationId));

            CreateMap<OrganizationLicenseDto, OrganizationLicense>().ReverseMap()         
                           .ForMember(p => p.PackageNameSl, d => d.MapFrom(
                           u => u.Package.PackageNameSl
                           ))
                           .ForMember(p => p.PackageNameFl, d => d.MapFrom(
                           u => u.Package.PackageNameFl
                           ))
                            .ForMember(p => p.OrganizationNameSl, d => d.MapFrom(
                           u => u.Organization.OrganizationNameSl
                           ))
                            .ForMember(p => p.Code, d => d.MapFrom(
                           u => u.Organization.Code
                           ))
                           .ForMember(p => p.OrganizationNameFl, d => d.MapFrom(
                           u => u.Organization.OrganizationNameFl
                           ))
                            .ForMember(p => p.ApplicationNameFl, d => d.MapFrom(
                           u => u.Application.ApplicationNameFl
                           ))
                             .ForMember(p => p.ApplicationNameSl, d => d.MapFrom(
                           u => u.Application.ApplicationNameSl
                           ));

            CreateMap<OrganizationWithHostsDto, Organization>().ReverseMap()
                    .ForMember(p => p.PackageNameFl, d => d.MapFrom(u => u.OrganizationLicenses[0].Package.PackageNameFl))
                    .ForMember(p => p.PackageNameSl, d => d.MapFrom(u => u.OrganizationLicenses[0].Package.PackageNameSl))
                    .ForMember(p => p.HostApiUrl, d => d.MapFrom(u => u.OrganizationHosts.FirstOrDefault(a=>a.HostApiDataId == HostApiDataEnum.HOST_API.GetEnumGuid()).Value))
                    .ForMember(p => p.NotificationApiUrl, d => d.MapFrom(u => u.OrganizationHosts.FirstOrDefault(a => a.HostApiDataId == HostApiDataEnum.Notification_API.GetEnumGuid()).Value))
                    .ForMember(p => p.LogoutApiHubUrl, d => d.MapFrom(u => u.OrganizationHosts.FirstOrDefault(a => a.HostApiDataId == HostApiDataEnum.Logout_APIHub.GetEnumGuid()).Value))
                    .ForMember(p => p.LogsApiHubUrl, d => d.MapFrom(u => u.OrganizationHosts.FirstOrDefault(a => a.HostApiDataId == HostApiDataEnum.Logs_APIHub.GetEnumGuid()).Value))
                ;
            CreateMap<SettingActualWorkingDto, SettingActualWorking>().ReverseMap();
            CreateMap<HostApiDataDto, HostApiData>().ReverseMap();
            CreateMap<OrganizationHostApisDto, OrganizationHost>().ReverseMap();
            //request 
            CreateMap<OrganizationDto, OrganizationRequest>().ReverseMap();
            CreateMap<OrganizationLicenseDto, OrganizationLicenseRequest>().ReverseMap()
                         .ForMember(p => p.PackageNameSl, d => d.MapFrom(
                         u => u.Package.PackageNameSl
                         ))
                         .ForMember(p => p.PackageNameFl, d => d.MapFrom(
                         u => u.Package.PackageNameFl
                         ))
                          .ForMember(p => p.OrganizationNameSl, d => d.MapFrom(
                         u => u.Organization.OrganizationNameSl
                         ))
                          .ForMember(p => p.Code, d => d.MapFrom(
                         u => u.Organization.Code
                         ))
                         .ForMember(p => p.OrganizationNameFl, d => d.MapFrom(
                         u => u.Organization.OrganizationNameFl
                         ))
                          .ForMember(p => p.ApplicationNameFl, d => d.MapFrom(
                         u => u.Application.ApplicationNameFl
                         ))
                           .ForMember(p => p.ApplicationNameSl, d => d.MapFrom(
                         u => u.Application.ApplicationNameSl
                         ));
            CreateMap<OrganizationHostApisDto, OrganizationHostRequest>().ReverseMap();
            CreateMap<OrganizationLicencesModuleDto, OrganizationLicencesModuleRequest>().ReverseMap();
            CreateMap<AddOrganizationSettingDto, OrganizationSetting>().ReverseMap();
        }
    }
    public class ActiveDirectoryKeyNameFl<TDto> : IValueResolver<ActiveDirectoryKey, TDto, string>
    {
        public string Resolve(ActiveDirectoryKey source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.ActiveDirectoryKeyNameSl) : context.Mapper.Map<string>(source.ActiveDirectoryKeyNameFl);
        }
    }
    public class ActiveDirectoryKeyNameSl<TDto> : IValueResolver<ActiveDirectoryKey, TDto, string>
    {
        public string Resolve(ActiveDirectoryKey source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.ActiveDirectoryKeyNameFl) : context.Mapper.Map<string>(source.ActiveDirectoryKeyNameSl);
        }
    }


    public class DropDownNameFl<TDto> : IValueResolver<DropdownDto, TDto, string>
    {
        public string Resolve(DropdownDto source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.NameSl) : context.Mapper.Map<string>(source.NameFl);
        }
    }
    public class DropDownNameSl<TDto> : IValueResolver<DropdownDto, TDto, string>
    {
        public string Resolve(DropdownDto source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.NameFl) : context.Mapper.Map<string>(source.NameSl);
        }
    }


    public class PrimaryKeyNameFl<TDto> : IValueResolver<ActiveDirectoryPrimaryKey, TDto, string>
    {
        public string Resolve(ActiveDirectoryPrimaryKey source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.PrimaryKeyNameSl) : context.Mapper.Map<string>(source.PrimaryKeyNameFl);
        }
    }
    public class PrimaryKeyNameSl<TDto> : IValueResolver<ActiveDirectoryPrimaryKey, TDto, string>
    {
        public string Resolve(ActiveDirectoryPrimaryKey source, TDto destination, string destMember, ResolutionContext context)
        {
            var IsArabic = Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.Ar || Helper.ChangeProperty() == (int)Helper.ChangePropertyEnum.ArEn;
            return IsArabic ? context.Mapper.Map<string>(source.PrimaryKeyNameFl) : context.Mapper.Map<string>(source.PrimaryKeyNameSl);
        }
    }
}
