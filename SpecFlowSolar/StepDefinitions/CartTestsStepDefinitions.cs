using NUnit.Framework;
using SpecFlowSolar.Pages;

namespace SpecFlowSolar.StepDefinitions
{
    [Binding]
    public class CartTestsStepDefinitions : BaseClass
    {
        [Given(@"open home page in CartTests")]

        public void GivenOpenHomePageInCartTests()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenHomePage();
        }

        [When(@"open solar cabels in menu in CartTests")]
        public void WhenOpenSolarCabelsInMenuInCartTests()
        {
            var homePage = new HomePage(_driver);
            homePage.OpenSolarCabels();
        }

        [When(@"add to cart one product with index (.*)")]
        public void WhenAddToCartOneProductWithIndex(int p0)
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.AddToCartOneProduct(p0);
        }

        [When(@"go to cart in modal")]
        public void WhenGoToCartInModal()
        {
            var catalogPage = new CatalogPage(_driver);
            catalogPage.GoToCartInModal();
        }

        [When(@"remove product from cart if one")]
        public void WhenRemoveProductFromCartIfOne()
        {
            var cartPage = new CartPage(_driver);
            cartPage.RemoveProductFromCartIfOne();
        }

        [Then(@"is current url equal home")]
        public void ThenIsCurrentUrlEqualHome()
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.IsCurentUrlEqualHome(), Is.EqualTo(true), "Current url NOT equal home url.");
        }

        [Then(@"is title displayed")]
        public void ThenIsTitleDisplayed()
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.IsTitleDisplayed(), Is.EqualTo(true), "Not found title on the page.");
        }

        [Then(@"home page title name should be '([^']*)'")]
        public void ThenHomePageTitleNameShouldBe(string titleName)
        {
            var homePage = new HomePage(_driver);
            Assert.That(homePage.GetTitlelHome(), Is.EqualTo(titleName), "Current title not equal home title.");
        }
    }
}