namespace NUnitHomeworks
{

    [TestFixture]
    internal class LambdaHomework
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public List<int> FilterEvenNumbers(List<int> numbers)
        {
            var evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }

        [Test]
        public void Test_Add_Function()
        {
            var result = Add(3, 4);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Test_Multiply_Function()
        {
            var result = Multiply(3, 4);
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Test_FilterEvenNumbers_Function()
        {
            var input = new List<int> { 1, 2, 3, 4 };
            var expected = new List<int> { 2, 4 };
            var result = FilterEvenNumbers(input);
            Assert.That(result, Is.EqualTo(expected).AsCollection);
        }


        // TODO: Uncomment and implement lambda functions instead of regular functions
 
        [Test]
        public void Test_Add_Function_To_Lambda()
        {
            var lambda = (int a, int b) => { return a + b; };
            var result = lambda(3, 4);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Test_Multiply_Function_To_Lambda()
        {
            var lambda = (int a, int b) => { return a * b; };
            var result = lambda(3, 4);
            Assert.That(result, Is.EqualTo(12));
        }
  
        [Test]
        public void Test_FilterEvenNumbers_Function_To_Lambda()
        {
            var lambda = (List<int> i) => i.Where(b => b % 2 == 0).ToList();
            var input = new List<int> { 1, 2, 3, 4 };
            var expected = new List<int> { 2, 4 };
            var result = lambda(input);
            Assert.That(result, Is.EqualTo(expected));
           
        }

        [Test]
        public void Test_Where_Lambda()
        {
            var myList = new List<string> { "one", "two", "three", "four" };
            var filterredList = myList.Where(e => e.Contains('t'));
            Assert.That(filterredList.Count, Is.EqualTo(2));
        }
        // TODO: Uncomment and implement without lambda functions
        
        [Test]
        public void Test_Where_NoLambda()
        {
            var myList = new List<string> { "one", "two", "three", "four" };
            var filterredList = new List<string>();

            foreach (var i in myList) 
            {
                if (i.Contains("t"))
                {
                    filterredList.Add(i);
                }
            }

            Assert.That(filterredList.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_All_Lambda()
        {
            var myList = new List<string> { "one", "two", "three", "four" };
            var notEmpty = myList.All(e => e.Length > 0);
            Assert.That(notEmpty, Is.True);
        }
        // TODO: Uncomment and implement without lambda functions
        
        [Test]
        public void Test_All_NoLambda()
        {
            var myList = new List<string> { "one", "two", "three", "four" };
            bool result = false;

            foreach (string i in myList)
            {
                if (i.Length > 0)
                {
                    result = true;
                    break;
                }
            }

            Assert.That(result, Is.True);
        }

    }
}