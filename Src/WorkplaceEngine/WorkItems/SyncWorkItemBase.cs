using System.Threading;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Synchronous work item base class
    /// </summary>
    public abstract class SyncWorkItemBase : WorkItemBase, ISyncWorkItem
    {
        public void WorkHard(CancellationToken cancel)
        {
            if (cancel.IsCancellationRequested)
                return;

            Start();
            WorkHardInternal(cancel);
            Finish();
        }

        protected abstract void WorkHardInternal(CancellationToken cancel);
    }
}
