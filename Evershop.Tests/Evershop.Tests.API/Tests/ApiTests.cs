﻿using Evershop.Tests.API.Assertions;
using Evershop.Tests.API.Models;
using Evershop.Tests.API.Utilities;
using Newtonsoft.Json;
using System.Net;

namespace Evershop.Tests.API.Tests
{
    [TestFixture]
    public class ApiTests : APITest
    {
        private string _sid;
        private CookieCollection _cookies;

        [SetUp]
        public async Task SetupAsync()
        {
            var request = new RestRequest("admin/user/login", Method.Post);
            request.AddJsonBody(new { email = "admin@admin.com", password = "admin123" });

            var response = await App.ApiClient.PostAsync<LoginResponseData>(request);
            _cookies = response.Response.Cookies;

            response.AssertStatusCode(HttpStatusCode.OK);
            Assert.IsNotNull(response.Data.Data.Sid);
            _sid = response.Data.Data.Sid;
        }

        [Test]
        public async Task CreateAndDeleteProduct()
        {
            // Arrange
            var request = new RestRequest("api/products", Method.Post);

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
            var response = await App.ApiClient.PostAsync<ProductResponseData>(request);
            var _uuid = response.Data.Data.Uuid;

            // Assert
            response.AssertStatusCode(HttpStatusCode.OK);
            Assert.IsNotNull(response.Data.Data);
            Assert.IsNotNull(response.Data.Data.ProductDescriptionId);
            response.AssertExecutionTimeUnder(1);

            //Delete product after create

            // Arrange
            //var deleteRequest = new RestRequest($"api/products/{_uuid}", Method.Delete);
            //for (int i = 0; i < _cookies.Count; i++)
            //{
            //    deleteRequest.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            //}
            //deleteRequest.AddHeader("Authorization", $"Bearer {_sid}");

            //// Act
            //var deleteResponse = await App.ApiClient.DeleteAsync(deleteRequest);

            //// Assert
            //deleteResponse.AssertStatusCode(HttpStatusCode.OK);

            var dbUtil = new DbUtil();
            dbUtil.DeleteProduct(_uuid);
        }

        [Test]
        public async Task CreateAndDeleteCategory()
        {
            // Arrange
            var requestAdd = new RestRequest("api/categories", Method.Post);

            for (int i = 0; i < _cookies.Count; i++)
            {
                requestAdd.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            }
            requestAdd.AddHeader("Authorization", $"Bearer {_sid}");

            var category = new Category()
            {
                Name = "New Category",
                ParentId = "",
                CategoryId = "",
                Description = "[]",
                UrlKey = "new_category",
                MetaTitle = "Title Category",
                MetaKeywords = "Category Keywords",
                MetaDescription = "Category Description",
                Image = "",
                Status = "1",
                IncludeInNav = "1",
                ShowProducts = "1",
            };
            requestAdd.AddJsonBody(JsonConvert.SerializeObject(category));

            // Act
            var responseAdd = await App.ApiClient.PostAsync<CategoryResponseData>(requestAdd);
            var _uuid = responseAdd.Data.Data.Uuid;

            // Assert
            responseAdd.AssertStatusCode(HttpStatusCode.OK);
            Assert.That(responseAdd.Data.Data, Is.Not.Null);
            Assert.That(responseAdd.Data.Data.Name, Is.EqualTo(category.Name));
            responseAdd.AssertExecutionTimeUnder(1);

            //Delete category after create

            // Arrange
            var requestDelete = new RestRequest($"/api/categories/{_uuid}", Method.Delete);
            for (int i = 0; i < _cookies.Count; i++)
            {
                requestDelete.AddCookie(_cookies[i].Name, _cookies[i].Value, _cookies[i].Path, _cookies[i].Domain);
            }
            requestDelete.AddHeader("Authorization", $"Bearer {_sid}");

            // Act
            var responseDelete = await App.ApiClient.DeleteAsync(requestDelete);

            // Assert
            responseDelete.AssertStatusCode(HttpStatusCode.OK);
        }
    }

}