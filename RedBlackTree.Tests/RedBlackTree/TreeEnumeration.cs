using NUnit.Framework;

namespace RedBlackTree.Tests.RedBlackTree
{
    [TestFixture]
    public class TreeEnumeration : Base
    {
        [Test]
        public void Enumeration_Should_TraverseTree_InOrder()
        {
            int index = 0;

            foreach (var item in RedBlackTree)
            {
                Assert.That(ItemsInOrder[index++], Is.EqualTo(item));
            }
        }
    }
}
