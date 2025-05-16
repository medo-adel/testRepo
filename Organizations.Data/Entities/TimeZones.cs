using Organizations.Data.Entities.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Organizations.Data.Entities
{
    public class TimeZones : BaseModel
     {
        public string Name { get; set; }
        public string TimeZone { get; set; }
        public virtual ICollection<Organization> Organization { get; set; } = new Collection<Organization>();

    }
}
