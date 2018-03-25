using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Mubble.Core;
using Mubble.Core.Events;
using Mubble.Core.Plugin;
using Mubble.Core.ServiceContainer;
using Mubble.Service;

using static Mubble.Core.Events.EventsType.Core;
using static Mubble.Core.Logger.MubbleLog;

namespace Mubble
{
    public class Host : IMubbleHost
    {
        public Host()
        {
            Events = InitEvents();
            ServiceContainer = new ServiceContainer(this);
        }

        public SemVersion Version
            => new SemVersion(0, 0, 1);

        private IObserver<IMubbleEvent> EventSource { get; set; }
        public IObservable<IMubbleEvent> Events { get; }

        public IServiceContainer ServiceContainer { get; }

        private IObservable<IMubbleEvent> InitEvents()
        {
            return Observable.Create(
                (IObserver<IMubbleEvent> source) => {
                    EventSource = source;
                    return Disposable.Empty;
                });
        }

        public MubbleEmitResponse EmitEvent(string type, string source)
        {
            return EmitEvent<string>(type, source, null);
        }

        public MubbleEmitResponse EmitEvent<T>(string type, string source, T payload)
        {
            var e = new MubbleEvent<T>(type, source, payload);
            Task.Run(() => EventSource.OnNext(e));
            return new MubbleEmitResponse(false, "Emit", e.Id);
        }

        public void Start()
        {
            LoadInternalPlugins();
            EmitEvent(INIT, "HOST");
            EmitEvent(LOG, "HOST", GetInfoLog("Mubble initialized"));
        }

        //Load plugins built internly
        private void LoadInternalPlugins()
        {
            ConfigManager.RegisterService(this);
        }
    }
}
