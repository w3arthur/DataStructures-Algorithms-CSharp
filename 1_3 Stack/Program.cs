
using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            Console.WriteLine(String.Join(", " ,stack1.ToArray()));
            Console.WriteLine(stack1.Pop());
            Console.WriteLine(ReverseString("Hello!"));

            String str2 = "(([1] + <2>))[a]";   //match expression
            String str3 = "((<1] + <2>))[a]";   //unMatch expression

            String str1 = "(1 + 2)";
            //Edge Cases ?
            String str1_1 = "(1 + 2"; // ( //also (( )
            String str1_2 = "1 + 2)"; // )
            String str1_3 = ")1 + 2("; //) (
            String str1_4 = "1 + 2";
            String str1_5 = "(1 + 2[])()";


            Stacks stack = new Stacks();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);
            stack.Push(60);
            stack.Push(70);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack);
            Console.WriteLine("Bracket Match: " + IsBalanced("[a()bc]"));
            Console.WriteLine("Bracket Match: " + IsBalanced("[a>bc]"));

        }



        private static char[] leftBracket = { '(', '<', '{', '[' };
        private static char[] rightBracket = { ')', '>', '}', ']' };
        private static bool BracketsMatch(char chLeft, char chRight) =>
            Array.IndexOf(leftBracket, chLeft) == Array.IndexOf(rightBracket, chRight);
        public static bool IsBalanced(String input) 
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in input.ToCharArray())
            {
                if ( leftBracket.Contains(ch) ) stack.Push(ch);
                else if ( rightBracket.Contains(ch) )
                {
                    if (stack.Count == 0) return false;    //Edge case
                    char opposite = stack.Pop();
                    if (!BracketsMatch(ch, opposite)) return false;
                }
            }
            return stack.Count == 0; //boolean
        }

        static public String ReverseString(String str) 
        {
            String reversedString = "";
            Stack<char> stack = new Stack<char>();
            foreach (char ch in str.ToCharArray()) stack.Push(ch);
            while (stack.Count > 0) reversedString += stack.Pop();
            return reversedString;
        }
    }
}