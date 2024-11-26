using AutomationExercise.Models;
using Microsoft.Playwright;
using System.Text.Json;

namespace AutomationExercise
{
    public class UITestFixture
    {
        public IPage page { get; private set; }
        private IBrowser browser;
        private IBrowserContext context;
        private readonly string emailForUserCreate = "1242134@example.com";
        private readonly string passwordForUserCreate = "123412341";

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

        [SetUp]
        public async Task Setup()
        {
            var ciEnv = Environment.GetEnvironmentVariable("CI");

            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = ciEnv == "true"
            });

            string subPath = "../../../playwright/.auth";
            string filePath = "../../../playwright/.auth/state.json";
            if (!Directory.Exists(subPath))
                Directory.CreateDirectory(subPath);
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, "{}");

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                },
                IgnoreHTTPSErrors = true,
                StorageStatePath = filePath
            });

            await context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            page = await context.NewPageAsync();

            await page.GotoAsync("https://automationexercise.com/login");
            if (await page.GetByRole(AriaRole.Heading, new() { Name = "Login to your account" }).IsVisibleAsync())
            {
                await page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").FillAsync(emailForUserCreate);
                await page.GetByPlaceholder("Password").FillAsync(passwordForUserCreate);
                await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
                await context.StorageStateAsync(new()
                {
                    Path = filePath
                });
            }
        }

        [TearDown]
        public async Task Teardown()
        {
            await context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
            });

            await page.CloseAsync();
            await browser.CloseAsync();
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
