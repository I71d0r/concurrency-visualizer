using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes synchronous work items by tasking them via Task.Run
    /// </summary>
    [Description("Manual Tasks")]
    public class WaitAllTaskRun : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel)
        {
            Task.WaitAll(items.Select(i => Task.Run(() => i.WorkHard(cancel))).ToArray());
        }
    }
}
