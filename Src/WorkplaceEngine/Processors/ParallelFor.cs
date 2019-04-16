using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes work items using for cycle provided by Parallel library
    /// </summary>
    [Description("Parallel For")]
    public class ParallelFor : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel)
        {
            Parallel.For(0, items.Length, i =>
            {
                items[i].WorkHard(cancel);
            });
        }
    }
}
