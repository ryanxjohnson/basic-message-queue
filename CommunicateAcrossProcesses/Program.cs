namespace CommunicateAcrossProcesses
{
    class Program
    {
        static void Main(string[] args)
        {
            MSMQFake.ClientQueue.SendMessage(new MSMQFake.MyMessage
            {
                MessageId = "1",
                MessageValue = "Hello"
            });

            System.Console.WriteLine("Checking the queue");

            MSMQFake.ClientQueue.ReceieveMessage();
            System.Console.ReadKey();
        }
    }
}
