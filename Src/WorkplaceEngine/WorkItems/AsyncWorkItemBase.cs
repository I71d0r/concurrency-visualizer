using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Base class for asynchronous work items
    /// </summary>
    public abstract class AsyncWorkItemBase : WorkItemBase, IAsyncWorkItem
    {
        public async Task WorkHard(CancellationToken cancel)
        {
            if (cancel.IsCancellationRequested)
                return;

            Start();
            await WorkHardInternal(cancel);
            Finish();
        }

        protected abstract Task WorkHardInternal(CancellationToken cancel);
    }
}
