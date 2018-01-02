using Mubble.Core.Func;
using System;

namespace Mubble.Core.Events
{
    public interface IMubbleEvent
    {
        Guid Id { get; }
        string Type { get; }
        Option Payload { get; }
        DateTime Timestamp { get; }
        string Source { get; }
    }

    public interface IMubbleEvent<T> : IMubbleEvent
    {
        new Option<T> Payload { get; }
    }
}
