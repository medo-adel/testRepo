namespace Common.StandardInfrastructure.Events
{
    public class RabbitMqSetting
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueStarter { get; set; }
    }
}
