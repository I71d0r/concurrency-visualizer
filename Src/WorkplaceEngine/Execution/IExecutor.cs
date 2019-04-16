using System;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Execution
{
    /// <summary>
    /// Work items execution interface
    /// </summary>
    public interface IExecutor : IDisposable
    {
        /// <summary>
        /// State of work
        /// </summary>
        WorkState State { get; }

        /// <summary>
        /// Execution method
        /// </summary>
        /// <returns>Execution task</returns>
        Task ExecuteAsync();

        /// <summary>
        /// Cancels the execution
        /// </summary>
        Task CancelAsync();

        /// <summary>
        /// Resets the work items state but keeps the items
        /// </summary>
        void ResetWorkItemsState();

        /// <summary>
        /// Gets all work items current work state
        /// </summary>
        /// <returns>Array of work states</returns>
        WorkProgress[] GetSnapshot();
    }
}
