namespace Recursion_Memoizetion
{
    class Program
    {
        static void Main()
        {

            int[] arr = { 1, 2, 3, 52 };
            Console.WriteLine("Recursion Array: " + ArrayCount(arr));
            Console.WriteLine("Recursion Power: " + Power(5, 3));
            Console.WriteLine("Recursion Fibonacci: " + FibBrut(5));
            Console.WriteLine("Recursion Fibonacci: " + FibLoop(5));
            Console.WriteLine("Recursion Fibonacci: " + Fib(5));
            Console.WriteLine("Recursion GridTraveler: " + GridTraveler(3, 3));
            Console.WriteLine("Recursion GridTravelerImproved: " + GridTravelerImproved(3, 3));
            Console.WriteLine("Recursion GridTravelerImproved: " + GridTravelerImproved(16, 16));

        }


        //*Read from bottom to top


        //Dynamic Programming, gridTraveler

        // GridTravelerImproved(4, 3) -> 10 (after m*n combination)
        // m: {0, 1, 2, 3, 4}
        // n: {0, 1, 2, 3}
        private static int GridTravelerImproved(int m, int n)    // O(m*n)  spaceO(m+n)  //different from tree O(2^(m+n))  spaceO(m+n) 
        {
            Dictionary<(int, int), int> memo = new() { [(1, 1)] = 1 };   //pair
            return GridTravelerImproved(m, n, memo);
        }

        private static int GridTravelerImproved(int m, int n, Dictionary<(int, int), int> memo)    //
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            if (memo.ContainsKey((m, n))) return memo[(m, n)];
            if (memo.ContainsKey((n, m))) return memo[(n, m)];  //not important
            memo[(m, n)] = GridTravelerImproved(m - 1, n, memo) + GridTravelerImproved(m, n - 1, memo);
            return memo[(m, n)];
        }


        //GridTraveler(m - 1, n) + GridTraveler(m, n - 1) flipped idea
        //          (2,3)
        // d(1,3)^        ^(2,2)r
        //d(0,3)^  ^(1,2)r d(1,2)^  ^(2,1)r    ... 
        public static int GridTraveler(int m, int n)    //O(2^(n+m)) -> O(2^n)   //tree //like Fibonacci //space o(h) = o(n+m)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            return GridTraveler(m - 1, n) + GridTraveler(m, n - 1);
        }



        // [S| | ]
        // [ | |E]
        //options
        //          (2,3)
        // d(1,3)^        ^(2,2)r
        //d(0,3)^  ^(1,2)r d(1,2)^  ^(2,1)r    ...  the ways  RRD, RDR, DRR
        //(1,1) -> 1
        //(n,0) -> 0
        //(0,n) -> 0
        //gridTraveler(3,3) -> 6
        // [S| | ]      [s|-|-] *Covered    [s|-|-]     [s|-|-]     [s|-|-]
        // [ | | ] ->   [v| | ] ->          [v|>| ] ->  [v|>|-] ->  [v|>|-]
        // [ | |E]      [ | |E]             [-| |E]     [-|v|E]     [-|v|>]
        //gridTraveler(2,3) -> 3
        // [S| | ]
        // [ | |E]
        // RRD, RDR, DRR
        //gridTraveler(1,1) -> 1
        // [S/E]
        //gridTraveler(0,N) -> 0 no grid2
        //gridTraveler(N,0) -> 0 no grid2
        //Dynamic Programming, memorization

        public static int Fib(int a)    //O(n)     ...(3^4)^5^6^4^(*^*).. ////. chain of both, space o(2n) -> o(n)
        {
            if (a < 3) throw new Exception();
            Dictionary<int, int> memo = new() { [1] = 1, [2] = 1 };
            //memo[1] = 1;    //if (a == 1) return 1;
            //memo[2] = 1;    //if (a == 2) return 1;
            return Fib(a, memo);
        }
        private static int Fib(int a, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(a)) return memo[a];
            memo[a] = Fib(a - 1, memo) + Fib(a - 2, memo);
            return memo[a]; //all recursion will save
        }



        //Recursion basics
        public static void Foob(int a)    //O(n)    6-5-4-3-2-1-0
        {
            if (a < 1) return;
            Foob(a - 1);
            return;
        }
        public static void Bar(int a)    //O(n)    6-4-2-0      o(n/2) -> o(n)
        {
            if (a < 1) return;
            Bar(a - 2);
            return;
        }
        public static void Dib(int a)    //O(2^n) ...(4^4)^5^6^5^(4^4).. tree
        {
            if (a < 1) return;
            Dib(a - 1);
            Dib(a - 1);
            return;
        }



        public static int FibBrut(int a)    //O(2^n)     ...(3^4)^5^6^4^(3^2).. 
        {
            if (a < 1) throw new Exception();
            if (a == 1) return 1;
            if (a == 2) return 1;
            return FibBrut(a - 1) + FibBrut(a - 2);
        }
        public static int FibLoop(int a)    //O(n)
        {
            if (a < 1) throw new Exception();
            if (a == 1) return 1;
            if (a == 2) return 1;
            int previous = 1, next = 1;
            for (int i = 3; i < a; ++i)
            {
                int tmp = next;
                next = next + previous;
                previous = tmp;
            }
            return previous + next;
        }


        //Recursion explain
        private static int ArrayCount(int[] arr)
        {
            return ArrayCount(arr, 0);
        }
        public static int ArrayCount(int[] arr, int index)
        {
            //if (arr[index] == 52) return 1; //52 is last
            try { var isNext = arr[index]; } catch (Exception) { return 0; }
            return 1 + ArrayCount(arr, index + 1);
        }

        public static int Power(int a, int times)
        {
            if (times == 0) return 1;
            return a * Power(a, times - 1);
        }



    }
}