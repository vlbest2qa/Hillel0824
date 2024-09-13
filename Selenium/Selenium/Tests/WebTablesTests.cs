namespace Selenium
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
            //Зробив перевірки що доданна строка містить усі елементи які додавали. А як оріентир для цієї строки використав firstName.
            Assert.Multiple(() =>
            {
                Assert.That(webTablesPage.СheckAddedSting(firstName, firstName), Is.EqualTo(true), "First Name not added or outside the result string");
                Assert.That(webTablesPage.СheckAddedSting(lastName, firstName), Is.EqualTo(true), "Last Name not added or outside the result string");
                Assert.That(webTablesPage.СheckAddedSting(age, firstName), Is.EqualTo(true), "Age not added or outside the result string");
                Assert.That(webTablesPage.СheckAddedSting(email, firstName), Is.EqualTo(true), "Email not added or outside the result string");
                Assert.That(webTablesPage.СheckAddedSting(salary, firstName), Is.EqualTo(true), "Salary not added or outside the result string");
                Assert.That(webTablesPage.СheckAddedSting(department, firstName), Is.EqualTo(true), "Departmant not added or outside the result string");
            });
        }

        [TestCase("Cierra")]
        [TestCase("Alden")]
        [TestCase("Kierra")]

        public async Task RemoveRecordFromTable(string firstName)
        {
            // Arrange
            var webTablesPage = new WebTablesPage(_driver);
            webTablesPage.Open();

            // Act

            // Assert
        }
    }
}
