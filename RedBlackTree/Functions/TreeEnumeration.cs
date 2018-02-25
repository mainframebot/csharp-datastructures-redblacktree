using System;
using System.Collections.Generic;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeEnumeration<T> : ITreeEnumeration<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;

        public TreeEnumeration(RedBlackTree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            _tree = tree;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_tree.Root != null)
            {
                var stack = new Stack<Node<T>>();

                var goLeft = true;

                var current = _tree.Root;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeft)
                    {
                        while (current.Left != _tree.Sentinel)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right == _tree.Sentinel)
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }
                    else
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                }
            }
        }
    }
}
