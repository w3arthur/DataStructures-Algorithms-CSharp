using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] array)    //לחזור
        {
            if (array.Length < 2) return;
            int middle =  array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];
            for (var i = 0; i < middle; ++i)  left[i] = array[i];
            for (var i = middle; i < array.Length; ++i) right[i - middle] = array[i];
            Sort(left);
            Sort(right);
            MergSort(left, right, array);
        }
        private static void MergSort(int[] left, int[] right, int[] array)
        {
            int l = 0, r = 0, arr = 0;
            while (l < left.Length && r < right.Length)
            {
                if (left[l] <= right[r]) array[arr++] = left[l++];
                else array[arr++] = right[r++];
            }
            // copy remaining items
            while (l < left.Length) array[arr++] = left[l++];
            while (r < right.Length) array[arr++] = right[r++];
        }
    }
}
