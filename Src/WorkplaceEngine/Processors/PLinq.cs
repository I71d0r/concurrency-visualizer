using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes synchronous work items using PLinq
    /// </summary>
    [Description("PLinq")]
    public class PLinq : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel, TaskScheduler scheduler)
        {
            items.AsParallel().ForAll(i => i.WorkHard(cancel));
        }
    }
}
