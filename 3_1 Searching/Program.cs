namespace Searching
{
    class Program
    {
        static void Main()
        {
            int[] array = new int[] { 7, 3, 1, 4, 6, 2, 3 };
            int[] arraySorted = new int[] { 1, 2, 3, 3, 4, 6, 7 };
            int target = 6;
            
            Console.WriteLine("LinearSearch.Search: " + LinearSearch.Search(array, target));
            Console.WriteLine();

            Array.Sort(array);  //!!! after sorting the array!

            Console.WriteLine("BinarySearch.SearchIterative " + BinarySearch.SearchIterative(arraySorted, target));
            Console.WriteLine("BinarySearch.SearchRecursion " + BinarySearch.SearchRecursion(arraySorted, target));
            Console.WriteLine();

            Console.WriteLine("TernarySearch.Search " + TernarySearch.Search(arraySorted, target));
            Console.WriteLine();

            Console.WriteLine("JumpSearch.Search " + JumpSearch.Search(arraySorted, target));
            Console.WriteLine();

            Console.WriteLine("ExponentialSearch.Search " + ExponentialSearch.Search(arraySorted, target));
            Console.WriteLine();
        }
    }
}
