using System.Threading;
using System.Threading.Tasks;

namespace WorkplaceEngine.Contract
{
    /// <summary>
    /// Asynchronous work item
    /// </summary>
    public interface IAsyncWorkItem : IWorkItem
    {
        /// <summary>
        /// The real work method
        /// </summary>
        /// <param name="cancel">Cancellation token</param>
        Task WorkHard(CancellationToken cancel);
    }
}
