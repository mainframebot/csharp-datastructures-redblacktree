using System;
using RedBlackTree.Models;

namespace RedBlackTree.Interfaces
{
    public interface ITreeBalancing<T>
        where T : IComparable<T>
    {
        void FixUp(Node<T> node);
    }
}
