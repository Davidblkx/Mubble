using Mubble.Core.Func;
using System;

namespace Mubble.Core.Logger
{
    public class MubbleLog : ILog
    {
        public MubbleLog()
            => Details = Option.None();

        public LogLevel Level { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }

        public Option Details { get; set; }

        public static MubbleLog GetLog(LogLevel level, string message)
            => new MubbleLog { Level = level, Message = message, Time = DateTime.Now };

        public static MubbleLog GetTrace(string message)
            => GetLog(LogLevel.Trace, message);

        public static MubbleLog GetDebug(string message)
            => GetLog(LogLevel.Debug, message);

        public static MubbleLog GetInfo(string message)
            => GetLog(LogLevel.Info, message);

        public static MubbleLog GetWarning(string message)
            => GetLog(LogLevel.Warning, message);

        public static MubbleLog GetError(string message)
            => GetLog(LogLevel.Error, message);

        public static MubbleLog GetFatal(string message)
            => GetLog(LogLevel.Fatal, message);

        public override string ToString()
        {
            return $"[{Time.ToString("yyyy-MM-dd|hh:mm:ss")}]{Level}|{Message}";
        }
    }
}