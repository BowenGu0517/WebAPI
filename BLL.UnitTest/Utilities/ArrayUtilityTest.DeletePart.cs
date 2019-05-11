using BLL.Utilities;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BLL.UnitTest.Utilities
{
    public partial class ArrayUtilityTest
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(6)]
        public void DeletePart_WhenPositionOutOfRange_ShouldThrowException(int position)
        {
            var multiIndexArray = new int[] { 1, 2, 3, 4, 5 };
            Action action = () => ArrayUtility<int>.DeletePart(position, multiIndexArray);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void DeletePart_WhenValidPositionWithSingleIndexArray_ShouldReturnEmptyArray()
        {
            var expectResult = new int[] { };

            var position = 1;
            var singleIndexArray = new int[] { 1 };
            var result = ArrayUtility<int>.DeletePart(position, singleIndexArray);

            result.Should().BeEquivalentTo(expectResult);
        }

        [Test]
        public void DeletePart_WhenValidPositionWithMultiIndexArray_ShouldReturnDeletedArray()
        {
            var expectResult = new int[] { 1, 2, 4, 5 };

            var position = 3;
            var multiIndexArray = new int[] { 1, 2, 3, 4, 5 };
            var result = ArrayUtility<int>.DeletePart(position, multiIndexArray);

            result.Should().BeEquivalentTo(expectResult);
        }
    }
}
