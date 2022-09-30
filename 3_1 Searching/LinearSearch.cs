using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class LinearSearch
    {
        public static int Search(int[] array, int target)
        {
            for (var i = 0; i < array.Length; ++i) if(array[i] == target) return i;
            return -1;
        }
    }
}
