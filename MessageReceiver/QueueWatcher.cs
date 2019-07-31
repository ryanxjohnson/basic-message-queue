using System.Collections.Generic;
using System.Timers;

namespace MessageReceiver
{
    public class QueueWatcher
    {
        private Timer t = new Timer();

        public void Start()
        {
            t.Interval = 1000;
            t.Elapsed += (s, e) => { PrintMessage(MSMQFake.ClientQueue.ReceieveMessage()); };
            t.Start();
        }

        public void Stop()
        {
            t.Stop();
        }

        private void PrintMessage(IEnumerable<MSMQFake.MyMessage> messages)
        {
            foreach (var message in messages)
            {
                System.Console.WriteLine($"ID: {message.MessageId}\r\nValue: {message.MessageValue}");
            }
        }
    }
}
