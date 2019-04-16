using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Execution
{
    /// <summary>
    /// Work item pool executor
    /// </summary>
    public class Executor<TWorkItem> : IExecutor
        where TWorkItem : IWorkItem
    {
        readonly TWorkItem[] items;
        readonly IWorkItemProcessor<TWorkItem> itemsProcessor;
        readonly object executionLock = new object();

        CancellationTokenSource cancellation;
        ManualResetEvent runningEvent;

        /// <summary>
        /// Ctr.
        /// </summary>
        /// <param name="itemsToProcess">Item pool to process</param>
        /// <param name="itemsProcessor">Processing delegate</param>
        public Executor(IEnumerable<TWorkItem> itemsToProcess, IWorkItemProcessor<TWorkItem> itemsProcessor)
        {
            if (itemsToProcess == null)
                throw new ArgumentNullException(nameof(itemsToProcess));

            items = itemsToProcess.ToArray();

            if (items.Length == 0)
                throw new ArgumentException("Empty item collection is an invalid workload.");

            this.itemsProcessor = itemsProcessor ?? throw new ArgumentNullException(nameof(itemsProcessor));

            State = WorkState.NotStarted;
        }

        #region  IExecutor

        public WorkState State { get; private set; }

        public async Task ExecuteAsync()
        {
            cancellation?.Dispose();
            cancellation = new CancellationTokenSource();

            runningEvent?.Dispose();
            runningEvent = new ManualResetEvent(initialState: false);

            lock (executionLock)
            {
                if (State == WorkState.Finished)
                    throw new InvalidOperationException("This executor is finished already.");

                if (State == WorkState.InProgress)
                    throw new InvalidOperationException("This executor is running already.");

                if (State == WorkState.Cancelling)
                    throw new InvalidOperationException("This executor is currently canceling the work.");

                State = WorkState.InProgress;
            }

            await Task.Run(() =>
            {
                itemsProcessor.Process(items, cancellation.Token);
            }).ConfigureAwait(false);

            State = WorkState.Finished;

            runningEvent.Set();
        }

        public async Task CancelAsync()
        {
            if (State == WorkState.InProgress)
            {
                bool shouldWaitForCancel = false;

                lock (executionLock)
                {
                    if (State == WorkState.InProgress)
                    {
                        State = WorkState.Cancelling;
                        cancellation.Cancel();
                        shouldWaitForCancel = true;
                    }
                }

                if (shouldWaitForCancel)
                {
                    await Task.Run(() => runningEvent.WaitOne()).ConfigureAwait(false);
                }
            }
        }

        public void ResetWorkItemsState()
        {
            if (State == WorkState.NotStarted || State == WorkState.Finished)
            {
                lock (executionLock)
                {
                    foreach (var item in items)
                    {
                        item.Reset();
                    }

                    State = WorkState.NotStarted;
                }
            }
            else
            {
                throw new InvalidOperationException($"Unable to reset while execution is in state {State}");
            }
        }

        public WorkProgress[] GetSnapshot() => items.Select(i => i.CurrentProgress).ToArray();

        public void Dispose()
        {
            CancelAsync().Wait();
            cancellation?.Dispose();
            runningEvent?.Dispose();
        }

        #endregion
    }
}
