using NUnit.Framework;

namespace RedBlackTree.Tests.RedBlackTree
{
    [TestFixture]
    public class TreeTraversal : Base
    {
        [Test]
        public void PreOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            RedBlackTree.PreOrderTraversal(item => Assert.That(ItemsPreOrder[index++], Is.EqualTo(item)));
        }

        [Test]
        public void InOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            RedBlackTree.InOrderTraversal(item => Assert.That(ItemsInOrder[index++], Is.EqualTo(item)));
        }

        [Test]
        public void PostOrderTraversal_Should_Traverse_In_Correct_Order()
        {
            int index = 0;

            RedBlackTree.PostOrderTraversal(item => Assert.That(ItemsPostOrder[index++], Is.EqualTo(item)));
        }
    }
}
