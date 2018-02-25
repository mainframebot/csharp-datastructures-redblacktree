using NUnit.Framework;
using RedBlackTree.Enum;

namespace RedBlackTree.Tests.RedBlackTree
{
    [TestFixture]
    public class TreeDelete : Base
    {
        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase1And4()
        {
            var tree = RedBlackTreeDeleteFixUpCase1And4;

            var node = tree.Search(DeleteFixUpCase1And4Item);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(20));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(5));

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(15));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(35));

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(50));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Left.Value, Is.EqualTo(45));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase1And4Items.Length - 1));
        }

        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase2()
        {
            var tree = RedBlackTreeDeleteFixUpCase2And3;

            var node = tree.Search(DeleteFixUpCase2Item);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(50));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(20));

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Left.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Right.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Right.Value, Is.EqualTo(15));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(65));

            // Root.Right.Left

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(60));

            Assert.That(tree.Root.Right.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Left.Value, Is.EqualTo(55));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(90));

            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Left.Value, Is.EqualTo(70));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase2And3Items.Length - 1));
        }

        [Test]
        public void Delete_Should_Generate_Valid_Tree_When_Triggering_DeleteFixUpCase3()
        {
            var tree = RedBlackTreeDeleteFixUpCase2And3;

            var node = tree.Search(DeleteFixUpCase3Item);

            tree.Delete(node);

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(50));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(15));

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(40));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(80));

            // Root.Right.Left

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(65));

            Assert.That(tree.Root.Right.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Left.Value, Is.EqualTo(60));

            Assert.That(tree.Root.Right.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Right.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Right.Value, Is.EqualTo(70));

            Assert.That(tree.Root.Right.Left.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left.Left));
            Assert.That(tree.Root.Right.Left.Left.Left.Value, Is.EqualTo(55));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(90));

            // Count

            Assert.That(tree.Count, Is.EqualTo(DeleteFixUpCase2And3Items.Length - 1));
        }
    }
}
