using System;
using System.Collections.Generic;

namespace RedBlackTree.Interfaces
{
    public interface ITreeEnumeration<T>
        where T : IComparable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
