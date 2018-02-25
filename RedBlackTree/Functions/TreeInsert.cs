using System;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeInsert<T> : ITreeInsert<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;
        private readonly ITreeBalancing<T> _treeBalancing;

        public TreeInsert(RedBlackTree<T> tree, ITreeBalancing<T> treeBalancing)
        {
            if (tree == null || treeBalancing == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeBalancing = treeBalancing;
        }

        public Node<T> Insert(Node<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (_tree.Root == null)
            {
                _tree.Root = node;
                _tree.Root.Parent = _tree.Sentinel;
            }
            else
            {
                InsertNode(_tree.Root, node);
            }

            node.Left = _tree.Sentinel;
            node.Right = _tree.Sentinel;

            _tree.Count++;

            _treeBalancing.FixUp(node);

            return node;
        }

        private void InsertNode(Node<T> current, Node<T> node)
        {
            node.Parent = current;

            if (node.Value.CompareTo(current.Value) < 0)
            {
                if (current.Left == _tree.Sentinel)
                {
                    current.Left = node;
                }
                else
                {
                    InsertNode(current.Left, node);
                }
            }
            else
            {
                if (current.Right == _tree.Sentinel)
                {
                    current.Right = node;
                }
                else
                {
                    InsertNode(current.Right, node);
                }
            }
        }
    }
}
