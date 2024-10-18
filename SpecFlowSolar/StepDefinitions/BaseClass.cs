using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowSolar.StepDefinitions
{
    public abstract class BaseClass
    {
        public IWebDriver _driver;
        public IJavaScriptExecutor _js;

        [BeforeScenario]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("window-size=1400,1200");
            _driver = new ChromeDriver(options);
            _js = (IJavaScriptExecutor)_driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}