// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Tams.WebJob.Services;

var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

IConfiguration config = configBuilder.Build();
var _jobService = new JobService(config);
var jobType = (JobType)Enum.Parse(typeof(JobType), config["JobType"]);
if (jobType == JobType.Creation) await _jobService.ReccuringJob();
else if (jobType == JobType.OutBox) await _jobService.PublishLogsJob();
else if (jobType == JobType.MobileLogs) await _jobService.ReccuringPullLogsMobileJob();


public enum JobType
{
    Creation = 1,
    OutBox,
    MobileLogs
}
