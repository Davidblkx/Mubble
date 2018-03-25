using System.Threading.Tasks;

namespace Mubble.Core.Socket
{
    public interface IMubbleSocketServer
    {
        /// <summary>
        /// Start listening for connections
        /// </summary>
        /// <returns>returns the port used to listening</returns>
        Task<int> Start();


        /// <summary>
        /// Close all connections and stop listening
        /// </summary>
        /// <returns></returns>
        Task Close();
    }
}
