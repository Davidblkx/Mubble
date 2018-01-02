using System;
using Mubble.Core.Events;
using Mubble.Core.ServiceContainer;

namespace Mubble.Core
{
    public interface IMubbleHost
    {
        /// <summary>
        /// Observer of events
        /// </summary>
        IObservable<IMubbleEvent> Events { get; }

        /// <summary>
        /// Entry point to handle services
        /// </summary>
        IServiceContainer ServiceContainer { get; }

        MubbleEmitResponse EmitEvent(string type, string source);
        MubbleEmitResponse EmitEvent<T>(string type, string source, T payload);
    }
}
