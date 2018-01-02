using Mubble.Core;
using Mubble.Core.Events;
using Mubble.Core.Func;
using Mubble.Core.Logger;
using System;
using System.Reactive.Linq;

namespace Mubble
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var host = new Host();
            SubscribeLogs(host);
            host.Start();

            Console.ReadKey();
        }

        private static void SubscribeLogs(IMubbleHost host)
        {
            host.Events
                .Where(e => e.Type == EventsType.Core.LOG)
                .Subscribe(LogEvents);
        }

        private static void LogEvents(IMubbleEvent e)
        {
            var info = e.Payload.ToTyped<ILog>();
            info.Some(i =>
            {
                Console.WriteLine($"${e.Source}");
                Console.WriteLine(i.ToString());
            });
        }
    }
}
