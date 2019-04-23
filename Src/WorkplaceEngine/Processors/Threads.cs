using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Processors
{
    /// <summary>
    /// Executes synchronous work items by assigning a new thread to each work item 
    /// </summary>
    [Description("Single thread per work item")]
    public class Threads : IWorkItemProcessor<ISyncWorkItem>
    {
        public void Process(ISyncWorkItem[] items, CancellationToken cancel)
        {
            var threads = new Thread[items.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                int index = i; // Make a copy

                var tsi = new ThreadStart(() => items[index].WorkHard(cancel));
                threads[i] = new Thread(tsi);
            }

            threads.AsParallel().ForAll(t => t.Start());

            while (threads.Any(t => t.IsAlive))
            {
                Thread.Sleep(100);
            }
        }
    }
}
