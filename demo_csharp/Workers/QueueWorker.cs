using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;

namespace demo_csharp.Workers
{
    public class QueueWorker : IMasterWorker
    {
        public void Do()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Count);

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
        }
    }
}
