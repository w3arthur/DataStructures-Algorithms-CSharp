using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap
    {
        private int[] Items { get; set; }
        private int Counter { get; set; }

        public Heap() {
            Items = new int[10];
            Counter = 0;
        }

        private bool IsFull() { return Items.Length == Counter; }
        public bool IsEmpty() { return Counter == 0; }
        private int Parant(int index) { return (index - 1) / 2; }
        private int ChildLeft(int index) { return index  * 2 + 1; }
        private int ChildRight(int index) { return index  * 2 + 2; }
        private void Swap(int a, int b)
        {
            var temp = Items[a];
            Items[a] = Items[b];
            Items[b] = temp;
        }

        public void Insert(int value)
        {
            if (IsFull()) throw new Exception();    //or extend
            Items[Counter] = value;
            Counter++;
            BubbleUp();

        }
        private void BubbleUp() 
        {
            var index = Counter - 1;    //last
            while (Items[index] > Items[Parant(index)]) 
            {
                Swap(index, Parant(index));
                index = Parant(index);
            }
        }
  
        public int Max() 
        {
            if (IsEmpty()) throw new Exception();
            return Items[0];    //root
        }

        public int Remove() 
        {
            if (IsEmpty()) throw new Exception();
            int temp = Items[0];
            Counter--;
            Items[0] = Items[Counter];
            BubbleDown();
            return temp;
        }
        private void BubbleDown()  // לחזור!
        {
            var index = 0;
            while ( index <= Counter && !isValidParent(index) )
            {
                var largerIndex = LargerChildIndex(index); //ChildLeft(index) >= Counter
                if (largerIndex != index) Swap(index, largerIndex);
                index = largerIndex;
            }
        }
        private bool HasLeftChild(int index) { return ChildLeft(index) <= Counter; }
        private bool HasRightChild(int index) { return ChildRight(index) <= Counter; }
        private int LargerChildIndex(int index)
        {
            if (HasLeftChild(index) && HasRightChild(index))
            {
                if (Items[ChildLeft(index)] > Items[ChildRight(index)]) return ChildLeft(index);
                else return ChildRight(index);
            }
            else if (HasLeftChild(index) && !HasRightChild(index)) return ChildLeft(index);
            else return index;
        }
        private bool isValidParent(int index)
        {
            var isValidLeft = Items[index] >= Items[ChildLeft(index)];
            var isValidRight = Items[index] >= Items[ChildRight(index)];
            if (HasLeftChild(index) && HasRightChild(index)) return isValidLeft && isValidRight;
            if (HasLeftChild(index) && !HasRightChild(index)) return isValidLeft;
            /*if (!HasLeftChild(index))*/ return true;
        }

        public override string ToString()
        {
            return String.Join(", ", Items.Take(Counter));
        }

    }
}
