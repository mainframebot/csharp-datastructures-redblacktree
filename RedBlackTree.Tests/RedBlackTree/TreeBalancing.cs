using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RedBlackTree.Enum;
using RedBlackTree.Models;

namespace RedBlackTree.Tests.RedBlackTree
{
    [TestFixture]
    public class TreeBalancing : Base
    {
        private Node<int> _sentinel;

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_With_BinarySearchTree_Properties()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                var left = new List<int>();
                var right = new List<int>();

                if (x.Left != _sentinel)
                {
                    TreeNodeInOrderTraversal(x.Left, node => left.Add(node.Value));

                    Assert.That(left.Any(node => node >= x.Value), Is.False);
                }

                if (x.Right != _sentinel)
                {
                    TreeNodeInOrderTraversal(x.Right, node => right.Add(node.Value));

                    Assert.That(right.Any(node => node < x.Value), Is.False);
                }
            });
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_Property1()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            TreeNodeInOrderTraversal(tree.Root, x => Assert.That(x.Color, Is.EqualTo(NodeColor.Black).Or.EqualTo(NodeColor.Red)));
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_Property2()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_Property3()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                if(x == _sentinel)
                    Assert.That(x.Color, Is.EqualTo(NodeColor.Black));
            });
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_Property4()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                if (x.Color == NodeColor.Red)
                {
                    Assert.That(x.Left.Color, Is.EqualTo(NodeColor.Black));
                    Assert.That(x.Right.Color, Is.EqualTo(NodeColor.Black));
                }
            });
        }

        [Test]
        public void Balancing_Should_Generate_Valid_Random_Tree_Property5()
        {
            var tree = GenerateRandomTree();

            _sentinel = tree.Sentinel;

            TreeNodeInOrderTraversal(tree.Root, x =>
            {
                var minimumCount = CountMinimumBlackNodes(x);
                var maximumCount = CountMaximumBlackNodes(x);

                Assert.That(minimumCount, Is.EqualTo(maximumCount));
            });
        }

        private void TreeNodeInOrderTraversal(Node<int> node, Action<Node<int>> action)
        {
            if (node != _sentinel)
            {
                TreeNodeInOrderTraversal(node.Left, action);
                action(node);
                TreeNodeInOrderTraversal(node.Right, action);
            }
        }

        private int CountMinimumBlackNodes(Node<int> node)
        {
            var blackNodeCount = 0;
            while (node != _sentinel)
            {
                if (node.Color == NodeColor.Black)
                    blackNodeCount++;

                node = node.Left;
            }

            return blackNodeCount;
        }

        private int CountMaximumBlackNodes(Node<int> node)
        {
            var blackNodeCount = 0;
            while (node != _sentinel)
            {
                if (node.Color == NodeColor.Black)
                    blackNodeCount++;

                node = node.Right;
            }

            return blackNodeCount;
        }
    }
}
