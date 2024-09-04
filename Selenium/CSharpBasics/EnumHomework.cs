namespace NUnitHomeworks
{
    // TODO: modify enum so CheckCustomIntNumbersForTestDataAgeEnum pass
    public enum TestDataAge
    {
        Child = 7,
        Teenager = 14,
        Adult = 30
    }

    // TODO: uncomment and implement tests so all Assert pass. Use such LINQ as Any(), Count(), Contains()
    [TestFixture]
    public class EnumHomework
    {
        [Test]
        public void CheckCustomIntNumbersForTestDataAgeEnum()
        {
            Assert.That((int)TestDataAge.Child, Is.EqualTo(7));
            Assert.That((int)TestDataAge.Teenager, Is.EqualTo(14));
            Assert.That((int)TestDataAge.Adult, Is.EqualTo(30));
        }

        [Test]
        public void SomeIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int>() { 5, 14, 15 };

            var ageInEnumValues = Enum.GetValues(typeof(TestDataAge)).Cast<int>().ToList();

            var isAnyIntCorrespondsToTestDataAge = listOfInt.Any(number => ageInEnumValues.Contains(number));

            Assert.That(isAnyIntCorrespondsToTestDataAge, Is.True);
        }
        
        [Test]
        public void NumberOfIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int>() { 5, 14, 15, 30 };

            var ageInEnumValues = Enum.GetValues(typeof(TestDataAge)).Cast<int>().ToList();

            var numberOfIntCorrespondToTestDataAge = listOfInt.Count(number => ageInEnumValues.Contains(number));

            Assert.That(numberOfIntCorrespondToTestDataAge, Is.EqualTo(2));
        }

        public static object[] StringlEmentsArePresentInEnumCases =
        {
                new object[] { new string[] { "Child", "Baby", "Teenager", "Eldery", "Adult" }, 3, 2, false, true },
                new object[] { new string[] { "Child", "Teenager", "Adult" }, 3, 0, true, false },
                new object[] { new string[] { "Baby", "Teenager", "Eldery" }, 1, 2, false, true },
                new object[] { new string[] { "Adult", "Child" }, 2, 0, true, false },
                new object[] { new string[] { "Eldery", "Baby" }, 0, 2, false, true },
                new object[] { new string[] { }, 0, 0, true, false },
        };

        [TestCaseSource(nameof(StringlEmentsArePresentInEnumCases))]
        public void StringlEmentsArePresentInEnum(string[] list, int expectedNumberPresent, int expectedNumberExtra, bool areAllPresentExpected, bool areExtraElementsExpected)
        {
            var listOfString = list.ToList();

            var enumValues = Enum.GetNames(typeof(TestDataAge)).ToList();

            var numberOfStringsWhichPresentInEnum = listOfString.Count(name => enumValues.Contains(name));

            var numberOfStringsWhichAreNotPresentInEnum = listOfString.Count(name => !enumValues.Contains(name));

            var areAllStringPresentInEnum = numberOfStringsWhichPresentInEnum == listOfString.Count; // Надеюсь это имелось ввиду под areAllPresent

            var areExtraElements = numberOfStringsWhichAreNotPresentInEnum > 0;

            Assert.That(numberOfStringsWhichPresentInEnum, Is.EqualTo(expectedNumberPresent));
            Assert.That(numberOfStringsWhichAreNotPresentInEnum, Is.EqualTo(expectedNumberExtra));
            Assert.That(areAllStringPresentInEnum, Is.EqualTo(areAllPresentExpected));
            Assert.That(areExtraElements, Is.EqualTo(areExtraElementsExpected));
        }
    }
}