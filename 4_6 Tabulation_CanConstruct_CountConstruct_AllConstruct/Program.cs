using System;

namespace Tabulation_CanConstruct_CountConstruct_AllConstruct
{
    class Program
    {
        static void Main()
        {

            // Time O(n) search iside the array Space O(n) for the array
            Console.WriteLine("Tabulation: ");

            Console.WriteLine("Can Construct Tabulation: " + CanConstructTabulation("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" }));
            Console.WriteLine("How Construct Tabulation: " + String.Join(", ", HowConstructTabulation("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" })));
            Console.WriteLine("Best Construct Tabulation: " + String.Join(", ", BestConstructTabulation("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" })));

        }
        //applied from the bottom to the top


        public static List<String> BestConstructTabulation(String target, String[] words) // Time O(n*m * m) => O(n*m^2) {worst case, m for the internal array size} Space O(m^2)  m for additional array internal size
        {
            var size = target.Length + 1;
            var table = new List<String>[size]; //Array fill with nulls
            table[0] = new();
            for (int i = 0; i < size; ++i)
            {
                if (table[i] != null)
                {
                    foreach (var word in words)
                    {
                        if (target.Substring(i).IndexOf(word) == 0)
                            if (i + word.Length < size)
                                if (table[i + word.Length] is null || table[i + word.Length].Count > table[i].Count)  //add only this logic
                                    table[i + word.Length] = new(table[i]) { word };
                        //table[i + word.Length].Add(word);
                        //shorter way for first result/ can work without
                        //                if (table[size - 1] != null) return table[size - 1];  //faster exit
                    }
                }
            }
            return table[size - 1];
        }




        public static List<String> HowConstructTabulation(String target, String[] words) // Time O(n*m * m) => O(n*m^2) {worst case, m for the internal array size} Space O(m^2)  m for additional array internal size
        {
            var size = target.Length + 1;
            var table = new List<String>[size]; //Array fill with nulls
            table[0] = new();
            for (int i = 0; i < size; ++i)
            {
                if (table[i] != null)
                {
                    foreach (var word in words)
                    {
                        if (target.Substring(i).IndexOf(word) == 0)
                            if (i + word.Length < size)
                                table[i + word.Length] = new(table[i]) { word };
                                //table[i + word.Length].Add(word);
                        //shorter way for first result/ can work without
        //                if (table[size - 1] != null) return table[size - 1];  //faster exit
                    }
                }
            }
            return table[size - 1];
        }




        public static bool CanConstructTabulation(string target, string[] words) // Time O(n*m) Space O(m) 
        {
            var size = target.Length + 1;
            var table = new bool[size]; //Array fill with false
            table[0] = true;
            for (int i = 0; i < size; ++i)
            {
                if (table[i])
                {
                    foreach (var word in words)
                        if (target.Substring(i).IndexOf(word) == 0)
                            if (i + word.Length < size)
                                table[i + word.Length] = true;
                }
            }
            return table[size - 1];
        }



    }
}