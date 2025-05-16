//using System;
//using System.Collections.Generic;
//using System.Text;
//using Newtonsoft.Json;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;

//namespace Common.StandardInfrastructure.Events
//{
    //public static class TamsEvent<T>
    //{
        //public static RabbitMqSetting Setting => AppServicesHelper.RabbitMqConfig;
        //public static void Publish(T tamsEvent, string queueName)
        //{
        //    try
        //    {
        //        var factory = string.IsNullOrWhiteSpace(Setting?.Server) ? new ConnectionFactory() { HostName = "localhost" } : new ConnectionFactory() { HostName = Setting?.Server, UserName = Setting?.Username, Password = Setting?.Password };
        //        using var connection = factory.CreateConnection();
        //        using var channel = connection.CreateModel();
        //        var queue = string.IsNullOrWhiteSpace(Setting?.QueueStarter) ? queueName : $"{Setting.QueueStarter}-{queueName}".Trim();
        //        channel.QueueDeclare(queue: queue,
        //            durable: true,
        //            exclusive: false,
        //            autoDelete: false,
        //            arguments: null);

        //        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tamsEvent));

        //        var properties = channel.CreateBasicProperties();
        //        properties.Persistent = true;

        //        channel.BasicPublish(exchange: "",
        //            routingKey: queue,
        //            basicProperties: properties,
        //            body: body);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //}
        //public static void PublishList(IEnumerable<T> tamsEvent, string queueName)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using var connection = factory.CreateConnection();
        //    using var channel = connection.CreateModel();
        //    channel.QueueDeclare(queue: queueName,
        //        durable: true,
        //        exclusive: false,
        //        autoDelete: false,
        //        arguments: null);

        //    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tamsEvent));

        //    var properties = channel.CreateBasicProperties();
        //    properties.Persistent = true;

        //    channel.BasicPublish(exchange: "",
        //        routingKey: queueName,
        //        basicProperties: properties,
        //        body: body);
        //}
        //public static void Subscribe(string queueName, Action<T> myMethodName)
        //{
        //    try
        //    {
        //        var factory = string.IsNullOrWhiteSpace(Setting?.Server) ? new ConnectionFactory() { HostName = "localhost" } : new ConnectionFactory() { HostName = Setting?.Server, UserName = Setting?.Username, Password = Setting?.Password };
        //        var connection = factory.CreateConnection();
        //        var channel = connection.CreateModel();
        //        var queue = string.IsNullOrWhiteSpace(Setting?.QueueStarter) ? queueName : $"{Setting.QueueStarter}-{queueName}".Trim();
        //        channel.QueueDeclare(queue: queue,
        //            durable: true,
        //            exclusive: false,
        //            autoDelete: false,
        //            arguments: null);

        //        channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        //        var consumer = new EventingBasicConsumer(channel);
        //        T data = default;

        //        consumer.Received += (model, ea) =>
        //        {
        //            var body = ea.Body.ToArray();
        //            var message = Encoding.UTF8.GetString(body);

        //            try
        //            {
        //                data = JsonConvert.DeserializeObject<T>(message);
        //            }
        //            catch (Exception)
        //            {
        //                // ignored
        //            }

        //            // call calculation, or do whatever you want with the data
        //            if (data != null && !data.Equals(default))
        //            {
        //                myMethodName(data);
        //            }

        //            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        //        };
        //        channel.BasicConsume(queue: queue,
        //            autoAck: false,
        //            consumer: consumer);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }


        //}
        //public static void SubscribeList(string queueName, Action<IEnumerable<T>> myMethodName)
        //{
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    var connection = factory.CreateConnection();
        //    var channel = connection.CreateModel();

        //    channel.QueueDeclare(queue: queueName,
        //                         durable: true,
        //                         exclusive: false,
        //                         autoDelete: false,
        //                         arguments: null);

        //    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        //    var consumer = new EventingBasicConsumer(channel);
        //    IEnumerable<T> data = default;

        //    consumer.Received += (model, ea) =>
        //    {
        //        var body = ea.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);

        //        try
        //        {
        //            data = JsonConvert.DeserializeObject<IEnumerable<T>>(message);
        //        }
        //        catch (Exception)
        //        {

        //        }

        //        // call calculation, or do whatever you want with the data
        //        if (data != default)
        //        {
        //            myMethodName(data);
        //        }

        //        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        //    };
        //    channel.BasicConsume(queue: queueName,
        //                         autoAck: false,
        //                         consumer: consumer);

        //}
    //}
//}
