namespace GraphUndirected
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Undirected Graph");
            WeightedGraph graph1 = new WeightedGraph();
            graph1.AddNode("A");
            graph1.AddNode("B");
            graph1.AddNode("C");
            graph1.AddEdge("A", "B", 3);
            graph1.AddEdge("A", "B", 2);
            graph1.AddEdge("A", "C", 2);
            Console.WriteLine(graph1);

            WeightedGraph graph2 = new WeightedGraph();
            graph2.AddNode("A");
            graph2.AddNode("B");
            graph2.AddNode("C");
            graph2.AddEdge("A", "B", 1);
            graph2.AddEdge("B", "C", 2);
            graph2.AddEdge("B", "C", 10);
            var path = graph2.GetShortestPath("A", "C");
            Console.WriteLine(String.Join(", ", path));

            WeightedGraph graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddEdge("A", "B", 3);
            graph.AddEdge("B", "D", 4);
            graph.AddEdge("C", "D", 5);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("B", "C", 2);
            var tree = graph.GetMinimumSpanningTree();
            Console.WriteLine(tree);

        }
    }
}