
using Common.StandardInfrastructure;
using Common.StandardInfrastructure.Utility;
using CryptoHelper;
using Organizations.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using NETCore.Encrypt;

// ReSharper disable StringLiteralTypo

namespace Organizations.Data.SeedData
{
    public class DataInitialize : IDataInitialize
    {
        //public IEnumerable<ActiveDirectoryKey> AddactiveDirectoryKey()
        //{
        //    var list = new List<ActiveDirectoryKey>();
        //    var activeDirectoryKeyEnums = Enum.GetValues(typeof(ActiveDirectoryKeyEnum));
        //    foreach (var enumItem in activeDirectoryKeyEnums)
        //    {
        //        list.Add(new ActiveDirectoryKey { Id = ((ActiveDirectoryKeyEnum)enumItem).GetEnumGuid(), ActiveDirectoryKeyNameFl = ((ActiveDirectoryKeyEnum)enumItem).GetName(true)[0], ActiveDirectoryKeyNameSl = ((ActiveDirectoryKeyEnum)enumItem).GetName(true)[1] });
        //    }
        //    return list;
        //}
        public IEnumerable<Roles> AddRoles()
        {
            var list = new List<Roles>();
            var rolesEnums = Enum.GetValues(typeof(RolesEnum));
            foreach (var enumItem in rolesEnums)
            {
                list.Add(new Roles { Id = ((RolesEnum)enumItem).GetEnumGuid(), RoleNameFl = ((RolesEnum)enumItem).GetName(true)[0], RoleNameSl = ((RolesEnum)enumItem).GetName(true)[1] });
            }
            return list;
        }

        public IEnumerable<HostApiData> AddHostApiDatas()
        {
            var list = new List<HostApiData>();
            var hostsEnums = Enum.GetValues(typeof(HostApiDataEnum));
            foreach (var enumItem in hostsEnums)
            {
                list.Add(new HostApiData { Id = ((HostApiDataEnum)enumItem).GetEnumGuid(), NameFl = ((HostApiDataEnum)enumItem).GetName(true)[0], NameSl = ((HostApiDataEnum)enumItem).GetName(true)[1] });
            }
            return list;
        }
        

        public IEnumerable<ActiveDirectoryPrimaryKey> AddactiveDirectoryPrimaryKey()
        {
            var list = new List<ActiveDirectoryPrimaryKey>();
            var activeDirectoryPrimaryKeyEnums = Enum.GetValues(typeof(ActiveDirectoryPrimaryKeyEnum));
            foreach (var enumItem in activeDirectoryPrimaryKeyEnums)
            {
                list.Add(new ActiveDirectoryPrimaryKey { Id = ((ActiveDirectoryPrimaryKeyEnum)enumItem).GetEnumGuid(), PrimaryKeyNameFl = ((ActiveDirectoryPrimaryKeyEnum)enumItem).GetName(true)[0], PrimaryKeyNameSl = ((ActiveDirectoryPrimaryKeyEnum)enumItem).GetName(true)[1] });
            }
            return list;
        }
        public IEnumerable<Application> Addapplication()
        {
            var list = new List<Application>();
            var applicationEnums = Enum.GetValues(typeof(ApplicationsEnum));
            foreach (var enumItem in applicationEnums)
            {
                list.Add(new Application { Id = ((ApplicationsEnum)enumItem).GetEnumGuid(), ApplicationNameFl = ((ApplicationsEnum)enumItem).GetName(true)[0], ApplicationNameSl = ((ApplicationsEnum)enumItem).GetName(true)[1] });
            }
            return list;
        }

        public IEnumerable<Screen> AddScreens()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/Menu.json");
            var screens = new List<Screen>();
            var data = Seeder<List<Screen>>.Seedit(dataText);
            var childerns = data.SelectMany(q => q.Childerns);
            screens.AddRange(data.Where(q => q.ParentId == null));
            screens.AddRange(childerns);
            screens = screens.Select(q => { q.Childerns = null; return q; }).ToList();
            return screens;
        }
        public IEnumerable<Module> AddModules()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/Module.json");
            var data = Seeder<List<Module>>.Seedit(dataText);
            return data;
        }
        public IEnumerable<Package> AddPackages()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/Package.json");
            var data = Seeder<List<Package>>.Seedit(dataText);
            return data;
        }
        public IEnumerable<PackageModule> AddPackageModules()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/PackageModule.json");
            var data = Seeder<List<PackageModule>>.Seedit(dataText);
            return data;
        }
        public IEnumerable<ModuleScreen> AddModuleScreens()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/ModuleScreen.json");
            var data = Seeder<List<ModuleScreen>>.Seedit(dataText);
            return data;
        }
        public IEnumerable<User> AddUsers()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/User.json");
            var data = Seeder<List<User>>.Seedit(dataText);
            data.ForEach(item =>
            {
                item.Password = Crypto.HashPassword(item.Password);
            });
            return data;
        }
        public IEnumerable<UserRoles> AddUserRoles()
        {
            var dataText = System.IO.File.ReadAllText(@"Seed/UserRoles.json");
            var data = Seeder<List<UserRoles>>.Seedit(dataText);
            return data;
        }
        public IEnumerable<Organization> AddOrganizations()
        {
            return new List<Organization>
            {
                new Organization
                {
                 Id = Guid.Parse("038efd7f-9bcf-42f4-3819-08d715a43531"),
                 CreatedDate = DateTime.Now,
                 CreatedBy = Guid.Parse("b31871ee-4e10-4d5a-9193-a1272b51b3be"),
                 IsDelete = false,
                 OrganizationNameSl = "ابيكس",
                 OrganizationNameFl = "apex",
                 NickName = "APEXUNITED",
                 Code = "apex",
                 RegistrationEmail = "tech@apexunited.com",
                 AlternativeEmail = "tech@apexunited.com",
                 PrimaryLanguage = "EN",
                 SecondaryLanguage = "AR",
                 AdminPassword = EncryptProvider.AESEncrypt("admin@123", Constants.EncryptDecryptKey),
                 IsPromise = true,
                 Encryption = string.Concat("apex", "tech@apexunited.com", "EN", "AR", true).Encrypt()
                },
                 //new Organization
                 //{
                 //Id = Guid.Parse("038efd7f-9bcf-42f4-3819-08d715a43532"),
                 //CreatedDate = DateTime.Now,
                 //CreatedBy = Guid.Parse("b31871ee-4e10-4d5a-9193-a1272b51b3be"),
                 //IsDelete = false,
                 //OrganizationNameSl = "عام",
                 //OrganizationNameFl = "public",
                 //NickName = "Public",
                 //Code = "public",
                 //RegistrationEmail = "tech@apexunited.com",
                 //AlternativeEmail = "tech@apexunited.com",
                 //PrimaryLanguage = "EN",
                 //SecondaryLanguage = "AR",
                 //AdminPassword = EncryptProvider.AESEncrypt("admin@123", Constants.EncryptDecryptKey),
                 //IsPromise = true,
                 //Encryption = string.Concat("public", "tech@apexunited.com", "EN", "AR", true).Encrypt()
                 //}
            };
        }


        public IEnumerable<TimeZones> AddTimeZones()
        {
            return new List<TimeZones>()
            {
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C680"),Name="Abu Dhabi", TimeZone = "Arabian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C681"), Name = "Adelaide", TimeZone = "Cen. Australia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C682"), Name = "Alaska", TimeZone = "Alaskan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C683"), Name = "Almaty", TimeZone = "Central Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C684"), Name = "American Samoa", TimeZone = "UTC-11"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C685"), Name = "Amsterdam", TimeZone = "W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C686"), Name = "Arizona", TimeZone = "US Mountain Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C687"), Name = "Astana", TimeZone = "Bangladesh Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C689"), Name = "Athens", TimeZone = "GTB Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C690"), Name = "Atlantic Time (Canada)", TimeZone = "Atlantic Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C691"), Name = "Auckland", TimeZone = "New Zealand Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C692"), Name = "Azores", TimeZone = "Azores Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C693"), Name = "Baghdad", TimeZone = "Arabic Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C694"), Name = "Baku", TimeZone = "Azerbaijan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C695"), Name = "Bangkok", TimeZone = "SE Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C696"), Name = "Beijing", TimeZone = "China Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C697"), Name = "Belgrade", TimeZone = "Central Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C698"), Name = "Berlin", TimeZone = "W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C699"), Name = "Bern", TimeZone = "W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C100"), Name = "Bogota", TimeZone = "SA Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C101"), Name = "Brasilia", TimeZone = "E. South America Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C102"), Name = "Bratislava", TimeZone = "Central Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C103"), Name = "Brisbane", TimeZone = "E. Australia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C104"), Name = "Brussels", TimeZone = "Romance Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C105"), Name = "Bucharest", TimeZone = "GTB Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C106"), Name = "Budapest", TimeZone = "Central Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C107"), Name = "Buenos Aires", TimeZone = "Argentina Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C108"), Name = "Cairo", TimeZone = "Egypt Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C109"), Name = "Canberra", TimeZone = "AUS Eastern Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C110"), Name = "Cape Verde Is", TimeZone = "Cape Verde Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C111"), Name = "Caracas", TimeZone = "Venezuela Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C112"), Name = "Casablanca", TimeZone = "Morocco Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C113"), Name = "Central America", TimeZone = "Central America Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C114"), Name = "Central Time (US & Canada)", TimeZone = "Central Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C115"), Name = "Chennai", TimeZone = "India Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C116"), Name = "Chihuahua", TimeZone = "Mountain Standard Time (Mexico)"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C117"), Name = "Chongqing", TimeZone = "China Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C118"), Name = "Copenhagen", TimeZone = "Romance Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C119"), Name = "Darwin", TimeZone = "AUS Central Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C120"), Name = "Dhaka", TimeZone = "Bangladesh Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C121"), Name = "Dublin", TimeZone = "GMT Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C122"), Name = "Eastern Time (US & Canada)", TimeZone = "Eastern Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C123"), Name = "Edinburgh", TimeZone = "GMT Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C124"), Name = "Ekaterinburg", TimeZone = "Ekaterinburg Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C125"), Name = "Fiji", TimeZone = "Fiji Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C126"), Name = "Georgetown", TimeZone = "SA Western Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C127"), Name = "Greenland", TimeZone = "Greenland Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C128"), Name = "Guadalajara", TimeZone = "Central Standard Time (Mexico)"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C129"), Name = "Guam", TimeZone = "West Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C130"), Name = "Hanoi", TimeZone = "SE Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C131"), Name = "Harare", TimeZone = "South Africa Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C132"), Name = "Hawaii", TimeZone = "Hawaiian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C133"), Name = "Helsinki", TimeZone = "FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C134"), Name = "Hobart", TimeZone = "Tasmania Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C135"), Name = "Hong Kong", TimeZone = "China Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C136"), Name = "Indiana (East)", TimeZone = "US Eastern Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C137"), Name = "International Date Line West", TimeZone = "UTC-11"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C138"), Name = "Irkutsk", TimeZone = "North Asia East Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C139"), Name = "Islamabad", TimeZone = "Pakistan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C140"), Name = "Istanbul", TimeZone = "Turkey Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C141"), Name = "Jakarta", TimeZone = "SE Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C142"), Name = "Jerusalem", TimeZone = "Israel Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C143"), Name = "Kabul", TimeZone = "Afghanistan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C144"), Name = "Kaliningrad", TimeZone = "Kaliningrad Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C145"), Name = "Kamchatka", TimeZone = "Russia Time Zone 11"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C146"), Name = "Karachi", TimeZone = "Pakistan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C147"), Name = "Kathmandu", TimeZone = "Nepal Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C148"), Name = "Kolkata", TimeZone = "India Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C149"), Name = "Krasnoyarsk", TimeZone = "North Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C150"), Name = "Kuala Lumpur", TimeZone = "Singapore Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C151"), Name = "Kuwait", TimeZone = "Arab Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C152"), Name = "Kyiv", TimeZone = "FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C153"), Name = "La Paz", TimeZone = "SA Western Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C154"), Name = "Lima", TimeZone = "SA Pacific Standard Time "},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C155"), Name = "Lisbon", TimeZone = "GMT Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C156"), Name = "Ljubljana", TimeZone = "Central Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C157"), Name = "London", TimeZone = "GMT Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C158"), Name = "Madrid", TimeZone = "Romance Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C159"), Name = "Magadan", TimeZone = "Magadan Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C160"), Name = "Marshall Is", TimeZone = "UTC+12"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C161"), Name = "Mazatlan", TimeZone = "Mountain Standard Time (Mexico)"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C162"), Name = "Melbourne", TimeZone = "AUS Eastern Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C163"), Name = "Mexico City", TimeZone = "Central Standard Time (Mexico)"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C164"), Name = "Mid-Atlantic", TimeZone = "UTC-02"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C165"), Name = "Midway Island", TimeZone = "UTC-11"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C167"), Name ="Minsk", TimeZone ="Belarus Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C168"), Name ="Monrovia", TimeZone ="Greenwich Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C169"), Name ="Monterrey", TimeZone ="Central Standard Time (Mexico)"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C170"), Name ="Montevideo", TimeZone ="Montevideo Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C171"), Name ="Moscow", TimeZone ="Russian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C172"), Name ="Mountain Time (US & Canada)", TimeZone ="Mountain Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C173"), Name ="Mumbai", TimeZone ="India Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C174"), Name ="Muscat", TimeZone ="Arabian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C175"), Name ="Nairobi", TimeZone ="E. Africa Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C176"), Name ="New Caledonia", TimeZone ="Central Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C177"), Name ="New Delhi", TimeZone ="India Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C178"), Name ="Newfoundland", TimeZone ="Newfoundland Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C179"), Name ="Novosibirsk", TimeZone ="N. Central Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C180"), Name ="Nuku'alofa", TimeZone ="Tonga Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C181"), Name ="Osaka", TimeZone ="Tokyo Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C182"), Name ="Pacific Time (US & Canada)", TimeZone ="Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C183"), Name ="Paris", TimeZone ="Romance Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C184"), Name ="Perth", TimeZone ="W. Australia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C185"), Name ="Port Moresby", TimeZone ="West Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C186"), Name ="Prague", TimeZone ="Central Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C187"), Name ="Pretoria", TimeZone ="South Africa Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C188"), Name ="Quito", TimeZone ="SA Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C189"), Name ="Rangoon", TimeZone ="Myanmar Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C190"), Name ="Riga", TimeZone ="FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C191"), Name ="Riyadh", TimeZone ="Arab Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C192"), Name ="Rome", TimeZone ="W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C193"), Name ="Samara", TimeZone ="Russia Time Zone 3"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C194"), Name ="Samoa", TimeZone ="Samoa Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C195"), Name ="Santiago", TimeZone ="Pacific SA Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C196"), Name ="Sapporo", TimeZone ="Tokyo Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C197"), Name ="Sarajevo", TimeZone ="Central European Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C198"), Name ="Saskatchewan", TimeZone ="Canada Central Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C199"), Name ="Seoul", TimeZone ="Korea Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C200"), Name ="Singapore", TimeZone ="Singapore Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C201"), Name ="Skopje", TimeZone ="Central European Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C202"), Name ="Sofia", TimeZone ="FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C203"), Name ="Solomon Is.", TimeZone ="Central Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C204"), Name ="Srednekolymsk", TimeZone ="Russia Time Zone 10"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C205"), Name ="Sri Jayawardenepura", TimeZone ="Sri Lanka Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C206"), Name ="St. Petersburg", TimeZone ="Russian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C207"), Name ="Stockholm", TimeZone ="W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C208"), Name ="Sydney", TimeZone ="AUS Eastern Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C209"), Name ="Taipei", TimeZone ="Taipei Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C210"), Name ="Tallinn", TimeZone ="FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C211"), Name ="Tashkent", TimeZone ="West Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C212"), Name ="Tbilisi", TimeZone ="Georgian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C213"), Name ="Tehran", TimeZone ="Iran Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C214"), Name ="Tijuana", TimeZone ="Pacific Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C215"), Name ="Tokelau Is.", TimeZone ="Tonga Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C216"), Name ="Tokyo", TimeZone ="Tokyo Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C217"), Name ="Ulaanbaatar", TimeZone ="Ulaanbaatar Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C218"), Name ="Urumqi", TimeZone ="Central Asia Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C219"), Name ="UTC", TimeZone ="UTC"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C220"), Name ="Vienna", TimeZone ="W. Europe Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C221"), Name ="Vilnius", TimeZone ="FLE Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C222"), Name ="Vladivostok", TimeZone ="Vladivostok Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C223"), Name ="Volgograd", TimeZone ="Russian Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C224"), Name ="Warsaw", TimeZone ="Central European Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C225"), Name ="Wellington", TimeZone ="New Zealand Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C226"), Name ="West Central Africa", TimeZone ="W. Central Africa Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C227"), Name ="Yakutsk", TimeZone ="Yakutsk Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C228"), Name ="Yerevan", TimeZone ="Caucasus Standard Time"},
                new TimeZones{ Id = new Guid("5C60F693-BEF5-E011-A485-80EE7300C229"), Name ="Zagreb", TimeZone ="Central European Standard Time"}



               
            };
        }

    }
}
