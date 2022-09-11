using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace ElectroApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        private HttpClient _httpClient;

        public UnitTest1()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task TestResponse_1()
        {
            var response = await _httpClient.GetAsync("/ApplianceStatus");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task TestResponse_2()
        {
            var response = await _httpClient.GetAsync("/ApplianceStatus");
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public async Task TestResponse_3()
        {
            var response = await _httpClient.GetAsync("/ApplianceStatus");            
            var data = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task TestPost_1()
        {
            var response = await _httpClient.PostAsync("/ApplianceStatus",null);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}