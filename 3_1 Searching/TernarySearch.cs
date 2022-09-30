using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class TernarySearch
    {
        public static int Search(int[] array, int target)
        {
            return Search(array, target, 0, array.Length - 1);
        }
        private static int Search(int[] array, int target, int left, int right)
        {
            if (right < left) return -1;
            int partitionSize = (right -left)/3;
            int mid1 = left + partitionSize;
            int mid2 = right - partitionSize;
            if (array[mid1] == target) return mid1;
            else if (array[mid2] == target) return mid2;
            else if (target < array[mid1]) return Search(array, target, left, mid1 - 1);
            else if (target < array[mid2]) return Search(array, target, mid1 + 1, mid2 - 1);
            else return Search(array, target, mid2 + 1, right);
        }
    }
}
