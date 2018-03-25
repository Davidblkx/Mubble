using System;
using Mubble.Core.Events;
using Mubble.Core.Plugin;
using Mubble.Core.ServiceContainer;

namespace Mubble.Core
{
    public interface IMubbleHost
    {
        /// <summary>
        /// Current version of Mubble
        /// </summary>
        SemVersion Version { get; }

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
