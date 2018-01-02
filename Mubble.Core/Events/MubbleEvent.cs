using System;
using System.Reactive.Linq;
using Mubble.Core.Func;

namespace Mubble.Core.Events
{
    public class MubbleEvent<T> : IMubbleEvent<T>
    {
        public MubbleEvent()
            => InitNewEvent("System", "Unkown", Option.None<T>());

        public MubbleEvent(string type, string source)
            => InitNewEvent(source, type, Option.None<T>());

        public MubbleEvent(string type, string source, T payload)
            => InitNewEvent(source, type, Option.Some(payload));

        public MubbleEvent(IMubbleEvent source)
        {
            Id = source.Id;
            Timestamp = source.Timestamp;
            Type = source.Type;
            Payload = source.Payload.ToTyped<T>();
        }

        private void InitNewEvent(string source, string type, Option<T> payload)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
            Type = type;
            Payload = payload;
            Source = source;
        }

        public Guid Id { get; private set; }
        public string Type { get; private set; }
        public Option<T> Payload { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Source { get; private set; }

        Guid IMubbleEvent.Id { get { return Id; } }
        string IMubbleEvent.Type { get { return Type; } }
        Option IMubbleEvent.Payload { get { return Payload; } }
        DateTime IMubbleEvent.Timestamp { get { return Timestamp; } }
        string IMubbleEvent.Source { get { return Source; } }

        public override string ToString()
        {
            return $"{Source}:{Type}";
        }
    }
}
