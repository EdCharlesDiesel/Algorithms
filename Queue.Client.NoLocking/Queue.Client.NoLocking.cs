using System;
using Queue.Common;
using System.Threading;
using System.Collections.Generic;

namespace Queue.Client.NoLocking
{
    public class Client
    {
        static int SharedCount = 0;

        public static void Main()
        {
            IQueue<Job> queue = new Locking.PriorityQueue<Job>();

            List<Thread> addThreads = new List<Thread>();
            List<Thread> runThreads = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                addThreads.Add(new Thread(AddItems));
                runThreads.Add(new Thread(ProcesJobs));
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
                queue.Enqueue(new Job(rnd.Next()));
            }
        }

        private static void ProcesJobs(object queueParam)
        {
            int count = 0;
            IQueue<Job> queue = queueParam as IQueue<Job>;

            while (queue.Count > 0)
            {
                Job j = queue.Dequeue();
                j.Process();
                count++;
                if (count % 5000 == 0)
                {
                    Console.WriteLine("{0} - Processed {1} jobs", Thread.CurrentThread.ManagedThreadId, count);
                }

                Interlocked.Increment(ref SharedCount);
            }

            Console.WriteLine("{0} - Processed {1} jobs (DONE)", Thread.CurrentThread.ManagedThreadId, count);
        }
    }
}
