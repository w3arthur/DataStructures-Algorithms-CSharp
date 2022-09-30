using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvlTree
{
    public class Tree
    {
        private class Node
        {
            public int Value { get; set; }
            public int Height { get; set; }
            public Node? ChildLeft { get; set; }
            public Node? ChildRight { get; set; }
            public Node(int value) { Value = value; }
        }
        private Node? Root { get; set; }
        private bool IsNull(Node? node) { return node == null; }
        private bool IsLeaf(Node? node) { return IsNull(node!.ChildLeft) && IsNull(node!.ChildRight); }
        private int GetHeight(Node? node) { return IsNull(node) ? -1 : node!.Height; }
        private int GetMaxHeight(Node node) { return 1 + Math.Max(GetHeight(node.ChildLeft), GetHeight(node.ChildRight)); }
        private int BalanceFactor(Node? node) { return IsNull(node) ? 0 : GetHeight(node!.ChildLeft) - GetHeight(node.ChildRight); }

        public void Insert(int value)
        {
            if (IsNull(Root)) { Root = new Node(value); return; }
            Root = Insert(value, Root!);
        }
        private Node Insert(int value, Node? node)
        {
            if (IsNull(node)) node = new Node(value);
            else if (value < node!.Value) node.ChildLeft =  Insert(value, node.ChildLeft);
            else if (value > node.Value) node.ChildRight =  Insert(value, node.ChildRight);
            else throw new Exception();
            node.Height = GetMaxHeight(node); // for balancing
            return Balance(node); //node;
        }
        private Node Balance(Node node)
        {
            if (BalanceFactor(node) > 1)    // RR
            {
                if (BalanceFactor(node.ChildLeft) < 0) /*LR*/ { node.ChildLeft = RotateLeft(node);/*Console.WriteLine("Left Route" + node.leftChild.value);*/}
                return RotateRight(node);/*Console.WriteLine("Right Route" + node.value);*/
            }
            else if (BalanceFactor(node) < -1) //LL
            {
                if (BalanceFactor(node.ChildRight) > 0) /*RL*/ { node.ChildRight = RotateRight(node);/*Console.WriteLine("Right Route" + node.rightChild.value);*/}
                return RotateLeft(node);/*Console.WriteLine("Left Route" + node.value);*/
            }
            else return node;   // balance ok -1 <=> 1
        }

        private Node RotateLeft(Node node)
        {   //maybe new root
            var topNode = node.ChildRight;
            node.ChildRight = topNode!.ChildLeft;
            topNode.ChildLeft = node;
            node.Height = GetMaxHeight(node);
            topNode.Height = GetMaxHeight(topNode);
            return topNode;
            // 10		  20
            //  20	=>	10  30
            // -  30   -
        }
        private Node RotateRight(Node node)
        {   //maybe new root
            var topNode = node.ChildLeft;
            node.ChildLeft = topNode!.ChildRight; // node.ChildLeft.ChildRight;
            topNode.ChildRight = node;
            node.Height = GetMaxHeight(node);
            topNode.Height = GetMaxHeight(topNode);
            return topNode;
            //   30		  20
            //  20 - =>	10  30
            // 10		
        }






        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(Root, distance, list); /*Console.WriteLine("");*/
            return list;
        }
        private void GetNodesAtDistance(Node? node, int distance, List<int> list)
        {
            if (IsNull(node)) return;
            if (distance == 0) { list.Add(node!.Value); /*System.out.print( node.value + " " );*/ return; }
            GetNodesAtDistance(node!.ChildLeft, distance - 1, list);
            GetNodesAtDistance(node!.ChildRight, distance - 1, list);
        }
        public int Height() { return Height(Root); }
        private int Height(Node? node)
        {
            if (IsNull(node)) return int.MinValue;//-1;
            if (IsLeaf(node)) return 0; // base condition
            return 1 + Math.Max(Height(node!.ChildLeft), Height(node.ChildRight));
        }

        public String TraverseLevelOrder()
        {
            StringBuilder str = new StringBuilder("");
            for (var i = 0; i <= Height(); i++) str.Append(i + "| " + String.Join(", ", GetNodesAtDistance(i).ToArray()) + "\n");
            return str.ToString();
        }
        public override String ToString() {
            return TraverseLevelOrder();
        }



        /*1*/ public bool IsBalanced() { return Math.Abs(BalanceFactor(Root)) <= 1;  }
        /*2*/ public bool IsPerfect() { return IsPerfect(Root); }
        private bool IsPerfect(Node? node)
        {
            if (IsNull(node)) return true;
            if (IsNull(node!.ChildLeft) && !IsNull(node.ChildRight) || !IsNull(node.ChildRight) && IsNull(node.ChildLeft)) return false;
            return IsPerfect(node.ChildLeft) && IsPerfect(node.ChildRight);
        }

    }
}
