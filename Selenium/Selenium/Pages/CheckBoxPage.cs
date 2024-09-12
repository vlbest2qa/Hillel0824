using OpenQA.Selenium;

namespace Selenium
{
    internal class CheckBoxPage
    {
        public CheckBoxPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver _driver;

        private string pageUrl = "https://demoqa.com/checkbox";
        private By firstTreeItemBy = By.XPath("//*[@id='tree-node']/ol/li/span/button");
        private By secondTreeItemBy = By.XPath("//*[@id='tree-node']/ol/li/ol/li[3]/span/button");
        private By thirdTreeItemBy = By.XPath(".//*[text()='Excel File.doc']/.");
        private By resultTextBy = By.XPath("//*[@class='text-success']");

        public void Open()
        {
            _driver.NavigateTo(pageUrl);
        }

        public void ClickFirstTreeItem()
        {
            _driver.ClickElement(firstTreeItemBy);
        }

        public void ClickSecondTreeItem()
        {
            _driver.ClickElement(secondTreeItemBy);
        }

        public void ClickThirdTreeItem()
        {
            _driver.ClickElement(thirdTreeItemBy);
        }

        public string GetResultText()
        {
            return _driver.GetTextElement(resultTextBy);
        }
    }
}
