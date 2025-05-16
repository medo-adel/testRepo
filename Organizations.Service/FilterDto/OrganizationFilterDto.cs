
using System;

namespace Organizations.Service.FilterDto
{
  public  class OrganizationFilterDto
    {
        public string OrganizationNameSl { get; set; }
        public string OrganizationNameFl { get; set; }
        public string NickName { get; set; }
        public string Code { get; set; }     
        public string RegistrationEmail { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
