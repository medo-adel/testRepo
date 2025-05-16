using Organizations.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations.Data.Entities
{
    public class HostApiData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string NameFl { get; set; }
        public string NameSl { get; set; }
        public List<OrganizationHost> OrganizationHosts { get; set; }
    }
}
