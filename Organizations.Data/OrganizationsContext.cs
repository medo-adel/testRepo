using Common.StandardInfrastructure;
using Microsoft.EntityFrameworkCore;
using Organizations.Data.Entities;
using Organizations.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Organizations.Data
{
    public class OrganizationsContext : DbContext
    {
        private readonly ISessionStorage _sessionStorage;
        private readonly IDataInitialize _dataInit;
        public OrganizationsContext(DbContextOptions<OrganizationsContext> options, IDataInitialize dataInit, ISessionStorage sessionStorage) : base(options)
        {
            _dataInit = dataInit;
            _sessionStorage = sessionStorage;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ActiveDirectoryKey>().HasData(_dataInit.AddactiveDirectoryKey());
            modelBuilder.Entity<ActiveDirectoryPrimaryKey>().HasData(_dataInit.AddactiveDirectoryPrimaryKey());
            modelBuilder.Entity<Application>().HasData(_dataInit.Addapplication());
            modelBuilder.Entity<Organization>().HasData(_dataInit.AddOrganizations());
            modelBuilder.Entity<Screen>().HasData(_dataInit.AddScreens());
            modelBuilder.Entity<Package>().HasData(_dataInit.AddPackages());
            modelBuilder.Entity<Module>().HasData(_dataInit.AddModules());
            modelBuilder.Entity<ModuleScreen>().HasData(_dataInit.AddModuleScreens());
            modelBuilder.Entity<User>().HasData(_dataInit.AddUsers());
            modelBuilder.Entity<UserRoles>().HasData(_dataInit.AddUserRoles());
            modelBuilder.Entity<PackageModule>().HasData(_dataInit.AddPackageModules());
            modelBuilder.Entity<Roles>().HasData(_dataInit.AddRoles());
            modelBuilder.Entity<TimeZones>().HasData(_dataInit.AddTimeZones());
            modelBuilder.Entity<HostApiData>().HasData(_dataInit.AddHostApiDatas());


            base.OnModelCreating(modelBuilder);


        }

        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<OrganizationLicense> OrganizationLicenses { get; set; }
        public virtual DbSet<OrganizationServer> OrganizationServers { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Module> Modules { get; set; }

        public virtual DbSet<Screen> Screens { get; set; }

        public virtual DbSet<ModuleScreen> ModuleScreens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<PackageModule> PackageModules { get; set; }
        public virtual DbSet<OrganizationLicencesModule> OrganizationLicencesModules { get; set; }

        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        public virtual DbSet<TimeZones> TimeZones { get; set; }

        public virtual DbSet<HostApiData> HostApiDatas { get; set; }
        public virtual DbSet<OrganizationHost> OrganizationHosts { get; set; }
        public virtual DbSet<SettingActualWorking> SettingActualWorkings { get; set; }
        public virtual DbSet<ActiveDirectoryKey> ActiveDirectoryKeys { get; set; }
        public virtual DbSet<OrganizationRequest> OrganizationRequests { get; set; }
        public virtual DbSet<OrganizationLicenseRequest> OrganizationLicenseRequests { get; set; }
        public virtual DbSet<OrganizationLicencesModuleRequest> OrganizationLicencesModuleRequests { get; set; }
        public virtual DbSet<OrganizationHostRequest> OrganizationHostRequests { get; set; }
        public DbSet<AppDetails> AppDetails { get; set; }

        

        // ReSharper disable once ArrangeModifiersOrder
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var propertiesList = new List<string>() { "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate" };
                foreach (var property in entry.Properties.Where(q => propertiesList.Contains(q.Metadata.Name)))
                {
                    string propertyName = property.Metadata.Name;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            if (propertyName == "CreatedBy") property.CurrentValue = _sessionStorage.UserId;
                            else if (propertyName == "CreatedDate") property.CurrentValue = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            if (propertyName == "ModifiedBy") property.CurrentValue = _sessionStorage.UserId;
                            else if (propertyName == "ModifiedDate") property.CurrentValue = DateTime.UtcNow;
                            else if (propertyName == "CreatedBy") property.CurrentValue = property.OriginalValue;
                            else if (propertyName == "CreatedDate") property.CurrentValue = property.OriginalValue;
                            break;
                    }
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
