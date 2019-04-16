using System.Threading;

namespace WorkplaceEngine.Contract
{
    /// <summary>
    /// Synchronous work item
    /// </summary>
    public interface ISyncWorkItem : IWorkItem
    {
        /// <summary>
        /// The real work method
        /// </summary>
        /// <param name="cancel">Cancellation token</param>
        void WorkHard(CancellationToken cancel);
    }
}
