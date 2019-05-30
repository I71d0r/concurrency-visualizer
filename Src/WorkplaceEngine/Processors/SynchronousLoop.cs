using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes synchronous work items via simple flat loop
    /// </summary>
    [Description("Synchronous Loop")]
    public class SynchronousLoop : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel, TaskScheduler scheduler)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (cancel.IsCancellationRequested)
                    break;

                items[i].WorkHard(cancel);
            }
        }
    }
}
