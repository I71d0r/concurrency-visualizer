using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkplaceEngine.Contract
{
    /// <summary>
    /// Used thread information
    /// </summary>
    public class ThreadInfo
    {
        /// <summary>
        /// Thread Id
        /// </summary>
        public int ThreadId { get; }

        /// <summary>
        /// Whether the thread is currently actively used by the application
        /// </summary>
        public bool ActivelyUsed { get; }

        /// <summary>
        /// Ctr.
        /// </summary>
        /// <param name="threadId">Thread Id</param>
        /// <param name="used">Whether the thread is currently actively used by the application</param>
        public ThreadInfo(int threadId, bool used)
        {
            ThreadId = threadId;
            ActivelyUsed = used;
        }
    }
}
