using Mubble.Core.Func;
using System.Threading.Tasks;

namespace Mubble.Core.Config
{
    /// <summary>
    /// Handles read/write of app configuration
    /// </summary>
    public interface IConfigManager
    {
        string ConfigFilePath { get; }

        Task<Option<T>> Get<T>(string key);
        Task Set<T>(string key, T value);
        Task<bool> Delete<T>(string key);
        Task<bool> IsAvaible<T>(string key);
    }
}
