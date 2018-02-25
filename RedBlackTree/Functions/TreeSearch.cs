using System;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeSearch<T> : ITreeSearch<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;

        public TreeSearch(RedBlackTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public bool Contains(Node<T> node, T value)
        {
            return SearchNode(node, value) != null;
        }

        public Node<T> Search(Node<T> node, T value)
        {
            return SearchNode(node, value);
        }

        public Node<T> Minimum(Node<T> node)
        {
            while (node.Left != _tree.Sentinel)
            {
                node = node.Left;
            }

            return node;
        }

        public Node<T> Maximum(Node<T> node)
        {
            while (node.Right != _tree.Sentinel)
            {
                node = node.Right;
            }

            return node;
        }

        public Node<T> Successor(Node<T> node)
        {
            if (node.Right != _tree.Sentinel)
                return Minimum(node.Right);

            var current = node.Parent;
            while (current != _tree.Sentinel && node == current.Right)
            {
                node = current;
                current = current.Parent;
            }

            return current == _tree.Sentinel ? null : current;
        }

        public Node<T> Predecessor(Node<T> node)
        {
            if (node.Left != _tree.Sentinel)
                return Maximum(node.Left);

            var current = node.Parent;
            while (current != _tree.Sentinel && node == current.Left)
            {
                node = current;
                current = current.Parent;
            }

            return current == _tree.Sentinel ? null : current;
        }

        private Node<T> SearchNode(Node<T> current, T value)
        {
            if (current == _tree.Sentinel)
                return null;

            if (value.Equals(current.Value))
                return current;

            if (value.CompareTo(current.Value) < 0)
            {
                return SearchNode(current.Left, value);
            }

            return SearchNode(current.Right, value);
        }
    }
}
