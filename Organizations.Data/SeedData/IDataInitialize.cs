
using Organizations.Data.Entities;
using System.Collections.Generic;

namespace Organizations.Data.SeedData
{
  public  interface IDataInitialize
    {
        //IEnumerable<ActiveDirectoryKey> AddactiveDirectoryKey();
        IEnumerable<ActiveDirectoryPrimaryKey> AddactiveDirectoryPrimaryKey();
        IEnumerable<Application> Addapplication();
        IEnumerable<Screen> AddScreens();
        IEnumerable<Module> AddModules();
        IEnumerable<Package> AddPackages();
        IEnumerable<User> AddUsers();
        IEnumerable<UserRoles> AddUserRoles();
        IEnumerable<PackageModule> AddPackageModules();
        IEnumerable<ModuleScreen> AddModuleScreens();
        IEnumerable<Roles> AddRoles();
        IEnumerable<Organization> AddOrganizations();
        IEnumerable<TimeZones> AddTimeZones();
        IEnumerable<HostApiData> AddHostApiDatas();
    }
}
