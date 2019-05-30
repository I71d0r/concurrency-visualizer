using System.Threading;
using System.Threading.Tasks;

namespace WorkplaceEngine.Contract
{
    /// <summary>
    /// Work item processor
    /// </summary>
    /// <typeparam name="TWorkItem">Work item type</typeparam>
    public interface IWorkItemProcessor<TWorkItem>
        where TWorkItem : IWorkItem
    {
        /// <summary>
        /// Processes given work items
        /// </summary>
        /// <param name="items">Items to process</param>
        /// <param name="cancel">Cooperative cancellation token</param>
        void Process(TWorkItem[] items, CancellationToken cancel, TaskScheduler scheduler);
    }
}
