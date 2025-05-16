

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.StandardInfrastructure
{
    public interface ISendMail
    {
        Task Send(string mailTo, string body, string subject, string logo=null, bool supportHtml = false, byte[] reportBytes = null);
        string GetBody(string body, bool isMobile = false);
        string GetWorkFlowBody(string nameAr, string nameEn, string bodyAr, string bodyEn, string url,string logo);
    }
}
