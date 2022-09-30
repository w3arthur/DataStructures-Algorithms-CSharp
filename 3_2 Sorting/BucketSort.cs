using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BucketSort
    {
        public static void Sort(int[] array, int numberOfBuckets)
        {
            var buckets = CreatBuckets(array, numberOfBuckets);
            var index = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort(); //c# quick sort each bucket
                foreach (var item in bucket) array[index++] = item;
            }
        }
        private static List<List<int>> CreatBuckets(int[] array, int numberOfBuckets)
        {
            List<List<int>> buckets = new();    //not initialized
            for (var i = 0; i < numberOfBuckets; ++i) buckets.Add(new()); //initialize each element as list
            foreach (var item in array) buckets[item / numberOfBuckets].Add(item);
            return buckets;
        }

    }
}
