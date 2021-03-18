using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;

namespace demo_csharp.Workers
{
    public class StackWorker : IMasterWorker
    {
        public void Do()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(6);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
        }
    }
}
