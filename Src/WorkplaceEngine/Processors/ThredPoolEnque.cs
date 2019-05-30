using System.ComponentModel;
using System.Threading;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes synchronous work items by queuing them as a thread pool work items
    /// </summary>
    [Description("ThredPool QueueUserWorkItem")]
    public class ThredPoolEnque : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel)
        {
            int finishedCount = 0;

            foreach (var item in items)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(o =>
                {
                    item.WorkHard(cancel);
                    Interlocked.Increment(ref finishedCount);
                }));
            }

            //Note: Would have to use Interlocked.Read if finishedCount would be long
			// What about volatile? ;)
            while (finishedCount != items.Length)
            {
                Thread.Sleep(100);
            }
        }
    }
}
