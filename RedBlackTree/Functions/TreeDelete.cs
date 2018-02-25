using System;
using RedBlackTree.Enum;
using RedBlackTree.Interfaces;
using RedBlackTree.Models;

namespace RedBlackTree.Functions
{
    public class TreeDelete<T> : ITreeDelete<T>
        where T : IComparable<T>
    {
        private readonly RedBlackTree<T> _tree;
        private readonly ITreeBalancing<T> _treeBalancing;
        private readonly ITreeSearch<T> _treeSearch;

        public TreeDelete(RedBlackTree<T> tree, ITreeBalancing<T> treeBalancing, ITreeSearch<T> treeSearch)
        {
            if (tree == null || treeBalancing == null|| treeSearch == null)
                throw new ArgumentNullException();

            _tree = tree;
            _treeBalancing = treeBalancing;
            _treeSearch = treeSearch; 
        }

        public bool Delete(Node<T> node)
        {
            Node<T> replacement;
            
            var currentOriginalColor = node.Color;

            if (node.Left == _tree.Sentinel)
            {
                replacement = node.Right;
                Transplant(node, node.Right);
            }
            else if (node.Right == _tree.Sentinel)
            {
                replacement = node.Left;
                Transplant(node, node.Left);
            }
            else
            {
                var leftmostNode = _treeSearch.Minimum(node.Right);
                currentOriginalColor = leftmostNode.Color;

                replacement = leftmostNode.Right;

                if (leftmostNode.Parent != node)
                {
                    Transplant(leftmostNode, leftmostNode.Right);
                    leftmostNode.Right = node.Right;
                    leftmostNode.Right.Parent = leftmostNode;
                }
                else
                {
                    replacement.Parent = leftmostNode;
                }

                Transplant(node, leftmostNode);
                leftmostNode.Left = node.Left;
                leftmostNode.Left.Parent = leftmostNode;
                leftmostNode.Color = node.Color;
            }

            _tree.Count--;

            if (currentOriginalColor == NodeColor.Black)
                _treeBalancing.FixUp(replacement);

            return true;
        }

        private void Transplant(Node<T> deletedNode, Node<T> replacementNode)
        {
            if (deletedNode.Parent == _tree.Sentinel)
            {
                _tree.Root = replacementNode;
            }
            else if (deletedNode == deletedNode.Parent.Left)
            {
                deletedNode.Parent.Left = replacementNode;
            }
            else
            {
                deletedNode.Parent.Right = replacementNode;
            }

            replacementNode.Parent = deletedNode.Parent;
        }
    }
}
