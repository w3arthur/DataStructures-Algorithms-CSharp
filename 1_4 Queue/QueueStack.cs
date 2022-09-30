using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueStack
    {
        private Stack<int> stack1;
        private Stack<int> stack2;
        
        public QueueStack()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        private void ExchangeStacks(Stack<int> stack1, Stack<int> stack2)
        {
            while (stack1.Count != 0) stack2.Push(stack1.Pop());
        }

        public void Enqueue(int value)
        {   //O(1)
            stack1.Push(value); //PUSH, stack = PUSH, queue
        }
        public int Peek()
        {           // O(n)
            if (stack1.Count == 0) throw new Exception();
            ExchangeStacks(stack1, stack2);
            int value = stack1.Peek();
            ExchangeStacks(stack2, stack1);
            return value;
        }
        public int Dequeue()
        {
            if (stack1.Count == 0) throw new Exception();
            ExchangeStacks(stack1, stack2);
            int value = stack1.Pop();
            ExchangeStacks(stack2, stack1);
            return value;
        }

        public override String ToString() { return String.Join(", " ,stack1.ToArray()); }
    }
}
