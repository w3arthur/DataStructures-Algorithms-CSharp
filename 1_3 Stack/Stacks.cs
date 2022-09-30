using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stacks
    {
        private int[] Items { get; set; }
        private int Count { get; set; }

        public Stacks()
        {
            Items = new int[10];
            Count = 0;
        }

        private bool IsEmpty() { return Count == 0; }

        public void Push(int item)
        {
            if (Items.Length == Count) throw new Exception();
            Items[Count] = item;
            Count++;
        }
        public int Peek()
        {
            if (IsEmpty()) throw new Exception();
            return Items[Count-1];
        }
        public int Pop()
        {
            int peek = Peek();
            Count--;
            return peek;
        }

        public override String ToString()
        {
            return String.Join(", ", Items[0..Count]);
        }
    }
}
