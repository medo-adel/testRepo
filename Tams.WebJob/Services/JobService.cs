using Common.StandardInfrastructure;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Tams.WebJob.Services
{
    //, IHostedService
    public class JobService
    {
        private readonly string BackendUrl;
        public JobService(IConfiguration configuration)
        {
            BackendUrl = configuration["BackendUrl"];
        }
        public async Task ReccuringJob()
        {
            var restClient = new RestSharpContainer(BackendUrl);
            var token = Helper.GenerateToken();
            var organizationsList = await restClient.SendRequest<List<Guid>>($"Organizations/GetOrganizationsIdsList", Method.GET, token);
            var listOfTasks = new List<Task>();
            foreach (var id in organizationsList)
            {
                var creationResult = restClient.SendRequest($"Reports/Creation/{id}", Method.GET, token);
                listOfTasks.Add(creationResult);
            }
            var postResult = restClient.SendRequest($"Request/PostRequests", Method.GET, token);
            var googleDriveSyncLogs = restClient.SendRequest($"LogsDriveSettings/SyncLogsDrive", Method.GET, token);

            listOfTasks.Add(postResult);
            listOfTasks.Add(googleDriveSyncLogs);
            await Task.WhenAll(listOfTasks);
        }
        public async Task PublishLogsJob()
        {
            var restClient = new RestSharpContainer(BackendUrl);
            var token = Helper.GenerateToken();
            await restClient.SendRequest($"Reports/OutBoxVerify", Method.GET, token);
        }
        public async Task ReccuringPullLogsMobileJob()
        {
            var restClient = new RestSharpContainer(BackendUrl);
            var token = Helper.GenerateToken();
            await restClient.SendRequest($"EmployeeAttedanceLogs/TotalMinutesFromParkingToOffice", Method.GET, token);
        }
    }
}
