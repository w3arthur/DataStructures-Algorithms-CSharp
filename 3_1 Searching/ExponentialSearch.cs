using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class ExponentialSearch
    {
        public static int Search(int[] array, int target)
        {
            int right = 1;
            while (array[right] < target) 
            {
                right *= 2;
                if (right >= array.Length) { right = array.Length; break; }
            }
            int[] newArray = array[(right/2)..right];
            int search = Array.BinarySearch(newArray, target);
            return search >= 0 ?  right /2 + search : -1 ;//BinarySearch.SearchRecursion(newArray, target);
        }
    }
}
