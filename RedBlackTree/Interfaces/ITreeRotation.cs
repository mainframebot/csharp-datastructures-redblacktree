using System;
using RedBlackTree.Models;

namespace RedBlackTree.Interfaces
{
    public interface ITreeRotation<T>
        where T : IComparable<T>
    {
        void RotateLeft(Node<T> oldRoot);

        void RotateRight(Node<T> oldRoot);
    }
}
