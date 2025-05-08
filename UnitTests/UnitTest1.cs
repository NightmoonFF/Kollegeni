namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int testint = 55;

            testint = testint + 55;

            Assert.AreEqual(testint, 110);
        }
    }
}