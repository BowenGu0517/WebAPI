using BLL.Utilities;
using System;
using System.Web.Http;
using WebAPI.Attributes;
using WebAPI.Constants;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/arraycalc")]
    public class ArrayCalculationController : ApiController
    {
        [HttpGet]
        [ValidationModel]
        [Route("reverse")]    
        public IHttpActionResult Reverse([FromUri] int[] productIds)
        {
            if (productIds == null || productIds.Length == 0)
                return BadRequest(ErrorMessage.INVALID_MISSING_PRODUCT_IDS);

            return Ok(ArrayUtility<int>.Reverse(productIds));
        }

        [HttpGet]
        [ValidationModel]
        [Route("deletepart")]
        public IHttpActionResult DeletePart([FromUri] int? position, [FromUri] int[] productIds)
        {
            try
            {
                if (!position.HasValue)
                    return BadRequest(ErrorMessage.INVALID_MISSING_POSITION);

                if (productIds == null || productIds.Length == 0)
                    return BadRequest(ErrorMessage.INVALID_MISSING_PRODUCT_IDS);

                return Ok(ArrayUtility<int>.DeletePart(position.Value, productIds));
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest(ErrorMessage.INVALID_POSITION_VALUE_RANGE);
            }
        }
    }
}
