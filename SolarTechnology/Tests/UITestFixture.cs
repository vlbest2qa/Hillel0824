using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace SolarTechnology.Tests
{
    public class UITestFixture
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200");
            _driver = new ChromeDriver(options);
            _js = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}