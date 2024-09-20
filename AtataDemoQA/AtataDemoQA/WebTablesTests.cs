using Atata;
using NUnit.Framework;
using System;

namespace AtataDemoQA
{
    public sealed class WebTablesTests : UITestFixture
    {
        [Test]
        public void DeleteAndCheckRow()
        {
            Go.To<WebTablesPage>()
                .People.Rows[r => r.FirstName.Content.Value.Equals("Alden")].DeleteButton.Click()
                .People.Rows.Count(x => x.FirstName.Content.Value == "Alden").Should.Equal(0);
        }

        [Test]
        public void AddAndCheckRow()
        {
            string firstName = "Vladyslav";
            string lastName = "Kotelevets";
            string email = "myemail@gmail.com";
            int age = 29;
            int salary = 99;
            string department = "None";

            Go.To<WebTablesPage>()
                .AddNewRecordButton.Click()
                .FirstName.Set(firstName)
                .LastName.Set(lastName)
                .Email.Set(email)
                .Age.Set(age)
                .Salary.Set(salary)
                .Department.Set(department)
                .Submit.Click()
                .People.Rows[r => r.FirstName.Content.Value == firstName
                        && r.LastName.Content.Value == lastName
                        && r.Age.Content.Value == age.ToString()
                        && r.Email.Content.Value == email
                        && r.Salary.Content.Value == salary.ToString()
                        && r.Department.Content.Value == department]
                        .Should.BePresent();
        }
    }
}