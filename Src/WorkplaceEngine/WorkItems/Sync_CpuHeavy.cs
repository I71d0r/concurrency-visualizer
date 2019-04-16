using System;
using System.ComponentModel;
using System.Threading;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// CPU intensive work item based on real numbers operations
    /// </summary>
    [Description("CPU Heavy")]
    public class Sync_CpuHeavy : SyncWorkItemBase
    {
        protected override void WorkHardInternal(CancellationToken cancel)
        {
            for (long l = 0; l < TotalWorkUnitCount; l++)
            {
                if (cancel.IsCancellationRequested)
                    break;

                double p = 0.0;

                for (int i = 0; i < 100000; i++)
                {
                    p += Math.Pow(12.6, 3.2);
                }

                Progress(1);
            }
        }
    }
}
