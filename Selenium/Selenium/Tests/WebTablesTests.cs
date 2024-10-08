﻿namespace Selenium
{
    internal class WebTablesTests : BaseClass
    {
        [Test]
        public void AddAndVerifyStringInTable()
        {
            // Arrange
            var webTablesPage = new WebTablesPage(_driver);
            string firstName = "Vladyslav";
            string lastName = "Kotelevets";
            string age = "30";
            string email = "mymail@example.com";
            string salary = "100";
            string department = "Engineering";

            webTablesPage.Open();

            // Act
            webTablesPage.ClickAddButton();
            webTablesPage.FillRegistrationForm(firstName, lastName, email, age, salary, department);
            webTablesPage.ClickFormSubmitButton();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(webTablesPage.CheckAddedRow(firstName, firstName), Is.EqualTo(true), "First Name not added or outside the result string");
                Assert.That(webTablesPage.CheckAddedRow(lastName, firstName), Is.EqualTo(true), "Last Name not added or outside the result string");
                Assert.That(webTablesPage.CheckAddedRow(age, firstName), Is.EqualTo(true), "Age not added or outside the result string");
                Assert.That(webTablesPage.CheckAddedRow(email, firstName), Is.EqualTo(true), "Email not added or outside the result string");
                Assert.That(webTablesPage.CheckAddedRow(salary, firstName), Is.EqualTo(true), "Salary not added or outside the result string");
                Assert.That(webTablesPage.CheckAddedRow(department, firstName), Is.EqualTo(true), "Departmant not added or outside the result string");
            });
        }

        [TestCase("Cierra")]
        [TestCase("Alden")]
        [TestCase("Kierra")]

        public void RemoveRecordFromTable(string firstName)
        {
            // Arrange
            var webTablesPage = new WebTablesPage(_driver);
            webTablesPage.Open();

            // Act
            int CountRowBeforeDelete = webTablesPage.CountRowInTable();
            webTablesPage.DeleteRowInTable(firstName);
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(webTablesPage.CountRowInTable(), Is.EqualTo(CountRowBeforeDelete - 1));
                Assert.That(webTablesPage.IsRowPresent(firstName), Is.Not.EqualTo(true));
            });
        }
    }
}
