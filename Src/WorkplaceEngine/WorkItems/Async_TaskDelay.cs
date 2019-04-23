using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Fully asynchronous I/O operation simulation using Task.Delay
    /// </summary>
    [Description("Task Delay")]
    public class Async_TaskDelay : AsyncWorkItemBase
    {
        protected override async Task WorkHardInternal(CancellationToken cancel)
        {
            for (long l = 0; l < TotalWorkUnitCount; l++)
            {
                if (cancel.IsCancellationRequested)
                    break;

                await Task.Delay(100);

                Progress(1);
            }
        }
    }
}
