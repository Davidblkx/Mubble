using Mubble.Core.Func;
using System;

namespace Mubble.Core.Logger
{
    public interface ILog
    {
        LogLevel Level { get; }
        string Message { get; }
        DateTime Time { get; }
        Option Details { get; }
    }
}
