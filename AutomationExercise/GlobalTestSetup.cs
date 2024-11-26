using AutomationExercise.Models;
using System.Text.Json;

namespace AutomationExercise
{
    [SetUpFixture]
    public class GlobalTestSetup
    {
        protected string emailForUserCreate => TestConstants.EmailForUserCreate;
        protected string passwordForUserCreate => TestConstants.PasswordForUserCreate;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            var url = "https://automationexercise.com/api/createAccount";

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                var model = new UserCreateRequest
                {
                    Name = "Vladyslav",
                    Email = emailForUserCreate,
                    Password = passwordForUserCreate,
                    Title = "Mr",
                    Birth_date = "31",
                    Birth_month = "5",
                    Birth_year = "1995",
                    FirstName = "Vlad",
                    LastName = "Kotelevets",
                    Company = "Corp",
                    Address1 = "1234 Main St",
                    Address2 = "Apt 101",
                    Country = "United States",
                    ZipCode = "12345",
                    State = "California",
                    City = "Los Angeles",
                    Mobile_number = "35235235231"
                };
                foreach (var property in model.GetType().GetProperties())
                {
                    formData.Add(new StringContent(property?.GetValue(model)?.ToString() ?? ""), property.Name.ToLower());
                }

                var response = await client.PostAsync(url, formData);
                response.EnsureSuccessStatusCode();

                var responseContent = await JsonSerializer.DeserializeAsync<UserCreateResponse>(
                    await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Assert.That(responseContent?.Message, Is.EqualTo("User created!"));
            }
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            var url = "https://automationexercise.com/api/deleteAccount";

            using (var client = new HttpClient())
            {
                var model = new UserDeleteRequest
                {
                    Email = emailForUserCreate,
                    Password = passwordForUserCreate
                };

                var formData = new MultipartFormDataContent();
                foreach (var property in model.GetType().GetProperties())
                {
                    formData.Add(new StringContent(property?.GetValue(model)?.ToString() ?? ""), property.Name.ToLower());
                }

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = formData
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseContent = await JsonSerializer.DeserializeAsync<UserDeleteResponse>(
                    await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Assert.That(responseContent.Message, Is.EqualTo("Account deleted!"));
            }
        }
    }
}
