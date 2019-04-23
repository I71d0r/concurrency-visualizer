using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Task executing CPU heavy computations
    /// </summary>
    [Description("CPU Heavy Task")]
    public class Async_CpuHeavyTask : AsyncWorkItemBase
    {
        protected override Task WorkHardInternal(CancellationToken cancel)
            => Task.Run(() =>
            {
                for (long l = 0; l < TotalWorkUnitCount; l++)
                {
                    if (cancel.IsCancellationRequested)
                        break;

                    double p = 0.0;

                    for (int i = 0; i < 1000000; i++)
                    {
                        p += Math.Pow(12.6, 3.2);
                    }

                    Progress(1);
                }
            });
    }
}
