using Organizations.Data.Entities.Base;
using System.Collections.Generic;

namespace Organizations.Data.Entities
{
   public class OrganizationServer : BaseModel
    {
        public string ProcessorId { get; set; }
        public string MbId { get; set; }
        public string WindowsId { get; set; }
        public string MacAdressId { get; set; }
        //public virtual ICollection<OrganizationLicense> OrganizationLicenseS { get; set; }
    }
}
