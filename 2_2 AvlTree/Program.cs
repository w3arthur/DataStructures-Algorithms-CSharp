namespace AvlTree
{
    class Program
    {
        static void Main()
        {
            Tree tree = new Tree();
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(7);
            tree.Insert(40);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(4);
            Console.WriteLine(tree);
        }
    }
}