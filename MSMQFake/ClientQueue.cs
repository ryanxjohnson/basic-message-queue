using Experimental.System.Messaging;
using System;
using System.Collections.Generic;

namespace MSMQFake
{
    public static class ClientQueue
    {
        private const string QueueName = @".\Private$\MyQueue";
        public static void SendMessage(MyMessage message)
        {
            try
            {
                MessageQueue messageQueue = null;

                if (MessageQueue.Exists(QueueName))
                {
                    messageQueue = new MessageQueue(QueueName);
                }
                else
                {
                    MessageQueue.Create(QueueName);
                    messageQueue = new MessageQueue(QueueName);
                }

                messageQueue.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static IEnumerable<MyMessage> ReceieveMessage()
        {
            var list = new List<MyMessage>();
            MessageQueue messageQueue = new MessageQueue(QueueName);

            try
            {
                foreach (Message message in messageQueue.GetAllMessages())
                {
                    message.Formatter = new XmlMessageFormatter(new Type[1] { typeof(MyMessage) });
                    list.Add((MyMessage)message.Body);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                messageQueue.Purge();
            }

            return list;
        }
    }
}
