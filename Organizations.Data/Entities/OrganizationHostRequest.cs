using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Data.Entities
{
    public class OrganizationHostRequest : BaseModel
    {
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public Guid HostApiDataId { get; set; }
        public virtual HostApiData HostApiData { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
