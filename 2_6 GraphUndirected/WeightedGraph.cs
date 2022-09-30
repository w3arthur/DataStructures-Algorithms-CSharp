using System.Text;

// להוסיף remove node

namespace GraphUndirected
{
    public class WeightedGraph
    { // Weighted

        private class Node   //Vertice
        {
            public String Label { get; private set; }
            /*!*/
            public List<Edge> EdgeList { get; private set; } // better Map
            public Node(String label) { Label = label; EdgeList = new(); }
            /*!*/
            public void AddEdge(Node to, int weight) { EdgeList.Add(new Edge(this, to, weight)); }
            public override String ToString() { return Label; }
        }

        private class Edge
        {
            public Node From { get; private set; }
            public Node To { get; private set; }
            public int Weight { get; private set; }
            public Edge(Node from, Node to, int weight) { From = from; To = to; Weight = weight; }
            public override String ToString() { return "<" + Weight + ">" + To; } // A->B
        }

        /*   private class NodePriority
             {
                public Vertice Node { get; set; }
                public int Priority { get; set; }
                public NodePriority(Vertice node, int priority) { Node = node; Priority = priority; }
             }*/

        private Dictionary<String, Node> Nodes { get; set; }
        // private Dictionary<Node, List<Edge>> Edges;

        public WeightedGraph() { Nodes = new(); }

        private bool IsNull(Node node) { return node == null; }

        private void AddNode(Node node) { AddNode(node.Label); }
        public void AddNode(String lable) { Nodes.TryAdd(lable, new Node(lable)); }

        private void AddEdge(Node from, Node to, Edge edge) { AddEdge(from.Label, to.Label, edge.Weight); }
        public void AddEdge(String fromString, String toString, int weight)
        { // relationship
            var from = Nodes?[fromString];
            var to = Nodes?[toString];
            if (IsNull(from!) || IsNull(to!)) throw new Exception();
            from!.AddEdge(to!, weight);
            to!.AddEdge(from!, weight);
        }


        public List<String> GetShortestPath(String fromString, String toString)
        {
            var from = Nodes?[fromString];
            var to = Nodes?[toString];
            if (IsNull(from!) || IsNull(to!)) throw new Exception();

            Dictionary<Node, int> distances = new();
            foreach (var node in Nodes!.Values) distances.Add(node, int.MaxValue);
            distances[from!] = 0; // java: replace(,) // A 0

            Dictionary<Node, Node> previousNodes = new();

            HashSet<Node> visited = new();

            PriorityQueue<Node, int> queue = new(); //java: PriorityQueue<NodeEntry> queue = new PriorityQueue<>(Comparator.comparingInt(ne->ne.priority));
            queue.Enqueue(from!, 0);  // only item in the queue

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                visited.Add(current);

                foreach (var edge in current.EdgeList)
                {
                    if (visited.Contains(edge.To)) continue;
                    /*!*/
                    var newDistance = distances[current] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance; // java: replace(,)
                        previousNodes.Add(edge.To, current);
                        queue.Enqueue(edge.To, newDistance);
                    }
                }
            }
            //return distances.get(toNode);
            return BuildPath(previousNodes, to!);
        }
        private List<String> BuildPath(Dictionary<Node, Node> previousNodes, Node toNode)
        {
            Stack<Node> stack = new();
            stack.Push(toNode);
            var previous = previousNodes?[toNode];
            while (true) //!IsNull(previous!)
            {
                stack.Push(previous!);
                try { previous = previousNodes![previous!]; }
                catch (Exception) { break; } //previous = previousNodes.GetValueOrDefault(previous, null);
            }
            return ToList(stack);
        }

        private List<String> ToList(Stack<Node> stack)
        {
            List<String> NodeList = new();
            foreach (var node in stack) NodeList.Add(node.Label);
            return NodeList;
        }




        public bool HasCycle()
        {
            HashSet<Node> visited = new();
            foreach (var node in Nodes.Values)
                if (!visited.Contains(node)
                        && HasCycle(node, null, visited)) return true;
            return false;
        }

        //לחזור !
        private bool HasCycle(Node node, Node? parent, HashSet<Node> visited)
        {
            visited.Add(node);
            foreach (var edge in node.EdgeList)
            {
                if (edge.To == parent) continue;
                if (visited.Contains((edge.To))
                        || HasCycle(edge.To, node, visited)) return true;
            }
            return false;
        }

        public WeightedGraph GetMinimumSpanningTree()
        {
            WeightedGraph tree = new WeightedGraph();
            if (Nodes.Count == 0) return tree;
            PriorityQueue<Edge, int> edges = new();
            var startNode = Nodes.First().Value; //java: nodes.values().iterator().next();
            foreach (var edge in startNode.EdgeList) edges.Enqueue(edge, edge.Weight);
            tree.AddNode(startNode.Label);

            if (edges.Count == 0) return tree;

            while (tree.Nodes.Count < Nodes.Count)
            {
                var minEdge = edges.Dequeue();
                var nextNode = minEdge.To;
                if (tree.ContainsNode(nextNode.Label)) continue;
                tree.AddNode(nextNode);
                tree.AddEdge(minEdge.From, nextNode, minEdge);
                foreach (var edge in nextNode.EdgeList)
                    if (!tree.ContainsNode(edge.To))
                        edges.Enqueue(edge, edge.Weight);
            }
            return tree;
        }


        public bool ContainsNode(String label) { return Nodes.ContainsKey(label); }
        private bool ContainsNode(Node node) { return Nodes.ContainsKey(node.Label); }
        // להוסיף remove node


        public override String ToString()
        {
            StringBuilder str = new("");
            foreach (var node in Nodes.Values/* adjecencyList.keySet() */)
            {
                var targets = node.EdgeList;// adjecencyList.get(source);
                if (targets.Count != 0) str.Append(node + " is connected to [" + String.Join(", ", targets) + "]\n");
            }
            return str.ToString();
        }

    }
}
