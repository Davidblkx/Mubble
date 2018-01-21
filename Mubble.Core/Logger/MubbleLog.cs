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

        public static MubbleLog GetTraceLog(string message)
            => GetLog(LogLevel.Trace, message);

        public static MubbleLog GetDebugLog(string message)
            => GetLog(LogLevel.Debug, message);

        public static MubbleLog GetInfoLog(string message)
            => GetLog(LogLevel.Info, message);

        public static MubbleLog GetWarningLog(string message)
            => GetLog(LogLevel.Warning, message);

        public static MubbleLog GetErrorLog(string message)
            => GetLog(LogLevel.Error, message);

        public static MubbleLog GetFatalLog(string message)
            => GetLog(LogLevel.Fatal, message);

        public override string ToString()
        {
            return $"[{Time.ToString("yyyy-MM-dd|hh:mm:ss")}]{Level}|{Message}";
        }
    }
}