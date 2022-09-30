using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort(int[] array, int start, int end)
        { 
            if (start >= end) return;   //base condition (single element / no elements)
            var pivot = PivotSort(array, start, end);
            Sort(array, start, pivot - 1); //Sort left
            Sort(array, pivot + 1, end); //Sort right
        }
        private static int PivotSort(int[] array, int start, int end)
        {
            var pivotSet = array[end];    //!
            var pivot = start - 1; // will be the new partition // right partition starts from index 0
            for (var i = start; i <= end; i++) 
                if (array[i] <= pivotSet) swap(array, i, ++pivot);
            return pivot;    //index of the pivot after its move
        }
        private static void swap(int[] array, int a, int b)
        {
            var tmp = array[a];
            array[a] = array[b];
            array[b] = tmp;
        }
    }
}
