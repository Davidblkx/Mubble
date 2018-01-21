﻿using System;
using System.Linq;
using System.Collections.Generic;
using Mubble.Core;
using Mubble.Core.Func;
using Mubble.Core.ServiceContainer;
using System.Reactive.Linq;
using Mubble.Core.Events;
using static Mubble.Core.Events.EventsType.ServiceContainer;
using Mubble.Core.Plugin;

namespace Mubble.Service
{
    internal class ServiceContainer : IServiceContainer
    {
        private const string EventSourceName = "INTERNAL.ServiceContainer";

        private readonly Dictionary<Type, Implementation> _container;
        private readonly IMubbleHost _host;

        public ServiceContainer(IMubbleHost host)
        {
            _container = new Dictionary<Type, Implementation>();
            _host = host;
        }

        public bool HasService<T>()
        {
            var type = typeof(T);

            return _container.ContainsKey(type);
        }

        public bool HasService<T>(out T value)
        {
            value = default(T);

            if(_container.TryGetValue(typeof(T), out var obj) && obj.Value is T)
            {
                value = (T)obj.Value;
                return true;
            }

            return false;
        }

        public Option<T> GetService<T>()
        {
            var key = typeof(T);

            if (_container.TryGetValue(key, out var obj) && obj.Value is T)
                return Option.Some((T)obj.Value);

            return Option.None<T>();
        }

        public bool RegisterService<T>(object serviceImplementation, SemVersion version)
        {
            if (!(serviceImplementation is T))
            {
                EmitEvent(ERROR_REGISTER, new SCPayload(typeof(T), serviceImplementation));
                return false;
            }

            var isOverride = HasService<T>();

            _container[typeof(T)] = new Implementation(serviceImplementation, version);
            EmitEvent(REGISTER, SCPayload.Create((T)serviceImplementation, isOverride));

            return true;
        }

        public bool RemoveService<T>()
        {
            var type = typeof(T);
            var success = _container.Remove(type);
            EmitEvent(REMOVE, new SCPayload(type, null, false));
            return success;
        }

        public IEnumerable<Type> ServiceTypes => _container.Keys;
        public IEnumerable<Implementation> ServiceImplementations => _container.Values;

        public IObservable<MubbleEvent<SCPayload>> Events
            => _host.Events
                .Where(e => e.Source == EventSourceName)
                .Select(e => new MubbleEvent<SCPayload>(e));

        private void EmitEvent(string type, SCPayload payload)
        {
            _host.EmitEvent(
                type,
                EventSourceName,
                payload);
        }

        public int MatchService<T>(SemVersion version)
        {
            if (!HasService<T>()) return 0;

            var current = _container[typeof(T)];
            return current.Version.IsCompatible(version) ? 1 : -1;
        }
    }
}
