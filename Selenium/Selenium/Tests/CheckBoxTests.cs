namespace Selenium
{
    public class CheckBoxTests : BaseClass
    {
        [Test]
        public void ClickAndValidationChoise()
        {
            // Arrange
            var checkBoxPage = new CheckBoxPage(_driver);
            checkBoxPage.Open();

            string validationChoise = "excelFile";

            // Act
            checkBoxPage.ClickFirstTreeItem();
            checkBoxPage.ClickSecondTreeItem();
            checkBoxPage.ClickThirdTreeItem();

            // Assert
            Assert.That(checkBoxPage.GetResultText(), Is.EqualTo(validationChoise), "Choise validation failed.");
        }
    }
}
