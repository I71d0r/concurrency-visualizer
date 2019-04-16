using System;

namespace WorkplaceEngine.Contract
{
    public class WorkProgress
    {
        public int[] WorkThreadIds { get; }
        public long Progess { get; }
        public long Total { get; }
        public WorkState State { get; }

        public WorkProgress(WorkState state, long progress, long total, int[] threadIds)
        {
            if (total == 0)
                throw new ArgumentOutOfRangeException($"Total number of work units has to be greater than zero.");
            if (progress > total)
                throw new ArgumentOutOfRangeException($"Progress {progress} cannot be bigger than total {total} work units.");
            if (state == WorkState.NotStarted && progress > 0)
                throw new InvalidOperationException($"Work cannot be no started when there are {progress}/{total} work units processed already.");

            State = state;
            Progess = progress;
            Total = total;

            WorkThreadIds = threadIds ?? throw new ArgumentNullException(nameof(threadIds));
        }
    }
}
