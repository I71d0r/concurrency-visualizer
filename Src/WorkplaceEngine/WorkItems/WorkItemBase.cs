using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.WorkItems
{
    /// <summary>
    /// Base class for executable work item holding the plumbing code
    /// </summary>
    public abstract class WorkItemBase : IWorkItem
    {
        long progress;
        WorkState workState = WorkState.NotInitialized;
        readonly List<int> threadIds = new List<int>();

        protected long TotalWorkUnitCount { get; private set; }
        
        #region IWorkItem

        public WorkProgress CurrentProgress { get; private set; }

        public void Initialize(long totalWorkUnitCount)
        {
            if (totalWorkUnitCount == 0)
                throw new ArgumentOutOfRangeException(nameof(totalWorkUnitCount), "Total work units count has to be greater than zero");

            this.TotalWorkUnitCount = totalWorkUnitCount;
            UpdateProgress(false);

            workState = WorkState.NotStarted;
        }

        public void Reset()
        {
            threadIds.Clear();
            workState = WorkState.NotStarted;
            progress = 0;
            UpdateProgress(false);
        }

        #endregion

        /// <summary>
        /// Makes a progress of given number of work units.
        /// Updates current progress
        /// </summary>
        /// <param name="count">Work units done since the last call</param>
        protected void Progress(int count)
        {
            Interlocked.Add(ref progress, count);
            UpdateProgress(true);
        }

        /// <summary>
        /// Switches to in progress state
        /// Updates current progress
        /// </summary>
        protected void Start()
        {
            if (workState == WorkState.NotInitialized)
                throw new InvalidOperationException($"Work item is not initialized, call {nameof(Initialize)} first");

            workState = WorkState.InProgress;
            UpdateProgress(false);
        }

        /// <summary>
        /// Switches to finished state
        /// Updates current progress
        /// </summary>
        protected void Finish()
        {
            workState = WorkState.Finished;
            UpdateProgress(false);
        }

        private void UpdateProgress(bool addUsedThread)
        {
            if (addUsedThread)
            {
                threadIds.Add(GetCurrentWin32ThreadId());
            }

            CurrentProgress = new WorkProgress(workState, progress, TotalWorkUnitCount, threadIds.ToArray());
        }

        [DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
        public static extern Int32 GetCurrentWin32ThreadId();
    }
}
