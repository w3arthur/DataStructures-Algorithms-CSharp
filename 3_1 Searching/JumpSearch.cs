using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class JumpSearch // לחזור!!
    {
        public static int Search(int[] array, int target)
        {
            int blockSize = (int)Math.Sqrt(array.Length);
            int left = 0;
            int right = blockSize;
            while (array[right -1] < target)
            {
                if (left >= array.Length) break;
                left = right;   //if (start >= array.length) break;	//edge case
                right += blockSize;
                if (right > array.Length) right = array.Length;
            }
            for (var i = left; i < right; i++) if (array[i] == target) return i;
            return -1;
        }
    }
}
