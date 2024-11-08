using Evershop.Tests.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Evershop.Tests.API.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private string _sid;
        private CookieCollection _cookies;
        private string uuid;
        private App app;

        [SetUp]
        public async Task SetupAsync()
        {
            app = new App();
            var request = new RestRequest("http://localhost:3000/admin/user/login", Method.Post);
            request.AddJsonBody(new { email = "admin@admin.com", password = "admin123" });

            var response = await app.ApiClient.PostAsync<LoginResponseData>(request);
            _cookies = response.Response.Cookies;


            //Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            response.AssertStatusCode(HttpStatusCode.OK);


            var jsonResponse = JObject.Parse(response.Response.Content);
            Assert.That(jsonResponse["data"], Is.Not.Null);
            Assert.That(jsonResponse["data"]["sid"], Is.Not.Null);

            Assert.IsNotNull(response.Data.Data.Sid);
            _sid = response.Data.Data.Sid;
        }

        [Test]
        public async Task CreateProduct()
        {
            // Arrange
            var request = new RestRequest("http://localhost:3000/api/products", Method.Post);

            for (int i = 0; i < _cookies.Count; i++)
            {
                request.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            }
            request.AddHeader("Authorization", $"Bearer {_sid}");

            var product = new Product()
            {
                Name = "Create product test 1",
                ProductId = "",
                Sku = "CPT-1",
                Price = "12.25",
                Weight = "0.28",
                CategoryId = "3",
                TaxClass = "",
                Description = "<p>Create product test 1 description</p>",
                UrlKey = "product1",
                MetaTitle = "",
                MetaKeywords = "",
                MetaDescription = "",
                Status = "1",
                Visibility = "1",
                ManageStock = "1",
                StockAvailability = "1",
                Qty = "1",
                GroupId = "1",
                Attributes =
                [
                    new Models.Attribute() { AttributeCode = "color" },
                    new Models.Attribute() { AttributeCode = "size" }
                ]
            };
            request.AddJsonBody(JsonConvert.SerializeObject(product));

            // Act
            var response = await app.ApiClient.PostAsync<ProductResponseData>(request);

            // Assert
            uuid = response.Data.Data.Uuid;
            response.AssertStatusCode(HttpStatusCode.OK);
            Assert.That(response.Data.Data, Is.Not.Null);
            Assert.That(response.Data.Data.ProductDescriptionId, Is.Not.Null);
            await Console.Out.WriteLineAsync(response.Data.Data.ProductDescriptionId);
            response.AssertExecutionTimeUnder(1);
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            if (uuid != null)
            {
                // Delete
                var request = new RestRequest($"http://localhost:3000/api/products/{uuid}", Method.Delete);
                for (int i = 0; i < _cookies.Count; i++)
                {
                    request.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
                }
                request.AddHeader("Authorization", $"Bearer {_sid}");
                var response = await app.ApiClient.DeleteAsync(request);

                response.AssertStatusCode(HttpStatusCode.OK);
            }
        }
    }
}