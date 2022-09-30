using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class PriorityQueue
    {
        private int[] Items { get; set; }
        private int Front { get; set; }
        private int Back { get; set; }

        public PriorityQueue()
        {
            Items = new int[10];
            Front = 0;
            Back = 0;
        }

        private bool IsEmpty() { return Front == Back; }
        private bool IsFull() { return Items.Length == Back + 1; }   // +1 !!!
        public void Enqueue(int value)
        {
            if (IsFull()) throw new Exception();
            for (int i = Back - 1; i >= Front; i--) //הזזה  !!!
            {
                if (Items[i] > value) { Items[i + 1] = Items[i]; }
                else { Items[i + 1] = value; break; }
            }
            Back++;
        }
        public int Peek()
        {
            if (IsEmpty()) throw new Exception();
            return Items[Front];
        }
        public int Dequeue()
        {
            int peek = Peek();
            Front++;    //!
            return peek;
        }

        public override String ToString()
        {
            return String.Join(",", Items[Front..Back]);
        }
    }
}
