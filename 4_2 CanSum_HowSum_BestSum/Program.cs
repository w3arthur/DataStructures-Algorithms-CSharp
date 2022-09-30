using System;

namespace CanSum_HowSum_BestSum
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(CanSumBrut(7, new int[] { 5, 3, 4, 7 })); // true
            Console.WriteLine(CanSumBrut(7, new int[] { 2, 4 })); // false

            Console.WriteLine(CanSum(7, new int[] { 5, 3, 4, 7 })); // true
            Console.WriteLine(CanSum(7, new int[] { 2, 4 })); // false


            Console.WriteLine("////");

            Console.WriteLine("HowSum Brut: " + String.Join(",", HowSum(7, new int[] { 2, 3 })));

            Console.WriteLine("HowSum Memorization: " +  String.Join("," ,HowSum(7, new int[] { 5, 3, 4, 7 })));
            Console.WriteLine("HowSum Memorization: " + String.Join(",", HowSum(7, new int[] { 7 })));
            try{ Console.WriteLine("HowSum Memorization: " + String.Join(",", HowSum(7, new int[] { 2, 4 })!) ); } 
            catch (ArgumentNullException) { Console.WriteLine("HowSum: NO RESULT"); }
            Console.WriteLine("HowSum Memorization: " + String.Join(",", HowSum(7, new int[] { 2, 3 })));
            Console.WriteLine("HowSum Memorization: " + String.Join(",", HowSum(100, new int[] { 1 })));  //o(m)

            Console.WriteLine("BestSum Memorization: " + String.Join(",", BestSum(8, new int[] { 2, 4, 6 })));  //o(m)
            Console.WriteLine("BestSum Memorization: " + String.Join(",", BestSum(100, new int[] {  5, 10, 25, 27 })));  //o(m)
        }




        //BestSum

        public static List<int>? BestSum(int sumTarget, int[] numbers) //  O((m*n) * m) -> O(n*m^2) space O(m^2)   because the list
        {
            Dictionary<int, List<int>> memo = new Dictionary<int, List<int>>() { /*[0] = true*/ };
            //memo[0] = true;
            return BestSum(sumTarget, numbers, memo);
        }
        public static List<int>? BestSum(int sumTarget, int[] numbers, Dictionary<int, List<int>> memo) //  O(n^m*m) space O(m)    m=targer sum n=array length
        {
            if (memo.ContainsKey(sumTarget)) return memo[sumTarget];
            if (sumTarget == 0) { return new(); } //{  }
            if (sumTarget < 0) return null;

            /*!*/    List<int>? shortenCombination = null;

            foreach (var num in numbers)
            {
                var remainder = sumTarget - num;
                List<int>? remainderList = BestSum(remainder, numbers);
                if (remainderList != null)
                {
                    remainderList.Add(num);
                    var comination = remainderList;
                    if (shortenCombination is null || comination.Count() < shortenCombination.Count())
                        shortenCombination = comination;
                }

            }
            memo[sumTarget] = shortenCombination;
            return shortenCombination;//;null; /*memo[sumTarget]*/
        }

        public static List<int>? BestSumBrut(int sumTarget, int[] numbers) //  O(n^m *m) space O(m)    m=targer sum n=array length
        {
            if (sumTarget == 0) { return new(); } //{  }
            if (sumTarget < 0) return null;

            /*!*/List<int>? shortenCombination = null;
            foreach (var num in numbers)
            {
                var remainder = sumTarget - num;
                List<int>? remainderList = BestSumBrut(remainder, numbers);
                if (remainderList != null) 
                {
                    List<int> combination = new List<int>(remainderList);
                    combination.Add(num);
                    var comination = remainderList; 
                    if(shortenCombination is null ||comination.Count() < shortenCombination.Count())
                        shortenCombination = comination;
                }   
            }
            return shortenCombination;//;null; /*memo[sumTarget]*/
        }




        //HowSum
        public static List<int>? HowSum(int sumTarget, int[] numbers) //  O((m*n) * m) -> O(n*m^2) space O(m^2)   because the list
        {
            Dictionary<int, List<int>> memo = new Dictionary<int, List<int>>() { /*[0] = true*/ };
            //memo[0] = true;
            return HowSum(sumTarget, numbers, memo);
        }
        public static List<int>? HowSum(int sumTarget, int[] numbers, Dictionary<int, List<int>> memo) //  O(n^m) <-O(n^hmax) space O(m)    m=targer sum n=array length
        {
            if (memo.ContainsKey(sumTarget)) return memo[sumTarget];
            if (sumTarget == 0) { return new(); } //{  }
            if (sumTarget < 0) return null;
            foreach (var num in numbers)
            {
                var remainder = sumTarget - num;
                List<int>? remainderList = HowSum(remainder, numbers, memo);
                if (remainderList != null) {
                    List<int> combination = new List<int>(remainderList);
                    remainderList.Add(num);
                    memo[sumTarget] = combination;
                    return remainderList; /*memo[remainder]*/ 
                }   //reminder from the sum
            }
            memo[sumTarget] = null;
            return null; /*memo[sumTarget]*/
        }




        public static List<int>? HowSumBrut(int sumTarget, int[] numbers) //  O(n^m*m) space O(m)    m=targer sum n=array length
        {
            if (sumTarget == 0) { return new(); } //{  }
            if (sumTarget < 0) return null;
            foreach (var num in numbers)
            {
                var remainder = sumTarget - num;
                List<int>? remainderList = HowSumBrut(remainder, numbers);
                if (remainderList != null) { remainderList.Add(num); return remainderList; /*memo[remainder]*/ }   //reminder from the sum
            }
            return null; /*memo[sumTarget]*/
        }



        // CanSum
        public static bool CanSum(int sumTarget, int[] numbers) //  O(n^m) <-O(n^hmax) space O(m)    m=targer sum n=array length
        {
            Dictionary<int, bool> memo = new Dictionary<int, bool>() { /*[0] = true*/ };
            //memo[0] = true;
            return CanSum(sumTarget, numbers, memo);
        }
        private static bool CanSum(int sumTarget, int[] numbers, Dictionary<int, bool> memo) //  O(n^m) <-O(n^hmax) space O(m)    m=targer sum n=array length
        {
            if (sumTarget == 0) { return true; }
            if (sumTarget < 0) return false;
            if (memo.ContainsKey(sumTarget) && memo[sumTarget]) return true;
            foreach (var num in numbers) 
            {
                var remainder = sumTarget - num;
                if (CanSum(remainder, numbers, memo)) { memo[remainder] = true; return true; /*memo[remainder]*/ }   //reminder from the sum
            }
            memo[sumTarget] = false;
            return false; /*memo[sumTarget]*/
        }



        // canSum(7, [5, 3, 4, 7]) -> true
        //          7
        //      2   4   3   0   for7 , after traveling

        // canSum(7, [2, 4]) -> false

        public static bool CanSumBrut(int sumTarget, int[] numbers) //  O(n^m) <-O(n^hmax) space O(m)    m=targer sum n=array length
        {
            if (sumTarget == 0) return true;
            if (sumTarget < 0) return false;
            foreach (var num in numbers)    //after all possibilities
            {
                var remainder = sumTarget - num;
                if(CanSumBrut(remainder, numbers)) return true ;    //reminder from the sum
            }
            return false;
        }




    }
}