using System.Linq;
using System.Xml.Linq;

namespace CSharpBasics
{
    internal class ArrayListHomework
    {
        [Test]
        public void TestSumOfArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            // Assert
            Assert.That(sum, Is.EqualTo(55));
        }

        [Test]
        public void TestReverseArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expectedReversed = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            int[] reversedArray = new int[numbers.Length];

            int count = numbers.Length - 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                reversedArray[count] = numbers[i];
                count--;
            }

            // Assert
            Assert.That(reversedArray, Is.EqualTo(expectedReversed));
        }

        [Test]
        public void TestReplaceStudentName()
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };
            string newName = "Bob";

            // Act
            students[1] = newName;

            // Assert
            Assert.That(students[1], Is.EqualTo(newName));
        }

        [TestCase("Sue", true)]
        [TestCase("Alex", false)]
        public void TestStudentNameExists(string nameToCheck, bool existsExpected)
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };

            // Act
            bool exists = students.Contains(nameToCheck);

            // Assert
            Assert.That(exists, Is.EqualTo(existsExpected));
        }

        [Test]
        public void TestDoubleValues()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedDoubled = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            List<int> doubledNumbers = new();
            
            foreach (int number in numbers)
            {
                doubledNumbers.Add(number * 2);
            }

            // Assert
            Assert.That(doubledNumbers, Is.EqualTo(expectedDoubled));
        }

        [Test]
        public void TestRemoveEvenNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedList = new List<int> { 1, 3, 5 };

            // Act
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                }
            }

            // Assert
            Assert.That(numbers, Is.EqualTo(expectedList));
        }

        [Test]
        public void TestAddAnimal()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            string newAnimal = "Penguin";
            List<string> expectedList = new List<string> { "Lion", "Tiger", "Penguin", "Elephant", "Giraffe", "Zebra" };

            // Act
            animals.Insert(2, newAnimal);

            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }

        [Test]
        public void TestSortAnimals()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            List<string> expectedList = new List<string> { "Elephant", "Giraffe", "Lion", "Tiger", "Zebra" };

            // Act
            animals.Sort();

            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }
    }
}