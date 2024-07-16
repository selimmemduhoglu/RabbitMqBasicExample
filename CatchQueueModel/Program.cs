using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CatchQueueModel
{
    internal class Program
    {
        static string key = "message-queue";
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://hlxfilsm:z8HI9n6M0caNW4Gr1YQmrhCic56U1pTG@toad.rmq.cloudamqp.com/hlxfilsm");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(key, true, false, false);

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(key, true, consumer);

            consumer.Received += Consumer_Received;

            Console.ReadLine();

        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Received Message: " + Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}
