using System;
using System.Collections.Generic;

namespace Trees
{
    public class Tree
    {
        Queue<Node> queue;
        public Node root;

        public void CreateTree()
        {
            Node currentNode;
            Node tempNode;

            queue = new Queue<Node>(100);

            Console.WriteLine("Enter the root value:");
            var data = Convert.ToInt32(Console.ReadLine());
            root = new Node(data);
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                Console.WriteLine("Enter the left child:");
                var leftData = Convert.ToInt32(Console.ReadLine());
                if (leftData != -1)
                {
                    tempNode = new Node(leftData);
                    currentNode.Left = tempNode;
                    queue.Enqueue(tempNode);
                }

                Console.WriteLine("Enter the right child:");
                var rightData = Convert.ToInt32(Console.ReadLine());
                if (rightData != -1)
                {
                    tempNode = new Node(rightData);
                    currentNode.Right = tempNode;
                    queue.Enqueue(tempNode);
                }
            }

        }
        public void RecursivePreorder(Node node)
        {
            if (node != null)
            {
                Console.Write($"{node.Value }");
                RecursivePreorder(node.Left);
                RecursivePreorder(node.Right);
            }
        }

        public void IterativePreorder(Node node)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            while (node != null || nodeStack.Count > 0)
            {
                if (node == null)
                {
                    node = nodeStack.Pop();
                    node = node.Right;
                }
                else
                {
                    Console.WriteLine(node.Value);
                    nodeStack.Push(node);
                    node = node.Left;
                }
            }
        }

        public void RecursiveInorder(Node node)
        {
            if (node != null)
            {
                RecursiveInorder(node.Left);
                Console.Write($"{node.Value }");
                RecursiveInorder(node.Right);
            }
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

        public void RecursivePostorder(Node node)
        {
            if (node != null)
            {
                RecursivePostorder(node.Left);
                RecursivePostorder(node.Right);
                Console.Write($"{node.Value }");
            }
        }

        public void IterativePostorder(Node node)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            while (node != null || nodeStack.Count > 0)
            {
                if (node != null)
                {
                    nodeStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = nodeStack.Pop();
                    if (node.IsPrintable)
                    {
                        Console.WriteLine(node.Value);
                        node = null;
                    }
                    else
                    {
                        node.IsPrintable = true;
                        nodeStack.Push(node);
                        node = node.Right;
                    }
                }
            }
        }

        public void Levelorder(Node node)
        {
            var levelQueue = new Queue<Node>();
            levelQueue.Enqueue(node);
            Console.Write($"{node.Value}");

            while (levelQueue.Count > 0)
            {
                var currentNode = levelQueue.Dequeue();
                if (currentNode.Left != null)
                {
                    Console.Write($"{currentNode.Left.Value}");
                    levelQueue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    Console.Write($"{currentNode.Right.Value}");
                    levelQueue.Enqueue(currentNode.Right);
                }
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

        public int CountNodes(Node node)
        {
            int left, right;
            if (node == null)
                return 0;
            left = CountNodes(node.Left);
            right = CountNodes(node.Right);
            return left + right + 1;
        }
        public int CountDegree2Nodes(Node node)
        {
            int left, right;
            if (node == null)
                return 0;
            left = CountDegree2Nodes(node.Left);
            right = CountDegree2Nodes(node.Right);
            if (node.Left != null && node.Right != null)
                return left + right + 1;
            else
                return left + right;
        }
        public int SumOfNodes(Node node)
        {
            int left, right;
            if (node != null)
            {
                left = SumOfNodes(node.Left);
                right = SumOfNodes(node.Right);
                return left + right + node.Value;
            }
            return 0;
        }
    }

    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public bool IsPrintable { get; set; }
        public Node(int value, Node left = null, Node right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
