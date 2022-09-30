using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class CountingSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, array.Max());
        }
        public static void Sort(int[] array, int max)
        {
            int[] counts = new int[max + 1];
            foreach (var item in array) counts[item]++; //increment
            var index = 0;
            for (var i = 0; i < counts.Length; ++i) //coping x times TO OUTPUT array
                for (var j = 0; j < counts[i]; j++) array[index++] = i; 
        }
    }
}
