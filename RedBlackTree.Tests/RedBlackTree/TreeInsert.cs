using NUnit.Framework;
using RedBlackTree.Enum;

namespace RedBlackTree.Tests.RedBlackTree
{
    [TestFixture]
    public class TreeInsert : Base
    {
        [Test]
        public void Insert_Should_Generate_Valid_Tree()
        {
            var tree = RedBlackTree;

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(50));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(20));

            // Root.Left.Left

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Left.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Left.Value, Is.EqualTo(5));

            Assert.That(tree.Root.Left.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Right.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Right.Value, Is.EqualTo(15));

            // Root.Left.Right

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Left.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Left.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Left.Value, Is.EqualTo(35));

            Assert.That(tree.Root.Left.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Right.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Right.Value, Is.EqualTo(45));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(80));

            // Root.Right.Left

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(70));

            Assert.That(tree.Root.Right.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Left.Value, Is.EqualTo(65));

            Assert.That(tree.Root.Right.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Right.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Right.Value, Is.EqualTo(75));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(90));

            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Left.Value, Is.EqualTo(85));

            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Value, Is.EqualTo(95));

            // Count

            Assert.That(tree.Count, Is.EqualTo(Items.Length));
        }

        [Test]
        public void Insert_Should_Place_Item_Less_Than_Parent_Left()
        {
            var tree = RedBlackTree;
            
            tree.Insert(ItemsInsertLessThanParent);

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Black));

            Assert.That(tree.Root.Right.Right.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Left.Value, Is.EqualTo(94));

            Assert.That(tree.Count, Is.EqualTo(Items.Length + 1));
        }

        [Test]
        public void Insert_Should_Place_Item_Equal_To_Parent_Right()
        {
            var tree = RedBlackTree;

            tree.Insert(ItemsInsertEqualToParent);

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Black));

            Assert.That(tree.Root.Right.Right.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Right.Value, Is.EqualTo(95));

            Assert.That(tree.Count, Is.EqualTo(Items.Length + 1));
        }

        [Test]
        public void Insert_Should_Place_Item_Greater_Than_Parent_Right()
        {
            var tree = RedBlackTree;

            tree.Insert(ItemsInsertGreaterThanParent);

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Black));

            Assert.That(tree.Root.Right.Right.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Right.Value, Is.EqualTo(96));

            Assert.That(tree.Count, Is.EqualTo(Items.Length + 1));
        }

        [Test]
        public void Insert_Should_Generate_Valid_Tree_When_Triggering_InsertFixUpCase1()
        {
            var tree = RedBlackTreeInsertFixUpCase1;

            tree.Insert(InsertFixUpCase1Item);

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(50));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(20));

            // Root.Left.Left

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Left.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Left.Value, Is.EqualTo(5));

            Assert.That(tree.Root.Left.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Right.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Right.Value, Is.EqualTo(15));

            // Root.Left.Right

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Left.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Left.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Left.Value, Is.EqualTo(35));

            Assert.That(tree.Root.Left.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Right.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Right.Value, Is.EqualTo(45));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(80));

            // Root.Right.Left

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(70));

            Assert.That(tree.Root.Right.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Left.Value, Is.EqualTo(65));

            Assert.That(tree.Root.Right.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Right.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Right.Value, Is.EqualTo(75));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(90));

            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Left.Value, Is.EqualTo(85));

            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Value, Is.EqualTo(95));

            // Inserted node

            Assert.That(tree.Root.Right.Right.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Right.Value, Is.EqualTo(98));

            // Count

            Assert.That(tree.Count, Is.EqualTo(InsertFixUpCase1Items.Length + 1));
        }

        [Test]
        public void Insert_Should_Generate_Valid_Tree_When_Triggering_InsertFixUpCase2And3()
        {
            var tree = RedBlackTreeInsertFixUpCase2And3;

            tree.Insert(InsertFixUpCase2And3Item);

            // Root

            Assert.That(tree.Root.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Parent, Is.EqualTo(tree.Sentinel));
            Assert.That(tree.Root.Value, Is.EqualTo(50));

            // Root.Left

            Assert.That(tree.Root.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Left.Value, Is.EqualTo(20));

            // Root.Left.Left

            Assert.That(tree.Root.Left.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Left.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Left.Value, Is.EqualTo(10));

            Assert.That(tree.Root.Left.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Left.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Left.Value, Is.EqualTo(5));

            Assert.That(tree.Root.Left.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Left.Right.Parent, Is.EqualTo(tree.Root.Left.Left));
            Assert.That(tree.Root.Left.Left.Right.Value, Is.EqualTo(15));

            // Root.Left.Right

            Assert.That(tree.Root.Left.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Left.Right.Parent, Is.EqualTo(tree.Root.Left));
            Assert.That(tree.Root.Left.Right.Value, Is.EqualTo(40));

            Assert.That(tree.Root.Left.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Left.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Left.Value, Is.EqualTo(35));

            Assert.That(tree.Root.Left.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Left.Right.Right.Parent, Is.EqualTo(tree.Root.Left.Right));
            Assert.That(tree.Root.Left.Right.Right.Value, Is.EqualTo(45));

            // Root.Right

            Assert.That(tree.Root.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Parent, Is.EqualTo(tree.Root));
            Assert.That(tree.Root.Right.Value, Is.EqualTo(80));

            // Root.Right.Left

            Assert.That(tree.Root.Right.Left.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Left.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Left.Value, Is.EqualTo(70));

            Assert.That(tree.Root.Right.Left.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Left.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Left.Value, Is.EqualTo(65));

            Assert.That(tree.Root.Right.Left.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Left.Right.Parent, Is.EqualTo(tree.Root.Right.Left));
            Assert.That(tree.Root.Right.Left.Right.Value, Is.EqualTo(75));

            // Root.Right.Right

            Assert.That(tree.Root.Right.Right.Color, Is.EqualTo(NodeColor.Black));
            Assert.That(tree.Root.Right.Right.Parent, Is.EqualTo(tree.Root.Right));
            Assert.That(tree.Root.Right.Right.Value, Is.EqualTo(94));

            Assert.That(tree.Root.Right.Right.Left.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Left.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Left.Value, Is.EqualTo(90));

            Assert.That(tree.Root.Right.Right.Right.Color, Is.EqualTo(NodeColor.Red));
            Assert.That(tree.Root.Right.Right.Right.Parent, Is.EqualTo(tree.Root.Right.Right));
            Assert.That(tree.Root.Right.Right.Right.Value, Is.EqualTo(95));

            // Count

            Assert.That(tree.Count, Is.EqualTo(InsertFixUpCase2And3Items.Length + 1));
        }
    }
}
