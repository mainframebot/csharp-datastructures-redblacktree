using System;
using RedBlackTree.Enum;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeInsertBalancing<T> : ITreeBalancing<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;
        private readonly ITreeRotation<T> _treeRotation;

        public TreeInsertBalancing(RedBlackTree<T> tree, ITreeRotation<T> treeRotation)
        {
            if (tree == null || treeRotation == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeRotation = treeRotation;
        }

        public void FixUp(Node<T> node)
        {
            while (node != _tree.Root && node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    FixUpLeft(ref node);
                }
                else
                {
                    FixUpRight(ref node);
                }
            }

            _tree.Root.Color = NodeColor.Black;
        }

        private void FixUpLeft(ref Node<T> node)
        {
            var uncle = node.Parent.Parent.Right;

            if (uncle.Color == NodeColor.Red)
            {
                uncle.Color = NodeColor.Black;
                node.Parent.Color = NodeColor.Black;
                node.Parent.Parent.Color = NodeColor.Red;

                node = node.Parent.Parent;
            }
            else
            {
                if (node == node.Parent.Right)
                {
                    node = node.Parent;

                    _treeRotation.RotateLeft(node);
                }

                node.Parent.Color = NodeColor.Black;
                node.Parent.Parent.Color = NodeColor.Red;

                _treeRotation.RotateRight(node.Parent.Parent);
            }
        }

        private void FixUpRight(ref Node<T> node)
        {
            var uncle = node.Parent.Parent.Left;

            if (uncle.Color == NodeColor.Red)
            {
                uncle.Color = NodeColor.Black;
                node.Parent.Color = NodeColor.Black;
                node.Parent.Parent.Color = NodeColor.Red;

                node = node.Parent.Parent;
            }
            else
            {
                if (node == node.Parent.Left)
                {
                    node = node.Parent;

                    _treeRotation.RotateRight(node);
                }

                node.Parent.Color = NodeColor.Black;
                node.Parent.Parent.Color = NodeColor.Red;

                _treeRotation.RotateLeft(node.Parent.Parent);
            }
        }
    }
}
