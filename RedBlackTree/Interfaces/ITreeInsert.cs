using System;
using RedBlackTree.Models;

namespace RedBlackTree.Interfaces
{
    public interface ITreeInsert<T>
        where T : IComparable<T>
    {
        Node<T> Insert(Node<T> node);
    }
}
