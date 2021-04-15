using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.CreateTree();
            var heightOfTheTree = tree.Height(tree.root);
        }
    }
}
