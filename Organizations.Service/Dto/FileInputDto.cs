using Microsoft.AspNetCore.Http;

namespace Organizations.Service.Dto
{
    public class FileInputDto
    {
        public string OrganizationCode { get; set; }
        public IFormFile File { get; set; }
    }
}
