using System;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening for new messages...");

            var q = new QueueWatcher();
            q.Start();

            Console.ReadKey();
            q.Stop();
        }
    }
}
