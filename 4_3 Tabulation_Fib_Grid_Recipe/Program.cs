using System;



namespace Tabulation_Fib_Grid_Recipe
{
    class Program
    {
        static void Main()
        {

            // Time O(n) search iside the array Space O(n) for the array
            Console.WriteLine("Tabulation: ");

            Console.WriteLine("Fib Tabulation: " + FibTabulation(6));
            Console.WriteLine("Fib Tabulation: " + FibTabulation(20));
            Console.WriteLine("Grid Traveler Tabulation: " + GridTraveler2(3, 3));


        }
        //applied from the bottom to the top



        //Tabulation Recipe:
        // *Visualize the problem as a table
        // *Size the table based on the inputs
        // *Initialize the table with default values
        // *Seed the trivial answer into table
        // *Iterate through the table
        // *Fill further positions based on the current position

        //Grid Traveler Tabulation:
        //[ 0 0 0 0 0 ]
        //[ 0 1 1 1 1 ]
        //[ 0 1 2 3 4 ]
        // ...

        public static int GridTraveler(int m, int n) // Time O(n*m) Space O(n*m) 
        {
            var size1 = n + 1;  //rows
            var size2 = m + 1;  //cols
            var table = new int[size1, size2]; //Array fill with 0s
            table[0, 0] = 0;
            table[1, 1] = 1;
            for (int i = 0; i < size1; ++i)
            {
                for (int j = 0; j < size2; ++j)
                {
                    int current = table[i, j];
                    if (j + 1 < size2)
                        table[i, j + 1] += current;
                    if (i + 1 < size1)
                        table[i + 1, j] += current;
                }
            }
            return table[m, n];
        }


        public static int GridTraveler2(int m, int n) // Time O(n*m) Space O(n*m) 
        {
            var size1 = n + 2;  //rows
            var size2 = m + 2;  //cols
            var table = new int[size1, size2]; //Array fill with 0s
            table[0, 0] = 0;
            table[1, 1] = 1;
            for (int i = 0; i < size1 - 1; ++i)
            {
                for (int j = 0; j < size2 - 1; ++j)
                {
                    int current = table[i, j];
                    table[i, j + 1] += current;
                    table[i + 1, j] += current;
                }
            }
            return table[m, n];
        }


        // less used for next requirements
        public static int GridTraveler3(int m, int n) // Time O(n*m) Space O(n*m) 
        {
            var size1 = n + 1;  //rows
            var size2 = m + 1;  //cols
            var table = new int[size1, size2]; //Array fill with 0s
            //table[0, 0] = 0;
            //table[1, 1] = 1;
            for (int i = 1; i < size1; ++i) /*table[i, 0] = 0;*/ table[i, 1] = 1;   // rows [ 0 1 1 1 1 ]
            for (int j = 1; j < size2; ++j) /*table[0, j] = 0;*/ table[1, j] = 1;   // cols [ 0 1 1 1 1 ]
            for (int i = 2; i < size1; ++i)
            {
                for (int j = 2; j < size2; ++j)
                {
                    int upper = table[i, j - 1];
                    int before = table[i - 1, j];
                    table[i, j] = upper + before;
                }
            }
            return table[m, n];
        }



        //Fib Tabulation:

        public static int FibTabulation(int n) // Time O(n) Space O(n) 
        {
            var size = n + 1;
            var table = new int[size];
            //for (int i = 0; i < size; ++i) table[i] = 0; //Array fill with 0s
            table[0] = 0;
            table[1] = 1;
            for (int i = 0; i < size; ++i)
            {
                if(i + 1 < size)
                    table[i + 1] += table[i];
                if (i + 2 < size)
                    table[i + 2] += table[i];
            }
            return table[n];
        }

        public static int FibTabulation2(int n) // Time O(n) Space O(n) 
        {
            var size = n + 2;
            var table = new int[size] ;
            //for (int i = 0; i < size; ++i) table[i] = 0; //Array fill with 0s
            table[0] = 0;
            table[1] = 1;
            for (int i = 0; i < size - 2; ++i)
            {
                table[i + 1] += table[i];
                table[i + 2] += table[i];
            }
            return table[n];
        }


        // less used for next requirements
        public static int FibTabulation3(int n) // Time O(n) Space O(n) 
        {
            var size = n + 1;
            var table = new int[size];
            // for (int i = 0; i < size; ++i) table[i] = 0; //Array fill with 0s
            table[0] = 0;
            table[1] = 1;
            for (int i = 2; i < size; ++i)
                table[i] = table[i - 1] + table[i - 2];
            return table[n];
        }



    }
}