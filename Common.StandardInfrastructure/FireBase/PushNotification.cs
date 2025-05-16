using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.StandardInfrastructure.CommonDto;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

// ReSharper disable StringLiteralTypo

namespace Common.StandardInfrastructure.FireBase
{
    public class PushNotification : IPushNotification
    {
        private readonly string _serverKey;
        private readonly string _projectId = "apex-push-e9457"; // Replace with your project ID
        private readonly string _serviceAccountFilePath = "apex-push-e9457-firebase-adminsdk-yvbp0-8aea2cdc7f.json"; // Replace with your service account JSON file path
        private readonly string SingPageUrl;

        public PushNotification(IConfiguration configuration)
        {
            _serverKey = configuration.GetSection("FCM:ServerKey").Value;
            SingPageUrl = configuration["SingPageUrl"];

        }

        public async Task SendNotification1(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null)
        {
            
            if (!string.IsNullOrWhiteSpace(topic) || users.Count == 1)
            {
                var obj = new PushToTopicOrOneDevice
                {
                    Notification = notification,
                    To = string.IsNullOrWhiteSpace(topic) ? users.FirstOrDefault()?.Token : $"/topics/{topic}"
                };
                await Send(obj);
            }
            else
            {
                var count = 0;
                const int passNumber = 999;
                while (users.Skip(count).Any())
                {
                    var obj = new PushToMultipleDevice()
                    {
                        Notification = notification,
                        RegistrationIds = users.Skip(count).Take(passNumber).Select(t => t.Token).ToArray()
                    };
                    await Send(obj);
                    count += passNumber;
                }
            }

        }

        public async Task SendNotification(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null)
        {
            if (!string.IsNullOrWhiteSpace(topic) || users.Count == 1)
            {
                var recipient = string.IsNullOrWhiteSpace(topic) ? users.FirstOrDefault()?.Token : $"/topics/{topic}";

                var notif = new
                {
                    message = new
                    {
                        token = string.IsNullOrWhiteSpace(topic) ? recipient : null, // Use token if not sending to a topic
                        topic = !string.IsNullOrWhiteSpace(topic) ? topic : null, // Use topic if sending to a topic
                        notification = new
                        {
                            title = notification.Title,
                            body = notification.Body,
                        },
                        android = new
                        {
                            notification = new
                            {
                                sound = "default"
                            }
                        },
                        apns = new
                        {
                            payload = new
                            {
                                aps = new
                                {
                                    sound = "default"
                                }
                            }
                        }
                    }
                };




            var messagePayload = new
                {
                    message = new
                    {
                        token = string.IsNullOrWhiteSpace(topic) ? recipient : null, // Use token if not sending to a topic
                        topic = !string.IsNullOrWhiteSpace(topic) ? topic : null, // Use topic if sending to a topic
                        notification = new
                        {
                            title = notification.Title,
                            body = notification.Body,

                        },
                        android = new
                        {
                            notification = new
                            {
                                sound = "default"
                            },
                        },
                        apns = new
                        {
                            payload = new
                            {
                                aps = new
                                {
                                    sound = "default"
                                },
                            },
                        },
                        //,
                        //data = new
                        //{
                        //    click_action = "pushNotificationActionPerformed",
                        //    route = SingPageUrl 
                        //}
                    
                }
                };

                await Send(notif);
            }
            else
            {                
                foreach (var user in users)
                {
                    var notif = new
                    {
                        message = new
                        {
                            token = user.Token,
                            notification = new
                            {
                                title = notification.Title,
                                body = notification.Body,
                            },
                            android = new
                            {
                                notification = new
                                {
                                    sound = "default"
                                }
                            },
                            apns = new
                            {
                                payload = new
                                {
                                    aps = new
                                    {
                                        sound = "default"
                                    }
                                }
                            }
                        }
                    };


                    var messagePayload = new
                    {
                        message = new
                        {
                            token = user.Token,
                            notification = new
                            {
                                title = notification.Title,
                                body = notification.Body,
                                sound = "default"

                            },
                         android = new
                         {
                             notification = new
                             {
                                 sound = "default"
                             },
                         },
                            apns = new
                            {
                                payload = new
                                {
                                    aps = new
                                    {
                                        sound = "default"
                                    },
                                },
                            },
                        },
                      
                        //,
                        //data = new
                        //{
                        //    click_action = "pushNotificationActionPerformed",
                        //    route = SingPageUrl 
                        //}
                    
                    };

                    await Send(notif);
                }
            }
        }
        public async Task SendNotificationForThirdSign(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null)
        {
            if (!string.IsNullOrWhiteSpace(topic) || users.Count == 1)
            {
                var recipient = string.IsNullOrWhiteSpace(topic) ? users.FirstOrDefault()?.Token : $"/topics/{topic}";

                var messagePayload = new
                {
                    message = new
                    {
                        token = string.IsNullOrWhiteSpace(topic) ? recipient : null, // Use token if not sending to a topic
                        topic = !string.IsNullOrWhiteSpace(topic) ? topic : null, // Use topic if sending to a topic
                        notification = new
                        {
                            title = notification.Title,
                            body = notification.Body,
                        },
                        android = new
                        {
                            notification = new
                            {
                                sound = "default"
                            }
                        },
                        apns = new
                        {
                            payload = new
                            {
                                aps = new
                                {
                                    sound = "default"
                                }
                            }
                        }

                    }
                };

                await Send(messagePayload);
            }
            else
            {
                foreach (var user in users)
                {
                    var messagePayload = new
                    {
                        message = new
                        {
                            token = user.Token,
                            notification = new
                            {
                                title = notification.Title,
                                body = notification.Body
                            },
                            android = new
                            {
                                notification = new
                                {
                                    sound = "default"
                                }
                            },
                            apns = new
                            {
                                payload = new
                                {
                                    aps = new
                                    {
                                        sound = "default"
                                    }
                                }
                            }
                            //,                          
                            //data = new
                            //{
                            //    click_action = "pushNotificationActionPerformed", 
                            //    route = SingPageUrl 
                            //}
                        }
                    };

                    await Send(messagePayload);
                }
            }
        }

        private async Task<string> GetAccessToken()
        {
            GoogleCredential credential = GoogleCredential.FromFile(_serviceAccountFilePath)
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");

            var token = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
            return token;
        }        
        public async Task Send(object obj)
        {
            string accessToken = await GetAccessToken();

            var client = new RestClient($"https://fcm.googleapis.com/v1/projects/{_projectId}/messages:send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {accessToken}");
            request.AddHeader("Content-Type", "application/json");

            var value = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", value, ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
        //private async Task Send(object obj)
        //{
        //    var client = new RestClient("https://fcm.googleapis.com/v1/fcm/message") { Timeout = -1 };


        //    var request = new RestRequest(Method.POST);
        //    var tt = $"Bearer {_serverKey}";
        //    request.AddHeader("Authorization", $"key: {_serverKey}");
        //    request.AddHeader("Content-Type", "application/json");
        //    var value = JsonConvert.SerializeObject(obj);
        //    request.AddParameter("application/json", value, ParameterType.RequestBody);
        //    var response = await client.ExecuteAsync(request);
        //    Console.WriteLine(response.Content);
        //}
    }

    public interface IPushNotification
    {
        Task SendNotification(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null);
        Task SendNotification1(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null);
        Task SendNotificationForThirdSign(List<UserNotificationDto> users, PushNotificationItem notification, string topic = null);
    }
}
