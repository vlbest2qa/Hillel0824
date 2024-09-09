using OpenQA.Selenium;
using SolarTechnology.Pages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolarTechnology.Tests
{
    internal class FilteringTests : UITestFixture
    {
        [Test]
        public void DiferentItemAfterFiltration()
        {
            // Arrange
            var catalogPage = new CatalogPage(_driver);
            var homePage = new HomePage(_driver);
            homePage.OpenPage();
            homePage.OpenSolarPanels();

            // Act
            int productsBeforeFiltered = catalogPage.CountFindProducts();
            catalogPage.OpenFilters();
            catalogPage.CheckBrand("JA Solar");
            int productsAfterFiltered = catalogPage.CountFindProducts();

            // Assert
            Assert.That(productsAfterFiltered, Is.Not.EqualTo(productsBeforeFiltered), "Number of products the same!");
        }
    }
}
