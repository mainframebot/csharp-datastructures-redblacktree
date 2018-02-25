using System;
using RedBlackTree.Enum;

namespace RedBlackTree.Models
{
    public class Node<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }  

        public Node<T> Parent { get; set; }   

        public NodeColor Color { get; set; }

        public Node(T value)
        {
            Value = value;
            Color = NodeColor.Red;
        }
    }
}
