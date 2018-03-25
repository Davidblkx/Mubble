using Mubble.Core;
using Mubble.Core.Plugin;
using System;
using System.Collections.Generic;

namespace BasicLogger
{
    public class Plugin : IMubblePlugin
    {
        public IPluginInfo Info
            => new PluginInfo();

        public SemVersion Version
            => new SemVersion(0, 0, 1);

        public long LoadPriority => 3;

        public IEnumerable<Dependency> Dependencies
            => new List<Dependency>();

        public bool Initialize(IMubbleHost host)
        {
            return true;
        }
    }
}
