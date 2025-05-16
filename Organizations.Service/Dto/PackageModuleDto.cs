using System;
using System.Collections.Generic;
using System.Text;

namespace Organizations.Service.Dto
{
   public class PackageModuleDto
    {
        public Guid Id { get; set; }
        public string NameFl { get; set; }
        public string NameSl { get; set; }
        public List<Guid> PackageId { get; set; }

    }
    public class PackageModuleCheckedDto
    {
        public Guid Id { get; set; }
        public string NameFl { get; set; }
        public string NameSl { get; set; }
        public bool? IsChecked { get; set; }

    }
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string NameFl { get; set; }
        public string NameSl { get; set; }
        public Guid ApplicationId { get; set; }

    }
}
