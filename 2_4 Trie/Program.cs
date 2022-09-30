using System.Data;

namespace Trie
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Main Method");
            Trie trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("cant");
            trie.Insert("cana");
            trie.Remove("cana");
            Console.WriteLine(trie);
            Console.WriteLine(trie.Contains("cat"));
            Console.WriteLine(trie.Contains("caty"));
            Console.WriteLine(trie.TraversePreOrder());
            trie.TraversePostOrder();
            Console.WriteLine();
            var words = trie.FindWords("ca").ToArray();
            Console.WriteLine("[" + string.Join(", ", words) + "]");
        }
    }
}