using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Organizations.Data.Migrations
{
    public partial class newmigrationorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveDirectoryKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveDirectoryKeyNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActiveDirectoryKeyNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveDirectoryKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActiveDirectoryPrimaryKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryKeyNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKeyNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveDirectoryPrimaryKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HostApiDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HostApiDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationScreens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<short>(type: "smallint", nullable: false),
                    IsReport = table.Column<bool>(type: "bit", nullable: false),
                    UrlPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CanShow = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationScreens_OrganizationScreens_ParentId",
                        column: x => x.ParentId,
                        principalTable: "OrganizationScreens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationServers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindowsId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAdressId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationServers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    SessionEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingActualWorkings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingActualWorkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleScreens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleScreens_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleScreens_OrganizationScreens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "OrganizationScreens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationUserRoles_OrganizationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "OrganizationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationUserRoles_OrganizationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "OrganizationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageModules_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationNameSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationNameFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AlternativeEmail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PrimaryLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURLFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURLSl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPromise = table.Column<bool>(type: "bit", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationHosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostApiDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationHosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationHosts_HostApiDatas_HostApiDataId",
                        column: x => x.HostApiDataId,
                        principalTable: "HostApiDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationHosts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersCount = table.Column<int>(type: "int", nullable: false),
                    EmployeesCount = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenses_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenses_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationLicenses_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActiveDirectory = table.Column<bool>(type: "bit", nullable: false),
                    AdDomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekendDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveDirectoryPrimaryKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ADKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActiveDirectoryKeyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsReviewLogs = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationSetting_ActiveDirectoryKey_ActiveDirectoryKeyId",
                        column: x => x.ActiveDirectoryKeyId,
                        principalTable: "ActiveDirectoryKey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationSetting_ActiveDirectoryPrimaryKey_ActiveDirectoryPrimaryKeyId",
                        column: x => x.ActiveDirectoryPrimaryKeyId,
                        principalTable: "ActiveDirectoryPrimaryKey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationSetting_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationLicencesModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationLicenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Encryption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationLicencesModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationLicencesModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationLicencesModules_OrganizationLicenses_OrganizationLicenseId",
                        column: x => x.OrganizationLicenseId,
                        principalTable: "OrganizationLicenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActiveDirectoryKey",
                columns: new[] { "Id", "ActiveDirectoryKeyNameFl", "ActiveDirectoryKeyNameSl", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("10000000-1000-1000-1000-100000000000"), "Attribute1", "Attribute1", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { new Guid("20000000-2000-2000-2000-200000000000"), "Attribute2", "Attribute2", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ActiveDirectoryPrimaryKey",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "PrimaryKeyNameFl", "PrimaryKeyNameSl" },
                values: new object[,]
                {
                    { new Guid("10000000-1000-1000-1000-100000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "CivilId", "الرقم المدني" },
                    { new Guid("20000000-2000-2000-2000-200000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "EmployeeNumber", "رقم الموظف" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "ApplicationNameFl", "ApplicationNameSl", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("40144a96-b6b3-4aae-bb68-3a9d27c580e6"), "Tams", "Tams", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { new Guid("8441f18d-17ba-4974-9f8b-d74472f8150d"), "Mobile", "Mobile", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null },
                    { new Guid("1e99618b-6294-4786-8b00-2b8e294c66fe"), "Aum", "Aum", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "HostApiDatas",
                columns: new[] { "Id", "NameFl", "NameSl" },
                values: new object[,]
                {
                    { new Guid("40000000-4000-4000-4000-400000000000"), "Logout_APIHub", "Logout_APIHub" },
                    { new Guid("30000000-3000-3000-3000-300000000000"), "Logs_APIHub", "Logs_APIHub" },
                    { new Guid("20000000-2000-2000-2000-200000000000"), "Notification_API", "Notification_API" },
                    { new Guid("10000000-1000-1000-1000-100000000000"), "HOST_API", "HOST_API" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[,]
                {
                    { new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58044"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Leaves Return)", "Workflow Module - (Leaves Return)", null },
                    { new Guid("8441f18d-17ba-4974-9f8b-d74472f81522"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Part-day Permissions)", "Workflow Module - (Part-day Permissions)", null },
                    { new Guid("10efc918-ef1f-409a-a0b3-ee5d35932997"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Full-day Permissions)", "Workflow Module - (Full-day Permissions)", null },
                    { new Guid("8441f18d-17ba-4974-9f8b-d74472f81533"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Overtime)", "Workflow Module - (Overtime)", null },
                    { new Guid("db79584c-f205-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Logs (Basic) Module", "Logs (Basic) Module", null },
                    { new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Logs (Advanced) Module", "Logs (Advanced) Module", null },
                    { new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Reports (Advanced) Module", "Reports (Advanced) Module", null },
                    { new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Basic Memos Module", "Basic Memos Module", null },
                    { new Guid("db79524c-f308-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "My Administration Inquiry Module", "My Administration Inquiry Module", null },
                    { new Guid("db79524c-f408-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow (Requests) Module", "Workflow (Requests) Module", null },
                    { new Guid("db79524c-f508-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sign Module", "Sign Module", null },
                    { new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58011"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Workflow Module - (Leaves)", "Workflow Module - (Leaves)", null },
                    { new Guid("db79523c-f508-491a-1a79-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "HR Module", "HR Module", null },
                    { new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Aum Modules", "Aum Modules", null },
                    { new Guid("db79524c-f208-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "My Inquiry Module", "My Inquiry Module", null },
                    { new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Inquiry (Basic) Module", "Inquiry (Basic) Module", null },
                    { new Guid("db79584c-f204-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Notifications & News Module", "Notifications & News Module", null },
                    { new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Break Module", "Break Module", null },
                    { new Guid("db79584c-f608-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Audit Module", "Audit Module", null },
                    { new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Basic Module", "Basic Module", null },
                    { new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Duties (Fixed) Module", "Duties (Fixed) Module", null },
                    { new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Part-day Permissions Module", "Part-day Permissions Module", null },
                    { new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Duties (Rotated) Module", "Duties (Rotated) Module", null },
                    { new Guid("8289daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Duties (Free) Module", "Duties (Free) Module", null },
                    { new Guid("8389daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Duties (Fixed Periods) Module", "Duties (Fixed Periods) Module", null },
                    { new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Leaves (Lite) Module", "Leaves (Lite) Module", null },
                    { new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Full-day Permissions Module", "Full-day Permissions Module", null },
                    { new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Exemptions / Tolerance Module", "Exemptions / Tolerance Module", null },
                    { new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Overtime Module", "Overtime Module", null },
                    { new Guid("db79584c-f208-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Deductions Module", "Deductions Module", null },
                    { new Guid("db79584c-f308-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Penalties Module", "Penalties Module", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleNameFl", "ModuleNameSl", "Price" },
                values: new object[,]
                {
                    { new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Leaves (Enterprise) Module", "Leaves (Enterprise) Module", null },
                    { new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Annual Evaluation Module", "Annual Evaluation Module", null }
                });

            migrationBuilder.InsertData(
                table: "OrganizationRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "RoleNameFl", "RoleNameSl" },
                values: new object[,]
                {
                    { new Guid("20000000-2000-2000-2000-200000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "User", "User" },
                    { new Guid("10000000-1000-1000-1000-100000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("cc930a1e-97d2-4642-a44f-07c4a8e20f36"), true, "menu9", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock", false, false, null, null, (short)8, null, null },
                    { new Guid("18c02172-1ea5-4e4e-a5e2-ec0ce5c310ef"), true, "menu10", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "notifications_active", false, false, null, null, (short)9, null, null },
                    { new Guid("15655108-4a92-4bd8-8e91-cc174f86eebc"), false, "OrganizationComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "list", false, false, null, null, (short)1, null, null },
                    { new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), true, "menu12", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "view_agenda", false, false, null, null, (short)11, null, null },
                    { new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), true, "menu6", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "receipt", false, true, null, null, (short)12, null, null },
                    { new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), true, "menu13", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)13, null, null },
                    { new Guid("54ee3f27-6a95-98e4-c188-6bb86119d85c"), true, "menu8", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dashboard", false, false, null, null, (short)7, null, null },
                    { new Guid("18c02133-1ea5-4e4e-a6e2-ec0ce5c310ef"), true, "menu14", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)14, null, null },
                    { new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c318ef"), true, "menu11", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm", false, false, null, null, (short)10, null, null },
                    { new Guid("93ee3f27-6a95-98e4-b177-8aa86119d85c"), true, "menu7", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "history", false, false, null, null, (short)6, null, null },
                    { new Guid("44db8859-8d41-4a86-97e7-ede5c508b521"), true, "menu4", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock", false, false, null, null, (short)4, null, null },
                    { new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), true, "menu4", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock", false, false, null, null, (short)4, null, null },
                    { new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), true, "menu3", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "access_time", false, false, null, null, (short)3, null, null },
                    { new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), true, "menu2", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "people", false, false, null, null, (short)2, null, null },
                    { new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), true, "menu1", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "list", false, false, null, null, (short)1, null, null },
                    { new Guid("15d48624-f880-44be-96b9-afe2f03606ac"), true, "menu3", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group", false, false, null, null, (short)3, null, null },
                    { new Guid("6cb30dd3-944c-4426-8893-a3d1dae2455e"), true, "menu5", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)5, null, null },
                    { new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), true, "menu6", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "receipt", false, true, null, null, (short)6, null, null },
                    { new Guid("93ee3f27-6a95-98e4-b177-8aa86119d90c"), true, "menu7", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "history", false, false, null, null, (short)7, null, null },
                    { new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), true, "menu1", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "list", false, false, null, null, (short)1, null, null },
                    { new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), true, "menu5", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)5, null, null },
                    { new Guid("ed8988cd-bbe5-4757-ac78-a7e29f60301b"), true, "menu2", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "people", false, false, null, null, (short)2, null, null }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUsers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "IsDelete", "IsLoggedIn", "ModifiedBy", "ModifiedDate", "Password", "SessionEndTime", "UserName" },
                values: new object[] { new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApexAdmin@ApexAdmin.com", false, false, null, null, "AQAAAAEAACcQAAAAECLOPZTc4gbeWqQ468Vrt8Tm+/CE2HE4nPenHXGxpNH5y+HRWWa9FBqQMatXcV4yJA==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ApexAdmin" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AdminPassword", "AlternativeEmail", "Code", "CreatedBy", "CreatedDate", "Encryption", "IsDelete", "IsPromise", "LogoURLFl", "LogoURLSl", "ModifiedBy", "ModifiedDate", "NickName", "OrganizationNameFl", "OrganizationNameSl", "PrimaryLanguage", "RegistrationEmail", "SecondaryLanguage", "TimeZoneId" },
                values: new object[] { new Guid("038efd7f-9bcf-42f4-3819-08d715a43531"), "EbDPTSTEwAqG91Jysjs8SA==", "tech@apexunited.com", "apex", new Guid("b31871ee-4e10-4d5a-9193-a1272b51b3be"), new DateTime(2022, 10, 20, 13, 19, 56, 478, DateTimeKind.Local).AddTicks(994), "000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f", false, true, null, null, null, null, "APEXUNITED", "apex", "ابيكس", "EN", "tech@apexunited.com", "AR", null });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "ApplicationId", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "PackageNameFl", "PackageNameSl" },
                values: new object[,]
                {
                    { new Guid("21df3c86-c767-4dde-989e-f8675987dcad"), new Guid("8441f18d-17ba-4974-9f8b-d74472f8150d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Smartin Package", "Smartin Package" },
                    { new Guid("91df3c86-c767-4dde-989e-f3675987dcad"), new Guid("40144a96-b6b3-4aae-bb68-3a9d27c580e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "TAMS Custom Package", "TAMS Custom Package" },
                    { new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9302"), new Guid("40144a96-b6b3-4aae-bb68-3a9d27c580e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "TAMS Lite Package", "TAMS Lite Package" },
                    { new Guid("ac1dc6d4-b2c6-4adb-a3a8-dfd896757658"), new Guid("1e99618b-6294-4786-8b00-2b8e294c66fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Aum Package", "Aum Package" }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "TimeZone" },
                values: new object[,]
                {
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c176"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "New Caledonia", "Central Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c177"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "New Delhi", "India Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c178"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Newfoundland", "Newfoundland Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c179"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Novosibirsk", "N. Central Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c180"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Nuku'alofa", "Tonga Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c181"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Osaka", "Tokyo Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c182"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Pacific Time (US & Canada)", "Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c184"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Perth", "W. Australia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c185"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Port Moresby", "West Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c186"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Prague", "Central Europe Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "TimeZone" },
                values: new object[,]
                {
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c187"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Pretoria", "South Africa Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c188"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Quito", "SA Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c189"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Rangoon", "Myanmar Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c190"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Riga", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c183"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Paris", "Romance Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c175"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Nairobi", "E. Africa Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c172"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mountain Time (US & Canada)", "Mountain Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c173"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mumbai", "India Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c156"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Ljubljana", "Central Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c157"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "London", "GMT Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c158"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Madrid", "Romance Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c159"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Magadan", "Magadan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c160"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Marshall Is", "UTC+12" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c161"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mazatlan", "Mountain Standard Time (Mexico)" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c162"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Melbourne", "AUS Eastern Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c163"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mexico City", "Central Standard Time (Mexico)" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c164"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Mid-Atlantic", "UTC-02" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c165"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Midway Island", "UTC-11" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c167"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Minsk", "Belarus Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c168"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Monrovia", "Greenwich Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c169"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Monterrey", "Central Standard Time (Mexico)" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c170"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Montevideo", "Montevideo Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c171"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Moscow", "Russian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c174"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Muscat", "Arabian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c191"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Riyadh", "Arab Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c194"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Samoa", "Samoa Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c193"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Samara", "Russia Time Zone 3" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c214"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tijuana", "Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c215"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tokelau Is.", "Tonga Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c216"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tokyo", "Tokyo Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c217"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Ulaanbaatar", "Ulaanbaatar Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c218"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Urumqi", "Central Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c219"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "UTC", "UTC" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c220"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Vienna", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c221"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Vilnius", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c222"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Vladivostok", "Vladivostok Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c223"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Volgograd", "Russian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c224"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Warsaw", "Central European Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c225"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Wellington", "New Zealand Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c226"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "West Central Africa", "W. Central Africa Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c227"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Yakutsk", "Yakutsk Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c228"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Yerevan", "Caucasus Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "TimeZone" },
                values: new object[,]
                {
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c213"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tehran", "Iran Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c192"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Rome", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c212"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tbilisi", "Georgian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c210"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tallinn", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c195"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Santiago", "Pacific SA Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c196"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sapporo", "Tokyo Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c197"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sarajevo", "Central European Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c198"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Saskatchewan", "Canada Central Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c199"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Seoul", "Korea Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c200"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Singapore", "Singapore Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c201"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Skopje", "Central European Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c202"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sofia", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c203"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Solomon Is.", "Central Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c204"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Srednekolymsk", "Russia Time Zone 10" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c205"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sri Jayawardenepura", "Sri Lanka Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c206"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "St. Petersburg", "Russian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c207"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Stockholm", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c208"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sydney", "AUS Eastern Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c209"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Taipei", "Taipei Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c211"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Tashkent", "West Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c155"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Lisbon", "GMT Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c153"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "La Paz", "SA Western Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c152"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kyiv", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c100"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Bogota", "SA Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c101"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Brasilia", "E. South America Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c102"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Bratislava", "Central Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c103"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Brisbane", "E. Australia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c104"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Brussels", "Romance Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c105"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Bucharest", "GTB Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c699"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Bern", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c106"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Budapest", "Central Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c108"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Cairo", "Egypt Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c109"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Canberra", "AUS Eastern Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c110"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Cape Verde Is", "Cape Verde Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c111"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Caracas", "Venezuela Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c112"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Casablanca", "Morocco Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c113"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Central America", "Central America Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c107"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Buenos Aires", "Argentina Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c698"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Berlin", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c697"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Belgrade", "Central Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c696"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Beijing", "China Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c680"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Abu Dhabi", "Arabian Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "TimeZone" },
                values: new object[,]
                {
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c681"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Adelaide", "Cen. Australia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c682"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Alaska", "Alaskan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c683"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Almaty", "Central Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c684"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "American Samoa", "UTC-11" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c685"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Amsterdam", "W. Europe Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c686"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Arizona", "US Mountain Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c687"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Astana", "Bangladesh Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c689"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Athens", "GTB Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c690"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Atlantic Time (Canada)", "Atlantic Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c691"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Auckland", "New Zealand Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c692"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Azores", "Azores Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c693"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Baghdad", "Arabic Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c694"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Baku", "Azerbaijan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c695"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Bangkok", "SE Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c114"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Central Time (US & Canada)", "Central Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c115"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Chennai", "India Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c116"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Chihuahua", "Mountain Standard Time (Mexico)" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c117"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Chongqing", "China Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c137"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "International Date Line West", "UTC-11" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c138"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Irkutsk", "North Asia East Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c139"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Islamabad", "Pakistan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c140"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Istanbul", "Turkey Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c141"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Jakarta", "SE Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c142"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Jerusalem", "Israel Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c143"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kabul", "Afghanistan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c144"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kaliningrad", "Kaliningrad Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c145"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kamchatka", "Russia Time Zone 11" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c146"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Karachi", "Pakistan Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c147"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kathmandu", "Nepal Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c148"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kolkata", "India Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c149"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Krasnoyarsk", "North Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c150"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kuala Lumpur", "Singapore Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c151"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Kuwait", "Arab Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c136"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Indiana (East)", "US Eastern Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c154"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Lima", "SA Pacific Standard Time " },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c135"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Hong Kong", "China Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c133"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Helsinki", "FLE Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c229"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Zagreb", "Central European Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c119"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Darwin", "AUS Central Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c120"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Dhaka", "Bangladesh Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c121"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Dublin", "GMT Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c122"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Eastern Time (US & Canada)", "Eastern Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "Name", "TimeZone" },
                values: new object[,]
                {
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c123"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Edinburgh", "GMT Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c124"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Ekaterinburg", "Ekaterinburg Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c125"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Fiji", "Fiji Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c126"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Georgetown", "SA Western Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c127"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Greenland", "Greenland Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c128"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Guadalajara", "Central Standard Time (Mexico)" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c129"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Guam", "West Pacific Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c130"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Hanoi", "SE Asia Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c131"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Harare", "South Africa Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c132"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Hawaii", "Hawaiian Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c134"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Hobart", "Tasmania Standard Time" },
                    { new Guid("5c60f693-bef5-e011-a485-80ee7300c118"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Copenhagen", "Romance Standard Time" }
                });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[] { new Guid("5c183d4e-8b4f-41f5-aa43-8b316a46a730"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("15655108-4a92-4bd8-8e91-cc174f86eebc") });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("ab268b4c-4c18-4208-aa0b-f350ba8fe929"), true, "ImportExcelComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "import_export", false, false, null, null, (short)2, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/sheetLogs" },
                    { new Guid("39aab175-d4fd-4108-8e8a-590dabaa6b44"), true, "NotificationsNewsGridComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "notifications_active", false, false, null, null, (short)1, new Guid("18c02172-1ea5-4e4e-a5e2-ec0ce5c310ef"), "/main/notification-news/notification-news-grid" },
                    { new Guid("ab168b4b-4c18-4208-aa0b-f350ba8fe933"), true, "LockLeavesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock", false, false, null, null, (short)1, new Guid("cc930a1e-97d2-4642-a44f-07c4a8e20f36"), "/main/lock-year/lock-leaves" },
                    { new Guid("54ee3f36-6a95-98e6-b177-8aa861850001"), true, "WorkflowTemplateComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dashboard", false, false, null, null, (short)1, new Guid("54ee3f27-6a95-98e4-c188-6bb86119d85c"), "/main/workflows/workflow-template" },
                    { new Guid("93ee3f36-6a95-98e6-b188-7aa76185d75c"), true, "AutoSolveAuditComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)2, new Guid("93ee3f27-6a95-98e4-b177-8aa86119d85c"), "/main/audits/auto-solve-audit" },
                    { new Guid("93ee3f36-6a95-98e6-b177-8aa86185d85c"), true, "AuditsGridComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)1, new Guid("93ee3f27-6a95-98e4-b177-8aa86119d85c"), "/main/audits/audits-log" },
                    { new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe999"), true, "UnknownUserLogsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)5, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/unknown-employee" },
                    { new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe959"), true, "LogsDriveSettingsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cloud", false, false, null, null, (short)5, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/logs-drive-settings" },
                    { new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe956"), true, "SyncLogsExceptionsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "block", false, false, null, null, (short)5, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/sync-logs-exceptions" },
                    { new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe950"), true, "ReviewLogsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "check_circle", false, false, null, null, (short)5, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/review-Logs" },
                    { new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe949"), true, "EmployeeAbsenceLogsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)4, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/employee-absence-logs" },
                    { new Guid("ab368b4c-4c18-4208-aa0b-f350ba8fe929"), true, "EmployeeAttedancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)3, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/employeeAttendances" },
                    { new Guid("e4e72d50-86d5-4eea-a2c6-f02f3cd2d2b6"), true, "MemoEarlyOutReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)2, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/memo-early-out-report" },
                    { new Guid("ab168b4c-4c18-4208-aa0b-f350ba8fe929"), true, "EmployeeLogsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)1, new Guid("bb930a1e-97d2-4644-a44f-07c4a8e20f34"), "/main/logs/manualLogs" },
                    { new Guid("93ee3f27-6a95-46e4-b177-8aa86115d85c"), true, "UserInquiriesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_identity", false, false, null, null, (short)4, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/UserInquiries" },
                    { new Guid("92ee3f27-6a95-46e4-b177-8aa86115d85c"), true, "UsermangmentsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_identity", false, false, null, null, (short)3, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/usermangments" },
                    { new Guid("90ee3f27-6a95-46e4-b177-8aa86115d85c"), true, "GroupsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "people_outline", false, false, null, null, (short)1, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/groups" },
                    { new Guid("e8a82e92-137b-47ca-a073-72e730b82c6d"), true, "ShiftsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "person_add", false, false, null, null, (short)7, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/EmployeeFixedDutyPeriod" },
                    { new Guid("e7a82e92-137b-47ca-a073-72e730b82c6d"), true, "EmployeeDutyComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "person_add", false, false, null, null, (short)6, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/employeeduty" },
                    { new Guid("e5a82e92-137b-47ca-a073-72e730b82c6d"), true, "HourlyDutiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "today", false, false, null, null, (short)5, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/hourly-rotated-duties" },
                    { new Guid("e4a82e92-137b-47ca-a073-72e730b82c6d"), true, "DailyRotatedSchedulesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "today", false, false, null, null, (short)4, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/daily-rotated-schedule" },
                    { new Guid("e3a82e92-137b-47ca-a073-72e730b82c6d"), true, "RotatedDutiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "schedule", false, false, null, null, (short)3, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/rotatedduties" },
                    { new Guid("e2a82e92-137b-47ca-a073-72e730b82c6d"), true, "FreeDutiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "schedule", false, false, null, null, (short)2, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/freeduties" },
                    { new Guid("e1a82e92-137b-47ca-a073-72e730b82c6d"), true, "FixeddutiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "schedule", false, false, null, null, (short)1, new Guid("f2e5ed25-cba3-45a2-ad8f-85caf39a55cb"), "/main/duties/fixedduties" },
                    { new Guid("c13acb26-6d39-40e9-831d-2dbcc01c0b5a"), true, "ApproveOvertimeComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "add_alarm", false, false, null, null, (short)14, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/approve-overtime" },
                    { new Guid("1234e9c7-fc23-4bec-bb17-a7a1da945632"), true, "OvertimeOrdersComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "add_alarm", false, false, null, null, (short)13, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/overtime-orders" },
                    { new Guid("c516e9c7-fc23-4bec-bb17-a7a1da945632"), true, "HolidayDatesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "date_range", false, false, null, null, (short)12, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/lookups/holidayDates" },
                    { new Guid("1226e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmergencyAllowancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "timer_off", false, false, null, null, (short)11, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/emergency-allowances" },
                    { new Guid("c486e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeAlowancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_on", false, false, null, null, (short)10, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/employee-allowances" },
                    { new Guid("91ee3f27-6a95-46e4-b177-8aa86115d85c"), true, "GroupRolesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock_open", false, false, null, null, (short)2, new Guid("1382b1a6-b38a-4112-87c8-4a46cf00907b"), "/main/usermanagement/group-roles" },
                    { new Guid("c506e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeePermissionsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_off", false, false, null, null, (short)9, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/employee-permissions" },
                    { new Guid("36aab155-d4fd-4508-8e8a-590dabaa6b44"), true, "BreakSettingComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "settings", false, false, null, null, (short)1, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c318ef"), "/main/breaks/break-setting" },
                    { new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b70"), true, "EmployeebreakreportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)3, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c318ef"), "/main/breaks/employee-break-report" },
                    { new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b14"), true, "MemosLateInReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)1, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/memos-late-in-report" },
                    { new Guid("146d3f84-33a1-48ce-bde3-103bdde75431"), true, "ConvertUnKnownUserReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)21, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/convert-un-knownuser-report" },
                    { new Guid("146d3f84-33a1-48ce-bde3-103bdde71332"), true, "EmployeesPenaltiesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)20, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employees-penalties-report" },
                    { new Guid("146d3f84-33a1-48ce-bde3-103bdde71331"), true, "UnKnownUserReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)19, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/un-knownuser-report" },
                    { new Guid("df1dbf09-302e-4b1d-94c6-76a3d0eb4560"), true, "ActualWorkingReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)18, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/actual-working-report" },
                    { new Guid("2db422f3-f497-4301-abfe-58995a1e18f1"), true, "EmployeesEvaluationReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)17, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employees-evaluation-report" },
                    { new Guid("2db422f3-f497-4301-abfe-58995a1e17f0"), true, "ApproveOvertimeReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)16, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/approve-overtime-report" },
                    { new Guid("06d10572-1a5e-4723-a49b-718e15a8641f"), true, "EmployeeWithoutFingerprintReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)15, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-without-fingerprin-report" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("b926e9c7-fc23-4bec-aa17-a7a1da945631"), true, "UserRolesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)14, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/user-roles-report" },
                    { new Guid("b926e9c7-fc23-4bec-aa17-a7a1da945632"), true, "EmployeeAllowancesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)13, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-allowances-report" },
                    { new Guid("c536e9c7-fc23-4bec-bb17-a7a1da945652"), true, "AdminMangerComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)12, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/admin-manger" },
                    { new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945552"), true, "EmployeeOnServiceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)11, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-onservice-report" },
                    { new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945652"), true, "EmployeeDeductionReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)10, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-Deduction-report" },
                    { new Guid("e39edfb2-5ec6-4ad5-9c3f-473b4256c319"), true, "CalculateEmployeeOverTimeReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)9, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/calculate-employee-OverTime-report" },
                    { new Guid("e38edfa3-5bc6-4bd5-9c3f-463b4256c319"), true, "EmployeeLeavesBalanceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)8, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-Leaves-Balance-report" },
                    { new Guid("e37edfa2-5ec6-4ad5-9c3f-463b4256c319"), true, "EmployeePermissionsBalanceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)7, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-Permissions-Balance-report" },
                    { new Guid("e36edfa2-4ec6-4ad5-9c3f-463b4256c319"), true, "EmployeeOverTimeOrdersReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)6, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-OverTime-Orders-report" },
                    { new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeFulldayPermissionsReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)5, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-fullday-permissions-report" },
                    { new Guid("b926e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeDutiesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)4, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-duties-report" },
                    { new Guid("a826e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeePermissionsReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)3, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-permissions-report" },
                    { new Guid("e666e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeLeavesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)2, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-leaves-report" },
                    { new Guid("d556e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeAttendanceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)1, new Guid("5a143af4-0ed3-417a-a592-639c84c9b090"), "/main/reports/employee-attendance-report" },
                    { new Guid("2f45cc65-78db-4479-90a8-075987f02e81"), true, "CalculateEmployeeEvaluationComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "view_agenda", false, false, null, null, (short)6, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/calculate-employee-evaluation" },
                    { new Guid("5c3e00bf-d07b-4df3-8dc6-f8889d1c5fb2"), true, "PreviousEmployeeEvaluationComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "view_agenda", false, false, null, null, (short)5, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/previous-employee-evaluation" },
                    { new Guid("e1398770-5fad-443f-afdd-dd45b212a0cb"), true, "PenaltieGroupsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "view_agenda", false, false, null, null, (short)4, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/penaltie-group" },
                    { new Guid("8770758b-7c07-4412-b42d-e45d119d2cd4"), true, "EmployeePenaltiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)3, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/employees-penalties" },
                    { new Guid("8770758b-7c07-4412-b42d-e45d119d2cd3"), true, "PenaltieTypesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)2, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/penaltie-types" },
                    { new Guid("7538a848-3cda-4acf-a128-f64dbab21899"), true, "EvaluationSettingsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "view_agenda", false, false, null, null, (short)1, new Guid("33067c23-5dd8-4c55-a42b-8a55749f9728"), "/main/penalties/evaluation-setting" },
                    { new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b75"), true, "EmployeeAttendanceWithBreakComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)4, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c318ef"), "/main/breaks/employee-attendance-with-break" },
                    { new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b68"), true, "EmployeesbreakComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_on", false, false, null, null, (short)2, new Guid("18c02172-1ea5-4e4e-a6e2-ec0ce5c318ef"), "/main/breaks/employees-break" },
                    { new Guid("c496e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeFulldayPermissionsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "card_travel", false, false, null, null, (short)8, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/permissions/employee-fullday-permissions" },
                    { new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeeLeavesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hotel", false, false, null, null, (short)7, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/leaves/employee-leaves" },
                    { new Guid("a937c70f-d295-4a9b-a970-55a44d310b1b"), true, "EmployeeLeavesBalanceComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "timeline", false, false, null, null, (short)6, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/leaves/employee-leaves-balance" },
                    { new Guid("18b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "TriggersComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "thumb_up", false, false, null, null, (short)6, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/triggers" },
                    { new Guid("19b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "AccessDoorsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "door_front", false, false, null, null, (short)7, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/accessDoors" },
                    { new Guid("20b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "HolidaiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "date_range", false, false, null, null, (short)8, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/holidaies" },
                    { new Guid("20b748c1-a7c5-4ea4-a41b-ee73f87abb3e"), true, "JobsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", false, false, null, null, (short)9, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/jobs" },
                    { new Guid("20b248c1-a7c5-4ea4-a31b-ee73f87abb3e"), true, "AdmistrativeLevelsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "domain", false, false, null, null, (short)10, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/admistrativeLevel" },
                    { new Guid("759e7936-8211-4adc-ad85-0863a0962156"), true, "DeviceMonitorComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, false, null, null, (short)11, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/device-monitor" },
                    { new Guid("f07cb184-9472-4d7e-a89d-555ed666f397"), true, "EmployeeMessagesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, false, null, null, (short)12, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/employee-messages" },
                    { new Guid("3387834b-5960-4c26-983f-6373eb58b1c3"), true, "EmployeesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "account_circle", false, false, null, null, (short)1, new Guid("ed8988cd-bbe5-4757-ac78-a7e29f60301b"), "/main/usermanagement/employees" },
                    { new Guid("3587834b-5960-4c26-983f-6373eb58b1c3"), true, "GroupEmployeesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group_add", false, false, null, null, (short)2, new Guid("ed8988cd-bbe5-4757-ac78-a7e29f60301b"), "/main/usermanagement/group-employees" },
                    { new Guid("3587834b-5240-4c26-983f-6373eb58b1c3"), true, "EmployeeDetailsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group_add", false, false, null, null, (short)3, new Guid("ed8988cd-bbe5-4757-ac78-a7e29f60301b"), "/main/usermanagement/employee-detail" },
                    { new Guid("3227834b-5240-4c26-983f-6373eb58b1c3"), true, "EmployeeEnrollsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group_add", false, false, null, null, (short)4, new Guid("ed8988cd-bbe5-4757-ac78-a7e29f60301b"), "/main/usermanagement/employee-enroll" },
                    { new Guid("ff96a778-21f2-418f-972f-ad121ea7b93d"), true, "AccessGroupsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group", false, false, null, null, (short)1, new Guid("15d48624-f880-44be-96b9-afe2f03606ac"), "/main/accessGroups/accessGroups" },
                    { new Guid("ff97a778-21f2-418f-972f-ad121ea7b93d"), true, "AccessGroupsWithDevicesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile_screen_share", false, false, null, null, (short)2, new Guid("15d48624-f880-44be-96b9-afe2f03606ac"), "/main/accessGroups/accessGroupsDevices" },
                    { new Guid("ff98a778-21f2-418f-972f-ad121ea7b93d"), true, "AccessGroupsWithEmployeesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group_add", false, false, null, null, (short)3, new Guid("15d48624-f880-44be-96b9-afe2f03606ac"), "/main/accessGroups/accessGroupsEmployees" },
                    { new Guid("5430edf1-fb5a-42b9-a942-f52653966df2"), true, "RolesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "people_outline", false, false, null, null, (short)1, new Guid("44db8859-8d41-4a86-97e7-ede5c508b521"), "/main/lookups/roles" },
                    { new Guid("5530edf1-fb5a-42b9-a942-f52653966df2"), true, "GroupRolesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lock_open", false, false, null, null, (short)2, new Guid("44db8859-8d41-4a86-97e7-ede5c508b521"), "/main/usermanagement/group-roles" },
                    { new Guid("5630edf1-fb5a-42b9-a942-f52653966df2"), true, "UsermangmentsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_identity", false, false, null, null, (short)3, new Guid("44db8859-8d41-4a86-97e7-ede5c508b521"), "/main/usermanagement/usermangments" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("3687834b-5960-4c26-983f-6373eb58b1c3"), true, "EmployeesFingerprintComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)1, new Guid("6cb30dd3-944c-4426-8893-a3d1dae2455e"), "/main/attendance/employees-fingerprint" },
                    { new Guid("3887834b-5960-4c26-983f-6373eb58b1c3"), true, "EmployeeManualLogsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)2, new Guid("6cb30dd3-944c-4426-8893-a3d1dae2455e"), "/main/attendance/employee-manual-logs" },
                    { new Guid("3787834b-5960-4c26-983f-6373eb58b1c3"), true, "EmployeeAttendancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)3, new Guid("6cb30dd3-944c-4426-8893-a3d1dae2455e"), "/main/attendance/employee-attendances" },
                    { new Guid("71dee0cc-c1b7-461e-9951-91bfa0b0206f"), true, "DeviceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)1, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/device-report" },
                    { new Guid("71dee0cc-c1b7-461e-9451-91bfa0b0208f"), true, "DeviceConnectEmployeesReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)2, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/device-connectemployees-report" },
                    { new Guid("23cdd125-2105-4612-a779-216afd714ae8"), true, "EmployeeTransactionReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)3, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/employee-transaction-report" },
                    { new Guid("e9e3fa9d-76ef-4b2c-b4d5-e43753a546ba"), true, "DeviceConnectGroupReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)4, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/device-connect-group-report" },
                    { new Guid("fa9d5ed4-5cdb-435a-b163-daff47e86ee1"), true, "EmployeeConnectDeviceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)5, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/employee-connect-device-report" },
                    { new Guid("568fc80c-9a7d-4063-bb6b-88cc61b82d31"), true, "EmployeeLocationReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)6, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/employee-location-report" },
                    { new Guid("9cb358bb-2be3-451a-8e19-8e85aa845017"), true, "UnKnownUserReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)7, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/un-knownUser-report" },
                    { new Guid("9cb358bb-2be3-451a-8e19-8e85aa915017"), true, "EmployeeAttendanceLogReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "data_usage", false, true, null, null, (short)8, new Guid("c45271ce-6771-42dc-b9fd-1617a42a9103"), "/main/report/employee-attendance-log-report" },
                    { new Guid("93ee3f36-6a95-98e6-b177-8aa86185d91c"), true, "AuditsGridComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "search", false, false, null, null, (short)1, new Guid("93ee3f27-6a95-98e4-b177-8aa86119d90c"), "/main/audits/audits-log" },
                    { new Guid("17b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "GroupsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "groups", false, false, null, null, (short)5, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/groups" },
                    { new Guid("16b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "DevicesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "devices_other", false, false, null, null, (short)4, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/devices" },
                    { new Guid("15b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "LocationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "location_on", false, false, null, null, (short)3, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/locations" },
                    { new Guid("14b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "DepartmentsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "domain", false, false, null, null, (short)2, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/departments" },
                    { new Guid("a937c70f-d295-4a9b-a970-55a44d310b1e"), true, "LeaveInServiceStartBalancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "timeline", false, false, null, null, (short)5, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/lookups/leave-inservice-start-balance" },
                    { new Guid("c466e9c7-fc23-4bec-bb17-a7a1da945632"), true, "PreviousLeavesBalancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "timeline", false, false, null, null, (short)4, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/leaves/previous-leaves-balances" },
                    { new Guid("e6a82e92-137b-47ca-a073-72e730b82c6d"), true, "TeamsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "group_add", false, false, null, null, (short)3, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/duties/teams" },
                    { new Guid("c456e9c7-fc23-4bec-bb17-a7a1da945632"), true, "AdminmangersComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "supervisor_account", false, false, null, null, (short)2, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/usermanagement/adminmangers" },
                    { new Guid("c446e9c7-fc23-4bec-bb17-a7a1da945632"), true, "EmployeesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "account_circle", false, false, null, null, (short)1, new Guid("2e043af4-0ed3-417a-a592-639c84c9b090"), "/main/usermanagement/employees" },
                    { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd57"), false, "OrganizationOvertimeRegulationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)21, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/organization-overtime-regulations" },
                    { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd56"), false, "OrganizationLatesRegulationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)20, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/organization-lates-regulations" },
                    { new Guid("9389daad-0c9f-47ba-825b-bc37d119bd50"), false, "AbsencesRegulationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)19, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/absences-regulations" },
                    { new Guid("9389daad-0c9f-46ba-825b-bc37d119bd47"), true, "DevicesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perm_device_information", false, false, null, null, (short)18, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/devices" },
                    { new Guid("9289daad-0c9f-46ba-825b-bc37d119bd47"), true, "LateRegulationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gavel", false, false, null, null, (short)17, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/late-regulations" },
                    { new Guid("9189daad-0c9f-46ba-825b-bc37d119bd47"), true, "OvertimeDatesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_add", false, false, null, null, (short)16, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/overtime-dates" },
                    { new Guid("9089daad-0c9f-46ba-825b-bc37d119bd47"), true, "AllowancesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_on", false, false, null, null, (short)13, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/allowances" },
                    { new Guid("8929daad-0c9f-44ba-825b-bc37d119bd47"), true, "LeaveRegulationLitesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "subject", false, false, null, null, (short)15, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/leaves-regulation-lites" },
                    { new Guid("8989daad-0c9f-46ba-825b-bc37d119bd47"), true, "LeaveRegulationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "subject", false, false, null, null, (short)15, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/leaves-regulations" },
                    { new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b15"), true, "DeductionMemoComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)4, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/deduction-memo" },
                    { new Guid("8889daad-0c9f-46ba-825b-bc37d119bd47"), true, "LeavetypesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "weekend", false, false, null, null, (short)14, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/leavetypes" },
                    { new Guid("8689daad-0c9f-46ba-825b-bc37d119bd47"), true, "FullDayPermissionsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "card_travel", false, false, null, null, (short)11, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/fullDayPermissions" },
                    { new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), true, "LocationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "location_on", false, false, null, null, (short)9, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/locations" },
                    { new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), true, "HolidaysComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "date_range", false, false, null, null, (short)10, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/holidays" },
                    { new Guid("8320daad-1c9f-46ba-825b-bc37d119bd47"), true, "AdmistrativeLevelsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "domain", false, false, null, null, (short)8, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/admistrativeLevel" },
                    { new Guid("8389daad-0c9f-46ba-825b-bc37d119bd47"), true, "ContractTypesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "import_contacts", false, false, null, null, (short)7, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/contract-types" },
                    { new Guid("8289daad-0c9f-46ba-825b-bc37d119bd47"), true, "JobDegreesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "trending_up", false, false, null, null, (short)6, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/jobDegrees" },
                    { new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), true, "JobsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", false, false, null, null, (short)5, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/jobs" },
                    { new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), true, "QualificationsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "school", false, false, null, null, (short)4, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/qualifications" },
                    { new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), true, "ReligionsComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brightness_3", false, false, null, null, (short)3, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/religions" },
                    { new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), true, "NationalitiesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "flag", false, false, null, null, (short)2, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/nationalities" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationScreens",
                columns: new[] { "Id", "CanShow", "ComponentName", "CreatedBy", "CreatedDate", "IconName", "IsDelete", "IsReport", "ModifiedBy", "ModifiedDate", "OrderNumber", "ParentId", "UrlPath" },
                values: new object[,]
                {
                    { new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), true, "CountriesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "public", false, false, null, null, (short)1, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/countries" },
                    { new Guid("32aab175-d4fd-6408-8e8a-590dabaa6b14"), true, "ChangeEmployeeTotalLateInAndOutComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)1, new Guid("18c02133-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/hrs/change-employee-total-late-in-and-out" },
                    { new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe990"), true, "EmployeesAbsencesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fingerprint", false, false, null, null, (short)2, new Guid("18c02133-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/hrs/employees-absences" },
                    { new Guid("13b748c1-a7c5-4ea4-a41b-ee73f87abb1e"), true, "BranchesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "location_city", false, false, null, null, (short)1, new Guid("13adfe94-2fa7-4046-a2c4-118ae00a5cbe"), "/main/lookups/branches" },
                    { new Guid("8789daad-0c9f-46ba-825b-bc37d119bd47"), true, "PartialPermissionTypesComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alarm_off", false, false, null, null, (short)12, new Guid("15655108-4a92-4bd8-8e81-cc174f86eebc"), "/main/lookups/partial-permission-types" },
                    { new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b19"), true, "EmployeeAbsenceReportComponent", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book", false, true, null, null, (short)3, new Guid("18c02122-1ea5-4e4e-a6e2-ec0ce5c310ef"), "/main/memos/employee-absences-report" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationUserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ddfbaefa-1981-4849-adb0-a5e6f53f9105"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("20000000-2000-2000-2000-200000000000"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309") },
                    { new Guid("ddfbaefa-1981-4849-adb0-a5e6f48f9904"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("10000000-1000-1000-1000-100000000000"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9309") }
                });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[,]
                {
                    { new Guid("d96baab4-5a25-491c-843f-e4516550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f308-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e9536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db79584c-f208-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e8536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e7536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e6536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e5536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e3536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8389daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4526550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e2536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8289daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4536550d6a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4536550d6a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4536550d6a4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("39b5a6d5-c6d1-4860-9ab3-2719c905dbd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9302") },
                    { new Guid("38b5a6d5-c6d1-4860-9ab3-2719c905dbd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9302") },
                    { new Guid("37b5a6d5-c6d1-4860-9ab3-2719c905dbd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9302") },
                    { new Guid("d96baab4-5a25-491c-843f-e1536550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d98baab4-5a25-491c-843f-e4593550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("ac1dc6d4-b2c6-4adb-a3a8-dfd896757658") },
                    { new Guid("d96baab4-5a25-491c-843f-e4546550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4566550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab6-5a25-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79524c-f508-481a-8a89-a8a1904bc1fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") },
                    { new Guid("d96baab5-5a25-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79524c-f408-481a-8a89-a8a1904bc1fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79524c-f308-481a-8a89-a8a1904bc1fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") },
                    { new Guid("d96baab3-5a25-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db79524c-f208-481a-8a89-a8a1904bc1fc"), new Guid("21df3c86-c767-4dde-989e-f8675987dcad") },
                    { new Guid("d96baab6-5a41-491c-843f-e4593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79523c-f508-491a-1a79-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab7-5a25-491c-843f-e2593550d6a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4593550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4592550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4596590d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db79584c-f205-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4596580d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("db79584c-f204-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4596570d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81533"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4596560d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("10efc918-ef1f-409a-a0b3-ee5d35932997"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4596550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81522"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") },
                    { new Guid("d96baab4-5a25-491c-843f-e4586550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58044"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") }
                });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab4-5a25-491c-843f-e4576550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, null, null, new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58011"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("d96baab4-5a25-491c-843f-e4556550d6a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("db79584c-f608-481a-8a89-a8a1904bc1fc"), new Guid("91df3c86-c767-4dde-989e-f3675987dcad") });

            migrationBuilder.InsertData(
                table: "PackageModules",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsChecked", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "PackageId" },
                values: new object[] { new Guid("36b5a6d5-c6d1-4860-9ab3-2719c905dbd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("ddfbaefa-1981-4849-adb0-a5e6f58f9302") });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("46f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("96aa5880-d5dc-48c5-9c5d-e1cc516b410b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-491a-1a79-a8a1904bc1fc"), new Guid("32aab175-d4fd-6408-8e8a-590dabaa6b14") },
                    { new Guid("96aa5470-d5dc-48c5-9c5d-e1cc516b410b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("e4e72d50-86d5-4eea-a2c6-f02f3cd2d2b6") },
                    { new Guid("6bde3850-3b65-4854-a389-ae4d7d641827"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b19") },
                    { new Guid("6bde3850-3b65-4854-a389-ae4d7d641826"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b15") },
                    { new Guid("6bde3850-3b65-4854-a389-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-481a-8a79-a8a1904bc1fc"), new Guid("32aab175-d4fd-4108-8e8a-590dabaa6b14") },
                    { new Guid("a5714e40-5892-42f3-a44e-1c41ea59cef6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-33a1-48ce-bde3-103bdde75431") },
                    { new Guid("a5393e20-4290-44f1-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f308-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-33a1-48ce-bde3-103bdde71332") },
                    { new Guid("a5723e40-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("146d3f84-33a1-48ce-bde3-103bdde71331") },
                    { new Guid("a5714e40-5891-42f3-a44e-1c41ea59cef6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("df1dbf09-302e-4b1d-94c6-76a3d0eb4560") },
                    { new Guid("a5383e90-4295-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("2db422f3-f497-4301-abfe-58995a1e18f1") },
                    { new Guid("a5363e90-4790-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("2db422f3-f497-4301-abfe-58995a1e17f0") },
                    { new Guid("a5723e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("06d10572-1a5e-4723-a49b-718e15a8641f") },
                    { new Guid("a5723e10-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f207-481a-8a89-a8a1904bc1fc"), new Guid("b926e9c7-fc23-4bec-aa17-a7a1da945631") },
                    { new Guid("a5663e90-4590-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("b926e9c7-fc23-4bec-aa17-a7a1da945632") },
                    { new Guid("a5383e90-4191-42f3-a44e-1c41ea49cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("c536e9c7-fc23-4bec-bb17-a7a1da945652") },
                    { new Guid("224e2621-b59d-44ae-b7c2-f0cf435b052b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945552") },
                    { new Guid("a5363e90-4290-44f3-a44e-2c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f208-481a-8a89-a8a1904bc1fc"), new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945652") },
                    { new Guid("a5393e90-4290-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f308-481a-8a89-a8a1904bc1fc"), new Guid("8770758b-7c07-4412-b42d-e45d119d2cd4") },
                    { new Guid("a5383e90-4292-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("e1398770-5fad-443f-afdd-dd45b212a0cb") },
                    { new Guid("a5383e90-4293-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("5c3e00bf-d07b-4df3-8dc6-f8889d1c5fb2") },
                    { new Guid("a5383e90-4294-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("2f45cc65-78db-4479-90a8-075987f02e81") },
                    { new Guid("64f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("d556e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("74f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e666e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5373e90-5891-42f3-a44e-1c52ea59cef9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79523c-f508-491a-1a79-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe990") },
                    { new Guid("13f31845-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e666e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("65f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("b926e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("14f31445-9bba-478c-8da9-e8439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c526e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5363e90-4590-44f3-a44e-3c41ea72cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("e36edfa2-4ec6-4ad5-9c3f-463b4256c319") },
                    { new Guid("83f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e37edfa2-5ec6-4ad5-9c3f-463b4256c319") },
                    { new Guid("13f31945-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e38edfa3-5bc6-4bd5-9c3f-463b4256c319") },
                    { new Guid("a5363e90-4690-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("e39edfb2-5ec6-4ad5-9c3f-473b4256c319") },
                    { new Guid("82f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("a826e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5383e90-4290-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f308-481a-8a89-a8a1904bc1fc"), new Guid("8770758b-7c07-4412-b42d-e45d119d2cd3") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba3a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("13b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba3a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("15b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("4b3d689f-48b4-440e-b123-c92177e33754"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("9cb358bb-2be3-451a-8e19-8e85aa845017") },
                    { new Guid("0c5299f8-5f9b-4bd7-bbcc-ff530cc449f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("568fc80c-9a7d-4063-bb6b-88cc61b82d31") },
                    { new Guid("bede2bab-006d-493b-b55a-14c66e12b804"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("fa9d5ed4-5cdb-435a-b163-daff47e86ee1") },
                    { new Guid("ef60cf7e-fb29-4e8a-9d0f-0234675f0c52"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("e9e3fa9d-76ef-4b2c-b4d5-e43753a546ba") },
                    { new Guid("5a3ed7d0-9949-4f5b-8b61-7d794546a963"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("23cdd125-2105-4612-a779-216afd714ae8") },
                    { new Guid("8432be1f-13d8-4338-bf2a-207cf76aeeda"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("71dee0cc-c1b7-461e-9451-91bfa0b0208f") }
                });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("8822be1f-13d8-4338-bf2a-207cf76aeeda"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("71dee0cc-c1b7-461e-9951-91bfa0b0206f") },
                    { new Guid("ba1667c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3787834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1707c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3887834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1567c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3687834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1965c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("5630edf1-fb5a-42b9-a942-f52653966df2") },
                    { new Guid("ba1964c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("5530edf1-fb5a-42b9-a942-f52653966df2") },
                    { new Guid("ba1963c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("5430edf1-fb5a-42b9-a942-f52653966df2") },
                    { new Guid("ba1967c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("ff98a778-21f2-418f-972f-ad121ea7b93d") },
                    { new Guid("ba1867c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("ff97a778-21f2-418f-972f-ad121ea7b93d") },
                    { new Guid("ba1767c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("ff96a778-21f2-418f-972f-ad121ea7b93d") },
                    { new Guid("3bde3840-3b65-4854-a229-ae5d7d641830"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3227834b-5240-4c26-983f-6373eb58b1c3") },
                    { new Guid("56f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("16b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba3a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("16b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba3a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("17b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba4a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("18b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba5a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("19b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba6a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("20b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba3a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("14b748c1-a7c5-4ea4-a41b-ee73f87abb1e") },
                    { new Guid("ba1967c5-521c-496b-b4bc-48e4fc8ba9a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("20b748c1-a7c5-4ea4-a41b-ee73f87abb3e") },
                    { new Guid("204c3270-0af9-46b3-8e41-723e46f106d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("759e7936-8211-4adc-ad85-0863a0962156") },
                    { new Guid("3fae5b5b-a08d-4f9e-81d8-970e94022e20"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("f07cb184-9472-4d7e-a89d-555ed666f397") },
                    { new Guid("58f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("3387834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba7a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3387834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1467c5-521c-496b-b4bc-48e4fc8ba9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3587834b-5960-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1567c5-521c-496b-b3bc-48e4fc5ba9a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("3587834b-5240-4c26-983f-6373eb58b1c3") },
                    { new Guid("ba1567c5-521c-496b-b4bc-48e4fc8ba9a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("20b248c1-a7c5-4ea4-a31b-ee73f87abb3e") },
                    { new Guid("a5383e90-4291-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f408-481a-8a89-a8a1904bc1fc"), new Guid("7538a848-3cda-4acf-a128-f64dbab21899") },
                    { new Guid("a5383e90-4291-42f3-a14e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b75") },
                    { new Guid("a5383e90-4291-42f3-a24e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b70") },
                    { new Guid("14f31445-9bba-478c-8da9-e7439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c496e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("13f31345-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("73f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c476e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("13f31645-9bba-478c-8da9-e6439f75d0a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("a937c70f-d295-4a9b-a970-55a44d310b1b") },
                    { new Guid("13f31645-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("a937c70f-d295-4a9b-a970-55a44d310b1e") },
                    { new Guid("13f31545-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c466e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5383e90-4191-42f3-a44e-1c41ea39cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("e6a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("a5383e90-4191-42f3-a44e-1c41ea29cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("c456e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("224e2621-b59d-44ae-b8c2-f0cf435b052b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c446e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("c9638ab7-a62a-4d5b-9b5f-b747dffa498d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd57") },
                    { new Guid("64866d8a-0d78-400b-9eb6-f84a5ac0bf0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd56") },
                    { new Guid("1e238bdd-ee34-460b-9e60-571f00f0f57f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-47ba-825b-bc37d119bd50") },
                    { new Guid("56f31445-9bba-178c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("9389daad-0c9f-46ba-825b-bc37d119bd47") }
                });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("a5363e90-4290-44f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f208-481a-8a89-a8a1904bc1fc"), new Guid("9289daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("a5363e90-4290-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("9189daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("a5363e90-4590-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("9089daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("74f22445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8929daad-0c9f-44ba-825b-bc37d119bd47") },
                    { new Guid("47f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("48f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("49f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("57bdf3c4-58fd-4527-b5e3-f4dcff74ed88"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("50f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8289daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("51f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8389daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("81f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c506e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("52f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8320daad-1c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("53f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("14f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8589daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8689daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("80f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8089daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8789daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("72f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7989daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8889daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("13f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8889daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("13f31245-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8989daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("54f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47") },
                    { new Guid("a5463e90-4590-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("c486e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5563e90-4590-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-33e9-4d0c-84dc-c3fde422b225"), new Guid("1226e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("55f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("c516e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5323e92-5191-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f205-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe956") },
                    { new Guid("a5353e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe959") },
                    { new Guid("a5373e90-5851-42f3-a44e-1c52ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-3309-aa0b-f350ba8fe999") },
                    { new Guid("a5383e90-4291-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f608-481a-8a89-a8a1904bc1fc"), new Guid("93ee3f36-6a95-98e6-b177-8aa86185d85c") },
                    { new Guid("a5373e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("93ee3f36-6a95-98e6-b188-7aa76185d75c") },
                    { new Guid("2bde3830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58044"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") },
                    { new Guid("a5363e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe950") },
                    { new Guid("3bde3830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("10efc918-ef1f-409a-a0b3-ee5d35932997"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") },
                    { new Guid("5bde3830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81522"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") },
                    { new Guid("6bde3830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8441f18d-17ba-4974-9f8b-d74472f81533"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") },
                    { new Guid("13f31745-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8489daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("ab168b4b-4c18-4208-aa0b-f350ba8fe933") },
                    { new Guid("a5383e90-5191-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f204-481a-8a89-a8a1904bc1fc"), new Guid("39aab175-d4fd-4108-8e8a-590dabaa6b44") },
                    { new Guid("a5383e90-4291-42f3-a44e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("36aab155-d4fd-4508-8e8a-590dabaa6b44") },
                    { new Guid("a5383e90-4291-42f3-a34e-1c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f508-481a-8a89-a8a1904bc1fc"), new Guid("36aab188-d4fd-4508-8e8a-590dabaa6b68") },
                    { new Guid("4bde3830-3b65-4854-a289-ae4d7d641825"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("40144a96-b6b3-4aae-bb68-3a9d27c58011"), new Guid("54ee3f36-6a95-98e6-b177-8aa861850001") },
                    { new Guid("4b3d749f-48b4-440e-b123-c92177e33754"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("9cb358bb-2be3-451a-8e19-8e85aa915017") },
                    { new Guid("a5343e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4209-aa0b-f350ba8fe949") },
                    { new Guid("a5323e90-5891-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f206-481a-8a89-a8a1904bc1fc"), new Guid("ab268b4c-4c18-4208-aa0b-f350ba8fe929") },
                    { new Guid("a5363e90-4390-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("1234e9c7-fc23-4bec-bb17-a7a1da945632") },
                    { new Guid("a5363e90-4490-44f3-a44e-3c41ea52cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("cbdf8448-34e9-4d0c-84dc-c3fde922b225"), new Guid("c13acb26-6d39-40e9-831d-2dbcc01c0b5a") }
                });

            migrationBuilder.InsertData(
                table: "ModuleScreens",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDelete", "ModifiedBy", "ModifiedDate", "ModuleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("62f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e1a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("88f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8289daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e2a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("84f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e3a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("85f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e4a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("a5323e91-5191-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f205-481a-8a89-a8a1904bc1fc"), new Guid("ab368b4c-4c18-4208-aa0b-f350ba8fe929") },
                    { new Guid("86f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8189daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e5a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("12f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8389daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e8a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("59f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("90ee3f27-6a95-46e4-b177-8aa86115d85c") },
                    { new Guid("ba3f5f24-d71d-4eda-99b1-ceaf4ae6e84d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("91ee3f27-6a95-46e4-b177-8aa86115d85c") },
                    { new Guid("60f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7789daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("92ee3f27-6a95-46e4-b177-8aa86115d85c") },
                    { new Guid("a5383e90-4191-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f708-481a-8a89-a8a1904bc1fc"), new Guid("93ee3f27-6a95-46e4-b177-8aa86115d85c") },
                    { new Guid("a5323e90-5191-42f3-a44e-1c41ea59cef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("db79584c-f205-481a-8a89-a8a1904bc1fc"), new Guid("ab168b4c-4c18-4208-aa0b-f350ba8fe929") },
                    { new Guid("63f31445-9bba-478c-8da9-e6439f75d0a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("7889daad-0c9f-46ba-825b-bc37d119bd47"), new Guid("e7a82e92-137b-47ca-a073-72e730b82c6d") },
                    { new Guid("3bde3830-3b65-4854-a289-ae5d7d641830"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new Guid("8ab7725e-f567-4e4d-9030-febb7af94162"), new Guid("93ee3f36-6a95-98e6-b177-8aa86185d91c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleScreens_ModuleId",
                table: "ModuleScreens",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleScreens_ScreenId",
                table: "ModuleScreens",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationHosts_HostApiDataId",
                table: "OrganizationHosts",
                column: "HostApiDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationHosts_OrganizationId",
                table: "OrganizationHosts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicencesModules_ModuleId",
                table: "OrganizationLicencesModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicencesModules_OrganizationLicenseId",
                table: "OrganizationLicencesModules",
                column: "OrganizationLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenses_ApplicationId",
                table: "OrganizationLicenses",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenses_OrganizationId",
                table: "OrganizationLicenses",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationLicenses_PackageId",
                table: "OrganizationLicenses",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_TimeZoneId",
                table: "Organizations",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationScreens_ParentId",
                table: "OrganizationScreens",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_ActiveDirectoryPrimaryKeyId",
                table: "OrganizationSetting",
                column: "ActiveDirectoryPrimaryKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationSetting_OrganizationId",
                table: "OrganizationSetting",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUserRoles_RoleId",
                table: "OrganizationUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUserRoles_UserId",
                table: "OrganizationUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModules_ModuleId",
                table: "PackageModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageModules_PackageId",
                table: "PackageModules",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleScreens");

            migrationBuilder.DropTable(
                name: "OrganizationHosts");

            migrationBuilder.DropTable(
                name: "OrganizationLicencesModules");

            migrationBuilder.DropTable(
                name: "OrganizationServers");

            migrationBuilder.DropTable(
                name: "OrganizationSetting");

            migrationBuilder.DropTable(
                name: "OrganizationUserRoles");

            migrationBuilder.DropTable(
                name: "PackageModules");

            migrationBuilder.DropTable(
                name: "SettingActualWorkings");

            migrationBuilder.DropTable(
                name: "OrganizationScreens");

            migrationBuilder.DropTable(
                name: "HostApiDatas");

            migrationBuilder.DropTable(
                name: "OrganizationLicenses");

            migrationBuilder.DropTable(
                name: "ActiveDirectoryKey");

            migrationBuilder.DropTable(
                name: "ActiveDirectoryPrimaryKey");

            migrationBuilder.DropTable(
                name: "OrganizationRoles");

            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "TimeZones");
        }
    }
}
