using FluentAssertions;
using NUnit.Framework;
using System.Web.Http.Results;
using WebAPI.Constants;

namespace WebAPI.UnitTest.Controllers
{
    public partial class ArrayCalculationControllerTest
    {
        [Test]
        public void DeletePart_WhenMissingPositionWithValidProductIds_ShouldReturenBadRequest()
        {
            int? position = null;
            var productIds = new int[] { 1, 2, 3, 4, 5 };
            var controller = GetArrayCalculationController();

            var actionResult = controller.DeletePart(position, productIds);

            actionResult.Should().BeOfType<BadRequestErrorMessageResult>();
            ((BadRequestErrorMessageResult)actionResult).Message.Should().BeEquivalentTo(ErrorMessage.INVALID_MISSING_POSITION);
        }

        [TestCase(null)]
        [TestCase(new int[] { })]
        public void DeletePart_WhenMissingProductIdsWithValidPosition_ShouldReturenBadRequest(int[] productIds)
        {
            int? position = 3;
            var controller = GetArrayCalculationController();

            var actionResult = controller.DeletePart(position, productIds);

            actionResult.Should().BeOfType<BadRequestErrorMessageResult>();
            ((BadRequestErrorMessageResult)actionResult).Message.Should().BeEquivalentTo(ErrorMessage.INVALID_MISSING_PRODUCT_IDS);
        }

        [Test]
        public void DeletePart_WhenPositionOutOfRangeWithValidProductIds_ShouldReturenBadRequest()
        {
            int? position = 6;
            var productIds = new int[] { 1, 2, 3, 4, 5 };
            var controller = GetArrayCalculationController();

            var actionResult = controller.DeletePart(position, productIds);

            actionResult.Should().BeOfType<BadRequestErrorMessageResult>();
            ((BadRequestErrorMessageResult)actionResult).Message.Should().BeEquivalentTo(ErrorMessage.INVALID_POSITION_VALUE_RANGE);
        }

        [Test]
        public void DeletePart_WhenValidPositionWithValidProductIds_ShouldReturenOkResult()
        {
            var expectedResult = new int[] { 1, 2, 4, 5 };

            int? position = 3;
            var productIds = new int[] { 1, 2, 3, 4, 5 };
            var controller = GetArrayCalculationController();

            var actionResult = controller.DeletePart(position, productIds);

            actionResult.Should().BeOfType<OkNegotiatedContentResult<int[]>>();
            ((OkNegotiatedContentResult<int[]>)actionResult).Content.Should().BeEquivalentTo(expectedResult);
        }
    }
}
