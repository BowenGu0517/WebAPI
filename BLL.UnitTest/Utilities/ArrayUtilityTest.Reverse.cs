using BLL.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace BLL.UnitTest.Utilities
{
    public partial class ArrayUtilityTest
    {
        [Test]
        public void Reverse_WhenEmptyArray_ShouldReturnEmptyArray()
        {
            var expectResult = new int[] { };

            var emptyArray = new int[] { };
            var result = ArrayUtility<int>.Reverse(emptyArray);

            result.Should().BeEquivalentTo(expectResult);
        }

        [Test]
        public void Reverse_WhenSingleIndexArray_ShouldReturnSingleIndexArray()
        {
            var expectResult = new int[] { 1 };

            var singleIndexArray = new int[] { 1 };
            var result = ArrayUtility<int>.Reverse(singleIndexArray);

            result.Should().BeEquivalentTo(expectResult);
        }

        [Test]
        public void Reverse_WhenMultiIndexArray_ShouldReturnSingleIndexArray()
        {
            var expectResult = new int[] { 5, 4, 3, 2, 1 };

            var multiIndexArray = new int[] { 1, 2, 3, 4, 5 };
            var result = ArrayUtility<int>.Reverse(multiIndexArray);

            result.Should().BeEquivalentTo(expectResult);
        }
    }
}
