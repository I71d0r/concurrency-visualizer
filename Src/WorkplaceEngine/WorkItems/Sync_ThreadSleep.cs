using System.ComponentModel;
using System.Threading;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Emulation of thread waiting
    /// </summary>
    [Description("Thread Sleep")]
    public class Sync_ThreadSleep : SyncWorkItemBase
    {
        protected override void WorkHardInternal(CancellationToken cancel)
        {
            for (long l = 0; l < TotalWorkUnitCount; l++)
            {
                if (cancel.IsCancellationRequested)
                    break;

                Thread.Sleep(10);

                Progress(1);
            }
        }
    }
}
