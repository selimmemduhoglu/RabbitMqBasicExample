using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMqBasicExample
{
    internal class Program
    {
        static string key = "message-queue";
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                SendMessage();
            }
        }

        public static void SendMessage()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://hlxfilsm:z8HI9n6M0caNW4Gr1YQmrhCic56U1pTG@toad.rmq.cloudamqp.com/hlxfilsm");
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(key, true, false, false);
            var message = "Test Message";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(String.Empty, key, null, body);

            Console.WriteLine("Hello world!");

            Console.ReadLine();
        }


    }
}
