namespace Sorting
{
    class Program
    {
        static void Main()
        {
            int[] array;
            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            BubbleSort.Sort(array);
            Console.WriteLine("BubbleSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();

            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            SelectionSort.Sort(array);
            Console.WriteLine("SelectionSort.Sort: " + String.Join(", ", array));
            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            SelectionSort.Sort2(array);
            Console.WriteLine("SelectionSort.Sort2: " + String.Join(", ", array));
            Console.WriteLine();


            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            InsertionSort.Sort(array);
            Console.WriteLine("InsertionSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();

            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            MergeSort.Sort(array);
            Console.WriteLine("MergeSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();

            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            QuickSort.Sort(array);
            Console.WriteLine("QuickSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();


            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            CountingSort.Sort(array);
            Console.WriteLine("CountingSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();

            array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            BucketSort.Sort(array, 3);
            Console.WriteLine("BucketSort.Sort: " + String.Join(", ", array));
            Console.WriteLine();

            //Heap sorting set inside trees

        }
    }
}