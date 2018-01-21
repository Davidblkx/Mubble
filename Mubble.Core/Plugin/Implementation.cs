namespace Mubble.Core.Plugin
{
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
