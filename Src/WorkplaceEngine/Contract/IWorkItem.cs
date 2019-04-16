using System.Threading;

namespace WorkplaceEngine.Contract
{
    /// <summary>
    /// Work item
    /// </summary>
    public interface IWorkItem
    {
        /// <summary>
        /// Current work progress
        /// </summary>
        WorkProgress CurrentProgress { get; }

        /// <summary>
        /// Initializes the work item and sets the number of work units
        /// </summary>
        /// <param name="totalWorkUnitCount">Number of work units to process</param>
        void Initialize(long totalWorkUnitCount);

        /// <summary>
        /// Resets the work item to initial state
        /// </summary>
        void Reset();
    }
}
