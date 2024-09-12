using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    internal class CheckBoxPage : BasePage
    {
        public CheckBoxPage(IWebDriver driver) : base(driver)
        {
        }

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
            ClickElement(firstTreeItemBy);
        }

        public void ClickSecondTreeItem()
        {
            ClickElement(secondTreeItemBy);
        }

        public void ClickThirdTreeItem()
        {
            ClickElement(thirdTreeItemBy);
        }

        public string GetResultText()
        {
            return GetTextElement(resultTextBy);
        }
    }
}
