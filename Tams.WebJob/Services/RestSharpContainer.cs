using RestSharp;
using System.Net;

namespace Tams.WebJob.Services
{
    public class RestSharpContainer
    {
        private readonly RestClient _client;
        private readonly string _serverUri;

        public RestSharpContainer(string serverUri)
        {
            _serverUri = serverUri;
            _client = new RestClient { Timeout = Timeout.Infinite, ReadWriteTimeout = Timeout.Infinite };
        }
        public async Task SendRequest(string uri, Method method, string accessToken = null, object obj = null)
        {
            _client.CookieContainer = new CookieContainer();
            var request = new RestRequest($"{_serverUri}{uri}", method);
            if (method == Method.POST || method == Method.PUT)
            {
                request.AddJsonBody(obj);
            }
            if (accessToken != null) request.AddHeader("Authorization", accessToken);
            await _client.ExecuteAsync(request);
        }
        public async Task<T> SendRequest<T>(string uri, Method method, string accessToken = null, object obj = null)
        {
            _client.CookieContainer = new CookieContainer();
            var request = new RestRequest($"{_serverUri}{uri}", method);
            if (method == Method.POST || method == Method.PUT)
            {
                request.AddJsonBody(obj);
            }
            if (accessToken != null) request.AddHeader("Authorization", accessToken);
            var response = await _client.ExecuteAsync<T>(request);
            return response.Data;
        }
    }
}
