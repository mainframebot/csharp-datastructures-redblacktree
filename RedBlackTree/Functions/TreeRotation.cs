using System;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeRotation<T> : ITreeRotation<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;

        public TreeRotation(RedBlackTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public void RotateLeft(Node<T> oldRoot)
        {
            var newRoot = oldRoot.Right;

            oldRoot.Right = newRoot.Left;

            if (newRoot.Left != _tree.Sentinel)
                newRoot.Left.Parent = oldRoot;

            if (oldRoot.Right != _tree.Sentinel)
                oldRoot.Right.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Left = oldRoot;
        }

        public void RotateRight(Node<T> oldRoot)
        {
            var newRoot = oldRoot.Left;

            oldRoot.Left = newRoot.Right;

            if (oldRoot.Left != _tree.Sentinel)
                oldRoot.Left.Parent = oldRoot;

            if (oldRoot.Right != _tree.Sentinel)
                oldRoot.Right.Parent = oldRoot;

            RotateParent(oldRoot, newRoot);

            newRoot.Right = oldRoot;
        }

        private void RotateParent(Node<T> oldRoot, Node<T> newRoot)
        {
            newRoot.Parent = oldRoot.Parent;

            if (oldRoot.Parent == _tree.Sentinel)
            {
                _tree.Root = newRoot;
            }
            else if (oldRoot == oldRoot.Parent.Left)
            {
                oldRoot.Parent.Left = newRoot;
            }
            else
            {
                oldRoot.Parent.Right = newRoot;
            }

            oldRoot.Parent = newRoot;
        }
    }
}
