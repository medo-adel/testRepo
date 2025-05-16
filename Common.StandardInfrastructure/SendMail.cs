using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MimeKit;
using MimeKit.Text;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Common.StandardInfrastructure
{
    public class SendMail : ISendMail
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostingEnvironment;
        public SendMail(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task Send(string mailTo, string body, string subject, string logo=null,bool supportHtml = false, byte[] reportBytes = null)
        {
            try
            {             
                var value = _configuration["Email:Smtp:EnableSSL"];
                var enableSsl = bool.Parse(value);
                var port = int.Parse(_configuration["Email:Smtp:Port"]);
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_configuration["Email:Smtp:FromName"], _configuration["Email:Smtp:Username"]));
                message.To.Add(new MailboxAddress(mailTo, mailTo));
                message.Subject = subject;
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;
                bodyBuilder.TextBody = " ";
                message.Body = new TextPart(supportHtml ? TextFormat.Html : TextFormat.Text) { Text = body };
                //  message.Body = bodyBuilder.ToMessageBody();
                var multipart = new Multipart("mixed");
                
                if (logo != null)
                {
                    var attachment = new MimePart("image", "gif")
                    {  ContentId= Path.GetFileName(logo),
                        Content = new MimeContent(File.OpenRead(logo)),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = Path.GetFileName(logo)
                    };   
                    multipart.Add(attachment);

                }
                // Add the report as an attachment if provided
                if (reportBytes != null)
                {
                    var reportAttachment = new MimePart("application", "pdf")
                    {
                        Content = new MimeContent(new MemoryStream(reportBytes)),
                        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                        ContentTransferEncoding = ContentEncoding.Base64,
                        FileName = "Report.pdf"
                    };
                    multipart.Add(reportAttachment);
                }
                var mainBody = new TextPart(supportHtml ? TextFormat.Html : TextFormat.Text) {Text = body};
                multipart.Add(mainBody);
                message.Body = multipart;

                using var emailClient = new SmtpClient();
                emailClient.Connect(_configuration["Email:Smtp:Host"], port, enableSsl);
                emailClient.Authenticate(_configuration["Email:Smtp:Username"], _configuration["Email:Smtp:Password"]);
                await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }
            catch (Exception e)
            {
                Log.Error(e, "email");
                Console.WriteLine(e);
                throw;
            }
        }
        public string GetBody(string body, bool isMobile = false)
        {
            var url = $"{(isMobile ? _configuration["FrontendUrlMobile"] : _configuration["FrontendUrl"])}reset?token={body}";
            var path = $"{_hostingEnvironment.ContentRootPath}/Templates/ResetPasswordTemplate.html";
            var htmlBody = File.ReadAllText(path);
            htmlBody = htmlBody.Replace("Urllogo", "https://drive.google.com/uc?export=view&id=1VAUJIA2YxqNsq6yE6y-GTm2nI6rKG5o-Tw");
            htmlBody = htmlBody.Replace("[ResetUrl]", url);
            return htmlBody;
        }
        public string GetWorkFlowBody(string nameAr, string nameEn, string bodyAr, string bodyEn, string url, string logo)
        {
            var baseUrl = _configuration["FrontendUrlMobile"] + url;
            var path = $"{_hostingEnvironment.ContentRootPath}/Templates/WorkFlow.html";
            var htmlBody = File.ReadAllText(path);
           // htmlBody = htmlBody.Replace("$Urllogo$", "https://drive.google.com/uc?export=view&id=1VAUJIA2YxqNsq6yE6y-GTm2nI6rKG5o-Tw");
            htmlBody = htmlBody.Replace("$Urllogo$", "cid:"+ Path.GetFileName(@logo));
            htmlBody = htmlBody.Replace("$NameAr$", nameAr);
            htmlBody = htmlBody.Replace("$NameEn$", nameEn);
            htmlBody = htmlBody.Replace("$BodyAr$", bodyAr);
            htmlBody = htmlBody.Replace("$BodyEn$", bodyEn);
            htmlBody = htmlBody.Replace("$URL$", baseUrl);
            return htmlBody;
        }
    }
}
