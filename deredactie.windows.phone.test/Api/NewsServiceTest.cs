using System.Net;
using System.Threading.Tasks;
using deredactie.windows.api.Service;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace deredactie.windows.phone.test.Api
{
    [TestClass]
    public class NewsServiceTest
    {
        [TestMethod]
        public async Task GetContent()
        {
            var service = new NewsService();
            var response = await service.GetContentAsync();
            Assert.IsTrue(response.Item2.StatusCode.Equals(HttpStatusCode.OK));
        } 
    }
}
