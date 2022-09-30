using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class BinarySearch
    {
        public static int SearchIterative(int[] array, int target)
        {
            var left = 0;
            var right = array.Length - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (array[middle] == target) return middle;
                else if (array[middle] > target) right = middle - 1;
                else left = middle + 1;
            }
            return -1;
        }

        public static int SearchRecursion(int[] array, int target)
        {
            return SearchRecursion(array, target, 0, array.Length - 1);
        }
        private static int SearchRecursion(int[] array, int target, int left, int right)
        {
            if (right < left) return -1; //edge race condition
            int middle = (left + right) / 2;
            if (array[middle] == target) return middle;
            else if (target < array[middle]) return SearchRecursion(array, target, left, middle - 1);
            else return SearchRecursion(array, target, middle + 1, right);
        }

    }
}
