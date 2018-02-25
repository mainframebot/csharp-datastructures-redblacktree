using System;
using RedBlackTree.Enum;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeDeleteBalancing<T> : ITreeBalancing<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;
        private readonly ITreeRotation<T> _treeRotation;

        public TreeDeleteBalancing(RedBlackTree<T> tree, ITreeRotation<T> treeRotation)
        {
            if (tree == null || treeRotation == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeRotation = treeRotation;
        }

        public void FixUp(Node<T> node)
        {
            while (node != _tree.Root && node.Color == NodeColor.Black)
            {
                if (node == node.Parent.Left)
                {
                    FixUpLeft(ref node);
                }
                else
                {
                    FixUpRight(ref node);
                }
            }

            node.Color = NodeColor.Black;
        }

        private void FixUpLeft(ref Node<T> node)
        {
            var sibling = node.Parent.Right;

            if (sibling.Color == NodeColor.Red)
            {
                sibling.Color = NodeColor.Black;
                node.Parent.Color = NodeColor.Red;

                _treeRotation.RotateLeft(node.Parent);

                sibling = node.Parent.Right;
            }

            if (sibling.Left.Color == NodeColor.Black &&
                sibling.Right.Color == NodeColor.Black)
            {
                sibling.Color = NodeColor.Red;
                node = node.Parent;
            }
            else
            {
                if (sibling.Right.Color == NodeColor.Black)
                {
                    sibling.Left.Color = NodeColor.Black;
                    sibling.Color = NodeColor.Red;

                    _treeRotation.RotateRight(sibling);

                    sibling = node.Parent.Right;
                }

                sibling.Color = node.Parent.Color;
                node.Parent.Color = NodeColor.Black;
                sibling.Right.Color = NodeColor.Black;

                _treeRotation.RotateLeft(node.Parent);

                node = _tree.Root;
            }
        }

        private void FixUpRight(ref Node<T> node)
        {
            var sibling = node.Parent.Left;

            if (sibling.Color == NodeColor.Red)
            {
                sibling.Color = NodeColor.Black;
                node.Parent.Color = NodeColor.Red;

                _treeRotation.RotateRight(node.Parent);

                sibling = node.Parent.Left;
            }

            if (sibling.Left.Color == NodeColor.Black &&
                sibling.Right.Color == NodeColor.Black)
            {
                sibling.Color = NodeColor.Red;
                node = node.Parent;
            }
            else
            {
                if (sibling.Left.Color == NodeColor.Black)
                {
                    sibling.Right.Color = NodeColor.Black;
                    sibling.Color = NodeColor.Red;

                    _treeRotation.RotateLeft(sibling);

                    sibling = node.Parent.Left;
                }

                sibling.Color = node.Parent.Color;
                node.Parent.Color = NodeColor.Black;
                sibling.Left.Color = NodeColor.Black;

                _treeRotation.RotateRight(node.Parent);

                node = _tree.Root;
            }
        }
    }
}
