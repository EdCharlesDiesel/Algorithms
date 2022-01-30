using System;
using Queue.Common;
using System.Threading;
using System.Collections.Generic;

namespace Queue.Client
{
    class JobProcessor
    {
        readonly IQueue<Job> queue;
        object syncLock = new object();
        List<Thread> runThreads = new List<Thread>();

        private volatile bool aborted = false;
        private volatile int completed = 0;

        public int Completed => completed;

        public int Remaining => queue.Count;

        // the first exception the processor encounters
        public Exception Exception
        {
            get;
            private set;
        }

        public JobProcessor(IQueue<Job> queue)
        {
            this.queue = queue;
        }

        public void Wait()
        {
            runThreads.ForEach(t => t.Join());
        }

        private void Abort(Exception ex)
        {
            // only store the first exception thrown
            if (Exception == null)
            {
                // check-lock-check pattern as
                // Abort may be called concurrently
                lock (syncLock)
                {
                    if (Exception == null)
                    {
                        Exception = ex;
                        aborted = true;
                    }
                }
            }
        }

        public void Load(int jobs)
        {
            // assign random priorities
            Random rnd = new Random();

            queue.Clear();
            for (int i = 0; i < jobs; i++)
            {
                queue.Enqueue(new Job(rnd.Next()));
            }
        }

        public void ProcessInParallel(int threads)
        {
            runThreads.Clear();

            for (int i = 0; i < threads; i++)
            {
                runThreads.Add(new Thread(ProcessJobs));
            }

            runThreads.ForEach(t => t.Start(queue));
        }

        private void ProcessJobs(object queueParam)
        {
            int count = 0;
            IQueue<Job> queue = queueParam as IQueue<Job>;

            try
            {
                while (queue.Count > 0 && !aborted)
                {
                    Job j = queue.Dequeue();
                    j.Process();
                    count++;

                    Interlocked.Increment(ref completed);
                }
            }
            catch (QueueEmptyException)
            {
                // ignore
            }
            catch (Exception ex)
            {
                Abort(ex);
            }
            finally
            {
                Console.WriteLine("{0} - Processed {1} jobs", Thread.CurrentThread.ManagedThreadId, count);
            }
        }
    }
}
