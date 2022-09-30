namespace ArrayList
{
    class Program
    {
        static void Main()
        {
            Array numbers = new Array(3);
            numbers.Insert(10);
            numbers.Insert(20);
            numbers.Insert(30);
            numbers.Insert(40);
            numbers.Remove(3);
            Console.WriteLine(numbers);
            Console.WriteLine("the index of:" + numbers.IndexOf(30));

            Console.WriteLine("/////");

            // Vector : increased by 100%, synchronized, only for 1 core
            // ArrayList: increased by 50%
            List<int> list = new List<int>(); //byte
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Remove(0);

            Console.WriteLine(list);
            Console.WriteLine(list.IndexOf(20));   //0
            Console.WriteLine(list.LastIndexOf(20));   //0
            Console.WriteLine(list.Count);    //2
            var arr = list.ToArray();

        }
    }
}