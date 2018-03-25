using System.Collections.Generic;
using Mubble.Core;
using Mubble.Core.Logger;
using Mubble.Core.Plugin;

namespace ConfigManager
{
    public class Plugin : IMubblePlugin
    {
        public IPluginInfo Info
            => new PluginInfo();

        public SemVersion Version
            => new SemVersion(0, 0, 1);

        public long LoadPriority => 5;

        public IEnumerable<Dependency> Dependencies
            => new[]
            {
                new Dependency(typeof(ILogger), 0, 0, 1)
            };


        public bool Initialize(IMubbleHost host)
        {
            return true;
        }
    }
}
