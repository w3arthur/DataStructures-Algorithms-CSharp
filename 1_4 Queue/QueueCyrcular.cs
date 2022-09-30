using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueCyrcular
    {
        private int[] Items { get; set; }
        private int Front { get; set; }
        private int Back { get; set; }
        private int Count { get; set; }

        public QueueCyrcular()
        {
            Items = new int[5];
            Front = 0;
            Back = 0;
            Count = 0;
        }

        private bool IsEmpty() { return Front == Back; }
        private bool IsFull() { return Items.Length == Count; }
        public void Enqueue(int value)
        {
            if (IsFull()) throw new Exception();
            Items[Back] = value;
            Back = (Back +1) % Items.Length;        //!!!    % Items.Length;   
            Count++;
        }
        public int Peek()
        {
            return Items[Front];
        }
        public int Dequeue()
        {
            int peek = Peek();
            Items[Front] = 0;
            Front = (Front + 1) % Items.Length;     //!!!    % Items.Length;   
            Count--;
            return peek;
        }

        public override String ToString() { return String.Join(", " ,Items); }
    }
}
