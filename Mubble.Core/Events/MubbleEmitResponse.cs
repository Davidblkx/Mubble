using System;

namespace Mubble.Core.Events
{
    public struct MubbleEmitResponse
    {
        public MubbleEmitResponse(bool isError, string message, Guid id)
        {
            IsError = isError;
            Message = message;
            Id = id;
        }

        /// <summary>
        /// If true, an error occur when pushing the event
        /// </summary>
        public bool IsError { get; }

        /// <summary>
        /// Error details
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// The event id
        /// </summary>
        public Guid Id { get; set; }
    }
}
