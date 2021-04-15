using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BinarySearchTree
    {
        Node Search(Node node, int key)
        {
            if (node == null)
                return null;
            if (node.Value == key)
                return node;
            else if (key < node.Value)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }

        Node SearchForInsert(Node node, ref Node tail, int key)
        {
            if (node == null)
                return null;
            tail = node;
            if (node.Value == key)
                return node;
            else if (key < node.Value)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }

        void Insert(Node node, int key)
        {
            Node tail = null;
            Node newNode = null;
            if (SearchForInsert(node, ref tail, key) == null)
            {
                newNode = new Node(key);
                if (key < tail.Value)
                    tail.Left = newNode;
                else
                    tail.Right = newNode;

            }
        }

        public Node RecursiveInsert(Node node, int key)
        {
            Node newNode;
            if (node == null)
            {
                newNode = new Node(key);
                return newNode;
            }

            if (key < node.Value)
                node.Left = RecursiveInsert(node.Left, key);
            else
                node.Right = RecursiveInsert(node.Right, key);
            return node;
        }

        public Node RecursiveDelete(Node node, int key)
        {
            if (key < node.Value)
                node.Left = RecursiveDelete(node.Left, key);
            else if(key > node.Value)
                node.Right = RecursiveDelete(node.Right, key);
            else
            {
                if(Height(node.Left) > Height(node.Right))

            }
        }

        public int Height(Node node)
        {

            if (node == null)
                return 0;
            int left = Height(node.Left);
            int right = Height(node.Right);
            if (left > right)
                return left + 1;
            else
                return right + 1;
        }

        public void IterativeInorder(Node node)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            while (node != null && nodeStack.Count > 0)
            {
                if (node != null)
                {
                    nodeStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = nodeStack.Pop();
                    Console.WriteLine(node.Value);
                    node = node.Right;
                }
            }
        }
    }
    class Node
    {
        public Node(int value, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
    }
}
