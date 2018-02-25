using System;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeTraversal<T> : ITreeTraversal<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;

        public TreeTraversal(RedBlackTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public void InOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != _tree.Sentinel)
            {
                InOrderTraversal(node.Left, action);
                action(node.Value);
                InOrderTraversal(node.Right, action);
            }
        }

        public void PostOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != _tree.Sentinel)
            {
                PostOrderTraversal(node.Left, action);
                PostOrderTraversal(node.Right, action);
                action(node.Value);
            }
        }

        public void PreOrderTraversal(Node<T> node, Action<T> action)
        {
            if (node != _tree.Sentinel)
            {
                action(node.Value);
                PreOrderTraversal(node.Left, action);
                PreOrderTraversal(node.Right, action);
            }
        }
    }
}
