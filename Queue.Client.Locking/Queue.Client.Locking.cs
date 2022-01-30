using System;
using Queue.Common;
using System.Threading;
using System.Collections.Generic;

namespace Queue.Client.Locking
{
    public class Client
    {
        static readonly object syncLock = new object();
        static int SharedCount = 0;

        public static void Main()
        {
            IQueue<Job> queue = new Queue.NonLocking.PriorityQueue<Job>();

            List<Thread> addThreads = new List<Thread>();
            List<Thread> runThreads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                addThreads.Add(new Thread(AddItems));
                runThreads.Add(new Thread(ProcessJobs));
            }

            addThreads.ForEach(t => t.Start(queue));
            addThreads.ForEach(t => t.Join());

            runThreads.ForEach(t => t.Start(queue));
            runThreads.ForEach(t => t.Join());

            Console.WriteLine($"Total Jobs: {SharedCount}");
        }

        private static void AddItems(object queueParam)
        {
            IQueue<Job> queue = queueParam as IQueue<Job>;

            // assign random priorities
            Random rnd = new Random();

            for (int actionId = 0; actionId < 50000; actionId++)
            {
                lock (syncLock)
                {
                    queue.Enqueue(new Job(rnd.Next()));
                }
            }
        }

        private static void ProcessJobs(object queueParam)
        {
            int count = 0;
            IQueue<Job> queue = queueParam as IQueue<Job>;

            while (queue.Count > 0)
            {
                Job j = null;
                lock (syncLock)
                {
                    if (queue.Count > 0)
                    {
                        j = queue.Dequeue();
                    }
                }

                if (j != null)
                {
                    j.Process();
                    count++;
                    if (count % 5000 == 0)
                    {
                        Console.WriteLine("{0} - Processed {1} jobs", Thread.CurrentThread.ManagedThreadId, count);
                    }

                    Interlocked.Increment(ref SharedCount);
                }
            }

            Console.WriteLine("{0} - Processed {1} jobs (DONE)", Thread.CurrentThread.ManagedThreadId, count);
        }
    }
}
