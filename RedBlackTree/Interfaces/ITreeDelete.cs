using System;
using RedBlackTree.Models;

namespace RedBlackTree.Interfaces
{
    public interface ITreeDelete<T>
        where T : IComparable<T>
    {
        bool Delete(Node<T> node);
    }
}
