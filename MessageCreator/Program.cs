using System;

namespace MessageCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            while(true)
            {
                Console.WriteLine("Enter your message");
                var result = Console.ReadLine();

                if (result == "q") break;

                MSMQFake.ClientQueue.SendMessage(new MSMQFake.MyMessage
                {
                    MessageId = count.ToString(),
                    MessageValue = result
                });

                count++;
            }
        }
    }
}
