using System;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Execution
{
    /// <summary>
    /// Execution snapshot contains information about work items
    /// processing so far and used threads.
    /// </summary>
    public class Snapshot
    {
        /// <summary>
        /// Work items state
        /// </summary>
        public WorkProgress[] State { get; }

        /// <summary>
        /// Used threads state
        /// </summary>
        public ThreadInfo[] Threads { get; }

        public Snapshot(WorkProgress[] state, ThreadInfo[] threads)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
            Threads = threads ?? throw new ArgumentNullException(nameof(threads));
        }
    }
}
