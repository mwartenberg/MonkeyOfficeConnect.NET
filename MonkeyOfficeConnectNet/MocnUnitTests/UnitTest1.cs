using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonkeyOfficeConnectNet;
using System.Net.Http;
using MonkeyOfficeConnectNet.DataItems;

namespace MocnUnitTests
{
    [TestClass]
    public class ApiConnectionTests
    {
        
        [TestMethod]
        public void ApiConnection_TestFactory()
        {
            var api = GetApiConnection();
            Assert.IsInstanceOfType(api, typeof(ApiConnection));
        }

        [TestMethod]
        public void ApiConnection_TestRequestToApiInfo()
        {
            var api = GetApiConnection();
            object d = new { apiInfoGet = "" };
            var result = api.ExecuteRequest(d).Result;
            Assert.IsInstanceOfType(result, typeof(HttpResponseMessage));
            Assert.IsTrue(result.IsSuccessStatusCode);
            string responseContent = result.Content.ReadAsStringAsync().Result;

        }
        [TestMethod]
        public void ApiConnection_GetApiInfoItem()
        {
            var api = GetApiConnection();
            var result = api.GetApiInfo().Result;
            Assert.IsInstanceOfType(result, typeof(ApiInfoItem));
            Assert.IsTrue(result.App_Name == "MonKey Office Connect");
        }


        internal static ApiConnection GetApiConnection()
        {
            return ApiConnection.BuildConnection(new Uri(TestHelpers.URI), TestHelpers.USERNAME, TestHelpers.PASSWORD);
        }
    }
}
