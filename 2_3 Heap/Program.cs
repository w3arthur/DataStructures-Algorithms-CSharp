using System.Data;

namespace Heap
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("heap");
            Heap heap = new Heap();
            heap.Insert(20);
            heap.Insert(10);
            heap.Insert(5);
            heap.Insert(2);
            Console.WriteLine(heap);
            Console.WriteLine(heap.Remove());
            Console.WriteLine(heap.Remove());

            heap.Insert(30);
            heap.Insert(50);
            Console.WriteLine(heap.Remove());
            Console.WriteLine(heap.Remove());
            Console.WriteLine(heap);
        }

        public static int GetKthLargest(int[] array, int kth)
        {
            if (kth > array.Length || kth < 1) throw new Exception();
            var heap = new Heap();
            foreach (var number in array) heap.Insert(number);

            for (int i = 0; i < kth - 1; i++) heap.Remove();
            return heap.Max();//heap.Remove();
        }



        public static void ArrayHeapify(int[] array)
        {
            for (var i = array.Length / 2 - 1; i >= 0; i--) ArrayHeapify(array, i);
            //for(var i = 0; i < array.length; i++) heapify(array, i);
        }
        private static void ArrayHeapify(int[] array, int i)
        {
            var largerIndex = i;
            var leftIndex = i * 2 + 1;
            var rightIndex = i * 2 + 2;
            if (leftIndex < array.Length && array[leftIndex] > array[largerIndex]) largerIndex = leftIndex;
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex]) largerIndex = rightIndex;
            if (i == largerIndex) return;
            Swap(array, i, largerIndex);

        }
        private static void Swap(int[] array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[a] = temp;
        }
    }




}