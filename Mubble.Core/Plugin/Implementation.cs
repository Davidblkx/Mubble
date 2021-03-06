﻿namespace Mubble.Core.Plugin
{
    /// <summary>
    /// Used by service container to store service instance and version
    /// </summary>
    public struct Implementation
    {
        public Implementation(object value, SemVersion version)
        {
            Value = value;
            Version = version;
        }

        public object Value { get; }
        public SemVersion Version { get; }
    }
}
