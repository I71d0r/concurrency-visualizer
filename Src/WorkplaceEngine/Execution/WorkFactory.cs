using System;
using System.Linq;
using WorkplaceEngine.Contract;

namespace WorkplaceEngine.Execution
{
    /// <summary>
    /// Work items generator
    /// </summary>
    public static class WorkFactory
    {
        static readonly Random randomizer = new Random();

        /// <summary>
        /// Generates a workload using reflection
        /// </summary>
        /// <typeparam name="TWorkItem">Work item type</typeparam>
        /// <param name="minItemSize">Item minimal work units count</param>
        /// <param name="maxItemSize">Item maximal work units count</param>
        /// <param name="itemCount">Total item count to generate</param>
        /// <param name="itemTypes">Array of types of work items to randomly choose from</param>
        /// <param name="processorType">Items processor type</param>
        /// <returns>New executor instance with a work load respecting given constraints</returns>
        public static Executor<TWorkItem> GenerateWork<TWorkItem>(
                int minItemSize,
                int maxItemSize,
                int itemCount,
                Type[] itemTypes,
                Type processorType)
            where TWorkItem : IWorkItem
        {
            if (itemCount < 1)
                throw new ArgumentOutOfRangeException($"{nameof(itemCount)} < 1");
            if (minItemSize > maxItemSize)
                throw new ArgumentOutOfRangeException($"{nameof(minItemSize)} is greater than {nameof(maxItemSize)}");
            if (itemTypes == null)
                throw new ArgumentNullException(nameof(itemTypes));
            if (itemTypes.Length == 0)
                throw new ArgumentException($"{nameof(itemTypes)} are empty");
            if (itemTypes.Any(t => !typeof(TWorkItem).IsAssignableFrom(t)))
                throw new ArrayTypeMismatchException($"Item types cannot be casted to {nameof(TWorkItem)}");
            if (processorType == null)
                throw new ArgumentNullException(nameof(processorType));
            if (!typeof(IWorkItemProcessor<TWorkItem>).IsAssignableFrom(processorType))
                throw new ArgumentException($"Processor type cannot be casted to {nameof(IWorkItemProcessor<TWorkItem>)}");


            var items = new TWorkItem[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                items[i] = (TWorkItem)Activator.CreateInstance(itemTypes[GetRandomNumber(0, itemTypes.Length)]);
                items[i].Initialize(GetRandomNumber(minItemSize, maxItemSize));
            };

            // TODO: Maybe processor has no parameterless constructor, the exception would be quite cryptic.
            return new Executor<TWorkItem>(items, (IWorkItemProcessor<TWorkItem>)Activator.CreateInstance(processorType));
        }

        private static int GetRandomNumber(int min, int max)
            => min == max ? min : randomizer.Next(min, max);
    }
}
