using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class Array
    {
        private int[] Items { get; set; }
        private int Count { get; set; }
        public Array(int length)
        {   //constructor
            Items = new int[length];
            Count = 0;
        }

        private int[] Allocate() 
        {
            int[] newItems = new int[Count * 2];
            for (int i = 0; i < Items.Length; ++i) newItems[i] = Items[i];
            return newItems;
        }
        
        public void Insert(int value)
        {   //o(n)
            if (Items.Length == Count) Items = Allocate();
            Items[Count] = value;
            Count++;
        }

        private void AllocateForRemove(int index) { for (int i = index; i < Count; i++) Items[i] = Items[i + 1]; }//for delete
        public void Remove(int index)
        {   //o(n)
            if (index >= Count || index < 0) throw new Exception();
            if (index != Count - 1) AllocateForRemove(index);
            Count--;
        }

        public int IndexOf(int item)
        {   //o(n)
            for (int i = 0; i < Count; ++i) if (Items[i] == item) return i;
            return -1;
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < Count; i++) str += Items[i] + " ";
            return str;
        }
    }
}
