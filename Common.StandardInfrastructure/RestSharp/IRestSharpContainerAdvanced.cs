using RestSharp;
using System.Threading.Tasks;

namespace Common.StandardInfrastructure.RestSharp
{
    public interface IRestSharpContainerAdvanced
    {
        Task<T> SendRequest<T>(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null);
        Task<IRestResponse> SendRequestWithFullResponse(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null);
        //Task<T> SendRequestWithFile<T>(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null);

    }
}
