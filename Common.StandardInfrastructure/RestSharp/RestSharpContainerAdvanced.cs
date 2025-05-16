using Common.StandardInfrastructure.Communication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Common.StandardInfrastructure.RestSharp
{
    public class RestSharpContainerAdvanced : IRestSharpContainerAdvanced
    {
        private readonly RestClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommuncationSetting _communcationSetting;
        public RestSharpContainerAdvanced(IOptions<CommuncationSetting> options, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = new RestClient { Timeout = Timeout.Infinite, ReadWriteTimeout = Timeout.Infinite };
            _communcationSetting = options.Value;
        }
        public async Task<T> SendRequest<T>(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null)
        {
            if (communcationDecision == CommuncationDecision.Org) uri = $"{_communcationSetting.OrganizationUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.Crystal) uri = $"{_communcationSetting.CrystalReportUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.TamsUrl) uri = $"{_communcationSetting.TamsUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.AumUrl) uri = $"{_communcationSetting.AumUrl}{uri}";

            var request = new RestRequest(uri, method);
            return await MainRequest<T>(request, method, accessToken, obj);
        }
        
        public async Task<IRestResponse> SendRequestWithFullResponse(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null)
        {
            if (communcationDecision == CommuncationDecision.Org) uri = $"{_communcationSetting.OrganizationUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.Crystal) uri = $"{_communcationSetting.CrystalReportUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.TamsUrl) uri = $"{_communcationSetting.TamsUrl}{uri}";
           else if (communcationDecision == CommuncationDecision.AumUrl) uri = $"{_communcationSetting.AumUrl}{uri}";

            var request = new RestRequest(uri, method);
            _client.CookieContainer = new CookieContainer();
            if (method == Method.POST || method == Method.PUT)
            {
                SetJsonContent(request, obj);
            }
            if (accessToken != null) request.AddHeader("Authorization", accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            return await _client.ExecuteAsync(request);
        }
        private async Task<T> MainRequest<T>(RestRequest request, Method method, string accessToken = null, object obj = null)
        {
            _client.CookieContainer = new CookieContainer();

            if (method == Method.POST || method == Method.PUT)
            {
                SetJsonContent(request, obj);
            }
            if (accessToken != null) request.AddHeader("Authorization", accessToken);
            request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
            var response = await _client.ExecuteAsync<T>(request);           
            Log.Information($"Response for URL:- {request.Resource}", response);
            T data;
            try { data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content); }
            catch (Exception e)
            {
                data = default(T);
                Log.Error(e, $"Exception for URL:- {request.Resource} ");
            }
            return data == null ? response.Data : data;
        }
        private void SetJsonContent(RestRequest request, object obj)
        {
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = NewtonsoftJsonSerializer.Default;
            request.AddJsonBody(obj);
        }

        //public async Task<T> SendRequestWithFile<T>(string uri, Method method, CommuncationDecision communcationDecision = CommuncationDecision.External, string accessToken = null, object obj = null)
        //{
        //    if (communcationDecision == CommuncationDecision.Org) uri = $"{_communcationSetting.OrganizationUrl}{uri}";
        //    else if (communcationDecision == CommuncationDecision.Crystal) uri = $"{_communcationSetting.CrystalReportUrl}{uri}";
        //    else if (communcationDecision == CommuncationDecision.TamsUrl) uri = $"{_communcationSetting.TamsUrl}{uri}";
        //    else if (communcationDecision == CommuncationDecision.AumUrl) uri = $"{_communcationSetting.AumUrl}{uri}";

        //    var request = new RestRequest(uri, method);
        //    return await MainRequest2<T>(request, method, accessToken, obj);
        //}
        //private async Task<T> MainRequest2<T>(RestRequest request, Method method, string accessToken = null, object obj = null)
        //{
        //    _client.CookieContainer = new CookieContainer();

        //    if (method == Method.POST || method == Method.PUT)
        //    {
        //        SetJsonContent(request, obj);
        //    }
        //    if (accessToken != null) request.AddHeader("Authorization", accessToken);
        //    request.AddHeader("lang", _httpContextAccessor?.HttpContext?.Request?.Headers["lang"] ?? "en-US");
        //    request.AddHeader("content-length", "8748");
        //    request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundaryZGbGhgf1AkQpoq1Q");
        //    var response = await _client.ExecuteAsync<T>(request);
        //    Log.Information($"Response for URL:- {request.Resource}", response);
        //    T data;
        //    try { data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content); }
        //    catch (Exception e)
        //    {
        //        data = default(T);
        //        Log.Error(e, $"Exception for URL:- {request.Resource} ");
        //    }
        //    return data == null ? response.Data : data;
        //}


    }
}
