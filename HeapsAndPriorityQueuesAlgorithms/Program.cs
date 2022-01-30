using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ads2_heap;

namespace TaskScheduler
{
    class ScheduledTask : IComparable<ScheduledTask>
    {
        public readonly int Priority;
        public readonly int TaskId;

        public ScheduledTask(int id, int priority)
        {
            Priority = priority;
            TaskId = id;
        }

        public void Execute()
        {
            Console.WriteLine($"Executing task {TaskId} with priority {Priority}");
        }

        public int CompareTo([AllowNull] ScheduledTask other)
        {
            return Priority.CompareTo(other?.Priority);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<ScheduledTask> tasks = new PriorityQueue<ScheduledTask>();
            Random rnd = new Random();
            foreach(var task in Enumerable.Range(1, 100).OrderBy(x => rnd.Next()).Select(i => new ScheduledTask(i, i % 9)))
            {
                tasks.Enqueue(task);
            }

            while(tasks.Count > 0)
            {
                tasks.Deque().Execute();
            }
        }
    }
}
