
using System.Xml.Linq;

namespace Queue
{
    class Program
    {
        static void Main()
        {

            Queue<int> CSharpQueue = new Queue<int>();  //Interface = Class, Implementation
            CSharpQueue.Enqueue(10);
            CSharpQueue.Enqueue(20);
            CSharpQueue.Enqueue(30);
            CSharpQueue.Enqueue(40);
            var Front = CSharpQueue.Dequeue();
            Console.WriteLine(Front);
            Console.WriteLine(String.Join(", " ,CSharpQueue.ToArray()));
            reverse(CSharpQueue);
            Console.WriteLine("Reversed vith Stack: "+String.Join(", ", CSharpQueue.ToArray()));

            Console.WriteLine("////////////");
            Console.WriteLine();
            QueueArray queueArray = new QueueArray();
            queueArray.Enqueue(10);
            queueArray.Enqueue(20);
            queueArray.Enqueue(30);
            queueArray.Enqueue(40);
            queueArray.Enqueue(50);
            queueArray.Enqueue(60);

            Console.WriteLine(queueArray.Dequeue());
            Console.WriteLine(queueArray);


            Console.WriteLine("////////////");
            Console.WriteLine();



           Console.WriteLine("////////////");
           Console.WriteLine("");
            QueueCyrcular queueCyrcular = new QueueCyrcular();
            queueCyrcular.Enqueue(10);
            queueCyrcular.Enqueue(20);
            queueCyrcular.Enqueue(30);
            queueCyrcular.Enqueue(40);
            queueCyrcular.Enqueue(50);
           Console.WriteLine(queueCyrcular.Dequeue());
            queueCyrcular.Enqueue(60);
           Console.WriteLine(queueCyrcular.Dequeue());
           Console.WriteLine(queueCyrcular.Dequeue());
            queueCyrcular.Enqueue(70);
           Console.WriteLine(queueCyrcular);

           Console.WriteLine("////////////");
           Console.WriteLine("");
            QueueStack queueStack = new QueueStack();
            queueStack.Enqueue(10);
            queueStack.Enqueue(20);
            queueStack.Enqueue(30);
           Console.WriteLine(queueStack.Dequeue());
           Console.WriteLine(queueStack);

           Console.WriteLine("////////////");
           Console.WriteLine("");
            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Enqueue(40);
            priorityQueue.Enqueue(20);
            priorityQueue.Enqueue(60);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(2);
           Console.WriteLine(priorityQueue.Dequeue());
           Console.WriteLine(priorityQueue);
        }


        public static void reverse(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0) stack.Push(queue.Dequeue());
            while (stack.Count > 0) queue.Enqueue(stack.Pop());
            //q [10, 20, 30]		[]					[30, 20, 10]
            //s						[10, 20, 30]		[]
        }
    }
}