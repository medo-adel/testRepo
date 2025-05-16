using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizations.Data.Entities
{
  public  class Organization :BaseModel
    {
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string NickName { get; set; }
        public string Code { get; set; }
        [StringLength(128)]
        public string RegistrationEmail { get; set; }
        [StringLength(128)]
        public string AlternativeEmail { get; set; }
        [Required]
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }
        public string LogoURLFl { get; set; }
        public string LogoURLSl { get; set; }
        public string AdminPassword { get; set; }      
        public bool IsPromise { get; set; }
        public string Encryption { get; set; }
        public List<OrganizationSetting> OrganizationSettings { get; set; }
        public List<OrganizationLicense> OrganizationLicenses { get; set; }
        public List<OrganizationHost> OrganizationHosts { get; set; }

        public Guid? TimeZoneId { get; set; }

        [ForeignKey("TimeZoneId")]
        public virtual TimeZones TimeZones { get; set; }
        public Guid? OrganizationTypeId { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
