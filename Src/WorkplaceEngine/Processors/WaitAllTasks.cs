using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes asynchronous work items as tasks
    /// </summary>
    [Description("Manual Tasks")]
    public class WaitAllTasks : IWorkItemProcessor<IAsyncWorkItem>
    {
        public void Process(IAsyncWorkItem[] items, CancellationToken cancel, TaskScheduler scheduler)
        {
            Task.WaitAll(items.Select(i => i.WorkHard(cancel)).ToArray());
        }
    }
}
