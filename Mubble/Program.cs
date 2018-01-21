using Mubble.Core;
using Mubble.Core.Events;
using Mubble.Core.Logger;
using System;
using System.IO;
using System.Reactive.Linq;
using System.Reflection;

namespace Mubble
{
    public static class Program
    {
        static void Main(string[] args)
        {
            CreatePluginsFolder();

            var host = new Host();
            SubscribeLogs(host);
            host.Start();

            Console.ReadKey();
        }

        private static string GetRunningDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        private static void CreatePluginsFolder()
        {
            var path = GetRunningDirectory() + "/Plugins";
            Directory.CreateDirectory(path);
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
