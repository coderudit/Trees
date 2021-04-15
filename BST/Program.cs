using System;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            Node root = bst.RecursiveInsert(null, 10);
            bst.RecursiveInsert(root, 5);
            bst.RecursiveInsert(root, 20);
            bst.RecursiveInsert(root, 8);
            bst.RecursiveInsert(root, 30);
            Console.Read();
        }
    }
}
