using FluentAssertions;
using NUnit.Framework;
using System.Web.Http.Results;
using WebAPI.Constants;

namespace WebAPI.UnitTest.Controllers
{
    public partial class ArrayCalculationControllerTest
    {
        [TestCase(null)]
        [TestCase(new int[] { })]
        public void Reverse_WhenMissingProductIds_ShouldReturenBadRequest(int[] productIds)
        {
            var controller = GetArrayCalculationController();

            var actionResult = controller.Reverse(productIds);

            actionResult.Should().BeOfType<BadRequestErrorMessageResult>();
            ((BadRequestErrorMessageResult)actionResult).Message.Should().BeEquivalentTo(ErrorMessage.INVALID_MISSING_PRODUCT_IDS);
        }

        [Test]
        public void Reverse_WhenInvalidProductIds_ShouldReturenOkResult()
        {
            var expectedResult = new int[] { 5, 4, 3, 2, 1 };

            var controller = GetArrayCalculationController();
            var productIds = new int[] { 1, 2, 3, 4, 5 };

            var actionResult = controller.Reverse(productIds);

            actionResult.Should().BeOfType<OkNegotiatedContentResult<int[]>>();
            ((OkNegotiatedContentResult<int[]>)actionResult).Content.Should().BeEquivalentTo(expectedResult);
        }
    }
}
