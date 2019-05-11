using NUnit.Framework;
using System.Net.Http;
using WebAPI.Controllers;

namespace WebAPI.UnitTest.Controllers
{
    [TestFixture]
    public partial class ArrayCalculationControllerTest
    {
        private ArrayCalculationController GetArrayCalculationController()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:3500");

            return new ArrayCalculationController
            {
                Request = requestMessage,
                Configuration = new System.Web.Http.HttpConfiguration(),
            };
        }
    }
}
