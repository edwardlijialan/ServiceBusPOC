using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ColService
{
    class MainClass
    {
        const string ServiceBusConnectionString = "Endpoint=sb://memberpoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wwcoaV9GthLVGLhFPAXvqFLZ9G79XvxTLpQhHOvoHJY=";
        const string QueueName = "CrmMemberQueue1";
        static QueueClient queueClient;

        public static void Main(string[] args)
        {
            MainAsyncSendtoQueue().GetAwaiter().GetResult();
            //SendMessage.MainAsyncSend().GetAwaiter().GetResult();
            //ReceiveMessage.MainAsyncReceive().GetAwaiter().GetResult();
        }

        static async Task MainAsyncSendtoQueue()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            // Create a new message to send to the topic.
            string messageBody = $"Message Test";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            // Send the message to the topic.
            await queueClient.SendAsync(message);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }
    }
}
